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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void CalculeItineraire(object sender, EventArgs e)
        {
            int comptFerme = 0;
            List<string> pointPassage = new List<string>();
            List<string> fermes = new List<string>(new string[] {"B","H","G","J","F","M","O","V","Q","T","S"});
            
            //construction de la liste   /!\ BETA
            
            foreach (string point in checkedListBoxNoeuds.CheckedItems)
            {
                pointPassage.Add(point);
                /*
                if (fermes.Contains(point))
                    comptFerme++;
                if (comptFerme == 4)
                { // passage par A après 4 fermes
                    pointPassage.Add("A");
                    comptFerme = 0;
                }
                */
            }
            pointPassage.Add("A"); // on termine toujours par A

            string chemin;
            labelCout.Text = NodeRecherche.reseau.getItineraire(pointPassage, out chemin).ToString();
            labelAfficheChemin.Text = chemin;


        }
    }
}
