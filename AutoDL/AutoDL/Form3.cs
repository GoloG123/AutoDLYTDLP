using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ToolTip = System.Windows.Forms.ToolTip;


namespace AutoDL
{
    public partial class Form3 : Form
    {
        private Form1 mainForm;
        public Form3(Form1 form1)
        {
            InitializeComponent(); 

            this.mainForm = form1;
            this.FormClosing += new FormClosingEventHandler(Form3_FormClosing);
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 2500;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 250;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(BtnClip,"Coller le lien youtube ici, si channel le nom est automatiquement inserer.");
            toolTip1.SetToolTip(button1, "Selectionner le dossier de destination pour le telechargement");
            toolTip1.SetToolTip(BtnSave, "Ajouter à la liste");
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }
      

        private void BtnClip_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                textbxLink.Text = Clipboard.GetText();
                string[] NameParse = Clipboard.GetText().Split('@');
                if (NameParse.Length > 1)
                {
                    txtName.Text = NameParse[1];
                }
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
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (textbxDest.Text != "" && textbxLink.Text != "" && txtName.Text != "" && txtNumber.Text != "" && txtNumber.Text != "0" && int.TryParse(txtNumber.Text, out _))
            {
                ListViewItem item1 = new ListViewItem("");
                item1.SubItems.Add(txtName.Text);
                item1.SubItems.Add(textbxLink.Text);
                item1.SubItems.Add(textbxDest.Text);
                item1.SubItems.Add(txtNumber.Text);
                item1.SubItems.Add(comboBox1.Text);
                item1.SubItems.Add(comboBox2.Text);
                item1.Checked = true;
                mainForm.ListviewInstance.Items.Add(item1);   
                mainForm.ListviewInstance.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                textbxLink.Text = "";
                txtName.Text = "";
                mainForm.SetButSave(true);

            }
            else if (textbxDest.Text == "")
            {
                MessageBox.Show("Pas de dossier de destination choisit","YTDLP - Erreur",0,MessageBoxIcon.Error);
            }
            else if (txtName.Text == "")
            {
                MessageBox.Show("Pas de nom choisis", "YTDLP - Erreur", 0, MessageBoxIcon.Error);
            }
            else if (textbxLink.Text == "")
            {
                MessageBox.Show("Pas de lien youtube", "YTDLP - Erreur", 0, MessageBoxIcon.Error);
            }

        }
    }
}
