using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetIA_Pesle_Spriet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NodeRecherche.nomLieuFinal = "A";

            Graph graph = new Graph();
            List<GenericNode> chemin_A_E = graph.RechercheSolutionAEtoile(new NodeRecherche("E"));

            graph.GetSearchTree(treeView1);       //     Console.WriteLine("le plus court chemin de A à E est " + String.Join("; ", chemin_A_E));
       //     Console.WriteLine("##################################");
        }
    }
}
