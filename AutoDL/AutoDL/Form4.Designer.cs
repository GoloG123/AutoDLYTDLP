namespace AutoDL
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.BtnClip = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textbxLink = new System.Windows.Forms.TextBox();
            this.textbxDest = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LblLang = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.Controls.Add(this.LblLang);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.BtnSave);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.BtnClip);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textbxLink);
            this.groupBox1.Controls.Add(this.textbxDest);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(-6, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(537, 232);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ajouter :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(318, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 16);
            this.label3.TabIndex = 37;
            this.label3.Text = "Format audio :";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "webm",
            "m4a"});
            this.comboBox2.Location = new System.Drawing.Point(321, 178);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 24);
            this.comboBox2.TabIndex = 36;
            // 
            // BtnSave
            // 
            this.BtnSave.Image = global::AutoDL.Properties.Resources.quick25px;
            this.BtnSave.Location = new System.Drawing.Point(467, 166);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(60, 60);
            this.BtnSave.TabIndex = 35;
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 16);
            this.label2.TabIndex = 34;
            this.label2.Text = "Format Vidéos :";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "webm",
            "mp4"});
            this.comboBox1.Location = new System.Drawing.Point(175, 178);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 33;
            // 
            // BtnClip
            // 
            this.BtnClip.Image = global::AutoDL.Properties.Resources.BtnPastBis25px;
            this.BtnClip.Location = new System.Drawing.Point(467, 36);
            this.BtnClip.Name = "BtnClip";
            this.BtnClip.Size = new System.Drawing.Size(60, 60);
            this.BtnClip.TabIndex = 31;
            this.BtnClip.UseVisualStyleBackColor = true;
            this.BtnClip.Click += new System.EventHandler(this.BtnClip_Click);
            // 
            // button1
            // 
            this.button1.Image = global::AutoDL.Properties.Resources.BtnFolder25px;
            this.button1.Location = new System.Drawing.Point(467, 102);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 60);
            this.button1.TabIndex = 28;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textbxLink
            // 
            this.textbxLink.AccessibleDescription = "Liens vers video / playliste youtube";
            this.textbxLink.Location = new System.Drawing.Point(9, 55);
            this.textbxLink.Name = "textbxLink";
            this.textbxLink.Size = new System.Drawing.Size(452, 22);
            this.textbxLink.TabIndex = 23;
            // 
            // textbxDest
            // 
            this.textbxDest.Enabled = false;
            this.textbxDest.Location = new System.Drawing.Point(9, 112);
            this.textbxDest.Name = "textbxDest";
            this.textbxDest.Size = new System.Drawing.Size(452, 22);
            this.textbxDest.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "Liens vers video / playliste youtube";
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 16);
            this.label1.TabIndex = 25;
            this.label1.Text = "Liens Youtube :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 16);
            this.label4.TabIndex = 26;
            this.label4.Text = "Dossier destination :";
            // 
            // LblLang
            // 
            this.LblLang.AutoSize = true;
            this.LblLang.Location = new System.Drawing.Point(18, 146);
            this.LblLang.Name = "LblLang";
            this.LblLang.Size = new System.Drawing.Size(104, 16);
            this.LblLang.TabIndex = 38;
            this.LblLang.Text = "Langue préféré :";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "fr-FR",
            "en-US"});
            this.comboBox3.Location = new System.Drawing.Point(21, 178);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 24);
            this.comboBox3.TabIndex = 39;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 240);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form4";
            this.Text = "Auto DLP : Quick Download";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button BtnClip;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textbxLink;
        private System.Windows.Forms.TextBox textbxDest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label LblLang;
    }
}