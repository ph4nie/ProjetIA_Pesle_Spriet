using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace partie2Q3
{
    class Perceptron
    {
        private double[] entrees;
        private double[] poids; //poids associés aux entrées
        private int nbEntrees;
        private int seuil;
        private int sortie;

        Random rnd = new Random();

        public Perceptron(int nbEntrees)
        {
            this.nbEntrees = nbEntrees;
            seuil = 1;
            poids = new double[nbEntrees];

            //Initialisation des poids W1, W2 et W3 de manière aléatoire
            for (int i = 0; i < nbEntrees; i++)
            {
                poids[i] = rnd.NextDouble();
            }
        }

        public double getPoids(int w)
        {
            return poids[w];
        }

        public void CalculeSortie()
        {
            double somme = 0;

            // somme des entrées pondérées par leurs poids respectifs
            for (int i = 0; i < nbEntrees; i++)
            {
                somme += (poids[i] * entrees[i]);
            }

            if (somme > seuil)
            {
                sortie = 1;
            }
            else
                sortie = 0;
        }

        public double[] ApprendreExemples(List<Exemple> exemples, out int nbErreurs, out int nbIterations)
        {
            // initialisation du nombre d'itérations et d'erreurs
            nbIterations = 0;
            nbErreurs = 0;

            //Tant qu'il existe une erreur de classification et qu'on n'a pas effectué 1000000 itérations
            do
            {
                //Initialisation à 0 du nombre d'erreurs de classification
                nbErreurs = 0;
                // Pour chacun des couples (E1,E2) de la base de données
                foreach (Exemple exemple in exemples)
                {
                    entrees = new double[nbEntrees];
                    //Initialiser les entrées
                    entrees[0] = exemple.getX(); //E1
                    entrees[1] = exemple.getY(); //E2
                    entrees[2] = 1;         // E3 = constante

                    //Calculer la sortie
                    CalculeSortie();

                    // Mise à jour des poids
                    switch (sortie)
                    {
                        // Si la sortie vaut 0 alors que 1 était attendu, Wi <- Wi + Ei pour chaque Wi
                        // Si la sortie n'est pas la bonne, augmenter de 1 le nombre d'erreurs
                        case 0:
                            if (exemple.getGroupe() == "A") //sortie désirée = 1
                            {
                                for (int i = 0; i < nbEntrees; i++)
                                {
                                    poids[i] += entrees[i];
                                }
                                nbErreurs++;
                            }
                            break;

                        // Si la sortie vaut 1 alors que 0 était attendu Wi <- Wi – Ei pour chaque Wi
                        // Si la sortie n'est pas la bonne, augmenter de 1 le nombre d'erreurs
                        case 1:
                            if (exemple.getGroupe() == "B") //sortie désirée = 0
                            {
                                for (int i = 0; i < nbEntrees; i++)
                                {
                                    poids[i] -= entrees[i];
                                }
                                nbErreurs++;
                            }
                            break;
                    }
                }
                //Augmenter de 1 le nombre d'itérations
                nbIterations++;
            } while (nbIterations < 1000000 && nbErreurs != 0);

            // renvoie les valeurs finales des poids
            return poids;
        }
    }
}
