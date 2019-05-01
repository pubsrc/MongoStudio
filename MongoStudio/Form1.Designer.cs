namespace MongoStudio
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
            SynapticEffect.Forms.ToggleColumnHeader toggleColumnHeader1 = new SynapticEffect.Forms.ToggleColumnHeader();
            SynapticEffect.Forms.ToggleColumnHeader toggleColumnHeader2 = new SynapticEffect.Forms.ToggleColumnHeader();
            SynapticEffect.Forms.ToggleColumnHeader toggleColumnHeader3 = new SynapticEffect.Forms.ToggleColumnHeader();
            this.btnRun = new System.Windows.Forms.Button();
            this.txtQueryEditor = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.treeListViewOutput = new SynapticEffect.Forms.TreeListView();
            this.tabOutput = new System.Windows.Forms.TabControl();
            this.tabPageTree = new System.Windows.Forms.TabPage();
            this.tabPageRaw = new System.Windows.Forms.TabPage();
            this.lblExecutionTime = new System.Windows.Forms.Label();
            this.tabOutput.SuspendLayout();
            this.tabPageTree.SuspendLayout();
            this.tabPageRaw.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(847, 12);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(140, 31);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // txtQueryEditor
            // 
            this.txtQueryEditor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQueryEditor.Location = new System.Drawing.Point(12, 12);
            this.txtQueryEditor.Multiline = true;
            this.txtQueryEditor.Name = "txtQueryEditor";
            this.txtQueryEditor.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtQueryEditor.Size = new System.Drawing.Size(829, 100);
            this.txtQueryEditor.TabIndex = 1;
            this.txtQueryEditor.Text = "db.wellvmTest.find()";
            // 
            // txtOutput
            // 
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Location = new System.Drawing.Point(3, 3);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(940, 613);
            this.txtOutput.TabIndex = 2;
            // 
            // treeListViewOutput
            // 
            this.treeListViewOutput.BackColor = System.Drawing.SystemColors.Window;
            toggleColumnHeader1.Hovered = false;
            toggleColumnHeader1.Image = null;
            toggleColumnHeader1.Index = 0;
            toggleColumnHeader1.Pressed = false;
            toggleColumnHeader1.ScaleStyle = SynapticEffect.Forms.ColumnScaleStyle.Slide;
            toggleColumnHeader1.Selected = false;
            toggleColumnHeader1.Text = "Key";
            toggleColumnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            toggleColumnHeader1.Visible = true;
            toggleColumnHeader2.Hovered = false;
            toggleColumnHeader2.Image = null;
            toggleColumnHeader2.Index = 0;
            toggleColumnHeader2.Pressed = false;
            toggleColumnHeader2.ScaleStyle = SynapticEffect.Forms.ColumnScaleStyle.Slide;
            toggleColumnHeader2.Selected = false;
            toggleColumnHeader2.Text = "Value";
            toggleColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            toggleColumnHeader2.Visible = true;
            toggleColumnHeader3.Hovered = false;
            toggleColumnHeader3.Image = null;
            toggleColumnHeader3.Index = 0;
            toggleColumnHeader3.Pressed = false;
            toggleColumnHeader3.ScaleStyle = SynapticEffect.Forms.ColumnScaleStyle.Slide;
            toggleColumnHeader3.Selected = false;
            toggleColumnHeader3.Text = "Type";
            toggleColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            toggleColumnHeader3.Visible = true;
            this.treeListViewOutput.Columns.AddRange(new SynapticEffect.Forms.ToggleColumnHeader[] {
            toggleColumnHeader1,
            toggleColumnHeader2,
            toggleColumnHeader3});
            this.treeListViewOutput.ColumnSortColor = System.Drawing.Color.Gainsboro;
            this.treeListViewOutput.ColumnTrackColor = System.Drawing.Color.WhiteSmoke;
            this.treeListViewOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListViewOutput.GridLineColor = System.Drawing.Color.WhiteSmoke;
            this.treeListViewOutput.HeaderMenu = null;
            this.treeListViewOutput.ItemHeight = 20;
            this.treeListViewOutput.ItemMenu = null;
            this.treeListViewOutput.LabelEdit = false;
            this.treeListViewOutput.Location = new System.Drawing.Point(3, 3);
            this.treeListViewOutput.Name = "treeListViewOutput";
            this.treeListViewOutput.RowSelectColor = System.Drawing.SystemColors.Highlight;
            this.treeListViewOutput.RowTrackColor = System.Drawing.Color.WhiteSmoke;
            this.treeListViewOutput.Size = new System.Drawing.Size(940, 613);
            this.treeListViewOutput.SmallImageList = null;
            this.treeListViewOutput.StateImageList = null;
            this.treeListViewOutput.TabIndex = 3;
            this.treeListViewOutput.Text = "treeListView1";
            // 
            // tabOutput
            // 
            this.tabOutput.Controls.Add(this.tabPageTree);
            this.tabOutput.Controls.Add(this.tabPageRaw);
            this.tabOutput.Location = new System.Drawing.Point(22, 144);
            this.tabOutput.Name = "tabOutput";
            this.tabOutput.SelectedIndex = 0;
            this.tabOutput.Size = new System.Drawing.Size(954, 645);
            this.tabOutput.TabIndex = 4;
            // 
            // tabPageTree
            // 
            this.tabPageTree.Controls.Add(this.treeListViewOutput);
            this.tabPageTree.Location = new System.Drawing.Point(4, 22);
            this.tabPageTree.Name = "tabPageTree";
            this.tabPageTree.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTree.Size = new System.Drawing.Size(946, 619);
            this.tabPageTree.TabIndex = 0;
            this.tabPageTree.Text = "Tree";
            this.tabPageTree.UseVisualStyleBackColor = true;
            // 
            // tabPageRaw
            // 
            this.tabPageRaw.Controls.Add(this.txtOutput);
            this.tabPageRaw.Location = new System.Drawing.Point(4, 22);
            this.tabPageRaw.Name = "tabPageRaw";
            this.tabPageRaw.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRaw.Size = new System.Drawing.Size(946, 619);
            this.tabPageRaw.TabIndex = 1;
            this.tabPageRaw.Text = "Raw";
            this.tabPageRaw.UseVisualStyleBackColor = true;
            // 
            // lblExecutionTime
            // 
            this.lblExecutionTime.AutoSize = true;
            this.lblExecutionTime.Location = new System.Drawing.Point(13, 119);
            this.lblExecutionTime.Name = "lblExecutionTime";
            this.lblExecutionTime.Size = new System.Drawing.Size(0, 13);
            this.lblExecutionTime.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 801);
            this.Controls.Add(this.lblExecutionTime);
            this.Controls.Add(this.tabOutput);
            this.Controls.Add(this.txtQueryEditor);
            this.Controls.Add(this.btnRun);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabOutput.ResumeLayout(false);
            this.tabPageTree.ResumeLayout(false);
            this.tabPageRaw.ResumeLayout(false);
            this.tabPageRaw.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TextBox txtQueryEditor;
        private System.Windows.Forms.TextBox txtOutput;
        private SynapticEffect.Forms.TreeListView treeListViewOutput;
        private System.Windows.Forms.TabControl tabOutput;
        private System.Windows.Forms.TabPage tabPageTree;
        private System.Windows.Forms.TabPage tabPageRaw;
        private System.Windows.Forms.Label lblExecutionTime;
    }
}

