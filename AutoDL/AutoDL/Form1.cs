using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Microsoft.Win32;
using ToolTip = System.Windows.Forms.ToolTip;
namespace AutoDL
{


    public partial class Form1 : Form
    {
        int CountDown = 0;
        private Form2 Frm2;
        private Form3 Frm3;
    //    private Form4 Frm4;
        private Form[] forms = new Form[5];

        public ListView ListviewInstance => listView1;
        
        public Form1()
        {
            InitializeComponent();
            
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 2500;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 250;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.button2, "Ajouter un Channel / Vidéo / Playliste Youtube ici..");
            toolTip1.SetToolTip(this.BtnQuick, "Telecharger rapidement une vidéo");
            toolTip1.SetToolTip(this.button3, "Effacer un élément de la liste");
            toolTip1.SetToolTip(this.ButSave, "Sauvegarder la liste");
            toolTip1.SetToolTip(this.ButStart, "Lancer le telechargement");
            toolTip1.SetToolTip(this.BtnSetting, "Options de l'application");
            toolTip1.SetToolTip(this.BtnInfo, "A propos...");
            toolTip1.SetToolTip(this.ButEnd, "Quitter");

            Frm2 = new Form2(this);

            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = this.Icon;
            notifyIcon.Visible = true;
            notifyIcon.Text = "Auto Download Youtube Playlist";
            

            ContextMenuStrip contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Restaurer",null, Restaurer_Click);
            contextMenu.Items.Add("-");
            contextMenu.Items.Add("Start Download", null, Lancement_Click);
            contextMenu.Items.Add("-");
            contextMenu.Items.Add("Quitter",null,button1_Click);
            notifyIcon.ContextMenuStrip = contextMenu;
            notifyIcon.DoubleClick += Restaurer_Click;

            listView1.ItemChecked += new ItemCheckedEventHandler(ListView1_ItemChecked);
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);

