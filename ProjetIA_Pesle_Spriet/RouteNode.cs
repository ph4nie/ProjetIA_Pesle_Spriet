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
        public RouteNode(string nom, ReseauRoutier Reseau) : base(nom)
        {
            Reseau.AjouteNode(this);
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

        public override double GetArcCost(GenericNode N2)
        {
            throw new NotImplementedException();
        }

        public override List<GenericNode> GetListSucc()
        {
            throw new NotImplementedException();
        }
    }
}
