using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AutoDL
{
    public partial class Form4 : Form
    {
        private Form1 mainForm;
        public Form4(Form1 mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.FormClosing += new FormClosingEventHandler(Form4_FormClosing);
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 2500;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 250;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(BtnClip, "Coller le lien youtube ici.");
            toolTip1.SetToolTip(button1, "Changer le dossier de destination.");
            toolTip1.SetToolTip(BtnSave, "Démarrer le téléchargement.");
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }
        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                textbxLink.Text = null;
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
               this.Hide();
            }
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            string DLPath = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos) + @"\";
            textbxDest.Text = DLPath;
        }

        private void BtnClip_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                textbxLink.Text = Clipboard.GetText();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dlg1 = new FolderBrowserDialog();
            if (textbxDest.Text != "")
            {
                dlg1.SelectedPath = textbxDest.Text;
            }
            dlg1.ShowDialog();
            if (dlg1.SelectedPath != "")
            {
                string ici1 = dlg1.SelectedPath.ToString();
                textbxDest.Text = ici1 + @"\";
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (textbxLink.Text != "")
            {
                mainForm.StartProcessYTDLP(1, textbxLink.Text, textbxDest.Text, comboBox1.Text, comboBox2.Text,null);
                this.Close();
            }
            else
            {
                if (Clipboard.ContainsText())
                {
                    string ClipB = Clipboard.GetText();
                    if (ClipB.Contains("youtu"))
                    {
                        mainForm.StartProcessYTDLP(1, ClipB, textbxDest.Text, comboBox1.Text, comboBox2.Text,null);
                        this.Close();

                    }
                }
            }

        }
    }
}
