namespace downloadProgress
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
            this.downBt = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.cancelBt = new System.Windows.Forms.Button();
            this.percentLabel = new System.Windows.Forms.Label();
            this.savePath = new System.Windows.Forms.Button();
            this.txt_saveFile = new System.Windows.Forms.TextBox();
            this.LogPathTb = new System.Windows.Forms.TextBox();
            this.ImportLogBt = new System.Windows.Forms.Button();
            this.downloadingFile = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // downBt
            // 
            this.downBt.Location = new System.Drawing.Point(327, 210);
            this.downBt.Name = "downBt";
            this.downBt.Size = new System.Drawing.Size(75, 23);
            this.downBt.TabIndex = 0;
            this.downBt.Text = "download";
            this.downBt.UseVisualStyleBackColor = true;
            this.downBt.Click += new System.EventHandler(this.downBt_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(86, 160);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(310, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // cancelBt
            // 
            this.cancelBt.Location = new System.Drawing.Point(428, 209);
            this.cancelBt.Name = "cancelBt";
            this.cancelBt.Size = new System.Drawing.Size(75, 23);
            this.cancelBt.TabIndex = 3;
            this.cancelBt.Text = "cancel";
            this.cancelBt.UseVisualStyleBackColor = true;
            this.cancelBt.Click += new System.EventHandler(this.cancelBt_Click);
            // 
            // percentLabel
            // 
            this.percentLabel.AutoSize = true;
            this.percentLabel.Location = new System.Drawing.Point(409, 166);
            this.percentLabel.Name = "percentLabel";
            this.percentLabel.Size = new System.Drawing.Size(0, 13);
            this.percentLabel.TabIndex = 4;
            // 
            // savePath
            // 
            this.savePath.Location = new System.Drawing.Point(405, 100);
            this.savePath.Name = "savePath";
            this.savePath.Size = new System.Drawing.Size(79, 23);
            this.savePath.TabIndex = 7;
            this.savePath.Text = "save_path";
            this.savePath.UseVisualStyleBackColor = true;
            this.savePath.Click += new System.EventHandler(this.savePath_Click);
            // 
            // txt_saveFile
            // 
            this.txt_saveFile.Location = new System.Drawing.Point(86, 102);
            this.txt_saveFile.Name = "txt_saveFile";
            this.txt_saveFile.Size = new System.Drawing.Size(309, 20);
            this.txt_saveFile.TabIndex = 6;
            // 
            // LogPathTb
            // 
            this.LogPathTb.Location = new System.Drawing.Point(86, 58);
            this.LogPathTb.Name = "LogPathTb";
            this.LogPathTb.Size = new System.Drawing.Size(309, 20);
            this.LogPathTb.TabIndex = 8;
            // 
            // ImportLogBt
            // 
            this.ImportLogBt.Location = new System.Drawing.Point(405, 58);
            this.ImportLogBt.Name = "ImportLogBt";
            this.ImportLogBt.Size = new System.Drawing.Size(75, 23);
            this.ImportLogBt.TabIndex = 9;
            this.ImportLogBt.Text = "import log";
            this.ImportLogBt.UseVisualStyleBackColor = true;
            this.ImportLogBt.Click += new System.EventHandler(this.ImportLogBt_Click);
            // 
            // downloadingFile
            // 
            this.downloadingFile.AutoSize = true;
            this.downloadingFile.Location = new System.Drawing.Point(89, 143);
            this.downloadingFile.Name = "downloadingFile";
            this.downloadingFile.Size = new System.Drawing.Size(0, 13);
            this.downloadingFile.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 275);
            this.Controls.Add(this.downloadingFile);
            this.Controls.Add(this.ImportLogBt);
            this.Controls.Add(this.LogPathTb);
            this.Controls.Add(this.savePath);
            this.Controls.Add(this.txt_saveFile);
            this.Controls.Add(this.percentLabel);
            this.Controls.Add(this.cancelBt);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.downBt);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button downBt;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button cancelBt;
        private System.Windows.Forms.Label percentLabel;
        private System.Windows.Forms.Button savePath;
        private System.Windows.Forms.TextBox txt_saveFile;
        private System.Windows.Forms.TextBox LogPathTb;
        private System.Windows.Forms.Button ImportLogBt;
        private System.Windows.Forms.Label downloadingFile;
    }
}

