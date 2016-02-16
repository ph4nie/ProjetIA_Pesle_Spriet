using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace copieProjet_VS10
{
    public class AdjMatrix
    {
        public Node Root;
        public List<Node> AllNodes = new List<Node>();

        public Node CreateRoot(string name)
        {
            Root = CreateNode(name);
            return Root;
        }

        public Node CreateNode(string name)
        {
            var n = new Node(name);
            AllNodes.Add(n);
            return n;
        }

        public void rempliValMatrix()
        {
            AdjMatrix graph = this;

            Node a = graph.CreateRoot("A");
            Node b = graph.CreateNode("B");
            Node c = graph.CreateNode("C");
            Node d = graph.CreateNode("D");
            Node e = graph.CreateNode("E");
            Node f = graph.CreateNode("F");
            Node g = graph.CreateNode("G");
            Node h = graph.CreateNode("H");
            Node i = graph.CreateNode("I");
            Node j = graph.CreateNode("J");
            Node k = graph.CreateNode("K");
            Node l = graph.CreateNode("L");
            Node m = graph.CreateNode("M");
            Node n = graph.CreateNode("N");
            Node o = graph.CreateNode("O");
            Node p = graph.CreateNode("P");
            Node q = graph.CreateNode("Q");
            Node r = graph.CreateNode("R");
            Node s = graph.CreateNode("S");
            Node t = graph.CreateNode("T");
            Node u = graph.CreateNode("U");
            Node v = graph.CreateNode("V");
            Node w = graph.CreateNode("W");

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

        }

        public int[,] CreateAdjMatrix() // creation de la matrice adjacente
        {
            int[,] adj = new int[AllNodes.Count, AllNodes.Count];

            for (int i = 0; i < AllNodes.Count; i++)
            {
                Node n1 = AllNodes[i];

                for (int j = 0; j < AllNodes.Count; j++)
                {
                    Node n2 = AllNodes[j];

                    var arc = n1.Arcs.FirstOrDefault(a => a.Child == n2);

                    if (arc != null)
                    {
                        adj[i, j] = arc.Weigth;
                    }
                }
            }
            return adj;
        }


    } 
}
