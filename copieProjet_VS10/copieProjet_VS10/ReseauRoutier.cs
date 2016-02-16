using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace copieProjet_VS10
{
    class ReseauRoutier
    {
        int nbNodes = 23; //A->W
        private List<FermeNode> fermeNodes;
        private int?[,] adjMat;  // ? -> nullable

        public ReseauRoutier()
        {
            fermeNodes = new List<FermeNode>();
            adjMat = new int?[nbNodes,nbNodes];
        }

        public void GetNbImpasses()
        {
            int comptArcs = 0;
            int comptImpasses = 0;

            for(int i = 0; i < nbNodes; i++)
            {
                for(int j = 0; j < nbNodes; j++)
                {
                    if (adjMat[i, j] != null)
                        comptArcs++;
                }

                if (comptArcs == 1)
                    comptImpasses++;
                comptArcs = 0;
            }
        }


        }
        public void AfficherMatrix()
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
                        Console.Write(" &.");
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
