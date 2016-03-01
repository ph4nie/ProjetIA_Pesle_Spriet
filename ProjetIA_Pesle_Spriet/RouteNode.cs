using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetIA_Pesle_Spriet
{
    class RouteNode : GenericNode
    {
        protected Dictionary<RouteNode, int> Arcs;
        protected ReseauRoutier Reseau;

        public RouteNode(string nom, ReseauRoutier reseau) : base(nom)
        {
            Reseau = reseau;
            reseau.AjouteNode(this);
            Arcs = new Dictionary<RouteNode, int>();
        }

        public Dictionary<RouteNode, int> GetArcs()
        {
            return Arcs;
        }

        //crée un arc connectant le noeud à un autre (fils)
        public void AddArc(RouteNode fils, int poids)
        {
            Arcs.Add(fils, poids);
            fils.SetNoeud_Parent(this);
        }
        public override void CalculeHCost()
        {
            throw new NotImplementedException();
        }

        
        public override bool EndState()
        {
            throw new NotImplementedException();


        }

        public bool IsImpasse()
        {
            List<RouteNode> impasses = new List<RouteNode>();
            int nbImp = this.Reseau.GetNbImpasses(out impasses);
            if (nbImp != 0 && impasses.Contains(this))
                return true;
            else
                return false;
        }

        public override double GetArcCost(GenericNode N2)
        {
            int arcCost;

            if (N2 == this)
                return 0;

            else if (this.GetArcs().TryGetValue(N2 as RouteNode, out arcCost))
            {
                return arcCost;
            }
            else
                throw new NotImplementedException();
        }

        // retourne la liste de tous les noeuds successeurs de this
        public override List<GenericNode> GetListSucc()
        {
            /*
            List<GenericNode> listSucc = new List<GenericNode>();

            foreach (RouteNode n in Reseau.GetNodes())
            {
                if (n.ParentNode == this)
                    listSucc.Add(n);
            }

            return listSucc;
            */

            return this.GetEnfants();
        }
    }
}
