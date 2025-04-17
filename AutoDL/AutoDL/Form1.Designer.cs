using System.Windows.Forms;

namespace AutoDL
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private NotifyIcon notifyIcon;
        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.LblTimeFinish = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnQuick = new System.Windows.Forms.Button();
            this.BtnInfo = new System.Windows.Forms.Button();
            this.BtnSetting = new System.Windows.Forms.Button();
            this.ButEnd = new System.Windows.Forms.Button();
            this.ButSave = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ButStart = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnEdit);
            this.groupBox1.Controls.Add(this.BtnQuick);
            this.groupBox1.Controls.Add(this.BtnInfo);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.BtnSetting);
            this.groupBox1.Controls.Add(this.ButEnd);
            this.groupBox1.Controls.Add(this.ButSave);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.ButStart);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1302, 731);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Auto Download Youtube";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.LblTimeFinish);
            this.groupBox4.Controls.Add(this.status);
            this.groupBox4.Location = new System.Drawing.Point(10, 625);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1286, 98);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Status :";
            // 
            // LblTimeFinish
            // 
            this.LblTimeFinish.AutoSize = true;
            this.LblTimeFinish.Location = new System.Drawing.Point(300, 31);
            this.LblTimeFinish.Name = "LblTimeFinish";
            this.LblTimeFinish.Size = new System.Drawing.Size(0, 16);
            this.LblTimeFinish.TabIndex = 7;
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.status.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.status.Location = new System.Drawing.Point(15, 25);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(2, 18);
            this.status.TabIndex = 6;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(10, 101);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1286, 518);
            this.listView1.TabIndex = 14;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // BtnEdit
            // 
            this.BtnEdit.Image = global::AutoDL.Properties.Resources.BtnEdit50px;
            this.BtnEdit.Location = new System.Drawing.Point(257, 20);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(75, 75);
            this.BtnEdit.TabIndex = 25;
            this.BtnEdit.UseVisualStyleBackColor = true;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnQuick
            // 
            this.BtnQuick.Image = global::AutoDL.Properties.Resources.quick50px;
            this.BtnQuick.Location = new System.Drawing.Point(466, 21);
            this.BtnQuick.Name = "BtnQuick";
            this.BtnQuick.Size = new System.Drawing.Size(90, 70);
            this.BtnQuick.TabIndex = 24;
            this.BtnQuick.UseVisualStyleBackColor = true;
            this.BtnQuick.Click += new System.EventHandler(this.BtnQuick_Click);
            // 
            // BtnInfo
            // 
            this.BtnInfo.Image = global::AutoDL.Properties.Resources.BtnInfo40px;
            this.BtnInfo.Location = new System.Drawing.Point(964, 20);
            this.BtnInfo.Name = "BtnInfo";
            this.BtnInfo.Size = new System.Drawing.Size(75, 75);
            this.BtnInfo.TabIndex = 23;
            this.BtnInfo.UseVisualStyleBackColor = true;
            this.BtnInfo.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // BtnSetting
            // 
            this.BtnSetting.Image = global::AutoDL.Properties.Resources.BtnSetting50px;
            this.BtnSetting.Location = new System.Drawing.Point(881, 20);
            this.BtnSetting.Name = "BtnSetting";
            this.BtnSetting.Size = new System.Drawing.Size(75, 75);
            this.BtnSetting.TabIndex = 22;
            this.BtnSetting.UseVisualStyleBackColor = true;
            this.BtnSetting.Click += new System.EventHandler(this.BtnSetting_Click);
            // 
            // ButEnd
            // 
            this.ButEnd.Image = global::AutoDL.Properties.Resources.BtnExit50px;
            this.ButEnd.Location = new System.Drawing.Point(1221, 20);
            this.ButEnd.Name = "ButEnd";
            this.ButEnd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ButEnd.Size = new System.Drawing.Size(75, 75);
            this.ButEnd.TabIndex = 9;
            this.ButEnd.UseVisualStyleBackColor = true;
            this.ButEnd.Click += new System.EventHandler(this.button1_Click);
            // 
            // ButSave
            // 
            this.ButSave.Image = global::AutoDL.Properties.Resources.BtnSave;
            this.ButSave.Location = new System.Drawing.Point(176, 20);
            this.ButSave.Name = "ButSave";
            this.ButSave.Size = new System.Drawing.Size(75, 75);
            this.ButSave.TabIndex = 5;
            this.ButSave.UseVisualStyleBackColor = true;
            this.ButSave.Click += new System.EventHandler(this.ButSave_Click);
            // 
            // button2
            // 
            this.button2.Image = global::AutoDL.Properties.Resources.AddBtn;
            this.button2.Location = new System.Drawing.Point(10, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 75);
            this.button2.TabIndex = 4;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_2);
            // 
            // ButStart
            // 
            this.ButStart.Image = global::AutoDL.Properties.Resources.BtnStart70px;
            this.ButStart.Location = new System.Drawing.Point(576, 20);
            this.ButStart.Name = "ButStart";
            this.ButStart.Size = new System.Drawing.Size(90, 70);
            this.ButStart.TabIndex = 6;
            this.ButStart.UseVisualStyleBackColor = true;
            this.ButStart.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Image = global::AutoDL.Properties.Resources.DelBtn;
            this.button3.Location = new System.Drawing.Point(92, 20);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 75);
            this.button3.TabIndex = 8;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1326, 741);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "AutoDL";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ButStart;
        private System.Windows.Forms.Button ButEnd;
        private System.Windows.Forms.Button ButSave;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label status;
        private GroupBox groupBox4;
        private Button button2;
        private Button button3;
        private ListView listView1;
        private Button BtnSetting;
        private Button BtnInfo;
        private Label LblTimeFinish;
        private Button BtnQuick;
        private ContextMenuStrip contextMenuStrip1;
        private ContextMenuStrip ContextMenuList;
        private ContextMenuStrip ContextMenuStrip2;
        private Button BtnEdit;
    }
}

