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

        // renvoie le chemin le plus court de A à A en passant par les "passages"
        public double getItineraire(List<string> pointPassage, out string cheminString)
        {
            double coutTotal = 0;
            cheminString = "";

            NodeRecherche n1 = new NodeRecherche("A");
            NodeRecherche n2;
            pointPassage.Add("A"); // on veut revenir à A à la fin de la boucle

            Graph graph = new Graph();

            List<GenericNode> chemin;
            List<GenericNode> cheminTotal = new List<GenericNode>();

            foreach (string np in pointPassage)
            {
                NodeRecherche.nomLieuFinal = np;

                //calcule plus court chemin de n1 à n2 // comme dans le Form1
                chemin = graph.RechercheSolutionAEtoile(n1);


                /****************
                fait varier la taille de la liste a explorer dans le prochain foreach -> plantage
                =>séparer en deux boucles, par exemple...
                // enlève les doublons (noeuds qui sont sur la route pour aller aux autres)
                if (chemin.Contains(n1) && n1.GetNom() != "A")
                    cheminTotal.Remove(n1);
*************************/
                double cout = 0;

                foreach (GenericNode n in cheminTotal)
                {
                    n2 = n as NodeRecherche;
                    if (n2 != n1)
                        cout += n1.GetArcCost(n2);
                    n1 = n2;
                    //l'ajoute au cout total
                    coutTotal += cout;
                }
                n1 = new NodeRecherche(np);
            }

            // après on réitère l'opé en changeant l'ordre des noeuds -> comment ? 
            // on stocke à chaq fois le coutTotal ds une liste ou un tab
            // on garde la solution pour le coutTotal le plus faible
            cheminString += String.Join(", ", cheminTotal);

            return coutTotal;
        }
    }
}
