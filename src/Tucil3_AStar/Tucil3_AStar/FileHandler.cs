using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
            int lineCount = Convert.ToInt32(line); // konversi line pertama menjadi integer;
            Console.WriteLine(lineCount);
            for (int i = 0; i < lineCount; i++)
            {
                line = readFile.ReadLine();
                var arr = line.Split(new[] { ' ' });
                this.nodelist.Add(new Node(arr[0], new Tuple<double, double>(Convert.ToDouble(arr[1]), Convert.ToDouble(arr[2]))));
            }
            this.g = new Graph(this.nodelist);
            for (int i = 0; i < lineCount; i++)
            {
                line = readFile.ReadLine();
                var arr = line.Split(new[] { ' ' });
                for (int j = 0; j < arr.Length; j++)
                {
                    if (Convert.ToInt32(arr[j]) == 0) continue;
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

