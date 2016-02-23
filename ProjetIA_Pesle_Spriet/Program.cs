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
            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());*/


            // Création des noeuds du réseau routier de collecte de lait : 
            ReseauRoutier ResCollectLait = new ReseauRoutier(23);

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

            A.SetGCost(0); //A est le noeud initial: chemin null

            A.AddArc(B, 4);
            A.AddArc(C, 5);
            A.AddArc(D, 6);

            B.AddArc(E, 5);

            C.AddArc(D, 4);
            C.AddArc(E, 6);
            C.AddArc(G, 8);

            D.AddArc(F, 9);

            E.AddArc(H, 4);

            F.AddArc(L, 9);

            G.AddArc(H, 8);
            G.AddArc(K, 8);

            H.AddArc(I, 2);

            I.AddArc(J, 3);
            I.AddArc(K, 4);

            K.AddArc(W, 7);

            L.AddArc(M, 2);
            L.AddArc(N, 4);
            L.AddArc(Q, 7);
            L.AddArc(W, 10);

            N.AddArc(O, 7);
            N.AddArc(P, 3);

            O.AddArc(P, 3);
            O.AddArc(S, 8);

            P.AddArc(R, 5);

            Q.AddArc(R, 3);

            R.AddArc(T, 6);

            S.AddArc(U, 7);

            T.AddArc(U, 5);

            U.AddArc(V, 11);

            V.AddArc(W, 6);

            ResCollectLait.CreateAdjMatrix();
            // ResCollectLait.AfficheMatrix();
            List<string> impNoms;
            int nbImp = ResCollectLait.GetNbImpasses(out impNoms);

            Console.WriteLine("le reseau a {0} impasses, pour les noeuds : {1}", nbImp, String.Join(", ",impNoms));

        }
    }
}
