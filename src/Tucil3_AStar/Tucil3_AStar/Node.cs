using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tucil3_AStar
{
    public class Node
    {
        private string Name; // Identitas Node
        private Tuple<double, double> Coordinate; // Koordinat Node (Latitude, Longitude)
        private List<Tuple<Node, double>> CNodes; // List Tuple Node dengan jarak ke node tersebut (node tetangga)
        public Node() // Default constructor
        {
            this.Name = null;
            this.Coordinate = null;
            this.CNodes = null;
        }
        public Node(string name, Tuple<double, double> Coordinate) // User-defined constructor
        {
            this.Name = name;
            this.Coordinate = Coordinate;
            this.CNodes = new List<Tuple<Node, double>>();
        }
        public string getName() // Getter Name
        {
            return this.Name;
        }
        public List<Tuple<Node, double>> getNeighbors() // Getter node tetangga
        {
            return this.CNodes;
        }
        public Tuple<double, double> getCoordinate() // Getter koordinat
        {
            return this.Coordinate;
        }
        public double getLatitude() // Getter Latitude dari Tuple<double, double> (Bagian pertama dari tuple)
        {
            return this.Coordinate.Item1;
        }
        public double getLongitude() // Getter Longitude dari Tuple<double, double> (Bagian kedua dari tuple)
        {
            return this.Coordinate.Item2;
        }
        public void sortConnected() // Method untuk mengurutkan connected nodes, sort berdasarkan distance menaik
        {
            this.CNodes.Sort((x, y) => x.Item2.CompareTo(y.Item2));
        }
        public double calcHaversine(Node other) // Menghitung jarak Haversine antar dua node, jarak dalam meter
        {
            // Referensi: https://moveable-type.co.uk/scripts/latlong.html
            double radius = 6371000;
            double radLat1 = (Math.PI / 180) * getLatitude();
            double radLat2 = (Math.PI / 180) * other.getLatitude();
            double dLat = (Math.PI / 180) * (other.getLatitude() - getLatitude());
            double dLong = (Math.PI / 180) * (other.getLongitude() - getLongitude());
            double a = Math.Pow(Math.Sin(dLat / 2), 2) + Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(dLong / 2), 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double distance = radius * c;
            return Math.Round(distance, 2);
        }
        public void addConnection(Node other) // Menambah koneksi dengan Node lain
        {
            if (this.getName() == other.getName()) return; // Guard agar tidak menambah koneksi ke diri sendiri
            foreach (Tuple<Node, double> tp in this.CNodes)
            {
                if (tp.Item1.getName() == other.getName()) return; // Guard agar tidak menambah koneksi pada node yang sudah memiliki koneksi
            }
            double distance = this.calcHaversine(other);
            this.CNodes.Add(new Tuple<Node, double>(other, distance));
            other.CNodes.Add(new Tuple<Node, double>(this, distance));
            this.sortConnected();
            other.sortConnected();
        }
        public void printInfo() // Menampilkan informasi mengenai Node, untuk debugging
        {
            Console.WriteLine("Name\t: " + this.Name);
            Console.WriteLine("Coor\t: " + "(" + this.Coordinate.Item1 + ", " + this.Coordinate.Item2 + ")");
            Console.Write("CNodes\t: ");
            for (int i = 0; i < this.CNodes.Count; i++)
            {
                Console.Write("(" + this.CNodes[i].Item1.getName() + ", " + this.CNodes[i].Item2 + ")");
                if (i == this.CNodes.Count - 1) Console.WriteLine(".");
                else Console.Write(", ");
            }
            Console.Write("\n\n");
        }
    }
}

