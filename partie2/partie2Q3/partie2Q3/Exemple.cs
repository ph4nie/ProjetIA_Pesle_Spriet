using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace partie2Q3
{
    class Exemple
    {
        private double x;
        private double y;
        private string groupe;

        public Exemple(double x, double y, string groupe)
        {
            this.x = x;
            this.y = y;
            this.groupe = groupe;
        }

        public double getX()
        {
            return x;
        }

        public double getY()
        {
            return y;
        }

        public string getGroupe()
        {
            return groupe;
        }


    }
}
