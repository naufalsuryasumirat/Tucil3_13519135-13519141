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
        void AddUndirectedEdge(Microsoft.Msagl.Drawing.Graph graphs, string source, string target, double distance)
        {
            var Edge = graphs.AddEdge(source, target);
            Edge.Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.None;
            Edge.Attr.ArrowheadAtSource = Microsoft.Msagl.Drawing.ArrowStyle.None;
            Edge.Attr.Color = Microsoft.Msagl.Drawing.Color.Black;
            Edge.LabelText = distance.ToString();
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
        }
        void DrawGraph(Microsoft.Msagl.Drawing.Graph graphs, List<Tuple<string, string, double>> list)
        {
            foreach (var tuple in list)
            {
                AddUndirectedEdge(graphs, tuple.Item1, tuple.Item2, tuple.Item3);
                EditNodeNormal(graphs, tuple.Item1);
                EditNodeNormal(graphs, tuple.Item2);
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
            this.GDraw = null;
            this.OG = null;
            this.initialNode = null;
            this.goalNode = null;
            cmb_Account.Visible = false;
            cmb_Goal.Visible = false;
            gViewer1.ToolBarIsVisible = false;
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
    }
}