namespace AutoDL
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnUp = new System.Windows.Forms.Button();
            this.LblVer = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textTime = new System.Windows.Forms.TextBox();
            this.CheckBoot = new System.Windows.Forms.CheckBox();
            this.CheckMini = new System.Windows.Forms.CheckBox();
            this.butDLP = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textbxYTeXe = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnUp);
            this.groupBox2.Controls.Add(this.LblVer);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.CheckBoot);
            this.groupBox2.Controls.Add(this.CheckMini);
            this.groupBox2.Controls.Add(this.butDLP);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textbxYTeXe);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(546, 149);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Configuration applications :";
            // 
            // BtnUp
            // 
            this.BtnUp.Enabled = false;
            this.BtnUp.Image = global::AutoDL.Properties.Resources.BtnUp25px;
            this.BtnUp.Location = new System.Drawing.Point(499, 83);
            this.BtnUp.Name = "BtnUp";
            this.BtnUp.Size = new System.Drawing.Size(35, 35);
            this.BtnUp.TabIndex = 15;
            this.BtnUp.UseVisualStyleBackColor = true;
            this.BtnUp.Click += new System.EventHandler(this.BtnUp_Click);
            // 
            // LblVer
            // 
            this.LblVer.AutoSize = true;
            this.LblVer.Location = new System.Drawing.Point(230, 33);
            this.LblVer.Name = "LblVer";
            this.LblVer.Size = new System.Drawing.Size(0, 16);
            this.LblVer.TabIndex = 14;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.textTime);
            this.groupBox3.Location = new System.Drawing.Point(247, 87);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(180, 59);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Automatique :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Minutes :";
            // 
            // textTime
            // 
            this.textTime.BackColor = System.Drawing.SystemColors.Window;
            this.textTime.Location = new System.Drawing.Point(110, 24);
            this.textTime.Name = "textTime";
            this.textTime.Size = new System.Drawing.Size(30, 22);
            this.textTime.TabIndex = 7;
            this.textTime.Text = "0";
            this.textTime.TextChanged += new System.EventHandler(this.textTime_TextChanged);
            // 
            // CheckBoot
            // 
            this.CheckBoot.AutoSize = true;
            this.CheckBoot.Location = new System.Drawing.Point(24, 113);
            this.CheckBoot.Name = "CheckBoot";
            this.CheckBoot.Size = new System.Drawing.Size(192, 20);
            this.CheckBoot.TabIndex = 12;
            this.CheckBoot.Text = "Démarrer automatiquement";
            this.CheckBoot.UseVisualStyleBackColor = true;
            this.CheckBoot.CheckedChanged += new System.EventHandler(this.CheckBoot_CheckedChanged);
            // 
            // CheckMini
            // 
            this.CheckMini.AutoSize = true;
            this.CheckMini.Location = new System.Drawing.Point(24, 87);
            this.CheckMini.Name = "CheckMini";
            this.CheckMini.Size = new System.Drawing.Size(146, 20);
            this.CheckMini.TabIndex = 11;
            this.CheckMini.Text = "Démarrer minimiser";
            this.CheckMini.UseVisualStyleBackColor = true;
            // 
            // butDLP
            // 
            this.butDLP.Image = global::AutoDL.Properties.Resources.BtnFolder25px;
            this.butDLP.Location = new System.Drawing.Point(499, 46);
            this.butDLP.Name = "butDLP";
            this.butDLP.Size = new System.Drawing.Size(35, 35);
            this.butDLP.TabIndex = 2;
            this.butDLP.UseVisualStyleBackColor = true;
            this.butDLP.Click += new System.EventHandler(this.butDLP_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Liens application YT-DLP :";
            // 
            // textbxYTeXe
            // 
            this.textbxYTeXe.Enabled = false;
            this.textbxYTeXe.Location = new System.Drawing.Point(24, 52);
            this.textbxYTeXe.Name = "textbxYTeXe";
            this.textbxYTeXe.Size = new System.Drawing.Size(469, 22);
            this.textbxYTeXe.TabIndex = 0;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 169);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.Text = "Auto DL Option";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button butDLP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textbxYTeXe;
        private System.Windows.Forms.CheckBox CheckBoot;
        private System.Windows.Forms.CheckBox CheckMini;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textTime;
        private System.Windows.Forms.Label LblVer;
        private System.Windows.Forms.Button BtnUp;
    }
}