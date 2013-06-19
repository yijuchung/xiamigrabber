namespace xiamigrabber
{
    partial class main
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
            this.options = new System.Windows.Forms.ComboBox();
            this.id = new System.Windows.Forms.TextBox();
            this.status = new System.Windows.Forms.StatusStrip();
            this.statuslabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressbar = new System.Windows.Forms.ToolStripProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.basedir = new System.Windows.Forms.TextBox();
            this.choosedir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.start = new System.Windows.Forms.Button();
            this.debugtext = new System.Windows.Forms.TextBox();
            this.id3 = new System.Windows.Forms.CheckBox();
            this.bw = new System.ComponentModel.BackgroundWorker();
            this.status.SuspendLayout();
            this.SuspendLayout();
            // 
            // options
            // 
            this.options.FormattingEnabled = true;
            this.options.Items.AddRange(new object[] {
            "album",
            "song",
            "playlist",
            "artist"});
            this.options.Location = new System.Drawing.Point(62, 13);
            this.options.Name = "options";
            this.options.Size = new System.Drawing.Size(121, 21);
            this.options.TabIndex = 0;
            this.options.Text = "album";
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(62, 40);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(100, 20);
            this.id.TabIndex = 1;
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statuslabel,
            this.progressbar});
            this.status.Location = new System.Drawing.Point(0, 254);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(519, 22);
            this.status.TabIndex = 3;
            // 
            // statuslabel
            // 
            this.statuslabel.Name = "statuslabel";
            this.statuslabel.Size = new System.Drawing.Size(63, 17);
            this.statuslabel.Text = "version 1.1";
            // 
            // progressbar
            // 
            this.progressbar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.progressbar.Name = "progressbar";
            this.progressbar.Size = new System.Drawing.Size(100, 16);
            this.progressbar.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(189, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "(artist will grab all studio albums belongs to the id)";
            // 
            // basedir
            // 
            this.basedir.Location = new System.Drawing.Point(12, 231);
            this.basedir.Name = "basedir";
            this.basedir.Size = new System.Drawing.Size(100, 20);
            this.basedir.TabIndex = 5;
            // 
            // choosedir
            // 
            this.choosedir.Location = new System.Drawing.Point(119, 228);
            this.choosedir.Name = "choosedir";
            this.choosedir.Size = new System.Drawing.Size(75, 23);
            this.choosedir.TabIndex = 6;
            this.choosedir.Text = "choose";
            this.choosedir.UseVisualStyleBackColor = true;
            this.choosedir.Click += new System.EventHandler(this.choosedir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "option :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(12, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "id :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(168, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(183, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "(the number shows up in the url)";
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(200, 228);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 10;
            this.start.Text = "start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // debugtext
            // 
            this.debugtext.Location = new System.Drawing.Point(15, 66);
            this.debugtext.Multiline = true;
            this.debugtext.Name = "debugtext";
            this.debugtext.Size = new System.Drawing.Size(492, 156);
            this.debugtext.TabIndex = 11;
            // 
            // id3
            // 
            this.id3.AutoSize = true;
            this.id3.Checked = true;
            this.id3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.id3.Location = new System.Drawing.Point(426, 231);
            this.id3.Name = "id3";
            this.id3.Size = new System.Drawing.Size(61, 17);
            this.id3.TabIndex = 12;
            this.id3.Text = "ID3 tag";
            this.id3.UseVisualStyleBackColor = true;
            // 
            // bw
            // 
            this.bw.WorkerReportsProgress = true;
            this.bw.WorkerSupportsCancellation = true;
            this.bw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.downloadWork);
            this.bw.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bw_ProgressChanged);
            this.bw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 276);
            this.Controls.Add(this.id3);
            this.Controls.Add(this.debugtext);
            this.Controls.Add(this.start);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.choosedir);
            this.Controls.Add(this.basedir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.status);
            this.Controls.Add(this.id);
            this.Controls.Add(this.options);
            this.Name = "main";
            this.Text = "Xiami Grabber";
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox options;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox basedir;
        private System.Windows.Forms.Button choosedir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.ToolStripStatusLabel statuslabel;
        private System.Windows.Forms.TextBox debugtext;
        private System.Windows.Forms.CheckBox id3;
        public System.ComponentModel.BackgroundWorker bw;
        public System.Windows.Forms.ToolStripProgressBar progressbar;
    }
}

