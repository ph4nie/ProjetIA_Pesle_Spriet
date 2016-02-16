using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace copieProjet_VS10
{
    class FermeNode : GenericNode
    {
        public FermeNode(string nom) : base(nom)
        {

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
