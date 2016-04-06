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
        
        public NodeRecherche ( string nom ) : base(nom)
        {
            
        }

        //recupère la valeur pour la clef correspondant à N2
        public override double GetArcCost(GenericNode N2)
        {
            NodeRecherche n2 = N2 as NodeRecherche;
            RouteNode referent1 = reseau.GetNodes()[(Name[0]) - 65]; // conversion de l'indice [A;W] en code ASCII
            RouteNode referent2 = reseau.GetNodes()[(n2.Name[0]) - 65];

            double cout = referent1.GetVoisins()[referent2]; //recup la Value corresp à Key=referent2
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

        //renvoie le cout du + court chemin de this à noeudFinal
        public double calculeMeilleurCout(string noeudFinal, out List<GenericNode> chemin)
        {
           // NodeRecherche noeudInit = this; // new NodeRecherche(Name); // départ de this
            NodeRecherche.nomLieuFinal = noeudFinal; // retour à noeudFinal

            Graph graph = new Graph();

            //meilleur chemin de this à noeudFinal
            chemin = graph.RechercheSolutionAEtoile(this/*noeudInit*/);

            double cout = 0;
            NodeRecherche n1 = this;// noeudInit;
            NodeRecherche n2;

            //somme des couts intermédiaires
            foreach (GenericNode n in chemin)
            {
                n2 = n as NodeRecherche;
                if (n2 != n1)
                    cout += n1.GetArcCost(n2);
                n1 = n2;
            }

            return (cout);
        }

        // surcharge si pas besoin de recup le chemin
        public double calculeMeilleurCout(string noeudFinal)
        {
            List<GenericNode> chemin = new List<GenericNode>();
            return (calculeMeilleurCout(noeudFinal, out  chemin));

        }
        // estimation du cout restant pour atteindre noeud final = cout de retour à A
        public override void CalculeHCost()
        {            
            SetEstimation(calculeMeilleurCout("A"));
        }
    }
}
