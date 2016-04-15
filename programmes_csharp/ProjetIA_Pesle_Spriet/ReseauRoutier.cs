using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetIA_Pesle_Spriet
{
    public class ReseauRoutier
    {
        int nbNodes;
        private List<RouteNode> Nodes;
        private int?[,] adjMat;  // ? -> nullable
        private Dictionary<List<GenericNode>, double> coutsRetour; // couts de retour au point A depuis chaq pt du reseau
        
        public static List<string> fermes = new List<string>(new string[] { "B", "H", "G", "J",
            "F", "M", "O", "V", "Q", "T", "S" }); // toutes les fermes du reseau laitier

        public List<RouteNode> GetNodes()
        {
            return Nodes;
        }

        //retourne le cout de retour au point A depuis un noeud
        public double getCoutRetour(string noeud)
        {
            double cout=0;

            foreach (List<GenericNode> chemin in coutsRetour.Keys)
            {
                if(chemin.First().GetNom()==noeud)
                    coutsRetour.TryGetValue(chemin, out cout);
            }
            return cout;
        }

        //retourne le chemin de retour au point A depuis un noeud
        public List<GenericNode> getCheminRetour(string noeud)
        {
            foreach (List<GenericNode> chemin in coutsRetour.Keys)
            {
                if (chemin.First().GetNom() == noeud)
                    return chemin;
            }
            return null;
        }

        public ReseauRoutier(int nbNodes)
        {
            this.nbNodes = nbNodes;
            Nodes = new List<RouteNode>();
            adjMat = new int?[nbNodes, nbNodes];
            coutsRetour = new Dictionary<List<GenericNode>, double>();
        }

        public void AjouteNode(RouteNode n)
        {
            Nodes.Add(n);
        }

        // creation de la matrice adjacente
        public int?[,] CreateAdjMatrix() 
        {
            for (int i=0;i<nbNodes;i++)
            {
                RouteNode n1 = Nodes[i];

                for (int j = 0; j < nbNodes; j++)
                {
                    RouteNode n2 = Nodes[j];
                    int arcVal;
                    // s'il existe un arc entre n1 et n2, on recup le poids
                    if (n1.GetVoisins().TryGetValue(n2, out arcVal))
                    {
                        adjMat[i, j] = arcVal;
                        adjMat[j, i] = arcVal; //matrice symétrique
                    }
                }
            }
            return adjMat;
        }

        public int GetNbImpasses(out List<RouteNode> impasses)
        {
            //compteur d'arcs de chaque noeud
            int comptArcs = 0;
            //compteur d'impasses totales du réseau
            int comptImpasses = 0;

            impasses = new List<RouteNode>();

            for (int i = 0; i < adjMat.GetLength(0); i++)
            {
                for (int j = 0; j < adjMat.GetLength(1); j++)
                {
                    if (adjMat[i, j] != null)
                        comptArcs++;
                }

                if (comptArcs == 1)
                {
                    comptImpasses++;
                    impasses.Add(Nodes[i]);
                }
                comptArcs = 0;
            }
            return comptImpasses;
        }


        public void AfficheMatrix()
        {

            Console.Write("      ");
            for (int i = 0; i < nbNodes; i++)
            {
                Console.Write("{0}  ", (char)('A' + i));
            }

            Console.WriteLine();

            for (int i = 0; i < nbNodes; i++)
            {
                Console.Write("\n {0} | ", (char)('A' + i));

                for (int j = 0; j < nbNodes; j++)
                {
                    if (i == j)
                    {
                        Console.Write(" # ");
                    }
                    else if (adjMat[i, j] == null)
                    {
                        Console.Write(" ..");
                    }
                    else
                    {
                        Console.Write(" {0} ", adjMat[i, j]);
                    }

                }
                Console.Write(" |\r\n");
            }
            Console.Write("\r\n");
        }

        // calcule les couts de retour en A depuis tous les points du reseau
        public void calculeCoutsRetour()
        {
            foreach(RouteNode rn in Nodes)
            {
                string nodeName = rn.GetName();
                List<GenericNode> chemin;
                double coutRetour = calculeMeilleurCout(nodeName, "A", out chemin);
                coutsRetour.Add(chemin, coutRetour);
            }
        }

        //renvoie le cout du + court chemin de noeudInital à noeudFinal
        public double calculeMeilleurCout(string noeudInital, string noeudFinal, out List<GenericNode> chemin)
        {
            NodeRecherche noeudInit = new NodeRecherche(noeudInital); // départ de noeudInital
            NodeRecherche.nomLieuFinal = noeudFinal; // retour à noeudFinal

            Graph graph = new Graph();

            //meilleur chemin de noeudInital à noeudFinal
            chemin = graph.RechercheSolutionAEtoile(noeudInit);
            
            double cout = 0;
            NodeRecherche n1 = noeudInit;
            NodeRecherche n2;

            //somme des couts intermédiaires
            foreach (GenericNode n in chemin)
            {
                n2 = n as NodeRecherche;
                if (n2 != n1)
                    cout += n1.GetArcCost(n2);
                n1 = n2;
            }

            return (cout);
        }

        // surcharge si pas besoin de recup le chemin
        public double calculeMeilleurCout(string noeudInitial, string noeudFinal)
        {
            List<GenericNode> chemin = new List<GenericNode>();
            return (calculeMeilleurCout(noeudInitial, noeudFinal, out chemin));
        }
        
        // false tant que tous les points n'ont pas été visités
        public bool tousVisites(List<string> pointsPassage, List<string> pointsVisites)
        {
            foreach(string point in pointsPassage)
            {
                if (!pointsVisites.Contains(point))
                    return false;
            }
            return true;
        }

        // renvoie le chemin le plus court de A à A en passant par les points de passage séléctionnés
        public double getItineraire(List<string> pointsPassage, out string cheminString)
        {
            pointsPassage.Add("A");
            List<string> pointsPassageOrdonnes = new List<string>();
            //liste ordonnée des noeuds du meilleur chemin
            List<NodeRecherche> cheminTotal = new List<NodeRecherche>();
            // cout associé
            double coutTotal = 0;


            // dico~matrice des <chemins+couts> de chaq couple de points de passage
            Dictionary<List<GenericNode>, double> coutsInter = new Dictionary<List<GenericNode>, double>();

            //remplissage du dico ~matrice
            //pour chaque couple de noeuds
            foreach (string np1 in pointsPassage)
            {
                foreach (string np2 in pointsPassage)
                {
                    if (np1 != np2)  // diagonale de la matrice nulle
                    {
                        List<GenericNode> chemin = new List<GenericNode>();
                        double cout = calculeMeilleurCout(np1, np2, out chemin);
                        coutsInter.Add(chemin, cout);
                    }
                }
            }

            List <string> coutsInterString = new List<string>();
            foreach(List<GenericNode> lgn in coutsInter.Keys)
            {
                coutsInterString.Add(string.Join(", ", lgn));
            }
            Console.WriteLine("chemins inter : "+ string.Join("| ",coutsInterString));
            Console.WriteLine("couts associés : " + string.Join("    |    ", coutsInter.Values));


            // a partir de cette "matrice", calcul des distances de proche en proche 
            // pour définir le chemin total à parcourir dans l'ordre optimal
            // => pr chaq "ligne" de la matrice = pr chaque couple contenant le noeud init
            // on va au prochain plus proche (n2)
            //on stocke le nom du noeud et le cout associé
            // on passe sur la "ligne" de n2 et on va au plus proche... etc
            // a la fin, on a la liste des noeuds du chemin optimal, et le cout total

            GenericNode noeudCourant = new NodeRecherche("A"); // on demarre en A
            GenericNode prochainNoeud;

            pointsPassageOrdonnes.Add(noeudCourant.GetNom());

            // tant qu'on n'a pas tout visité et qu'on n'est pas retourné en A
            while (!(tousVisites(pointsPassage, pointsPassageOrdonnes) && noeudCourant.GetNom() == "A"))
            {
                //dico temporaire correspondant aux successeurs du noeudCourant (= sa ligne dans la matrice) 
                Dictionary<List<GenericNode>, double> successeurs = new Dictionary<List<GenericNode>, double>();
                
                foreach (KeyValuePair<List<GenericNode>, double> couple in coutsInter)
                {
                    if (couple.Key.First().GetNom() == noeudCourant.GetNom() && //chemin au départ de noeudCourant
                        (!pointsPassageOrdonnes.Contains(couple.Key.Last().GetNom()) || // evite doublons
                            //sauf pour retour en A à la fin
                        couple.Key.Last().GetNom()=="A" && tousVisites(pointsPassage, pointsPassageOrdonnes))) 
                    {
                        successeurs.Add(couple.Key, couple.Value);
                    }
                }

                Console.WriteLine("le noeud {0} a {1} successeur(s)", noeudCourant.GetNom(),
                    successeurs.Count().ToString());

                //recherche du successeur le plus proche
                foreach (KeyValuePair<List<GenericNode>, double> succ in successeurs)
                {
                    // celui dont le chemin est le plus court
                    if (succ.Value == successeurs.Values.Min())
                    {
                        // dernière valeur du chemin pour aller à ce noeud
                        prochainNoeud = succ.Key.Last();
                        //ajout du noeud a la liste ordonnée
                        pointsPassageOrdonnes.Add(prochainNoeud.GetNom());
                        //ajout du cout du trajet intermédiaire
                        coutTotal += succ.Value;
                        //ajout de chaque point intermédiaire au chemin total
                        foreach (NodeRecherche n in succ.Key)
                        {                          
                            if(cheminTotal.Count==0 || n.GetNom()!=cheminTotal.Last().GetNom())
                                cheminTotal.Add(n);       
                        }
                        
                        //passage au couple suivant, c à d au depart de ce noeud
                        noeudCourant = prochainNoeud;

                        // si plusieurs noeuds ont le même cout minimal, on s'arrete au premier
                        break; 
                    }
                }
            }


            // conversion du chemin en string lisible
            cheminString = "";
            cheminString+= String.Join(", ", cheminTotal);

            return coutTotal;
        }

        // renvoie le chemin le plus court passant par les points de passage séléctionnés
        // avec vidange après 4 fermes visitées
        public double getItinCollecte(List<string> pointsPassage, out string cheminString)
        {
            pointsPassage.Add("A");
            List<string> pointsPassageOrdonnes = new List<string>();
            //liste ordonnée des noeuds du meilleur chemin
            List<NodeRecherche> cheminTotal = new List<NodeRecherche>();
            // cout associé
            double coutTotal = 0;
            int comptFerme = 0; // compte fermes parmi points passage


            // dico (~matrice) des <chemins+couts> de chaq couple de points de passage
            Dictionary<List<GenericNode>, double> coutsInter = new Dictionary<List<GenericNode>, double>();

            //remplissage du dico ~matrice
            //pour chaque couple de noeuds
            foreach (string np1 in pointsPassage)
            {
                foreach (string np2 in pointsPassage)
                {
                    if (np1 != np2)  // diagonale de la matrice nulle
                    {
                        List<GenericNode> chemin = new List<GenericNode>();
                        double cout = calculeMeilleurCout(np1, np2, out chemin);
                        coutsInter.Add(chemin, cout);
                    }
                }
            }
            Console.WriteLine(coutsInter.Count().ToString() + " couts intermédiares calculés");
            Console.WriteLine("####################################################");
            List<string> coutsInterString = new List<string>();
            foreach (List<GenericNode> lgn in coutsInter.Keys)
            {
                coutsInterString.Add(string.Join(", ", lgn));
            }
            Console.WriteLine("chemins inter : " + string.Join("| ", coutsInterString));
            Console.WriteLine("couts associés : " + string.Join("    |    ", coutsInter.Values));


            // a partir de cette "matrice", calcul des distances de proche en proche 
            // pour définir le chemin total à parcourir dans l'ordre optimal
            // => pr chaq "ligne" de la matrice = pr chaque couple contenant le noeud init
            // on va au prochain plus proche (n2)
            //on stocke le nom du noeud et le cout associé
            // on passe sur la "ligne" de n2 et on va au plus proche... etc
            // a la fin, on a la liste des noeuds du chemin optimal, et le cout total

            GenericNode noeudCourant = new NodeRecherche("A"); // on demarre en A
            GenericNode prochainNoeud;

            pointsPassageOrdonnes.Add(noeudCourant.GetNom());

            while (!tousVisites(pointsPassage, pointsPassageOrdonnes) || noeudCourant.GetNom() != "A")
            {
                if (comptFerme < 4) // la citerne n'est pas pleine
                {
                    //dico temporaire correspondant aux successeurs du noeudCourant (= sa ligne dans la matrice) 
                    Dictionary<List<GenericNode>, double> successeurs = new Dictionary<List<GenericNode>, double>();

                    foreach (KeyValuePair<List<GenericNode>, double> couple in coutsInter)
                    {
                        if (couple.Key.First().GetNom() == noeudCourant.GetNom() && //chemin au départ de noeudCourant
                            (!pointsPassageOrdonnes.Contains(couple.Key.Last().GetNom()))) // evite doublons
                        {
                            successeurs.Add(couple.Key, couple.Value);
                        }
                    }

                    Console.WriteLine("le noeud {0} a {1} successeur(s) et citerne remplie à {2}/4",
                        noeudCourant.GetNom(), successeurs.Count().ToString(),comptFerme);

                    //recherche du successeur le plus proche
                    foreach (KeyValuePair<List<GenericNode>, double> succ in successeurs)
                    {
                        // celui dont le chemin est le plus court
                        if (succ.Value == successeurs.Values.Min())
                        {
                            // dernière valeur du chemin pour aller à ce noeud
                            prochainNoeud = succ.Key.Last();
                            double coutInter = succ.Value;

                            //ajout de chaque point intermédiaire au chemin total
                            foreach (NodeRecherche n in succ.Key)
                            {
                                if (cheminTotal.Count == 0 || n.GetNom() != cheminTotal.Last().GetNom())
                                {
                                    cheminTotal.Add(n);

                                    if (fermes.Contains(n.GetNom()))
                                    {
                                        comptFerme++;
                                        if (comptFerme == 4)
                                        {
                                            // on arrete là
                                            prochainNoeud = n;
                                            coutInter = calculeMeilleurCout(noeudCourant.GetNom(), n.GetNom()); 
                                            break;
                                        }
                                    }
                                }
                            }
                            
                            //ajout du noeud a la liste ordonnée
                            pointsPassageOrdonnes.Add(prochainNoeud.GetNom());

                            //ajout du cout du trajet intermédiaire
                            coutTotal += coutInter;

                            //passage au couple suivant, c à d au depart de ce noeud
                            noeudCourant = prochainNoeud;

                            // si plusieurs noeuds ont le même cout minimal, on s'arrete au premier
                            break;
                        }
                    }
                }

                // la citerne est pleine, ou la collecte est terminée
                if ((comptFerme == 4) || tousVisites(pointsPassage, pointsPassageOrdonnes)) 
                {
                    // on retourne en A
                    List<GenericNode> succChemin = getCheminRetour(noeudCourant.GetNom());
                    double succCout = getCoutRetour(noeudCourant.GetNom());

                    prochainNoeud = succChemin.Last();
                    coutTotal += succCout;

                    //ajout de chaque point intermédiaire au chemin total
                    foreach (NodeRecherche n in succChemin)
                    {
                        if (cheminTotal.Count == 0 || n.GetNom() != cheminTotal.Last().GetNom())
                        {
                            cheminTotal.Add(n);
                        }
                    }
                    comptFerme = 0;  //réinit après vidange en A
                    //passage au couple suivant
                    noeudCourant = prochainNoeud;
                }
            }

            // conversion du chemin en string lisible
            cheminString = "";
            cheminString += String.Join(", ", cheminTotal);

            return coutTotal;
        }
    }
}
