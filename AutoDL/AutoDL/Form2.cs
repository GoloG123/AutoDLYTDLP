using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace AutoDL
{
    public partial class Form2 : Form
    {
        private Form1 form1Instance;
        public Form2(Form1 form1)
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Form2_FormClosing);
            this.form1Instance = form1;

            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 2500;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 250;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(BtnUp, "Mis à jour de YT-DLP.exe");
            toolTip1.SetToolTip(butDLP, "Définir emplacement YT-DLP.exe");
            
        }

        public async void UpdateYTDLP()
        {
            string ver = GetVersionYTDLP(textbxYTeXe.Text);
            LblVer.Text = "Version : " + ver;
            await Task.Delay(1000);
            Process t = new Process();
            t = new Process();
            t.StartInfo.Arguments = "-U"; 
            t.StartInfo.FileName = textbxYTeXe.Text; 
            t.StartInfo.UseShellExecute = true;
            t.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            t.Start();
            await Task.Run(() => t.WaitForExit());
            await Task.Delay(1000);
            string ver2 = GetVersionYTDLP(textbxYTeXe.Text);
            if (ver != ver2)
            {
                MessageBox.Show("Nouvelle mis à jour de YT-DLP.exe en version :" + "\n" + ver2,"Mis à jours réussie...",0,MessageBoxIcon.Exclamation);
            }
            LblVer.Text = "Version : " + ver2;
            BtnUp.Enabled = true;

        }

        public string GetYTexe()
        {
            return textbxYTeXe.Text;

        }
        public string TimeValue()
        {
            return textTime.Text;
        }
        public void SetTime(int value)
        {
            textTime.Text = value.ToString();
        }
        public void SetCheckMini(bool value)
        {
            CheckMini.Checked = value;
        }
        public void SetCheckBoot(bool value)
        {
            CheckBoot.Checked = value;
        }
        public void SetYTExe(string value)
        {
            textbxYTeXe.Text = value;
        }
        public string CheckMinit()
        {
            return CheckMini.Checked.ToString();
        }
        public string CheckBt()
        {
            return CheckBoot.Checked.ToString();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            if (textbxYTeXe.Text != null)
            {
                BtnUp.Enabled = true;
            }

        }

        private void CheckBoot_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoot.Checked == false)
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                key.SetValue("AutoDl", "");
            }
            else
            {
                string cheminApplication = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string cheminApplicationGuillement = $"\"{cheminApplication}\"";
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                key.SetValue("AutoDl", cheminApplicationGuillement);
            }
        }

        private void butDLP_Click(object sender, EventArgs e)
        {
            var dlg1 = new OpenFileDialog();
            dlg1.Filter = "Executable (*.exe)|*.exe";
            dlg1.ShowDialog();

            if (dlg1.FileName != "")
            {
                string ici1 = dlg1.FileName.ToString();
                textbxYTeXe.Text = ici1;// + @"\";
                string ffmpeg = Path.GetDirectoryName(ici1) + @"\ffmpeg.exe";
                if (!File.Exists(ffmpeg))
                {
                    MessageBox.Show("L'application FFMPEG.EXE n'existe pas dans le même dossier que YT-DLP.EXE." + "\n" + "Veuillez mettre l'application FFMPEG.EXE pour poursuivre.");

                    return;
                }
            }
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
            form1Instance.SaveConfig();
        }

        static string GetVersionYTDLP(string exePath)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    FileName = exePath,
                    Arguments = "--version"
                };
                using (Process process = Process.Start(startInfo))
                {
                    using (System.IO.StreamReader reader = process.StandardOutput)
                    {
                        string result = reader.ReadToEnd();
                        return result.Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return string.Empty;
            }
        }

        private void BtnUp_Click(object sender, EventArgs e)
        {
            BtnUp.Enabled = false;
            UpdateYTDLP();
        }

        private void textTime_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
