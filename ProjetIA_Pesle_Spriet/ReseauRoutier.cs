using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetIA_Pesle_Spriet
{
    class ReseauRoutier
    {
        int nbNodes;
        private List<FermeNode> fermeNodes;
        private int[,] adjMat;

        public ReseauRoutier()
        {
            fermeNodes = new List<FermeNode>();
            adjMat = new int[fermeNodes.Count, fermeNodes.Count];
        }

        public void GetNbImpasses()
        {
            int comptArcs = 0;

            for(int i = 0; i < nbNodes; i++)
            {
                for(int j = 0; j < nbNodes; j++)
                {
                    if (adjMat[i, j] != null)
                        comptArcs++;
                }
            }
        }
    }
}
