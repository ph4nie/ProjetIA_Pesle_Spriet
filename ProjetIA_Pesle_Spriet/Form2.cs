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


        private void CalculeItineraire(object sender, EventArgs e)
        {
            //int comptFerme = 0; // compte fermes parmi points passage
            List<string> pointPassage = new List<string>();

            // toutes les fermes du reseau laitier
            List<string> fermes = new List<string>(new string[] {"B","H","G","J","F","M","O","V","Q","T","S"});
            
            
            
            // parcours des noeuds selectionnés par l'utilisateur
            foreach (string point in checkedListBoxNoeuds.CheckedItems)
            {
                pointPassage.Add(point);
            }
          
            string chemin;
            labelCout.Text = NodeRecherche.reseau.getItineraire(pointPassage, out chemin).ToString();
            labelAfficheChemin.Text = chemin;


        }
    }
}
