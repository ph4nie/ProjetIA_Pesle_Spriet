using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace copieProjet_VS10
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            
            AdjMatrix graph = new AdjMatrix();
            graph.rempliValMatrix();

            int?[,] adj = graph.CreateAdjMatrix();
            graph.AfficherMatrix(ref adj);
        }
    }
}