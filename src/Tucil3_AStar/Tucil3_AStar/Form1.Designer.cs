﻿
namespace Tucil3_AStar
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation planeTransformation2 = new Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation();
            this.gViewer1 = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            this.pnl_SideMenu = new System.Windows.Forms.Panel();
            this.cmb_Goal = new System.Windows.Forms.ComboBox();
            this.btn_Goal = new System.Windows.Forms.Button();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.cmb_Account = new System.Windows.Forms.ComboBox();
            this.btn_Account = new System.Windows.Forms.Button();
            this.btn_Minimize = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.pnl_Logo = new System.Windows.Forms.Panel();
            this.lbl_Logo = new System.Windows.Forms.Label();
            this.pnl_Bottom = new System.Windows.Forms.Panel();
            this.btn_Pan = new System.Windows.Forms.Button();
            this.pnl_Main = new System.Windows.Forms.Panel();
            this.lbl_Content = new System.Windows.Forms.Label();
            this.pnl_Filename = new System.Windows.Forms.Panel();
            this.lbl_FileName = new System.Windows.Forms.Label();
            this.btn_FindPath = new System.Windows.Forms.Button();
            this.pnl_SideMenu.SuspendLayout();
            this.pnl_Logo.SuspendLayout();
            this.pnl_Bottom.SuspendLayout();
            this.pnl_Main.SuspendLayout();
            this.pnl_Filename.SuspendLayout();
            this.SuspendLayout();
            // 
            // gViewer1
            // 
            this.gViewer1.ArrowheadLength = 10D;
            this.gViewer1.AsyncLayout = false;
            this.gViewer1.AutoScroll = true;
            this.gViewer1.BackwardEnabled = false;
            this.gViewer1.BuildHitTree = true;
            this.gViewer1.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.MDS;
            this.gViewer1.Dock = System.Windows.Forms.DockStyle.Right;
            this.gViewer1.EdgeInsertButtonVisible = true;
            this.gViewer1.FileName = "";
            this.gViewer1.ForwardEnabled = false;
            this.gViewer1.Graph = null;
            this.gViewer1.InsertingEdge = false;
            this.gViewer1.LayoutAlgorithmSettingsButtonVisible = true;
            this.gViewer1.LayoutEditingEnabled = true;
            this.gViewer1.Location = new System.Drawing.Point(774, 66);
            this.gViewer1.LooseOffsetForRouting = 0.25D;
            this.gViewer1.MouseHitDistance = 0.05D;
            this.gViewer1.Name = "gViewer1";
            this.gViewer1.NavigationVisible = true;
            this.gViewer1.NeedToCalculateLayout = true;
            this.gViewer1.OffsetForRelaxingInRouting = 0.6D;
            this.gViewer1.PaddingForEdgeRouting = 8D;
            this.gViewer1.PanButtonPressed = false;
            this.gViewer1.SaveAsImageEnabled = true;
            this.gViewer1.SaveAsMsaglEnabled = true;
            this.gViewer1.SaveButtonVisible = true;
            this.gViewer1.SaveGraphButtonVisible = true;
            this.gViewer1.SaveInVectorFormatEnabled = true;
            this.gViewer1.Size = new System.Drawing.Size(930, 909);
            this.gViewer1.TabIndex = 1;
            this.gViewer1.TightOffsetForRouting = 0.125D;
            this.gViewer1.ToolBarIsVisible = true;
            this.gViewer1.Transform = planeTransformation2;
            this.gViewer1.UndoRedoButtonsVisible = true;
            this.gViewer1.WindowZoomButtonPressed = false;
            this.gViewer1.ZoomF = 1D;
            this.gViewer1.ZoomWindowThreshold = 0.05D;
            this.gViewer1.Load += new System.EventHandler(this.gViewer1_Load);
            // 
            // pnl_SideMenu
            // 
            this.pnl_SideMenu.AutoScroll = true;
            this.pnl_SideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(90)))));
            this.pnl_SideMenu.Controls.Add(this.btn_FindPath);
            this.pnl_SideMenu.Controls.Add(this.cmb_Goal);
            this.pnl_SideMenu.Controls.Add(this.btn_Goal);
            this.pnl_SideMenu.Controls.Add(this.btn_Reset);
            this.pnl_SideMenu.Controls.Add(this.cmb_Account);
            this.pnl_SideMenu.Controls.Add(this.btn_Account);
            this.pnl_SideMenu.Controls.Add(this.btn_Minimize);
            this.pnl_SideMenu.Controls.Add(this.btn_exit);
            this.pnl_SideMenu.Controls.Add(this.btn_Browse);
            this.pnl_SideMenu.Controls.Add(this.pnl_Logo);
            this.pnl_SideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_SideMenu.Location = new System.Drawing.Point(0, 0);
            this.pnl_SideMenu.Name = "pnl_SideMenu";
            this.pnl_SideMenu.Size = new System.Drawing.Size(200, 1041);
            this.pnl_SideMenu.TabIndex = 0;
            // 
            // cmb_Goal
            // 
            this.cmb_Goal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(114)))), ((int)(((byte)(164)))));
            this.cmb_Goal.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmb_Goal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_Goal.FormattingEnabled = true;
            this.cmb_Goal.Location = new System.Drawing.Point(0, 222);
            this.cmb_Goal.Name = "cmb_Goal";
            this.cmb_Goal.Size = new System.Drawing.Size(200, 21);
            this.cmb_Goal.TabIndex = 10;
            this.cmb_Goal.SelectedIndexChanged += new System.EventHandler(this.cmb_Goal_SelectedIndexChanged);
            // 
            // btn_Goal
            // 
            this.btn_Goal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(90)))));
            this.btn_Goal.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Goal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Goal.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Goal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(233)))), ((int)(((byte)(253)))));
            this.btn_Goal.Location = new System.Drawing.Point(0, 177);
            this.btn_Goal.Name = "btn_Goal";
            this.btn_Goal.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btn_Goal.Size = new System.Drawing.Size(200, 45);
            this.btn_Goal.TabIndex = 11;
            this.btn_Goal.Text = "Goal Node";
            this.btn_Goal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Goal.UseVisualStyleBackColor = false;
            this.btn_Goal.Click += new System.EventHandler(this.btn_Goal_Click);
            // 
            // btn_Reset
            // 
            this.btn_Reset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(140)))));
            this.btn_Reset.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Reset.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Reset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btn_Reset.Location = new System.Drawing.Point(0, 900);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(200, 40);
            this.btn_Reset.TabIndex = 9;
            this.btn_Reset.Text = "Reset";
            this.btn_Reset.UseVisualStyleBackColor = false;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // cmb_Account
            // 
            this.cmb_Account.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(114)))), ((int)(((byte)(164)))));
            this.cmb_Account.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmb_Account.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_Account.FormattingEnabled = true;
            this.cmb_Account.Location = new System.Drawing.Point(0, 156);
            this.cmb_Account.Name = "cmb_Account";
            this.cmb_Account.Size = new System.Drawing.Size(200, 21);
            this.cmb_Account.TabIndex = 4;
            this.cmb_Account.SelectedIndexChanged += new System.EventHandler(this.cmb_Account_SelectedIndexChanged);
            // 
            // btn_Account
            // 
            this.btn_Account.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(90)))));
            this.btn_Account.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Account.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Account.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Account.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(233)))), ((int)(((byte)(253)))));
            this.btn_Account.Location = new System.Drawing.Point(0, 111);
            this.btn_Account.Name = "btn_Account";
            this.btn_Account.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btn_Account.Size = new System.Drawing.Size(200, 45);
            this.btn_Account.TabIndex = 6;
            this.btn_Account.Text = "Start Node";
            this.btn_Account.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Account.UseVisualStyleBackColor = false;
            this.btn_Account.Click += new System.EventHandler(this.btn_Account_Click);
            // 
            // btn_Minimize
            // 
            this.btn_Minimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(250)))), ((int)(((byte)(123)))));
            this.btn_Minimize.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Minimize.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Minimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(114)))), ((int)(((byte)(164)))));
            this.btn_Minimize.Location = new System.Drawing.Point(0, 940);
            this.btn_Minimize.Name = "btn_Minimize";
            this.btn_Minimize.Size = new System.Drawing.Size(200, 35);
            this.btn_Minimize.TabIndex = 5;
            this.btn_Minimize.Text = "Minimize";
            this.btn_Minimize.UseVisualStyleBackColor = false;
            this.btn_Minimize.Click += new System.EventHandler(this.btn_Minimize_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btn_exit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(140)))));
            this.btn_exit.Location = new System.Drawing.Point(0, 975);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(200, 66);
            this.btn_exit.TabIndex = 3;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_Browse
            // 
            this.btn_Browse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(90)))));
            this.btn_Browse.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Browse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Browse.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Browse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(233)))), ((int)(((byte)(253)))));
            this.btn_Browse.Location = new System.Drawing.Point(0, 66);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btn_Browse.Size = new System.Drawing.Size(200, 45);
            this.btn_Browse.TabIndex = 2;
            this.btn_Browse.Text = "Browse";
            this.btn_Browse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Browse.UseVisualStyleBackColor = false;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // pnl_Logo
            // 
            this.pnl_Logo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(54)))));
            this.pnl_Logo.Controls.Add(this.lbl_Logo);
            this.pnl_Logo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Logo.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.pnl_Logo.Location = new System.Drawing.Point(0, 0);
            this.pnl_Logo.Name = "pnl_Logo";
            this.pnl_Logo.Size = new System.Drawing.Size(200, 66);
            this.pnl_Logo.TabIndex = 1;
            // 
            // lbl_Logo
            // 
            this.lbl_Logo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Logo.Font = new System.Drawing.Font("Bob Sponge", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Logo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(121)))), ((int)(((byte)(198)))));
            this.lbl_Logo.Location = new System.Drawing.Point(0, 0);
            this.lbl_Logo.Name = "lbl_Logo";
            this.lbl_Logo.Size = new System.Drawing.Size(200, 66);
            this.lbl_Logo.TabIndex = 0;
            this.lbl_Logo.Text = "A* Algo";
            this.lbl_Logo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnl_Bottom
            // 
            this.pnl_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(54)))));
            this.pnl_Bottom.Controls.Add(this.btn_Pan);
            this.pnl_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_Bottom.Location = new System.Drawing.Point(200, 975);
            this.pnl_Bottom.Name = "pnl_Bottom";
            this.pnl_Bottom.Size = new System.Drawing.Size(1704, 66);
            this.pnl_Bottom.TabIndex = 2;
            // 
            // btn_Pan
            // 
            this.btn_Pan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Pan.Font = new System.Drawing.Font("Bob Sponge", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Pan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(121)))), ((int)(((byte)(198)))));
            this.btn_Pan.Location = new System.Drawing.Point(790, 0);
            this.btn_Pan.Name = "btn_Pan";
            this.btn_Pan.Size = new System.Drawing.Size(100, 43);
            this.btn_Pan.TabIndex = 3;
            this.btn_Pan.Text = "Pan Mode";
            this.btn_Pan.UseVisualStyleBackColor = true;
            this.btn_Pan.Click += new System.EventHandler(this.btn_Pan_Click);
            // 
            // pnl_Main
            // 
            this.pnl_Main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(54)))));
            this.pnl_Main.Controls.Add(this.lbl_Content);
            this.pnl_Main.Controls.Add(this.gViewer1);
            this.pnl_Main.Controls.Add(this.pnl_Filename);
            this.pnl_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Main.Location = new System.Drawing.Point(200, 0);
            this.pnl_Main.Name = "pnl_Main";
            this.pnl_Main.Size = new System.Drawing.Size(1704, 975);
            this.pnl_Main.TabIndex = 3;
            // 
            // lbl_Content
            // 
            this.lbl_Content.Font = new System.Drawing.Font("LEMON MILK", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Content.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(121)))), ((int)(((byte)(198)))));
            this.lbl_Content.Location = new System.Drawing.Point(19, 83);
            this.lbl_Content.Name = "lbl_Content";
            this.lbl_Content.Size = new System.Drawing.Size(734, 864);
            this.lbl_Content.TabIndex = 2;
            // 
            // pnl_Filename
            // 
            this.pnl_Filename.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(90)))));
            this.pnl_Filename.Controls.Add(this.lbl_FileName);
            this.pnl_Filename.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Filename.Location = new System.Drawing.Point(0, 0);
            this.pnl_Filename.Name = "pnl_Filename";
            this.pnl_Filename.Size = new System.Drawing.Size(1704, 66);
            this.pnl_Filename.TabIndex = 0;
            // 
            // lbl_FileName
            // 
            this.lbl_FileName.Font = new System.Drawing.Font("LEMON MILK", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FileName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(121)))), ((int)(((byte)(198)))));
            this.lbl_FileName.Location = new System.Drawing.Point(19, 9);
            this.lbl_FileName.Name = "lbl_FileName";
            this.lbl_FileName.Size = new System.Drawing.Size(992, 45);
            this.lbl_FileName.TabIndex = 0;
            this.lbl_FileName.Text = "File Name: ";
            this.lbl_FileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_FindPath
            // 
            this.btn_FindPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(54)))));
            this.btn_FindPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_FindPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_FindPath.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_FindPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(121)))), ((int)(((byte)(198)))));
            this.btn_FindPath.Location = new System.Drawing.Point(0, 243);
            this.btn_FindPath.Name = "btn_FindPath";
            this.btn_FindPath.Size = new System.Drawing.Size(200, 54);
            this.btn_FindPath.TabIndex = 12;
            this.btn_FindPath.Text = "Find Path";
            this.btn_FindPath.UseVisualStyleBackColor = false;
            this.btn_FindPath.Click += new System.EventHandler(this.btn_FindPath_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.pnl_Main);
            this.Controls.Add(this.pnl_Bottom);
            this.Controls.Add(this.pnl_SideMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1080, 608);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnl_SideMenu.ResumeLayout(false);
            this.pnl_Logo.ResumeLayout(false);
            this.pnl_Bottom.ResumeLayout(false);
            this.pnl_Main.ResumeLayout(false);
            this.pnl_Filename.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Msagl.GraphViewerGdi.GViewer gViewer1;
        private System.Windows.Forms.Panel pnl_SideMenu;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.Panel pnl_Logo;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Panel pnl_Bottom;
        private System.Windows.Forms.Label lbl_Logo;
        private System.Windows.Forms.Panel pnl_Main;
        private System.Windows.Forms.Panel pnl_Filename;
        private System.Windows.Forms.ComboBox cmb_Account;
        private System.Windows.Forms.Button btn_Minimize;
        private System.Windows.Forms.Button btn_Account;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Label lbl_FileName;
        private System.Windows.Forms.Label lbl_Content;
        private System.Windows.Forms.Button btn_Pan;
        private System.Windows.Forms.ComboBox cmb_Goal;
        private System.Windows.Forms.Button btn_Goal;
        private System.Windows.Forms.Button btn_FindPath;
    }
}

