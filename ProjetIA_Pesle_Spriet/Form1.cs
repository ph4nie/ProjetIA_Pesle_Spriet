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
            NodeRecherche.nomLieuFinal = textBox_noeudFinal.Text;

            Graph graph = new Graph();
            List<GenericNode> chemin = graph.RechercheSolutionAEtoile(new NodeRecherche(textBox_noeudInit.Text));

            listBox1.Items.Clear();
            foreach (GenericNode n in chemin)
            {
                listBox1.Items.Add(n.ToString());
            }

            graph.GetSearchTree(treeView1);
        }
    }
}
