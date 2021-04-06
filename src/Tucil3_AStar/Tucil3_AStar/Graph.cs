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
        public Graph() // Default constructor dari Graph
        {
            this.nodes = new List<Node>();
            this.DrawInfo = new List<Tuple<string, string, double>>();
        }
        public Graph(List<Node> nodes) // User-defined constructor dari List<Node> yang sudah ada
        {
            this.nodes = nodes;
            this.DrawInfo = new List<Tuple<string, string, double>>();
        }
        public List<Node> getNodes() // Getter list Node yang terdapat pada Graph
        {
            return this.nodes;
        }
        public List<Tuple<string, string, double>> getDrawInfo() // Getter Info untuk menggambar Graph pada MSAGL viewer dan pada GoogleMaps
        {
            return this.DrawInfo;
        }
        public void addConnection(int from, int to) // Method menambah koneksi pada Node yang terdapat dalam graph (input indeks dua node pada graph)
        {
            if ((from > this.nodes.Count || from < 0) || (to > this.nodes.Count || to < 0) || (from == to)) return;
            var t1 = new Tuple<string, string, double>(nodes[from].getName(), nodes[to].getName(), nodes[from].calcHaversine(nodes[to]));
            var t2 = new Tuple<string, string, double>(t1.Item2, t1.Item1, t1.Item3);
            if (!this.DrawInfo.Contains(t1) && !this.DrawInfo.Contains(t2)) { this.DrawInfo.Add(t1); }
            this.nodes[from].addConnection(this.nodes[to]);
        }
        public void addNode(Node node) // Method menambah node pada graph
        {
            if (findNode(node.getName()) != null) return;
            this.nodes.Add(node);
            this.DrawInfo.Add(new Tuple<string, string, double>(node.getName(), null, 0.0));
        }
        public Node findNode(string name) // Method mencari Node berdasarkan nama node, null jika tidak ditemukan
        {
            foreach (Node node in this.nodes)
            {
                if (node.getName() == name) return node;
            }
            return null;
        }
        public void printInfo() // Menampilkan informasi mengenai Graph, untuk debugging
        {
            foreach (Node node in this.nodes)
            {
                node.printInfo();
            }
        }
        public void printNames() // Menampilkan nama node yang terdapat pada graph, untuk debugging
        {
            for (int i = 0; i < this.nodes.Count; i++)
            {
                Console.Write(this.nodes[i].getName());
                if (i == this.nodes.Count - 1) Console.WriteLine(".");
                else Console.Write(", ");
            }
        }
        public void printDrawInfo() // Menampilkan Info yang digunakan untuk digambar, untuk debugging
        {
            foreach (Tuple<string, string, double> tp in this.DrawInfo)
            {
                Console.WriteLine("(" + tp.Item1 + ", " + tp.Item2 + ", " + tp.Item3 + ")");
            }
        }
        // Algoritma AStar yang digunakan untuk mencari jalur terpendek antar dua node yang terdapat pada Graph
        // Menggunakan List of List of Nodes (merepresentasikan jalur) yang diurutkan dan diperilakukan seperti PriorityQueue berdasarkan cost
        // Yang dihitung/diperkirakan menggunakan F(n) heuristic evaluation function (jarak dari awal node ditambah dengan prediksi jarak ke node tujuan)
        // Prediksi jarak ke node tujuan menggunakan Formula Haversine untuk menghitung jarak antar dua koordinat (latitude dan longitude) di bumi
        // Bekerja dengan mengambil node terakhir dari list of nodes pada tuple dan meng-eksplore node tetangganya dan menambahkannya sebagai jalur pada PriorityQueue tersebut setelah dihitung cost perkiraannya
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
        public int findIndexWithCoor(double latitude, double longitude) // Method mencari index Node pada graph dengan input koordinat (latitutde, longitude), mengembalikan -1 jika tidak ditemukan
        {
            for (int i = 0; i < this.nodes.Count; i++)
            {
                if (nodes[i].getLatitude() == latitude && nodes[i].getLongitude() == longitude) return i;
            }
            return -1;
        }
    }
}