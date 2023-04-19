using log4net;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace UsagiConnect.WForms
{
    public partial class SettingsForm : Form
    {

        private static readonly ILog Log = LogManager.GetLogger(typeof(SettingsForm).Name);

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            dtbPrefix.Texts = MainForm.Config.Prefix;
            tsUseUpdater.Checked = MainForm.Config.UseUpdater;
            dtbTwitchUsername.Texts = MainForm.Config.TwitchUsername;
            dtbTwitchPassword.Texts = MainForm.Config.TwitchPassword;
            dtbTwitchChannel.Texts = MainForm.Config.TwitchChannel;
            dtbGOsuMemoryPath.Texts = MainForm.Config.GOsuMemoryPath;
            dtbBanchoUsername.Texts = MainForm.Config.BanchoUsername;
            dtbBanchoPassword.Texts = MainForm.Config.BanchoPassword;
            dtbOsuClientId.Texts = MainForm.Config.OsuClientId;
            dtbOsuClientSecret.Texts = MainForm.Config.OsuClientSecret;
        }

        private void lblLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url;
            url = e.Link.LinkData.ToString();

            if (!url.Contains("://"))
                url = "http://" + url;

            var myLink = new ProcessStartInfo(url);
            Process.Start(myLink);
        }

        private void dbSave_Click(object sender, EventArgs e)
        {
            Log.Info("Saving settings...");
            MainForm.Config.Prefix = dtbPrefix.Texts;
            MainForm.Config.UseUpdater = tsUseUpdater.Checked;
            MainForm.Config.TwitchUsername = dtbTwitchUsername.Texts;
            MainForm.Config.TwitchUsername = dtbTwitchUsername.Texts;
            MainForm.Config.TwitchPassword = dtbTwitchPassword.Texts;
            MainForm.Config.TwitchChannel = dtbTwitchChannel.Texts;
            MainForm.Config.GOsuMemoryPath = dtbGOsuMemoryPath.Texts;
            MainForm.Config.BanchoUsername = dtbBanchoUsername.Texts;
            MainForm.Config.BanchoPassword = dtbBanchoPassword.Texts;
            MainForm.Config.OsuClientId = dtbOsuClientId.Texts;
            MainForm.Config.OsuClientSecret = dtbOsuClientSecret.Texts;
            MainForm.Config.SaveConfiguration();
        }
    }
}