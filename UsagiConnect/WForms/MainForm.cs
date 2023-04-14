﻿using log4net;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using UsagiConnect.Client;
using UsagiConnect.Configuration;
using UsagiConnect.Osu.API.Beatmap;
using UsagiConnect.Osu.API.Enums;
using UsagiConnect.Osu.API.User;
using Button = System.Windows.Forms.Button;

namespace UsagiConnect.WForms
{
    public partial class MainForm : Form
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(MainForm));
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        
        public static OsuClient OsuClient;
        public static Config Config;
        private Form activeForm;
        private Button currentButton;

        public MainForm()
        {
            InitializeComponent();
            pnlNav.Height = btnDashboard.Height;
            pnlNav.Top = btnDashboard.Top;
            pnlNav.Left = btnDashboard.Left;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            Log.Info("Welcome to UsagiConnect!");
            Config = new Config();
            OsuClient = OsuClient.CreateClient(Config.OsuClientId, Config.OsuClientSecret);
            User user = new User();
            Beatmap map = await OsuClient.getBeatmap("2023927");
            user = await OsuClient.getUser("I_Only_Hit_100s", Gamemode.Osu);
            profileAvatar.ImageLocation = user.AvatarUrl;
            lbName.Text = user.Username;

            Log.Info(GetConfiguration().GetApiParsedMessage("[RECEIVED] > <beatmap_url> <user_sent> [<ranked_status>] <artist> - <title> [<version>] <music_note_emoji> <length> <star_emoji> <star_rating> BPM:<bpm> AR:<ar> OD:<od>", map).Result);

            if (OsuClient.IsOnline)
            {
                profileAvatar.BorderColor = Color.Green;
                profileAvatar.BorderColor2 = Color.Green;
                profileAvatar.BorderSize = 2;
            }
            else
            {
                profileAvatar.BorderColor = Color.Red;
                profileAvatar.BorderColor2 = Color.Red;
                profileAvatar.BorderSize = 2;
            }
        }

        public static OsuClient GetOsuClient()
        {
            return OsuClient;
        }

        public static Config GetConfiguration()
        {
            return Config;
        }

        private void rtbLinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                pnlNav.Height = btnDashboard.Height;
                pnlNav.Top = btnDashboard.Top;
                pnlNav.Left = btnDashboard.Left;
            }
        }
        private void btnSettings_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnSettings.Height;
            pnlNav.Top = btnSettings.Top;
            pnlNav.Left = btnSettings.Left;
            OpenChildForm(new SettingsForm(), sender);
            ActivateButton(sender);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pnlTopLeft_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void OpenChildForm(Form childForm, object sender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Add(childForm);
            this.pnlMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = Color.FromArgb(61, 61, 61);
                    currentButton.ForeColor = Color.FromArgb(170, 170, 170);
                    currentButton.Font = new System.Drawing.Font("LT Asus", 20.25f, System.Drawing.FontStyle.Bold);
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in pnlLeft.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(61, 61, 61);
                    previousBtn.ForeColor = Color.FromArgb(170, 170, 170);
                    previousBtn.Font = new System.Drawing.Font("LT Asus", 20.25f, System.Drawing.FontStyle.Bold);
                }
            }
        }
    }
}
