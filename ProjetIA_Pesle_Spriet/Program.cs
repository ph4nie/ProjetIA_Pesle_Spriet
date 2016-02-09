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

            var graph = new AdjMatrix();

            var a = graph.CreateRoot("A");
            var b = graph.CreateNode("B");
            var c = graph.CreateNode("C");
            var d = graph.CreateNode("D");
            var e = graph.CreateNode("E");
            var f = graph.CreateNode("F");
            var g = graph.CreateNode("G");
            var h = graph.CreateNode("H");
            var i = graph.CreateNode("I");
            var j = graph.CreateNode("J");
            var k = graph.CreateNode("K");
            var l = graph.CreateNode("L");
            var m = graph.CreateNode("M");
            var n = graph.CreateNode("N");
            var o = graph.CreateNode("O");
            var p = graph.CreateNode("P");
            var q = graph.CreateNode("Q");
            var r = graph.CreateNode("R");
            var s = graph.CreateNode("S");
            var t = graph.CreateNode("T");
            var u = graph.CreateNode("U");
            var v = graph.CreateNode("V");
            var w = graph.CreateNode("W");

            a.AddArc(b, 4)
             .AddArc(c, 5)
             .AddArc(d, 6);

            b.AddArc(e, 5);

            c.AddArc(d, 4)
             .AddArc(e, 6)
             .AddArc(g, 8);

            d.AddArc(f, 9);

            e.AddArc(h, 4);

            f.AddArc(l, 9);

            g.AddArc(h, 8)
             .AddArc(k, 8);

            h.AddArc(i, 2);

            i.AddArc(j, 3)
             .AddArc(k, 4);

            k.AddArc(w, 7);

            l.AddArc(m, 2)
             .AddArc(n, 4)
             .AddArc(q, 7)
             .AddArc(w, 10);

            n.AddArc(o, 7)
             .AddArc(p, 3);

            o.AddArc(p, 3)
             .AddArc(s, 8);

            p.AddArc(r, 5);

            q.AddArc(r, 3);

            r.AddArc(t, 6);

            s.AddArc(u, 7);

            t.AddArc(u, 5);

            u.AddArc(v, 11);

            v.AddArc(w, 6);

            int?[,] adj = graph.CreateAdjMatrix();
            graph.AfficherMatrix(ref adj, graph.AllNodes.Count);

        }
    }
}
