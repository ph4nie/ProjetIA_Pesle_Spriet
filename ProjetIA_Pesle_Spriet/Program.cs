using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetIA_Pesle_Spriet
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
          
            // Création des noeuds du réseau routier de collecte de lait : 
            ReseauRoutier ResCollectLait = new ReseauRoutier(23);
            NodeRecherche.reseau = ResCollectLait;

            RouteNode A = new RouteNode("A",ResCollectLait);
            RouteNode B = new RouteNode("B",ResCollectLait);
            RouteNode C = new RouteNode("C",ResCollectLait);
            RouteNode D = new RouteNode("D",ResCollectLait);
            RouteNode E = new RouteNode("E",ResCollectLait);
            RouteNode F = new RouteNode("F",ResCollectLait);
            RouteNode G = new RouteNode("G",ResCollectLait);
            RouteNode H = new RouteNode("H",ResCollectLait);
            RouteNode I = new RouteNode("I",ResCollectLait);
            RouteNode J = new RouteNode("J",ResCollectLait);
            RouteNode K = new RouteNode("K",ResCollectLait);
            RouteNode L = new RouteNode("L",ResCollectLait);
            RouteNode M = new RouteNode("M",ResCollectLait);
            RouteNode N = new RouteNode("N",ResCollectLait);
            RouteNode O = new RouteNode("O",ResCollectLait);
            RouteNode P = new RouteNode("P",ResCollectLait);
            RouteNode Q = new RouteNode("Q",ResCollectLait);
            RouteNode R = new RouteNode("R",ResCollectLait);
            RouteNode S = new RouteNode("S",ResCollectLait);
            RouteNode T = new RouteNode("T",ResCollectLait);
            RouteNode U = new RouteNode("U",ResCollectLait);
            RouteNode V = new RouteNode("V",ResCollectLait);
            RouteNode W = new RouteNode("W",ResCollectLait);

            // Création des arcs entre les noeuds

            A.AddArc(B, 4);
            A.AddArc(C, 5);
            A.AddArc(D, 6);

            B.AddArc(E, 5);
            B.AddArc(A, 4);

            C.AddArc(D, 4);
            C.AddArc(E, 6);
            C.AddArc(G, 8);
            C.AddArc(A, 5);

            D.AddArc(F, 9);
            D.AddArc(A, 6);
            D.AddArc(C, 4);

            E.AddArc(H, 4);
            E.AddArc(C, 6);
            E.AddArc(B, 5);

            F.AddArc(D, 9);
            F.AddArc(L, 9);

            G.AddArc(H, 8);
            G.AddArc(K, 8);
            G.AddArc(C, 8);

            H.AddArc(I, 2);
            H.AddArc(E, 4);
            H.AddArc(G, 8);

            I.AddArc(J, 3);
            I.AddArc(K, 4);
            I.AddArc(H, 2);

            J.AddArc(I, 3);

            K.AddArc(W, 7);
            K.AddArc(I, 4);
            K.AddArc(G, 8);

            L.AddArc(M, 2);
            L.AddArc(F, 9);
            L.AddArc(N, 4);
            L.AddArc(Q, 7);
            L.AddArc(W, 10);

            M.AddArc(L, 2);

            N.AddArc(O, 7);
            N.AddArc(P, 3);
            N.AddArc(L, 4);

            O.AddArc(P, 3);
            O.AddArc(S, 8);
            O.AddArc(N, 7);

            P.AddArc(R, 5);
            P.AddArc(O, 3);
            P.AddArc(N, 3);

            Q.AddArc(R, 3);
            Q.AddArc(L, 7);

            R.AddArc(T, 6);
            R.AddArc(P, 5);
            R.AddArc(Q, 3);

            S.AddArc(U, 7);
            S.AddArc(O, 8);

            T.AddArc(U, 5);
            T.AddArc(R, 6);

            U.AddArc(V, 11);
            U.AddArc(S, 7);
            U.AddArc(T, 5);

            V.AddArc(W, 6);
            V.AddArc(U, 11);

            W.AddArc(V, 6);
            W.AddArc(L, 10);
            W.AddArc(K, 7);

            // création et affichage de la matrice d'adjacences du reseeau
            ResCollectLait.CreateAdjMatrix();
            ResCollectLait.AfficheMatrix();
            
            //Recherche des impasses du reseau
            List<RouteNode> impNoms;
            int nbImp = ResCollectLait.GetNbImpasses(out impNoms);

            //calcul du dictionnaire d'heuristiques (retours en A)
            ResCollectLait.calculeCoutsRetour();


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            Application.Run(new Form2());


            Console.WriteLine("##################################");
            Console.WriteLine("le reseau a {0} impasses, pour les noeuds : {1}",
                nbImp, String.Join(", ",impNoms));
            Console.WriteLine("##################################");

            
            List<GenericNode> chemin = new List<GenericNode>();
            string n1 = "G";
            string n2 = "F";
            double unCout = ResCollectLait.calculeMeilleurCout(n1, n2, out chemin);
            Console.WriteLine("meilleur cout de {0} à {1} : {2}",n1,n2, unCout.ToString());
            Console.WriteLine("en passant par : {0}", String.Join(", ", chemin));

            Console.WriteLine("##################################");
            string n3 = "B";
            //string n4 = "F";
            List<string> pointsPassage = new List<string>{n1,n2,n3 }; // "B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W"
            string cheminString;
            unCout = ResCollectLait.getItineraire(pointsPassage, out cheminString);
            Console.WriteLine("meilleur ordre de passage par {0} : {1}", String.Join(", ", pointsPassage),cheminString);
            Console.WriteLine("cout associé : {0}", unCout);

            Console.WriteLine("##################################");
            
        }
    }
}
