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
using System.Net.Http;
using System.Runtime.CompilerServices;

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
            lblFFmpeg.Text = null;
            string ver = GetVersionYTDLP(textbxYTeXe.Text);
            LblVer.ForeColor = Color.Black;
            LblVer.Text = "Version : " + ver + " , recherche en cours...";
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
                MessageBox.Show("Nouvelle mis à jour de YT-DLP.exe en version :" + "\n" + ver2, "Mis à jours réussie...", 0, MessageBoxIcon.Exclamation);
            }
            LblVer.Text = "Version : " + ver2;
            LblVer.ForeColor = Color.Green;
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
        public void SetTimeDif(int value)
        {
            textTimeDif.Text = value.ToString();
        }
        public void SetCheckMini(bool value)
        {
            CheckMini.Checked = value;
        }
        public void SetCheckBoot(bool value)
        {
            CheckBoot.Checked = value;
        }
        public void SetAutoUp(bool value)
        {
            CheckUpdate.Checked = value;
        }
        public string CheckAutoUp()
        {
            return CheckUpdate.Checked.ToString();
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
            LblVersion.Text = "Version : " + this.ProductVersion.ToString();

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
                if (int.Parse(textTimeDif.Text) > 0)
                {
                    RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                    key.SetValue("AutoDl", cheminApplicationGuillement + " -T:" + textTimeDif.Text);
                }
                else
                {
                    RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                    key.SetValue("AutoDl", cheminApplicationGuillement);
                }
            }
        }

        private void butDLP_Click(object sender, EventArgs e)
        {
            var dlg1 = new OpenFileDialog();
            dlg1.Filter = "Executable (*.exe)|*.exe";
            dlg1.ShowDialog();

            if (dlg1.FileName != "")
            {
                if (dlg1.FileName.Contains("yt-dlp.exe"))
                {
                    string PathA = dlg1.FileName.ToString();
                    textbxYTeXe.Text = PathA;
                    string ffmpeg = Path.GetDirectoryName(PathA) + @"\ffmpeg.exe";
                    if (!File.Exists(ffmpeg))
                    {
                        MessageBox.Show("L'application FFMPEG.EXE n'existe pas dans le même dossier que YT-DLP.EXE." + "\n" + "Veuillez mettre l'application FFMPEG.EXE pour poursuivre.",this.Text,0,MessageBoxIcon.Warning);

                        return;
                    }
                    else
                    {
                        lblFFmpeg.Text = "FFMpeg présent";
                        lblFFmpeg.ForeColor = System.Drawing.Color.Green;
                    }
                }
                else
                {
                    MessageBox.Show("Le fichier selectionner n'est pas yt-dlp.exe", this.Text, 0, MessageBoxIcon.Error);
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
                MessageBox.Show($"Vérification de mise à jour interrompue : {ex.Message}", "Auto DL - Erreur", 0, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        private void BtnUp_Click(object sender, EventArgs e)
        {
            BtnUp.Enabled = false;
            UpdateYTDLP();
        }

        public async void UpdateApp()
        {
            string Cuvers = this.ProductVersion.ToString();
            string WebVerUrl = "https://raw.githubusercontent.com/GoloG123/AutoDLYTDLP/main/version";
            LblVersion.Text = "Recherche en cours..";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.CacheControl = new System.Net.Http.Headers.CacheControlHeaderValue
                    {
                        NoCache = true
                    };

                    string onlineversion = await client.GetStringAsync(WebVerUrl);
                    LblVersion.Text = "Version en ligne : " + onlineversion.ToString();

                    if (onlineversion.Trim() != Cuvers)
                    {
                       DialogResult Upt =  MessageBox.Show("Une nouvelle version est disponible : " + onlineversion,"Auto DL - Mise à jour",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (Upt == DialogResult.Yes)
                        {
                            UpgradeApp();
                        }
                    }
                    else
                    {
                        LblVersion.Text = "Version à jours : " + onlineversion;
                    }
                    
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Vérification de mise à jour interrompue : {e.Message}",this.Text,0,MessageBoxIcon.Error);
                }
            }

        }
        public async void UpgradeApp() 
        {
            string WebApp = "https://github.com/GoloG123/AutoDLYTDLP/releases/download/Release/AutoDL.exe";
            string DlFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),"AutoDL.exe");
            using (HttpClient client = new HttpClient())
            {
                try
                {
                   LblVersion.Text = "Telechargement en cours...";
                   byte[] filedata = await client.GetByteArrayAsync(WebApp);
                   File.WriteAllBytes(DlFolder,filedata);
                   LblVersion.Text = "Telechargement terminé dans : " + DlFolder;

                }
                catch (Exception e) 
                {
                    MessageBox.Show($"{e.Message}", this.Text, 0, MessageBoxIcon.Error);
                }
            }

        }

        private void btnUpg_Click(object sender, EventArgs e)
        {
            UpdateApp();
        }

       

        private void CheckMini_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckUpdate_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textTimeDif_TextChanged(object sender, EventArgs e)
        {
           if (!string.IsNullOrEmpty(textTimeDif.Text) && int.TryParse(textTimeDif.Text, out int diff))
           {
                CheckBoot_CheckedChanged(sender, e);
            }
        }
    }
}
