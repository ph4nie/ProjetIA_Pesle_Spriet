﻿using System;
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
        private Dictionary<string, double> coutsRetour; // couts de retour au point A depuis chaq pt du reseau

        public List<RouteNode> GetNodes()
        {
            return Nodes;
        }

        //retourne le cout de retour au point A depuis un noeud
        public double getCoutRetour(string noeud)
        {
            double cout;
            coutsRetour.TryGetValue(noeud, out cout);
            return cout;
        }
        public ReseauRoutier(int nbNodes)
        {
            this.nbNodes = nbNodes;
            Nodes = new List<RouteNode>();
            adjMat = new int?[nbNodes, nbNodes];
            coutsRetour = new Dictionary<string, double>();
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
                double coutRetour = calculeMeilleurCout(nodeName, "A");
                coutsRetour.Add(nodeName, coutRetour);
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
            Console.WriteLine(coutsInter.Count().ToString() + " couts intermédiares calculés");
            Console.WriteLine("et {0} points de passage", pointsPassage.Count().ToString());
            Console.WriteLine("####################################################");
            List <string> coutsInterString = new List<string>();
            foreach(List<GenericNode> lgn in coutsInter.Keys)
            {
                coutsInterString.Add(string.Join(", ", lgn));
            }
            Console.WriteLine("chemins inter : "+ string.Join("| ",coutsInterString));
            Console.WriteLine("couts associés : " + string.Join("    |    ", coutsInter.Values));

            Console.WriteLine("##################################");
            string debut, fin;
            debut = coutsInter.First().Key.First().GetNom();
            fin = coutsInter.First().Key.Last().GetNom();
            Console.WriteLine("le chemin {0} commence par {1} et fini par {2}",coutsInterString[0],
                debut, fin);

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

            for (int i = 0; i <= pointsPassage.Count(); i++) 
            {
                //dico temporaire correspondant aux successeurs du noeudCourant (= sa ligne dans la matrice) 
                Dictionary<List<GenericNode>, double> successeurs = new Dictionary<List<GenericNode>, double>();

                foreach (KeyValuePair<List<GenericNode>, double> couple in coutsInter)
                {
                    if (couple.Key.First().GetNom() == noeudCourant.GetNom() && //chemin au départ de noeudCourant
                        (!pointsPassageOrdonnes.Contains(couple.Key.Last().GetNom()) // evite doublons
                        || (couple.Key.Last().GetNom()=="A" && i == pointsPassage.Count()))) //sauf pour retour en A à la fin
                    {
                        Console.WriteLine("MATCH ! " + couple.Key.Last().GetNom()+", "+couple.Value);
                        successeurs.Add(couple.Key, couple.Value);
                    }
                }

                Console.WriteLine("le noeud {0} a {1} successeur(s)"/* : {2}"*/, noeudCourant.GetNom(),
                    successeurs.Count().ToString() /*, String.Join(", ", successeurs.Keys.First())*/);

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
                        //passage au couple suivant, c à d au depart de ce noeud
                        noeudCourant = prochainNoeud;
                    }
                }
            }

            /* théoriquement, on recup les points d'interet dans l'ordre ideal de passage, 
            il faut récupérer aussi TOUS les points du chemin avec le cout */


            // conversion du chemin en string lisible
            cheminString = "";
            cheminString+= String.Join(", ", pointsPassageOrdonnes/*cheminTotal*/);

            return coutTotal;
        }
    }
}
