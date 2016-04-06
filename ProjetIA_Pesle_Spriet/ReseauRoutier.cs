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

        public List<RouteNode> GetNodes()
        {
            return Nodes;
        }
        public ReseauRoutier(int nbNodes)
        {
            this.nbNodes = nbNodes;
            Nodes = new List<RouteNode>();
            adjMat = new int?[nbNodes, nbNodes];
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

        // renvoie le chemin le plus court de A à A en passant par les points de passage séléctionnés
        public double getItineraire(List<string> pointsPassage, out string cheminString)
        {
            List<GenericNode> pointsPassageOrdonnes = new List<GenericNode>();
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
                NodeRecherche n1 = new NodeRecherche(np1);
                foreach (string np2 in pointsPassage)
                {
                    if (np1 != np2)  // diagonale de la matrice nulle
                    {
                        NodeRecherche n2 = new NodeRecherche(np2);
                        List<GenericNode> chemin;
                        double cout = n1.calculeMeilleurCout(np2, out chemin);

                        coutsInter.Add(chemin, cout);
                    }
                }
            }


            // a partir de cette "matrice", calcul des distances de proche en proche 
            // pour définir le chemin total à parcourir dans l'ordre optimal
            // => pr chaq "ligne" de la matrice = pr chaque couple contenant le noeud init
            // on va au prochain plus proche (n2)
            //on stocke le nom du noeud et le cout associé
            // on passe sur la "ligne" de n2 et on va au plus proche... etc
            // a la fin, on a la liste des noeuds du chemin optimal, et le cout total

            GenericNode noeudCourant = new NodeRecherche("A"); // on demarre en A
            GenericNode prochainNoeud;

            pointsPassageOrdonnes.Add(noeudCourant);


            /*
            foreach (KeyValuePair< List<GenericNode>, double> couple in coutsInter)
            {
                //dico temporaire correspondant aux successeurs du noeudCourant (= sa ligne dans la matrice) 
                Dictionary<List<GenericNode>, double> successeurs = new Dictionary<List<GenericNode>, double>();

                if (couple.Key.First<GenericNode>() == noeudCourant)
                {
                    successeurs.Add(couple.Key,couple.Value);
                }

                //recherche du successeur le plus proche
                foreach(KeyValuePair<List<GenericNode>, double> succ in successeurs)
                {
                    // celui dont le chemin est le plus court
                    if(succ.Value== successeurs.Values.Min())
                    {
                        // dernière valeur du chemin pour aller à ce noeud
                        prochainNoeud = succ.Key.Last<GenericNode>();
                        //ajout du noeud a la liste ordonnée
                        pointsPassageOrdonnes.Add(prochainNoeud);
                        //passage au couple suivant, c à d au depart de ce noeud
                        noeudCourant = prochainNoeud;
                        
                    }
                }
            }

            */


            /* on recup les points d'interet dans l'ordre ideal de passage, 
            il faut récupérer aussi TOUS les points du chemin avec le cout */

            //    /!\ plantage à résoudre ! /!\

            // conversion du chemin en string lisible
            cheminString = "";
            cheminString+= String.Join(", ", pointsPassageOrdonnes/*cheminTotal*/);

            return coutTotal;
        }
    }
}
