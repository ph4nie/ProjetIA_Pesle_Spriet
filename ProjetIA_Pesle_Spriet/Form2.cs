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
            if (checkedListBoxNoeuds.CheckedItems.Count != 0)
            {

                List<string> pointsPassage = new List<string>();


                // parcours des points selectionnés par l'utilisateur
                foreach (string point in checkedListBoxNoeuds.CheckedItems)
                {
                    pointsPassage.Add(point);
                }
                label3.Text = String.Join(", ", pointsPassage);
                string chemin = "";
                double cout = NodeRecherche.reseau.getItineraire(pointsPassage, out chemin);
                labelCout.Text = cout.ToString();
                labelAfficheChemin.Text = chemin;
            }
        }

                // *****************************************

             private void CalculeItineraireCollecte(object sender, EventArgs e)
             {
                if (checkedListBoxNoeuds.CheckedItems.Count != 0)
                {

                    List<string> pointsPassage = new List<string>();

                    // parcours des points selectionnés par l'utilisateur
                    foreach (string point in checkedListBoxNoeuds.CheckedItems)
                    {
                        pointsPassage.Add(point);
                    }
                    label3.Text = String.Join(", ", pointsPassage);
                    string chemin = "";
                    double cout = NodeRecherche.reseau.getItinCollecte(pointsPassage, out chemin);
                    labelCout.Text = cout.ToString();
                    labelAfficheChemin.Text = chemin;
                }
            }
    }
}
