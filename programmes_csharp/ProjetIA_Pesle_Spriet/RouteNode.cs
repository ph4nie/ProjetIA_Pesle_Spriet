using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetIA_Pesle_Spriet
{
    public class RouteNode
    {
        string Name;
        public Dictionary<RouteNode, int> Voisins;
        public static ReseauRoutier Reseau;

    public RouteNode(string nom, ReseauRoutier reseau)
        {
            Name=nom;
            Reseau = reseau;
            reseau.AjouteNode(this);
            Voisins = new Dictionary<RouteNode, int>();
        }

        public string GetName()
        {
            return Name;
        }

        public Dictionary<RouteNode, int> GetVoisins()
        {
            return Voisins;
        }

        //crée un arc connectant le noeud à un autre (voisin)
        public void AddArc(RouteNode voisin, int poids)
        {
            Voisins.Add(voisin, poids);            
        }

        public override string ToString()
        {
            return this.Name;
        }

        public bool IsImpasse()
        {
            List<RouteNode> impasses = new List<RouteNode>();
            int nbImp = Reseau.GetNbImpasses(out impasses);
            if (nbImp != 0 && impasses.Contains(this))
                return true;
            else
                return false;
        }    
    }
}
