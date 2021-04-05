using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tucil3_AStar
{
    public partial class Form1 : Form
    {
        class ItemCombo // Kelas untuk form pilihan akun/find friend
        {
            public ItemCombo() { }
            public string Value { set; get; }
            public string Text { set; get; }
            public override string ToString()
            {
                return Value;
            }
        }
        private Graph OG;
        private Microsoft.Msagl.Drawing.Graph GDraw;
        private string initialNode; // Node awal pencarian jalur
        private string goalNode; // Node yang dituju pencarian jalur
        private List<ItemCombo> startList; // List akun untuk pilihan Initial Node saat ini
        private List<ItemCombo> goalList; // List akun untuk pilihan Goal Node saat ini
        private List<Tuple<double, double>> markerList; // Maksimal berisi dua untuk menambahkan koneksi antar dua node pada Google Maps
        private List<Tuple<double, double>> pathList; // Maksimal berisi dua untuk mencari jalur terpendek antar dua node pada Google Maps
        private bool mapOnly;
        private int nodeMapCount;
        void AddUndirectedEdge(Microsoft.Msagl.Drawing.Graph graphs, string source, string target, double distance)
        {
            var Edge = graphs.AddEdge(source, target);
            Edge.Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.None;
            Edge.Attr.ArrowheadAtSource = Microsoft.Msagl.Drawing.ArrowStyle.None;
            Edge.Attr.Color = Microsoft.Msagl.Drawing.Color.Black;
            Edge.LabelText = distance.ToString();
        }
        void AddNode(Microsoft.Msagl.Drawing.Graph graphs, string name, string color, string shape) // Menambahkan Node baru pada Graph MSAGL jika belum terdapat
        {
            graphs.AddNode(name);
            var Node = graphs.FindNode(name);
            if (color.ToLower() == "blue")
            {
                Node.Attr.FillColor = Microsoft.Msagl.Drawing.Color.SkyBlue;
            }
            else if (color.ToLower() == "yellow")
            {
                Node.Attr.FillColor = Microsoft.Msagl.Drawing.Color.LightYellow;
            }
            else if (color.ToLower() == "red")
            {
                Node.Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
            }
            else
            {
                Node.Attr.FillColor = Microsoft.Msagl.Drawing.Color.White;
            }
            if (shape.ToLower() == "diamond")
            {
                Node.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Diamond;
            }
            else if (shape.ToLower() == "dcircle")
            {
                Node.Attr.Shape = Microsoft.Msagl.Drawing.Shape.DoubleCircle;
            }
            else if (shape.ToLower() == "box")
            {
                Node.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Box;
            }
            else
            {
                Node.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Circle;
            }
        }
        void AddDirectedEdge(Microsoft.Msagl.Drawing.Graph graphs, string source, string target) // Menggambarkan jalur / edge berarah, diperlukan pencarian path
        {
            var Edge = graphs.AddEdge(source, target);
            Edge.Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.Normal;
            Edge.Attr.ArrowheadAtSource = Microsoft.Msagl.Drawing.ArrowStyle.None;
            Edge.Attr.Color = Microsoft.Msagl.Drawing.Color.Blue;
        }
        void EditNodePath(Microsoft.Msagl.Drawing.Graph graphs, string name) // Mengubah atribut sebuah simpul untuk menunjukkan jalur
        {
            Microsoft.Msagl.Drawing.Node find = graphs.FindNode(name);
            find.Attr.FillColor = Microsoft.Msagl.Drawing.Color.Yellow;
            find.Attr.Shape = Microsoft.Msagl.Drawing.Shape.DoubleCircle;
        }
        void EditNodeNormal(Microsoft.Msagl.Drawing.Graph graphs, string name) // Mengubah atribut sebuah simpul untuk menjadi simpul normal
        {
            Microsoft.Msagl.Drawing.Node find = graphs.FindNode(name);
            find.Attr.FillColor = Microsoft.Msagl.Drawing.Color.White;
            find.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Circle;
        }
        void EditNodeAccount(Microsoft.Msagl.Drawing.Graph graphs, string name) // Mengubah atribut sebuah simpul untuk menunjukkan pilihan node saat ini
        {
            Microsoft.Msagl.Drawing.Node find = graphs.FindNode(name);
            find.Attr.FillColor = Microsoft.Msagl.Drawing.Color.Yellow;
            find.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Circle;
        }
        void EditNodeFind(Microsoft.Msagl.Drawing.Graph graphs, string name) // Mengubah atribut sebuah simpul untuk menunjukkan simpul tujuan
        {
            Microsoft.Msagl.Drawing.Node find = graphs.FindNode(name);
            find.Attr.FillColor = Microsoft.Msagl.Drawing.Color.Red;
            find.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Circle;
        }
        void Wait(int ms) // Timer / Wait untuk animasi pencarian jalur // Pastikan terdapat path terlebih dahulu untuk parameter
        {
            var timer = new System.Windows.Forms.Timer();
            if (ms <= 0) return;
            timer.Interval = ms;
            timer.Enabled = true;
            timer.Start();

            timer.Tick += (s, e) =>
            {
                timer.Enabled = false;
                timer.Stop();
            };

            while (timer.Enabled == true)
            {
                Application.DoEvents();
            }
        }
        void AnimatePath(Microsoft.Msagl.Drawing.Graph graphs, List<string> list, Microsoft.Msagl.GraphViewerGdi.GViewer gdi) // Menganimasikan pencarian jalur terpendek
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                AddDirectedEdge(graphs, list[i], list[i + 1]);
                EditNodePath(graphs, list[i]);
                if (i == list.Count - 2)
                {
                    EditNodePath(graphs, list[i + 1]);
                }
                gdi.Graph = graphs;

                Wait(1500); // menunggu 1.5 detik
            }
            // Menggambar pada Google Maps
            List<GMap.NET.PointLatLng> listPoints = new List<GMap.NET.PointLatLng>();
            // Memperlihatkan pada GMap
            foreach (string str in list)
            {
                Node find = this.OG.findNode(str);
                listPoints.Add(new GMap.NET.PointLatLng(find.getLatitude(), find.getLongitude()));
            }
            GMap.NET.WindowsForms.GMapOverlay routeOverlay = new GMap.NET.WindowsForms.GMapOverlay("routeOverlay");
            GMap.NET.WindowsForms.GMapRoute routeAdd = new GMap.NET.WindowsForms.GMapRoute(listPoints, "");
            routeAdd.Stroke = new Pen(Color.Red, 4);
            routeOverlay.Routes.Add(routeAdd);
            gMap.Overlays.Add(routeOverlay);
            gMap.Zoom -= 1; // Reset agar tampilan Gmaps benar
            gMap.Zoom += 1;
        }
        void DrawGraph(Microsoft.Msagl.Drawing.Graph graphs, List<Tuple<string, string, double>> list)
        {
            foreach (var tuple in list)
            {
                if (tuple.Item2 == null) { AddNode(graphs, tuple.Item1, "white", "circle"); continue; }
                AddUndirectedEdge(graphs, tuple.Item1, tuple.Item2, tuple.Item3);
                EditNodeNormal(graphs, tuple.Item1);
                EditNodeNormal(graphs, tuple.Item2);
                Node from = OG.findNode(tuple.Item1);
                Node to = OG.findNode(tuple.Item2);
                List<GMap.NET.PointLatLng> listPoints = new List<GMap.NET.PointLatLng>();
                listPoints.Add(new GMap.NET.PointLatLng(from.getLatitude(), from.getLongitude()));
                listPoints.Add(new GMap.NET.PointLatLng(to.getLatitude(), to.getLongitude()));
                GMap.NET.WindowsForms.GMapOverlay routeOverlay = new GMap.NET.WindowsForms.GMapOverlay("routeOverlay");
                GMap.NET.WindowsForms.GMapRoute routeAdd = new GMap.NET.WindowsForms.GMapRoute(listPoints, "");
                routeAdd.Stroke = new Pen(Color.Blue, 3);
                routeOverlay.Routes.Add(routeAdd);
                gMap.Overlays.Add(routeOverlay);
            }
        }
        void InitializeComboItems(List<ItemCombo> list1, List<ItemCombo> list2, Graph graph)
        {
            foreach (var node in graph.getNodes())
            {
                list1.Add(new ItemCombo() { Text = node.getName(), Value = node.getName() });
                list2.Add(new ItemCombo() { Text = node.getName(), Value = node.getName() });
            }
            cmb_Account.DataSource = list1;
            cmb_Account.DisplayMember = "Text";
            cmb_Account.ValueMember = "Value";

            cmb_Goal.DataSource = list2;
            cmb_Goal.DisplayMember = "Text";
            cmb_Goal.ValueMember = "Value";
        }
        public Form1() // Konstruktor form (Menginisialisasikan tiap atribut dengan null, dan beberapa komponen tidak dapat dilihat terlebih dahulu pada form)
        {
            InitializeComponent();
            this.GDraw = new Microsoft.Msagl.Drawing.Graph("graph");
            this.OG = new Graph();
            this.initialNode = null;
            this.goalNode = null;
            cmb_Account.Visible = false;
            cmb_Goal.Visible = false;
            gViewer1.ToolBarIsVisible = false;
            this.mapOnly = false;
            this.markerList = new List<Tuple<double, double>>();
            this.pathList = new List<Tuple<double, double>>();
        }

        private void gViewer1_Load(object sender, EventArgs e)
        {

        }

        private void btn_Browse_Click(object sender, EventArgs e) // Event btn_Browse di klik (Browse files) dan menggambarkan graph setelah berhasil di load file
        {
            var result = new System.Windows.Forms.OpenFileDialog();
            if (result.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileToOpen = result.FileName;
                this.GDraw = new Microsoft.Msagl.Drawing.Graph("graph");
                FileHandler f = new FileHandler(fileToOpen);
                // this.OG = new Classes.Graph(fileToOpen);
                this.OG = f.getGraph();
                DrawGraph(this.GDraw, OG.getDrawInfo());
                gViewer1.Graph = this.GDraw;
                gViewer1.OutsideAreaBrush = Brushes.White;
                gViewer1.ToolBarIsVisible = false;
                this.initialNode = null;
                this.goalNode = null;
                lbl_FileName.Text = "File Name: " + System.IO.Path.GetFileName(fileToOpen);

                // Initialize dropdown menu
                startList = new List<ItemCombo>();
                goalList = new List<ItemCombo>();
                InitializeComboItems(startList, goalList, OG);

                // Setting up Google Maps
                GMap.NET.WindowsForms.GMapOverlay mapOverlay = new GMap.NET.WindowsForms.GMapOverlay("mapOverlay");
                foreach (var node in OG.getNodes())
                {
                    GMap.NET.PointLatLng Point = new GMap.NET.PointLatLng(node.getLatitude(), node.getLongitude());
                    GMap.NET.WindowsForms.GMapMarker mapMarker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(Point, GMap.NET.WindowsForms.Markers.GMarkerGoogleType.orange_small);
                    mapOverlay.Markers.Add(mapMarker);
                }
                gMap.Overlays.Add(mapOverlay);
                gMap.Position = new GMap.NET.PointLatLng(OG.getNodes()[0].getLatitude(), OG.getNodes()[0].getLongitude());
            }
        }

        private void btn_exit_Click(object sender, EventArgs e) // Event btn_exit di klik (Exit) dan menghentikan program
        {
            this.Close();
        }

        private void btn_Minimize_Click(object sender, EventArgs e) // Event btn_Minimize di klik dan me-minimize window program
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void cmb_Account_SelectedIndexChanged(object sender, EventArgs e) // Event memilih pada pilihan initialNode
        {
            if (initialNode != null)
            {
                EditNodeNormal(this.GDraw, this.initialNode);
                gViewer1.Graph = GDraw;
            }
            this.initialNode = cmb_Account.SelectedValue.ToString();
            EditNodeAccount(this.GDraw, this.initialNode);
            gViewer1.Graph = GDraw;
        }

        private void btn_Account_Click(object sender, EventArgs e) // Event btn_Account di klik, memperlihatkan/menutup pilihan initialNode
        {
            cmb_Account.Visible = !cmb_Account.Visible;
        }

        private void btn_Reset_Click(object sender, EventArgs e) // Reset graph untuk menghilangkan path sebelumnya (mengembalikan ke state awal di load)
        {
            if (this.OG == null || this.GDraw == null) return;
            this.GDraw = new Microsoft.Msagl.Drawing.Graph("graph");
            DrawGraph(this.GDraw, OG.getDrawInfo());
            gViewer1.Graph = this.GDraw;
            gViewer1.OutsideAreaBrush = Brushes.White;
            gViewer1.ToolBarIsVisible = false;
            this.initialNode = null;
            this.goalNode = null;
            lbl_Content.Text = "";
        }

        private void btn_Pan_Click(object sender, EventArgs e)
        {
            gViewer1.PanButtonPressed = !(gViewer1.PanButtonPressed);
            if (gViewer1.PanButtonPressed) { btn_Pan.ForeColor = Color.FromArgb(255, 68, 71, 90); btn_Pan.BackColor = Color.FromArgb(255, 255, 121, 198); }
            else { btn_Pan.ForeColor = Color.FromArgb(255, 255, 121, 198); btn_Pan.BackColor = Color.FromArgb(255, 40, 42, 54); }
        }

        private void btn_Goal_Click(object sender, EventArgs e)
        {
            cmb_Goal.Visible = !cmb_Goal.Visible;
        }

        private void cmb_Goal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (goalNode != null)
            {
                EditNodeNormal(this.GDraw, this.goalNode);
                gViewer1.Graph = GDraw;
            }
            this.goalNode = cmb_Goal.SelectedValue.ToString();
            EditNodeFind(this.GDraw, this.goalNode);
            gViewer1.Graph = GDraw;
        }

        private void btn_FindPath_Click(object sender, EventArgs e)
        {
            if (initialNode == null || goalNode == null) return;
            var Result = OG.AStar(initialNode, goalNode);
            if (Result == null) { lbl_Content.Text = "Tidak terdapat jalur"; return; }
            AnimatePath(this.GDraw, Result.Item1, this.gViewer1);
            lbl_Content.Text = "Penelusuran dengan Algoritma A*\n";
            for (int i = 0; i < Result.Item1.Count; i++)
            {
                lbl_Content.Text += Result.Item1[i];
                if (i == Result.Item1.Count - 1) lbl_Content.Text += ".\n";
                else lbl_Content.Text += " → ";
            }
            lbl_Content.Text += ("Distance: " + Result.Item2 + "\n");
        }

        private void gMap_Load(object sender, EventArgs e)
        {
            gMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            // gMap.SetPositionByKeywords("Jakarta");
            gMap.MinZoom = 2;
            gMap.MaxZoom = 20;
            gMap.Zoom = 14;
            gMap.ShowCenter = false;
            gMap.Position = new GMap.NET.PointLatLng(-6.91998366420654, 107.60658682292411);
            gMap.MarkersEnabled = true;
            gMap.RoutesEnabled = true;
            gMap.DragButton = MouseButtons.Left;
            gMap.MouseClick += new MouseEventHandler(gMap_MouseClick);
        }
        private void gMap_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            { 
                double latitude = gMap.FromLocalToLatLng(e.X, e.Y).Lat;
                double longitude = gMap.FromLocalToLatLng(e.X, e.Y).Lng;
                var Point = new GMap.NET.PointLatLng(latitude, longitude);
                lbl_Content.Text = "Marker Added with Coordinates:\n";
                lbl_Content.Text += "Latitude\t: " + latitude + "\n"; // TEST
                lbl_Content.Text += "Longitude\t: " + longitude + "\n"; // TEST
                GMap.NET.WindowsForms.GMapOverlay mapOverlay = new GMap.NET.WindowsForms.GMapOverlay("mapOverlay");
                GMap.NET.WindowsForms.GMapMarker mapMarker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(Point, GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red);
                mapOverlay.Markers.Add(mapMarker);
                gMap.Overlays.Add(mapOverlay);
                gMap.Zoom -= 1;
                gMap.Zoom += 1;
                string newNodeName = ("node" + this.nodeMapCount);
                this.nodeMapCount++;
                this.OG.addNode(new Node(newNodeName, new Tuple<double, double>(Point.Lat, Point.Lng)));
                this.GDraw = new Microsoft.Msagl.Drawing.Graph("graph");
                DrawGraph(this.GDraw, OG.getDrawInfo());
                gViewer1.Graph = this.GDraw;
                gViewer1.OutsideAreaBrush = Brushes.White;
                this.startList = new List<ItemCombo>();
                this.goalList = new List<ItemCombo>();
                InitializeComboItems(this.startList, this.goalList, this.OG);
            }
        }
        private void btn_MapOnly_Click(object sender, EventArgs e)
        {
            btn_Browse.Enabled = !btn_Browse.Enabled;
            this.mapOnly = !this.mapOnly;
            if (mapOnly) { btn_MapOnly.ForeColor = Color.FromArgb(255, 68, 71, 90); btn_MapOnly.BackColor = Color.FromArgb(255, 255, 121, 198); }
            else { btn_MapOnly.ForeColor = Color.FromArgb(255, 255, 121, 198); btn_MapOnly.BackColor = Color.FromArgb(255, 40, 42, 54); }
            this.OG = new Graph();
            this.initialNode = null;
            this.goalNode = null;
            if (startList != null) this.startList.Clear();
            if (goalList != null) this.goalList.Clear();
            gMap.Overlays.Clear();
            this.GDraw = new Microsoft.Msagl.Drawing.Graph("graph");
            gViewer1.Graph = this.GDraw;
            gViewer1.OutsideAreaBrush = Brushes.White;
            gViewer1.ToolBarIsVisible = false;
            this.initialNode = null;
            this.goalNode = null;
            lbl_Content.Text = "";
            this.nodeMapCount = 0;
            this.markerList.Clear();
            this.pathList.Clear();
            gMap.Zoom -= 1;
            gMap.Zoom += 1;
        }

        private void gMap_OnMarkerDoubleClick(GMap.NET.WindowsForms.GMapMarker item, MouseEventArgs e)
        {
            if (this.markerList.Count < 1)
            {
                var add = new Tuple<double, double>(item.Position.Lat, item.Position.Lng);
                if (!this.markerList.Contains(add)) this.markerList.Add(add);
            }
            else
            {
                var add = new Tuple<double, double>(item.Position.Lat, item.Position.Lng);
                if (!this.markerList.Contains(add)) this.markerList.Add(add);
                else return;
                this.OG.addConnection(OG.findIndexWithCoor(markerList[0].Item1, markerList[0].Item2), OG.findIndexWithCoor(markerList[1].Item1, markerList[1].Item2));
                this.GDraw = new Microsoft.Msagl.Drawing.Graph("graph");
                DrawGraph(this.GDraw, OG.getDrawInfo());
                gViewer1.Graph = this.GDraw;
                List<GMap.NET.PointLatLng> listPoints = new List<GMap.NET.PointLatLng>();
                listPoints.Add(new GMap.NET.PointLatLng(markerList[0].Item1, markerList[0].Item2));
                listPoints.Add(new GMap.NET.PointLatLng(markerList[1].Item1, markerList[1].Item2));
                GMap.NET.WindowsForms.GMapOverlay routeOverlay = new GMap.NET.WindowsForms.GMapOverlay("routeOverlay");
                GMap.NET.WindowsForms.GMapRoute routeAdd = new GMap.NET.WindowsForms.GMapRoute(listPoints, "");
                routeAdd.Stroke = new Pen(Color.Blue, 3);
                routeOverlay.Routes.Add(routeAdd);
                gMap.Overlays.Add(routeOverlay);
                gMap.Zoom -= 1;
                gMap.Zoom += 1;
                this.markerList.Clear();
            }
        }

        private void gMap_OnMarkerClick(GMap.NET.WindowsForms.GMapMarker item, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Middle) return;
            if (pathList.Count < 1)
            {
                var add = new Tuple<double, double>(item.Position.Lat, item.Position.Lng);
                if (!this.pathList.Contains(add)) this.pathList.Add(add);
            }
            else
            {
                var add = new Tuple<double, double>(item.Position.Lat, item.Position.Lng);
                if (!this.pathList.Contains(add)) this.pathList.Add(add);
                else return;
                Node Initial = this.OG.getNodes()[OG.findIndexWithCoor(pathList[0].Item1, pathList[0].Item2)];
                Node Goal = this.OG.getNodes()[OG.findIndexWithCoor(pathList[1].Item1, pathList[1].Item2)];
                var Result = this.OG.AStar(Initial.getName(), Goal.getName());
                if (Result == null) { lbl_Content.Text = "Tidak terdapat jalur"; return; }
                AnimatePath(this.GDraw, Result.Item1, this.gViewer1);
                lbl_Content.Text = "Penelusuran dengan Algoritma A*\n";
                for (int i = 0; i < Result.Item1.Count; i++)
                {
                    lbl_Content.Text += Result.Item1[i];
                    if (i == Result.Item1.Count - 1) lbl_Content.Text += ".\n";
                    else lbl_Content.Text += " → ";
                }
                lbl_Content.Text += ("Distance: " + Result.Item2 + "\n");
                pathList.Clear();
            }
        }
    }
}