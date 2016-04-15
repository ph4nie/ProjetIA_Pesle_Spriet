using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace partie2Q3
{
    public partial class Form1 : Form
    {
        // Fenetre permettant de visualiser les valeurs initiales et finales des poids,
        // le nombre d'itérations et le nombre d'erreurs
        // Un graphe montrant la position des points et la droite séparatrice définie par les poids

        List<Exemple> exemples = new List<Exemple>();
        Perceptron perceptron;
        Bitmap bmp;
        double xmax = 6;
        double ymin = 0;
        double ymax = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Initialisation de l'image
            bmp = (Bitmap)pictBoxPlot.Image;
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                   bmp.SetPixel(i, j, Color.Black);
            

            //importation des données

            exemples.Add(new Exemple(0.2, 4.839161656, "A"));
            exemples.Add(new Exemple(0.4, 5.043697771, "A"));
            exemples.Add(new Exemple(0.6, 4.548758355, "A"));
            exemples.Add(new Exemple(0.8, 3.626296189, "A"));
            exemples.Add(new Exemple(1, 3.777023723, "A"));
            exemples.Add(new Exemple(1.2, 3.009015886, "A"));
            exemples.Add(new Exemple(1.4, 2.963880389, "A"));
            exemples.Add(new Exemple(1.6, 2.185124748, "A"));
            exemples.Add(new Exemple(1.8, 1.809000661, "A"));
            exemples.Add(new Exemple(2, 1.634322957, "A"));
            exemples.Add(new Exemple(2.2, 0.919315808, "A"));
            exemples.Add(new Exemple(2.4, 0.515845586, "A"));
            exemples.Add(new Exemple(2.6, 0.502571483, "A"));
            exemples.Add(new Exemple(2.8, -0.332149786, "A"));
            exemples.Add(new Exemple(3, 0.082429368, "A"));
            exemples.Add(new Exemple(3.2, -0.47429866, "A"));
            exemples.Add(new Exemple(3.4, -1.024828934, "A"));
            exemples.Add(new Exemple(3.6, -1.660408796, "A"));
            exemples.Add(new Exemple(3.8, -2.477061314, "A"));
            exemples.Add(new Exemple(4, -2.899482942, "A"));
            exemples.Add(new Exemple(4.2, -2.78043264, "A"));
            exemples.Add(new Exemple(4.4, -3.067248941, "A"));
            exemples.Add(new Exemple(4.6, -3.730859517, "A"));
            exemples.Add(new Exemple(4.8, -4.223165137, "A"));
            exemples.Add(new Exemple(5, -3.977326057, "A"));
            exemples.Add(new Exemple(5.2, -4.699555208, "A"));
            exemples.Add(new Exemple(5.4, -4.73372386, "A"));
            exemples.Add(new Exemple(5.6, -5.949667516, "A"));
            exemples.Add(new Exemple(5.8, -5.912389894, "A"));
            exemples.Add(new Exemple(6, -6.750912844, "A"));

            exemples.Add(new Exemple(0.2, 5.776117785, "B"));
            exemples.Add(new Exemple(0.4, 6.088224, "B"));
            exemples.Add(new Exemple(0.6, 5.099807062, "B"));
            exemples.Add(new Exemple(0.8, 5.285979623, "B"));
            exemples.Add(new Exemple(1, 5.030360354, "B"));
            exemples.Add(new Exemple(1.2, 4.118991581, "B"));
            exemples.Add(new Exemple(1.4, 3.839315515, "B"));
            exemples.Add(new Exemple(1.6, 3.278899842, "B"));
            exemples.Add(new Exemple(1.8, 3.210410483, "B"));
            exemples.Add(new Exemple(2, 2.230539618, "B"));
            exemples.Add(new Exemple(2.2, 1.913241393, "B"));
            exemples.Add(new Exemple(2.4, 2.272924192, "B"));
            exemples.Add(new Exemple(2.6, 1.133540493, "B"));
            exemples.Add(new Exemple(2.8, 0.633607804, "B"));
            exemples.Add(new Exemple(3, 0.384251622, "B"));
            exemples.Add(new Exemple(3.2, 0.17456169, "B"));
            exemples.Add(new Exemple(3.4, -0.271964762, "B"));
            exemples.Add(new Exemple(3.6, -0.77041877, "B"));
            exemples.Add(new Exemple(3.8, -1.182224717, "B"));
            exemples.Add(new Exemple(4, -1.100788947, "B"));
            exemples.Add(new Exemple(4.2, -2.27745889, "B"));
            exemples.Add(new Exemple(4.4, -2.462855515, "B"));
            exemples.Add(new Exemple(4.6, -2.187547774, "B"));
            exemples.Add(new Exemple(4.8, -3.290209121, "B"));
            exemples.Add(new Exemple(5, -3.489036554, "B"));
            exemples.Add(new Exemple(5.2, -3.642730068, "B"));
            exemples.Add(new Exemple(5.4, -4.616142787, "B"));
            exemples.Add(new Exemple(5.6, -4.485012876, "B"));
            exemples.Add(new Exemple(5.8, -4.700576381, "B"));
            exemples.Add(new Exemple(6, -5.528898302, "B"));

            
            foreach (Exemple ex in exemples)
            {
                //affichage des données dans la listBox
                listBoxExemples.Items.Add(ex.getX()+"   " + ex.getY() +"    " + ex.getGroupe());

                //calcul de ymin et ymax pour l'étalonnage
                if (ex.getY() < ymin)
                    ymin = ex.getY();
                if (ex.getY() > ymax)
                    ymax = ex.getY();
            }

            // Affichage en nuage de points dans l'image
            foreach (Exemple ex in exemples)
            {
                // mise à l'échelle des valeurs pour optimiser l'affichage dans l'image
                double ax = ex.getX()/xmax;
                double ay = (ex.getY()+ Math.Abs(ymin))/(ymax+ Math.Abs(ymin));

                int x = (int)((bmp.Width-1) * ax);
                int y = (int)((bmp.Height-1) * ay);

                switch (ex.getGroupe())
                {
                    case "A":
                        bmp.SetPixel(x-1, bmp.Height - y-1, Color.Red);
                        break;
                    case "B":
                        bmp.SetPixel(x-1, bmp.Height - y-1, Color.Chartreuse);
                        break;
                }
            }
            pictBoxPlot.Invalidate();
        }

        private void buttonTri_Click(object sender, EventArgs e)
        {
            //tri de la liste avec Linq pour alterner A/B
            exemples = exemples.OrderBy(o => o.getX()).ToList();

            //affichage de la liste triée
            listBoxExemples.Items.Clear(); //vide la listbox
            foreach (Exemple ex in exemples)
            {
                listBoxExemples.Items.Add(ex.getX() + "   " + ex.getY() + "    " + ex.getGroupe());
            }
        }

        private void buttonInit_Click(object sender, EventArgs e)
        {
            // Initialisation du perceptron à 2 entrées + 1 constante
            perceptron = new Perceptron(3);

            // affichage des poids initiaux
            labelW1init.Text = perceptron.getPoids(0).ToString();
            labelW2init.Text = perceptron.getPoids(1).ToString();
            labelW3init.Text = perceptron.getPoids(2).ToString();
        }

        private void buttonExeAppr_Click(object sender, EventArgs e)
        {
            int nbErreurs;
            int nbIterations;

            // apprentissage sur la base d'exemple = calcul des poids
            double[] poids = perceptron.ApprendreExemples(exemples, out nbErreurs, out nbIterations);

            // affichage des poids finaux
            labelW1fin.Text = poids[0].ToString();
            labelW2fin.Text = poids[1].ToString();
            labelW3fin.Text = poids[2].ToString();

            // affichage du nombre d'erreurs et d'itérations
            label_nbErreurs.Text = nbErreurs.ToString();
            label_nbIterations.Text = nbIterations.ToString();

            //**** Affichage de la droite séparatrice calculée

            //Initialisation ddu background
            bmp = (Bitmap)pictBoxPlot.Image;
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                    bmp.SetPixel(i, j, Color.Black);

            // Affichage en nuage de points dans l'image
            foreach (Exemple ex in exemples)
            {
                // mise à l'échelle des valeurs pour optimiser l'affichage dans l'image
                double ax = ex.getX() / xmax;
                double ay = (ex.getY() + Math.Abs(ymin)) / (ymax + Math.Abs(ymin));

                int x = (int)((bmp.Width - 1) * ax);
                int y = (int)((bmp.Height - 1) * ay);

                switch (ex.getGroupe())
                {
                    case "A":
                        bmp.SetPixel(x - 1, bmp.Height - y - 1, Color.Red);
                        break;
                    case "B":
                        bmp.SetPixel(x - 1, bmp.Height - y - 1, Color.Chartreuse);
                        break;
                }
            }
            pictBoxPlot.Invalidate();

            // Affichage nouvelle droite
            for (int x = 0; x < bmp.Width; x++)
            {
                double ax = (double)x / bmp.Width;
                double x_calc = xmax * ax;
                //equation de la droite séparatrice
                double y_calc = -(poids[0] * x_calc + poids[2]) / poids[1];

                double ay = (y_calc + Math.Abs(ymin)) / (ymax + Math.Abs(ymin));
                int y = (int)((bmp.Height - 1) * ay);

                //affichage(ty
                pictBoxPlot.Invalidate();
                if (y >= 0 && y < bmp.Height)
                    bmp.SetPixel(x, bmp.Height - y - 1, Color.White);
            }
        }
    }
}
