using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Tucil3_AStar
{
    public class FileHandler
    {
        private List<Node> nodelist;
        private Graph g;
        public FileHandler()
        {
            this.g = new Graph();
            this.nodelist = new List<Node>();
        }
        public FileHandler(string path)
        {
            this.nodelist = new List<Node>();
            Console.WriteLine("READING FROM FILE"); // pendanda reading file
            string line;
            var readFile = new StreamReader(path);
            line = readFile.ReadLine();
            int lineCount = int.Parse(line); // konversi line pertama menjadi integer;
            Console.WriteLine(lineCount);
            readFile.ReadLine();
            for (int i = 0; i < lineCount; i++)
            {
                line = readFile.ReadLine();
                var arr = line.Split(new[] { ' ' });
                double latitude = double.Parse(arr[1], CultureInfo.InvariantCulture);
                double longitude = double.Parse(arr[2], CultureInfo.InvariantCulture);
                this.nodelist.Add(new Node(arr[0], new Tuple<double, double>(latitude, longitude)));
            }
            readFile.ReadLine();
            this.g = new Graph(this.nodelist);
            for (int i = 0; i < lineCount; i++)
            {
                line = readFile.ReadLine();
                var arr = line.Split(new[] { ' ' });
                for (int j = 0; j < arr.Length; j++)
                {
                    if (int.Parse(arr[j]) == 0) continue;
                    else g.addConnection(i, j);
                }
            }
            readFile.Close();
        }
        public Graph getGraph()
        {
            return this.g;
        }
    }
}