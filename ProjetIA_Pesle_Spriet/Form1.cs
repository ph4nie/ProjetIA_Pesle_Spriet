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
        
        private void buttonCourtChemin_Click(object sender, EventArgs e)
        {
            NodeRecherche.nomLieuFinal = textBox_noeudFinal.Text;

            Graph graph = new Graph();
            NodeRecherche noeudInit = new NodeRecherche(textBox_noeudInit.Text);
            List<GenericNode> chemin = graph.RechercheSolutionAEtoile(noeudInit);

            double cout=0;
            NodeRecherche n1 = noeudInit;
            NodeRecherche n2;
            listBoxChemin.Items.Clear();
            foreach (GenericNode n in chemin)
            {
                listBoxChemin.Items.Add(n.ToString());
                
                n2 = n as NodeRecherche;
                if (n2!=n1)
                cout += n1.GetArcCost(n2);
                n1 = n2;
            }


            textBoxCout.Text = cout.ToString();            

            graph.GetSearchTree(treeView1);
        }
    }
}
