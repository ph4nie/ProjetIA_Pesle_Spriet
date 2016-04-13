using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static Graphics g;
        static Bitmap bmp;
         Random rnd = new Random();

        Reseau reseau;

        private void button1_Click(object sender, EventArgs e)
        {
            // Initialisation d'un réseau de neurones avec le nombre d'entrées, 
            // le nombre de couches et le nbre de neurones par couches
            reseau = new Reseau(Convert.ToInt32(textBoxnbentrees.Text),
                                        Convert.ToInt32(textBoxnbcouches.Text),
                                        Convert.ToInt32(textBoxnbneurcouche.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
             List<List<double>> lvecteursentrees = new List<List<double>>();
             List<double> lsortiesdesirees = new List<double>();
             for (int i = 0; i < 1000; i++)
             {
                 List<double> vect = new List<double>();
                 double x = rnd.NextDouble();
                 vect.Add(x); // Une seule valeur ici pour ce vecteur 
                 lvecteursentrees.Add(vect);
                 lsortiesdesirees.Add(fonctionmodele(x));
             }

             reseau.backprop(lvecteursentrees, lsortiesdesirees ,
                                Convert.ToDouble(textBoxalpha.Text),
                                Convert.ToInt32(textBoxnbiter.Text));
            Tests( g, bmp);
            pictureBox1.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = (Bitmap)pictureBox1.Image;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            reseau.AfficheInfoNeurone(Convert.ToInt32(textBoxnumcouche.Text),
                                       Convert.ToInt32(textBoxnumneur.Text),
                                       listBox1);

        }
        /*****************************************************************/
        // Attention, la fonction à apprendre doit fournir des valeurs entre 0 et 1 !!!
        double fonctionmodele(double x)
        {
            // return Math.Sin(x * 20) / 2.5 + 0.5;
            if (x < 0.2 || x > 0.8) return 0.8;
            else return 0.2;
        }

        /**********************************************************************/
        public void Tests(Graphics g, Bitmap bmp)
        {
            int x, z, zdesire;
            double x2, z2;
            for (x = 0; x < bmp.Width; x++)
                for (z = 0; z < bmp.Height; z++)
                    bmp.SetPixel(x, z, Color.Black);

            List<List<double>> lvecteursentrees = new List<List<double>>();
            List<double> lsortiesdesirees = new List<double>();
            List<double> lsortiesobtenues; 

            // On teste 200 exemples de x pris entre 0 et +200
            // En fait, x2 sera compris entre -100 et 100, x sera utilisé pour l'affichage entre 0 et 200
            for (x = 0; x < 200; x++)
            {
                x2 = x /200.0;
                // Initialisation des activations  ai correspondant aux entrées xi
                // Le premier neurone est une constante égale à 1
                List<double> vect = new List<double>();
                vect.Add(x2); // Une seule valeur ici pour ce vecteur 
                lvecteursentrees.Add(vect);
                lsortiesdesirees.Add( fonctionmodele(x2) );
            }

            lsortiesobtenues = reseau.ResultatsEnSortie( lvecteursentrees );
            
            // Affichage
             for (x = 0; x < 200; x++)
             {
                 z2 = lsortiesobtenues[x];
                
                // z2 valeur attendu entre 0 et 1 ; conversion pour z qui est retenu pour l'affichage
                 z = (int)(z2 * 200);
                 zdesire = (int)(lsortiesdesirees[x] * 200);
                bmp.SetPixel(x, bmp.Height - z - 1, Color.Yellow);
                
                bmp.SetPixel(x, bmp.Height - zdesire - 1, Color.White);
            }

        }
        
    }
}
