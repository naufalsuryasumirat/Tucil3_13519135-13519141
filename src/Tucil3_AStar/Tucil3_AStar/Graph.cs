using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tucil3_AStar
{
    public class Graph
    {
        private List<Node> nodes;
        private List<Tuple<string, string, double>> DrawInfo;
        public Graph()
        {
            this.nodes = new List<Node>();
            this.DrawInfo = new List<Tuple<string, string, double>>();
        }
        public Graph(List<Node> nodes)
        {
            this.nodes = nodes;
            this.DrawInfo = new List<Tuple<string, string, double>>();
        }
        public List<Node> getNodes()
        {
            return this.nodes;
        }
        public List<Tuple<string, string, double>> getDrawInfo()
        {
            return this.DrawInfo;
        }
        public void addConnection(int from, int to)
        {
            if ((from > this.nodes.Count || from < 0) || (to > this.nodes.Count || to < 0) || (from == to)) return;
            var t1 = new Tuple<string, string, double>(nodes[from].getName(), nodes[to].getName(), nodes[from].calcHaversine(nodes[to]));
            var t2 = new Tuple<string, string, double>(t1.Item2, t1.Item1, t1.Item3);
            if (!this.DrawInfo.Contains(t1) && !this.DrawInfo.Contains(t2)) { this.DrawInfo.Add(t1); }
            this.nodes[from].addConnection(this.nodes[to]);
        }
        public void addNode(Node node)
        {
            if (findNode(node.getName()) != null) return;
            this.nodes.Add(node);
            this.DrawInfo.Add(new Tuple<string, string, double>(node.getName(), null, 0.0));
        }
        public Node findNode(string name)
        {
            foreach (Node node in this.nodes)
            {
                if (node.getName() == name) return node;
            }
            return null;
        }
        public void printInfo()
        {
            foreach (Node node in this.nodes)
            {
                node.printInfo();
            }
        }
        public void printNames()
        {
            for (int i = 0; i < this.nodes.Count; i++)
            {
                Console.Write(this.nodes[i].getName());
                if (i == this.nodes.Count - 1) Console.WriteLine(".");
                else Console.Write(", ");
            }
        }
        public void printDrawInfo()
        {
            foreach (Tuple<string, string, double> tp in this.DrawInfo)
            {
                Console.WriteLine("(" + tp.Item1 + ", " + tp.Item2 + ", " + tp.Item3 + ")");
            }
        }
        public Tuple<List<string>, double, double> AStar(string from, string to)
        {
            Node GoalNode = findNode(to);
            Node InitialNode = findNode(from);
            if (InitialNode == null || GoalNode == null) return null; // Guard jika node tidak terdapat pada graf
            List<Tuple<List<Node>, double, double>> PQueue = new List<Tuple<List<Node>, double, double>>();
            // List<Path, distanceSoFar, cost> sort berdasarkan cost
            List<Node> first = new List<Node>();
            first.Add(InitialNode);
            PQueue.Add(new Tuple<List<Node>, double, double>(first, 0, 0));
            while (PQueue.Count > 0)
            {
                var Head = PQueue[0]; // Mengambil head dari PriorityQueue
                PQueue.RemoveAt(0); // Pop Head
                if (Head.Item1[Head.Item1.Count - 1].getName() == GoalNode.getName()) // Sampai tujuan
                {
                    List<string> toReturn = new List<string>();
                    foreach (var node in Head.Item1) { toReturn.Add(node.getName()); }
                    foreach (var test in PQueue) // TEST
                    {
                        Console.Write("Path\t: ");
                        foreach (var test2 in test.Item1)
                        {
                            Console.Write(test2.getName() + ", ");
                        }
                        Console.WriteLine();
                        Console.WriteLine("DSF\t: " + test.Item2);
                        Console.WriteLine("Cost\t: " + test.Item3);
                    }; // ends here
                    PQueue.Clear();
                    return new Tuple<List<string>, double, double>(toReturn, Head.Item2, Head.Item3);
                }
                else
                {
                    foreach (var tp in Head.Item1[Head.Item1.Count - 1].getNeighbors())
                    {
                        if (Head.Item1.Contains(tp.Item1)) continue; // Jika sudah terdapat node pada path, dilewatkan
                        List<Node> toAdd = new List<Node>(Head.Item1)
                        {
                            tp.Item1
                        };
                        PQueue.Add(new Tuple<List<Node>, double, double>(toAdd, Head.Item2 + tp.Item2, Head.Item2 + tp.Item2 + tp.Item1.calcHaversine(GoalNode)));
                    }
                    PQueue.Sort((x, y) => x.Item3.CompareTo(y.Item3));
                }
            }
            return null; // Tidak ditemukan path
        }
        public int findIndexWithCoor(double latitude, double longitude)
        {
            for (int i = 0; i < this.nodes.Count; i++)
            {
                if (nodes[i].getLatitude() == latitude && nodes[i].getLongitude() == longitude) return i;
            }
            return -1;
        }
    }
}
