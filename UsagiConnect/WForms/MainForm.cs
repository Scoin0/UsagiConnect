using log4net;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsagiConnect.Client;
using UsagiConnect.Commands;
using UsagiConnect.Configuration;
using UsagiConnect.Osu.Beatmap;
using UsagiConnect.Osu.Enums;
using UsagiConnect.Osu.User;
using Button = System.Windows.Forms.Button;

namespace UsagiConnect.WForms
{
    public partial class MainForm : Form
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(MainForm).Name);
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        
        public static OsuClient OsuClient;
        public static Config Config;
        public static TwiClient TwiClient;
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
            await CreateClientsAsync();

            //Beatmap map = await OsuClient.GetBeatmap("2023927");
            //Log.Info(Config.GetApiParsedMessage(Config.OsuIrcMessage, map).Result);

            //CommandClient.ReceiveBeatmap("https://osu.ppy.sh/beatmapsets/1972778#osu/4093569");
        }

        private void rtbLinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                Config.SaveConfiguration();
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

        private async Task CreateClientsAsync()
        {
            OsuClient = OsuClient.CreateClient(Config.OsuClientId, Config.OsuClientSecret);
            TwiClient = new TwiClient();
            TwiClient.StartClient();

            if (OsuClient.IsOnline) 
            {
                User user = new User();
                user = await OsuClient.GetUser(Config.BanchoUsername, Gamemode.Osu);
                profileAvatar.BorderColor = Color.Green;
                profileAvatar.BorderColor2 = Color.Green;
                profileAvatar.BorderSize = 2;
                profileAvatar.ImageLocation = user.AvatarUrl;
                lbName.Text = user.Username;
            }
            else
            {
                profileAvatar.BorderColor = Color.Red;
                profileAvatar.BorderColor2 = Color.Red;
                profileAvatar.BorderSize = 2;
                lbName.ForeColor = Color.Red;
                lbName.Text = "Offline";
            }
        }
    }
}
