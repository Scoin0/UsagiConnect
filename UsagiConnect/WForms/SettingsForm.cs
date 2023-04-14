using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace UsagiConnect.WForms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            linkLabel1.Text = "https://osu.ppy.sh/beatmapsets/966339#osu/2023927";
            textBox1.Text = MainForm.GetConfiguration().BanchoUsername + "";
        }

        private void lblLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url;
            url = e.Link.LinkData.ToString();

            if (!url.Contains("://"))
                url = "http://" + url;

            var myLink = new ProcessStartInfo(url);
            Process.Start(myLink);
            linkLabel1.LinkVisited = true;
        }
    }
}
