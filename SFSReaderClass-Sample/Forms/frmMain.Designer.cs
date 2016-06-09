namespace SFSReaderClass_Sample.Forms
{
    partial class frmMain
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
            this.btnLoadSFSFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSFSFileName = new System.Windows.Forms.Label();
            this.lblNumberOfLines = new System.Windows.Forms.Label();
            this.lblNumberOfNodes = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // btnLoadSFSFile
            // 
            this.btnLoadSFSFile.Location = new System.Drawing.Point(13, 13);
            this.btnLoadSFSFile.Name = "btnLoadSFSFile";
            this.btnLoadSFSFile.Size = new System.Drawing.Size(121, 34);
            this.btnLoadSFSFile.TabIndex = 0;
            this.btnLoadSFSFile.Text = "Load SFS FIle";
            this.btnLoadSFSFile.UseVisualStyleBackColor = true;
            this.btnLoadSFSFile.Click += new System.EventHandler(this.btnLoadSFSFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Using file";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Number of lines";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Number of nodes";
            // 
            // lblSFSFileName
            // 
            this.lblSFSFileName.AutoSize = true;
            this.lblSFSFileName.Location = new System.Drawing.Point(136, 54);
            this.lblSFSFileName.Name = "lblSFSFileName";
            this.lblSFSFileName.Size = new System.Drawing.Size(96, 17);
            this.lblSFSFileName.TabIndex = 4;
            this.lblSFSFileName.Text = "lblSFSFileName";
            // 
            // lblNumberOfLines
            // 
            this.lblNumberOfLines.AutoSize = true;
            this.lblNumberOfLines.Location = new System.Drawing.Point(136, 75);
            this.lblNumberOfLines.Name = "lblNumberOfLines";
            this.lblNumberOfLines.Size = new System.Drawing.Size(113, 17);
            this.lblNumberOfLines.TabIndex = 4;
            this.lblNumberOfLines.Text = "lblNumberOfLines";
            // 
            // lblNumberOfNodes
            // 
            this.lblNumberOfNodes.AutoSize = true;
            this.lblNumberOfNodes.Location = new System.Drawing.Point(136, 96);
            this.lblNumberOfNodes.Name = "lblNumberOfNodes";
            this.lblNumberOfNodes.Size = new System.Drawing.Size(121, 17);
            this.lblNumberOfNodes.TabIndex = 4;
            this.lblNumberOfNodes.Text = "lblNumberOfNodes";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 8);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(603, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(227, 49);
            this.button1.TabIndex = 6;
            this.button1.Text = "Load TreeView";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.treeView1.Location = new System.Drawing.Point(0, 130);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(830, 439);
            this.treeView1.TabIndex = 7;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 569);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblNumberOfNodes);
            this.Controls.Add(this.lblNumberOfLines);
            this.Controls.Add(this.lblSFSFileName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoadSFSFile);
            this.Name = "frmMain";
            this.Text = "SFS Reader Sample";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadSFSFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSFSFileName;
        private System.Windows.Forms.Label lblNumberOfLines;
        private System.Windows.Forms.Label lblNumberOfNodes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TreeView treeView1;
    }
}