            ContextMenuList = new ContextMenuStrip();
           // ContextMenuList.Items.Add("Cocher Tout", null, CocherTout_Click);
            listView1.ContextMenuStrip = ContextMenuList;
            listView1.MouseDown += ListView1_MouseDown;


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnsubscribeFormClosing();
            ExitApp(e);
            ResubscribeFormClosing();
           
        }
        
        
        private void ListView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            bool anyChecked = listView1.CheckedItems.Count > 0;
            ButSave.Enabled = anyChecked;
        }
       
        public void SetButSave(bool b)
        {
            ButSave.Enabled = b;
        }
       
        public void Lancement_Click(object sender, EventArgs e)
        {
            StartProcessYTDLP(0,null,null,null,null,null);
        }
        public void Restaurer_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.WindowState == FormWindowState.Minimized)
            {
               Minize_it();
            }
        }
        
        public async void StartProcessYTDLP(int Q,string QLink, string QDesti, string QFormatV, string QFormatA, string Qnb)
        {
           
            ProgressBar bar = new ProgressBar();
            bar.Location = new System.Drawing.Point(5,status.Top + 20);
            bar.Name = "ProgressBar";
            bar.Width = groupBox4.Width - 10;
            bar.Height = 30;
            groupBox4.Controls.Add(bar);
            bar.Visible = true;

            LblTimeFinish.Text = "";
            DateTime StartTime = DateTime.Now;

            string AdressAp = Frm2.GetYTexe(); // variable chemin application YT-DLP

            switch (Q)
            {
                case 0:

                    List<string> YTLink = new List<string>();
                    List<string> OutPath = new List<string>();
                    List<string> NumberV = new List<string>();
                    List<string> Name = new List<string>();
                    List<string> FormatV = new List<string>();
                    List<string> FormatA = new List<string>();



                    foreach (ListViewItem item in listView1.Items)
                    {
                        if (!item.Checked)
                        {
                            continue;
                        }
                        if (item.SubItems.Count >= 5)
                        {
                            Name.Add(item.SubItems[1].Text);
                            YTLink.Add(item.SubItems[2].Text);
                            OutPath.Add(item.SubItems[3].Text);
                            NumberV.Add(item.SubItems[4].Text);
                            FormatV.Add(item.SubItems[5].Text);
                            FormatA.Add(item.SubItems[6].Text);
                        }
                    }

                    timer1.Stop(); // stop du timer
                    ButStart.Enabled = false; // on désactive le bouton pour ne pas relancer le process


                    bar.Minimum = 0;
                    bar.Maximum = YTLink.Count;
                    bar.Value = 0;

                    for (int j = 0; j < YTLink.Count; j++)
                    {
                        string ArguDLp = $"-f bestvideo[ext={FormatV[j]}]+bestaudio[language='fr-FR'][ext={FormatA[j]}]/bestvideo[ext={FormatV[j]}]+bestaudio[ext={FormatA[j]}] "; // argument envoyé a YT-DLP.exe
                        string OutP = OutPath[j] + "%(upload_date)s - %(title)s.%(ext)s"; // ARGUMENT
                        string Yt = YTLink[j]; // Adresse video Youtube ou Channel Youtube
                        string nb = NumberV[j]; // Nombres de video a telecharger si chaine
                        string Names = Name[j]; // Nom de la chaine en cours

                        LblTimeFinish.Left = status.Left + status.Width + 20;
                        bar.Value = j + 1;

                        string Atr;

                        if (Yt.Contains("@"))
                        {
                            status.Text = "En cours... " + Names;
                            Atr = ArguDLp + Yt + " --playlist-end " + nb + " -o " + $"\"{OutP}\"";
                        }
                        else
                        {
                            status.Text = "En cours... " + Names;
                            Atr = ArguDLp + Yt + " -o " + $"\"{OutP}\"";
                        }
                        try
                        {
                            Process t = new Process(); // creation du process T pour lancer l'application externe.
                            t = new Process();
                            t.StartInfo.Arguments = Atr; // on donne l'argument stocker dans la variable Atr
                            t.StartInfo.FileName = AdressAp; // on définit où est l'application yt-dlp définit par l'user
                            t.StartInfo.UseShellExecute = true;
                            t.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            t.Start();
                            await Task.Run(() => t.WaitForExit()); // on attend qu'elle termine mais en permettant l'utilisation de la fenetre
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Une erreur est survenue : " + ex.Message);
                            ButStart.Enabled = true;
                            status.Text = "Erreur..." + ex.Message;

                        }
                    }
                    DateTime Endtime = DateTime.Now;
                    TimeSpan Elapse = Endtime - StartTime;
                    status.Text = $"Fini...";
                    LblTimeFinish.Text = $"Opération terminé en : {Elapse.Hours.ToString()}H:{Elapse.Minutes.ToString()}M:{Elapse.Seconds.ToString()}S";
                    ButStart.Enabled = true; // on permet de pouvoir recliquer sur le boutton
                    CountDown = int.Parse(Frm2.TimeValue()) * 60; // on définit coutdown en variable de seconde (donné en minute a la base)
                    if (int.Parse(Frm2.TimeValue()) > 0)
                    {
                        timer1.Start(); // on lance le timer
                    }
                    bar.Visible = false;
                    break;
                case 1:
                    string QDlp = $"-f bestvideo[ext={QFormatV}]+bestaudio[language='fr-FR'][ext={QFormatA}]/bestvideo[ext={QFormatV}]+bestaudio[ext={QFormatA}] "; // argument envoyé a YT-DLP.exe
                    string QArg = QDlp + QLink + " -o " + QDesti + @"%(title)s.%(ext)s";
                    bar.Value = 90;
                    try
                    {
                        Process t = new Process(); // creation du process T pour lancer l'application externe.
                        t = new Process();
                        t.StartInfo.Arguments = QArg; // on donne l'argument stocker dans la variable Atr
                        t.StartInfo.FileName = AdressAp; // on définit où est l'application yt-dlp définit par l'user
                        t.StartInfo.UseShellExecute = true;
                        t.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        t.Start();
                        await Task.Run(() => t.WaitForExit()); // on attend qu'elle termine mais en permettant l'utilisation de la fenetre
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Une erreur est survenue : " + ex.Message);
                        ButStart.Enabled = true;
                        status.Text = "Erreur..." + ex.Message;

                    }
                    bar.Value = 100;
                    DateTime Endtime1 = DateTime.Now;
                    TimeSpan Elapse1 = Endtime1 - StartTime;
                    status.Text = $"Fini...";
                    LblTimeFinish.Text = $"Opération terminé en : {Elapse1.Hours.ToString()}H:{Elapse1.Minutes.ToString()}M:{Elapse1.Seconds.ToString()}S";
                    bar.Visible = false;
                    break;
                case 2:
                    try
                    {
                       
                        status.Text = "En cours...";
                        ButStart.Enabled = false;
                        bar.Value = 50;
                        bool TimEnabled = false;
                        if (timer1.Enabled == true)
                        {
                          TimEnabled = true;
                          timer1.Enabled = false;
                        }

                        string SDlp = $"-f bestvideo[ext={QFormatV}]+bestaudio[language='fr-FR'][ext={QFormatA}]/bestvideo[ext={QFormatV}]+bestaudio[ext={QFormatA}] "; // argument envoyé a YT-DLP.exe
                        string Desti = QDesti + "%(upload_date)s - %(title)s.%(ext)s";
                        string SAtr = SDlp + QLink + " --playlist-end " + Qnb + " -o " + "\"" + Desti + "\"";
                        Process t = new Process(); // creation du process T pour lancer l'application externe.
                        bar.Value = 75;
                        t = new Process();
                        t.StartInfo.Arguments = SAtr; // on donne l'argument stocker dans la variable Atr
                        t.StartInfo.FileName = AdressAp; // on définit où est l'application yt-dlp définit par l'user
                        t.StartInfo.UseShellExecute = true;
                        t.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        t.Start();
                        bar.Value = 85;
                        await Task.Run(() => t.WaitForExit()); // on attend qu'elle termine mais en permettant l'utilisation de la fenetre
                        ButStart.Enabled = true;
                        bar.Value = 100;
                        bar.Visible = false;
                        status.Text = "Terminé";
                       if (TimEnabled == true)
                        { 
                            timer1.Enabled = true;
                        }
                       

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Une erreur est survenue : " + ex.Message);
                        ButStart.Enabled = true;
                        status.Text = "Erreur..." + ex.Message;

                    }
                    break;
            }
        } 
        private void button2_Click(object sender, EventArgs e)
        {
            StartProcessYTDLP(0,null,null,null,null,null); // lancement du process de telechargement    
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ChargeConfig(); // chargement des données d'utilisateur sauvegardé

            if (Frm2.CheckMinit() == "True")
            {
                Minize_it();
            }
            listView1.Columns.Add("✓");
            listView1.CheckBoxes = true;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Nom");
            listView1.Columns.Add("Liens Youtube");
            listView1.Columns.Add("Dossier");
            listView1.Columns.Add("Nombre Vidéo");
            listView1.Columns.Add("Format Vidéo");
            listView1.Columns.Add("Format Audio");
            listView1.GridLines = true;
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            status.Text = "Temps restant : " + Frm2.TimeValue();
            LblTimeFinish.Top = status.Top;
            LblTimeFinish.Left = status.Left + status.Width + 30;
          //  await Task.Delay(100); // on attend car sinon la fenetre ne se hide pas
            ChargeData(); // chargement de la base de donnée
            ButSave.Enabled = false;


        }
        public async void Minize_it()
        {
            await Task.Delay(100);
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
            // non activé car trop répétitife =
            //notifyIcon.ShowBalloonTip(0, "Auto Download Youtube", "L'application est maintenant dans la barre de notification.", ToolTipIcon.Info);
        }
        public void ChargeConfig()
        {
            try
            {  
            string UserPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\config.ini";
            string ChargeData = File.ReadAllText(UserPath);
            string[] data = ChargeData.Split(new char[] { ';' });
                Frm2.SetCheckMini(bool.Parse(data[0]));
                Frm2.SetCheckBoot(bool.Parse(data[1]));
                Frm2.SetTime(int.Parse(data[2]));
                Frm2.SetYTExe(data[3]);
                if (int.Parse(data[2]) > 0)
                {
                    CountDown = int.Parse(data[2]) * 60;
                    timer1.Enabled = true;
                }
               
            }
            catch (Exception e)
            {
              MessageBox.Show("Une erreur lors du chargement des données est survenue :" + "\n" + e.Message);
            }

            
            }
        private void ChargeData()
        {
            try
            {
                string UserPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\data.txt";
                string BaseData = File.ReadAllText(UserPath);
                string[] lines = BaseData.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                listView1.Items.Clear();
                foreach (string line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        string[] columns = line.Split(',');

                        if (columns.Length > 5)
                        {
                            ListViewItem item = new ListViewItem("");
                            item.Checked = bool.Parse(columns[0]);
                            item.SubItems.Add(columns[1]);
                            item.SubItems.Add(columns[2]);
                            item.SubItems.Add(columns[3]);
                            item.SubItems.Add(columns[4]);
                            item.SubItems.Add(columns[5]);
                            item.SubItems.Add(columns[6]);
                            listView1.Items.Add(item);
                            listView1.Refresh();
                            
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            UnsubscribeFormClosing();
            ExitApp();
            ResubscribeFormClosing();
        }

        private void UnsubscribeFormClosing()
        {
            this.FormClosing -= Form1_FormClosing;
        }
        private void ResubscribeFormClosing()
        {
            this.FormClosing += Form1_FormClosing;
        }

        public void ExitApp(FormClosingEventArgs e = null) 
        {
            if (ButSave.Enabled == true)
            {
                DialogResult result = MessageBox.Show("Vous avez des données non sauvegardées. Voulez-vous sauvegarder avant de quitter ?", "Auto DLP - Données non sauvegarder", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    SaveData();
                }
                else if (result == DialogResult.Cancel)
                {
                    if (e != null)
                    {
                        e.Cancel = true;
                    }
                    return;
                }
            }
            Application.Exit();

        }

        private void ButSave_Click(object sender, EventArgs e)
        {
            SaveData();
            SetButSave(false);
        }

        public void SaveConfig()
        {
            try
            {
                if (!int.TryParse(Frm2.TimeValue(), out _)) 
                {
                    MessageBox.Show("Entrer un chiffre dans le temps");
                    Frm2.SetTime(0); 
                    Frm2.Show();
                    return;
                    
                }
                if (int.Parse(Frm2.TimeValue()) == 0)
                {
                    timer1.Enabled = false;
                }
                else
                {
                    CountDown = int.Parse(Frm2.TimeValue()) * 60;
                    timer1.Enabled = true;

                }
                if (!int.TryParse(Frm2.TimeValue(), out _))
                {
                    MessageBox.Show("Le temps doit être supérieur à zéro");
                    Frm2.SetTime(30);
                }
                else
                {
                    if (Frm2.GetYTexe() == "")
                    {
                        MessageBox.Show("Veuillez définir où est YT-DL.EXE");
                        Frm2.Show();
                        return;
                    }
                    string DataSave = Frm2.CheckMinit() + ";" + Frm2.CheckBt() + ";" + Frm2.TimeValue() + ";" + Frm2.GetYTexe() + ";";
                    string UserPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\config.ini";
                    File.WriteAllText(UserPath, DataSave);
                    status.Text = "Options sauver..";
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
             }
        }
        private void SaveData()
        {
            try
            {
                    string UserPathData = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\data.txt";
                    string DataBase = "";
                    foreach (ListViewItem item in listView1.Items)
                    {
                        DataBase += item.Checked.ToString() ;
                        for (int i = 0; i < item.SubItems.Count; i++)
                        {
                           DataBase += item.SubItems[i].Text + ",";
                        }
                        DataBase += Environment.NewLine;
                    }
                    File.WriteAllText(UserPathData, DataBase);
                   
                    status.Text = "Sauver...";
                
                
                
            }
            catch (Exception e)
            {
                MessageBox.Show("Une erreur lors de la sauvegarde est survenue. Relancer avec les droits d'administrateur" + "\n" + e.Message.ToString());
            }
        }
        private void textTime_TextChanged(object sender, EventArgs e)
        { }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CountDown > 0)
            {
                CountDown--;
                int Minute = CountDown / 60;
                int Sec = CountDown % 60; 
                status.Text = "Temps restant : " + $"{Minute:D2}:{Sec:D2}";            
            }
            else
            {
            timer1.Stop();
                StartProcessYTDLP(0,null,null,null,null,null);
            }

        }


        private void button2_Click_2(object sender, EventArgs e)
        {
            ShowForm(3);
    
        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                int selectedIndex = selectedItem.Index;
                listView1.Items.RemoveAt(selectedIndex);
                ButSave.Enabled = true;
                // Sélectionner l'élément précédent ou le premier élément restant
                if (selectedIndex > 0 && selectedIndex - 1 < listView1.Items.Count)
                {
                    listView1.Items[selectedIndex - 1].Selected = true;
                }
                else if (listView1.Items.Count > 0)
                {
                    listView1.Items[0].Selected = true;
                }

                // Redimensionner les colonnes après la suppression de l'élément
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }


        }

        private void ListView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var item = listView1.GetItemAt(e.X, e.Y);
                if (item != null)
                {
                    string selectedItemName = item.SubItems[1].Text;
                    ContextMenuList.Items.Clear();
                    ContextMenuList.Items.Add($"Cocher uniquement {selectedItemName}", null,CocherItem_Click);
                    ContextMenuList.Items.Add("Cocher Tout", null, CocherTout_Click);
                    ContextMenuList.Items.Add("Decocher Tout", null, DecocherTout_Click);
                    ContextMenuList.Items.Add("-", null, null);
                    ContextMenuList.Items.Add($"Démarrer {selectedItemName}", null, DemarrerItem_Click);
                    ContextMenuList.Items.Add($"Modifier {selectedItemName}", null, null);
                    ContextMenuList.Items.Add($"Supprimer {selectedItemName}", null, null);

                }
            }
        }

        private void CocherItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string SelectedItemName = listView1.SelectedItems[0].SubItems[1].Text;
                foreach (ListViewItem item in listView1.Items)
                {
                    item.Checked = item.SubItems[1].Text == SelectedItemName;
                }
            }
        }
        private void CocherTout_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                item.Checked = true;
            }
        }
        private void DecocherTout_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                item.Checked = false;
                ButSave.Enabled = true;
            }
        }

        private void DemarrerItem_Click(object obj, EventArgs e)
        {
            string ItemName = listView1.SelectedItems[0].SubItems[1].Text;
            string YTLink = listView1.SelectedItems[0].SubItems[2].Text;
            string Path = listView1.SelectedItems[0].SubItems[3].Text;
            string NbV = listView1.SelectedItems[0].SubItems[4].Text;
            string FormatV = listView1.SelectedItems[0].SubItems[5].Text;
            string FormatA = listView1.SelectedItems[0].SubItems[6].Text;
            StartProcessYTDLP(2, YTLink, Path, FormatV, FormatA, NbV);
           
            //MessageBox.Show(ItemName + "\n" + YTLink + "\n" + Path + "\n" + NbV + "\n" + FormatV + "\n" + FormatA);
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string info1 = "Programme créer par Defend Emmanuel @GoloG ";
            string info2 = "Contact : golog123@hotmail.com ";
            string info3 = "Version : " + this.ProductVersion.ToString();
            MessageBox.Show(info1 + "\n\n" + info2 + "\n\n" + info3);
        }

        private void BtnSetting_Click(object sender, EventArgs e)
        {
            Frm2.Show();
            Frm2.BringToFront();
            //ShowForm(2);
        }

        private void BtnQuick_Click(object sender, EventArgs e)
        {
            ShowForm(4);
        }
        public void ShowForm(int N)
        {
            if (forms[N] == null || forms[N].IsDisposed)
            {
                switch (N)
                {
                    case 0:
                      //  forms[N] = new Form0(this);
                        break;
                    case 1:
                    //    Frm[N] = new Form1(this);
                        break;
                    case 2:
                        Frm2.Show();
                        forms[N] = new Form2(this);
                        break;
                    case 3:
                        forms[N] = new Form3(this);
                        break;
                    case 4:
                        forms[N] = new Form4(this);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(N), "Numéro de formulaire invalide");
                }
            }

            forms[N].Show();
            forms[N].BringToFront();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
