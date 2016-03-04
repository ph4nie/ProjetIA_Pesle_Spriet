using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetIA_Pesle_Spriet
{
    public class NodeRecherche : GenericNode
    {
        public static ReseauRoutier reseau;
        public static string nomLieuFinal;
    //    private RouteNode referent;  // lien entre un noeud de recherche et un noeud dans le reseau routier
        
        public NodeRecherche ( string nom ) : base(nom)
        {
            //recup LE noeud du reseau qui a le meme nom que this
       //    foreach(RouteNode rn in RouteNode.Reseau.GetNodes())
       //     {
       //         if (rn.GetName() == Name)
        //            referent = rn;
         //   }
        }

    /*    public RouteNode GetReferent()
        {
            return referent;
        }
        */
        //recupère la valeur pour la clef correspondant à N2
        public override double GetArcCost(GenericNode N2)
        {
            NodeRecherche n2 = N2 as NodeRecherche;
            RouteNode referent1 = reseau.GetNodes()[(Name[0]) - 65];
            RouteNode referent2 = reseau.GetNodes()[(n2.Name[0]) - 65];

            double cout = referent1.GetVoisins()[referent2];
            return cout;
            }
        public override bool EndState()
        {
            if (Name == nomLieuFinal)
                return true;
            else
                return false;
        }

        //crée un NodeRecherche pour chaque voisin du noeud dans le reseau 
        public override List<GenericNode> GetListSucc()
        {
            List<GenericNode> ListeSucc = new List<GenericNode>();
            RouteNode referent = reseau.GetNodes()[(Name[0]) - 65];
            //pour chaque voisin de ce noeud dans le reseau
            foreach (KeyValuePair<RouteNode,int> voisin in referent.GetVoisins())
            {
                //crée un noeud du meme nom
                NodeRecherche successeur = new NodeRecherche(voisin.Key.GetName());
                //et l'ajoute à la liste
                ListeSucc.Add(successeur);
            }
             return ListeSucc;
        }
        public override void CalculeHCost()
        {
            
        }
    }
}
