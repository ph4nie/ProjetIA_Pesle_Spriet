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
    }
}
