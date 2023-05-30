using System.Windows.Forms;

namespace UsagiConnect.WForms
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPrefix = new System.Windows.Forms.Label();
            this.lblUseUpdater = new System.Windows.Forms.Label();
            this.lblConfigurationSettings = new System.Windows.Forms.Label();
            this.lblTwitchUsername = new System.Windows.Forms.Label();
            this.lblTwitchPassword = new System.Windows.Forms.Label();
            this.lblTwitchChannel = new System.Windows.Forms.Label();
            this.lblGOsuMemoryPath = new System.Windows.Forms.Label();
            this.lblBanchoUsername = new System.Windows.Forms.Label();
            this.lblBanchoPassword = new System.Windows.Forms.Label();
            this.lblOsuClientId = new System.Windows.Forms.Label();
            this.lblOsuClientSecret = new System.Windows.Forms.Label();
            this.lblStarLimit = new System.Windows.Forms.Label();
            this.lblTwitchMessage = new System.Windows.Forms.Label();
            this.lblOsuIrcMessage = new System.Windows.Forms.Label();
            this.lblNowPlayingMessage = new System.Windows.Forms.Label();
            this.lblStarLimitMessage = new System.Windows.Forms.Label();
            this.dtbStarLimitMessage = new UsagiConnect.WForms.CustomControls.DesignTextBox();
            this.dtbNowPlayingMessage = new UsagiConnect.WForms.CustomControls.DesignTextBox();
            this.dtbOsuIrcMessage = new UsagiConnect.WForms.CustomControls.DesignTextBox();
            this.dtbTwitchMessage = new UsagiConnect.WForms.CustomControls.DesignTextBox();
            this.dtbStarLimit = new UsagiConnect.WForms.CustomControls.DesignTextBox();
            this.dbSave = new UsagiConnect.WForms.CustomControls.DesignButton();
            this.dtbOsuClientSecret = new UsagiConnect.WForms.CustomControls.DesignTextBox();
            this.dtbOsuClientId = new UsagiConnect.WForms.CustomControls.DesignTextBox();
            this.dtbBanchoPassword = new UsagiConnect.WForms.CustomControls.DesignTextBox();
            this.dtbBanchoUsername = new UsagiConnect.WForms.CustomControls.DesignTextBox();
            this.dtbGOsuMemoryPath = new UsagiConnect.WForms.CustomControls.DesignTextBox();
            this.dtbTwitchChannel = new UsagiConnect.WForms.CustomControls.DesignTextBox();
            this.dtbTwitchPassword = new UsagiConnect.WForms.CustomControls.DesignTextBox();
            this.dtbTwitchUsername = new UsagiConnect.WForms.CustomControls.DesignTextBox();
            this.tsUseUpdater = new UsagiConnect.WForms.CustomControls.ToggleSlider();
            this.dtbPrefix = new UsagiConnect.WForms.CustomControls.DesignTextBox();
            this.SuspendLayout();
            // 
            // lblPrefix
            // 
            this.lblPrefix.AutoSize = true;
            this.lblPrefix.Font = new System.Drawing.Font("Franklin Gothic Medium", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrefix.ForeColor = System.Drawing.Color.White;
            this.lblPrefix.Location = new System.Drawing.Point(12, 41);
            this.lblPrefix.Name = "lblPrefix";
            this.lblPrefix.Size = new System.Drawing.Size(88, 34);
            this.lblPrefix.TabIndex = 0;
            this.lblPrefix.Text = "Prefix";
            // 
            // lblUseUpdater
            // 
            this.lblUseUpdater.AutoSize = true;
            this.lblUseUpdater.Font = new System.Drawing.Font("Franklin Gothic Medium", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUseUpdater.ForeColor = System.Drawing.Color.White;
            this.lblUseUpdater.Location = new System.Drawing.Point(12, 82);
            this.lblUseUpdater.Name = "lblUseUpdater";
            this.lblUseUpdater.Size = new System.Drawing.Size(168, 34);
            this.lblUseUpdater.TabIndex = 2;
            this.lblUseUpdater.Text = "Use Updater";
            // 
            // lblConfigurationSettings
            // 
            this.lblConfigurationSettings.AutoSize = true;
            this.lblConfigurationSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblConfigurationSettings.Font = new System.Drawing.Font("Franklin Gothic Medium", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfigurationSettings.ForeColor = System.Drawing.Color.White;
            this.lblConfigurationSettings.Location = new System.Drawing.Point(0, 0);
            this.lblConfigurationSettings.Name = "lblConfigurationSettings";
            this.lblConfigurationSettings.Size = new System.Drawing.Size(375, 41);
            this.lblConfigurationSettings.TabIndex = 4;
            this.lblConfigurationSettings.Text = "Configuration Settings";
            // 
            // lblTwitchUsername
            // 
            this.lblTwitchUsername.AutoSize = true;
            this.lblTwitchUsername.Font = new System.Drawing.Font("Franklin Gothic Medium", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTwitchUsername.ForeColor = System.Drawing.Color.White;
            this.lblTwitchUsername.Location = new System.Drawing.Point(12, 123);
            this.lblTwitchUsername.Name = "lblTwitchUsername";
            this.lblTwitchUsername.Size = new System.Drawing.Size(232, 34);
            this.lblTwitchUsername.TabIndex = 5;
            this.lblTwitchUsername.Text = "Twitch Username";
            // 
            // lblTwitchPassword
            // 
            this.lblTwitchPassword.AutoSize = true;
            this.lblTwitchPassword.Font = new System.Drawing.Font("Franklin Gothic Medium", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTwitchPassword.ForeColor = System.Drawing.Color.White;
            this.lblTwitchPassword.Location = new System.Drawing.Point(12, 164);
            this.lblTwitchPassword.Name = "lblTwitchPassword";
            this.lblTwitchPassword.Size = new System.Drawing.Size(225, 34);
            this.lblTwitchPassword.TabIndex = 7;
            this.lblTwitchPassword.Text = "Twitch Password";
            // 
            // lblTwitchChannel
            // 
            this.lblTwitchChannel.AutoSize = true;
            this.lblTwitchChannel.Font = new System.Drawing.Font("Franklin Gothic Medium", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTwitchChannel.ForeColor = System.Drawing.Color.White;
            this.lblTwitchChannel.Location = new System.Drawing.Point(12, 205);
            this.lblTwitchChannel.Name = "lblTwitchChannel";
            this.lblTwitchChannel.Size = new System.Drawing.Size(209, 34);
            this.lblTwitchChannel.TabIndex = 9;
            this.lblTwitchChannel.Text = "Twitch Channel";
            // 
            // lblGOsuMemoryPath
            // 
            this.lblGOsuMemoryPath.AutoSize = true;
            this.lblGOsuMemoryPath.Font = new System.Drawing.Font("Franklin Gothic Medium", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGOsuMemoryPath.ForeColor = System.Drawing.Color.White;
            this.lblGOsuMemoryPath.Location = new System.Drawing.Point(12, 246);
            this.lblGOsuMemoryPath.Name = "lblGOsuMemoryPath";
            this.lblGOsuMemoryPath.Size = new System.Drawing.Size(256, 34);
            this.lblGOsuMemoryPath.TabIndex = 11;
            this.lblGOsuMemoryPath.Text = "GOsu Memory Path";
            // 
            // lblBanchoUsername
            // 
            this.lblBanchoUsername.AutoSize = true;
            this.lblBanchoUsername.Font = new System.Drawing.Font("Franklin Gothic Medium", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBanchoUsername.ForeColor = System.Drawing.Color.White;
            this.lblBanchoUsername.Location = new System.Drawing.Point(12, 287);
            this.lblBanchoUsername.Name = "lblBanchoUsername";
            this.lblBanchoUsername.Size = new System.Drawing.Size(244, 34);
            this.lblBanchoUsername.TabIndex = 13;
            this.lblBanchoUsername.Text = "Bancho Username";
            // 
            // lblBanchoPassword
            // 
            this.lblBanchoPassword.AutoSize = true;
            this.lblBanchoPassword.Font = new System.Drawing.Font("Franklin Gothic Medium", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBanchoPassword.ForeColor = System.Drawing.Color.White;
            this.lblBanchoPassword.Location = new System.Drawing.Point(12, 328);
            this.lblBanchoPassword.Name = "lblBanchoPassword";
            this.lblBanchoPassword.Size = new System.Drawing.Size(237, 34);
            this.lblBanchoPassword.TabIndex = 15;
            this.lblBanchoPassword.Text = "Bancho Password";
            // 
            // lblOsuClientId
            // 
            this.lblOsuClientId.AutoSize = true;
            this.lblOsuClientId.Font = new System.Drawing.Font("Franklin Gothic Medium", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOsuClientId.ForeColor = System.Drawing.Color.White;
            this.lblOsuClientId.Location = new System.Drawing.Point(12, 369);
            this.lblOsuClientId.Name = "lblOsuClientId";
            this.lblOsuClientId.Size = new System.Drawing.Size(179, 34);
            this.lblOsuClientId.TabIndex = 17;
            this.lblOsuClientId.Text = "Osu Client ID";
            // 
            // lblOsuClientSecret
            // 
            this.lblOsuClientSecret.AutoSize = true;
            this.lblOsuClientSecret.Font = new System.Drawing.Font("Franklin Gothic Medium", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOsuClientSecret.ForeColor = System.Drawing.Color.White;
            this.lblOsuClientSecret.Location = new System.Drawing.Point(12, 410);
            this.lblOsuClientSecret.Name = "lblOsuClientSecret";
            this.lblOsuClientSecret.Size = new System.Drawing.Size(232, 34);
            this.lblOsuClientSecret.TabIndex = 19;
            this.lblOsuClientSecret.Text = "Osu Client Secret";
            // 
            // lblStarLimit
            // 
            this.lblStarLimit.AutoSize = true;
            this.lblStarLimit.Font = new System.Drawing.Font("Franklin Gothic Medium", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStarLimit.ForeColor = System.Drawing.Color.White;
            this.lblStarLimit.Location = new System.Drawing.Point(12, 451);
            this.lblStarLimit.Name = "lblStarLimit";
            this.lblStarLimit.Size = new System.Drawing.Size(140, 34);
            this.lblStarLimit.TabIndex = 22;
            this.lblStarLimit.Text = "Star Limit";
            // 
            // lblTwitchMessage
            // 
            this.lblTwitchMessage.AutoSize = true;
            this.lblTwitchMessage.Font = new System.Drawing.Font("Franklin Gothic Medium", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTwitchMessage.ForeColor = System.Drawing.Color.White;
            this.lblTwitchMessage.Location = new System.Drawing.Point(12, 492);
            this.lblTwitchMessage.Name = "lblTwitchMessage";
            this.lblTwitchMessage.Size = new System.Drawing.Size(215, 34);
            this.lblTwitchMessage.TabIndex = 24;
            this.lblTwitchMessage.Text = "Twitch Message";
            // 
            // lblOsuIrcMessage
            // 
            this.lblOsuIrcMessage.AutoSize = true;
            this.lblOsuIrcMessage.Font = new System.Drawing.Font("Franklin Gothic Medium", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOsuIrcMessage.ForeColor = System.Drawing.Color.White;
            this.lblOsuIrcMessage.Location = new System.Drawing.Point(12, 533);
            this.lblOsuIrcMessage.Name = "lblOsuIrcMessage";
            this.lblOsuIrcMessage.Size = new System.Drawing.Size(220, 34);
            this.lblOsuIrcMessage.TabIndex = 26;
            this.lblOsuIrcMessage.Text = "Osu Irc Message";
            // 
            // lblNowPlayingMessage
            // 
            this.lblNowPlayingMessage.AutoSize = true;
            this.lblNowPlayingMessage.Font = new System.Drawing.Font("Franklin Gothic Medium", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNowPlayingMessage.ForeColor = System.Drawing.Color.White;
            this.lblNowPlayingMessage.Location = new System.Drawing.Point(12, 574);
            this.lblNowPlayingMessage.Name = "lblNowPlayingMessage";
            this.lblNowPlayingMessage.Size = new System.Drawing.Size(288, 34);
            this.lblNowPlayingMessage.TabIndex = 28;
            this.lblNowPlayingMessage.Text = "Now Playing Message";
            // 
            // lblStarLimitMessage
            // 
            this.lblStarLimitMessage.AutoSize = true;
            this.lblStarLimitMessage.Font = new System.Drawing.Font("Franklin Gothic Medium", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStarLimitMessage.ForeColor = System.Drawing.Color.White;
            this.lblStarLimitMessage.Location = new System.Drawing.Point(12, 615);
            this.lblStarLimitMessage.Name = "lblStarLimitMessage";
            this.lblStarLimitMessage.Size = new System.Drawing.Size(258, 34);
            this.lblStarLimitMessage.TabIndex = 30;
            this.lblStarLimitMessage.Text = "Star Limit Message";
            // 
            // dtbStarLimitMessage
            // 
            this.dtbStarLimitMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(53)))));
            this.dtbStarLimitMessage.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.dtbStarLimitMessage.BorderFocusColor = System.Drawing.Color.HotPink;
            this.dtbStarLimitMessage.BorderRadius = 15;
            this.dtbStarLimitMessage.BorderSize = 2;
            this.dtbStarLimitMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtbStarLimitMessage.ForeColor = System.Drawing.Color.White;
            this.dtbStarLimitMessage.IsFocused = false;
            this.dtbStarLimitMessage.IsPasswordChar = false;
            this.dtbStarLimitMessage.IsPlaceholder = true;
            this.dtbStarLimitMessage.Location = new System.Drawing.Point(299, 615);
            this.dtbStarLimitMessage.Margin = new System.Windows.Forms.Padding(4);
            this.dtbStarLimitMessage.Multiline = false;
            this.dtbStarLimitMessage.Name = "dtbStarLimitMessage";
            this.dtbStarLimitMessage.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.dtbStarLimitMessage.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.dtbStarLimitMessage.PlaceholderText = "<red_exclamation> Sorry The star level exceeds the limit.";
            this.dtbStarLimitMessage.Size = new System.Drawing.Size(250, 32);
            this.dtbStarLimitMessage.TabIndex = 31;
            this.dtbStarLimitMessage.Texts = "";
            this.dtbStarLimitMessage.UnderlinedStyle = true;
            // 
            // dtbNowPlayingMessage
            // 
            this.dtbNowPlayingMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(53)))));
            this.dtbNowPlayingMessage.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.dtbNowPlayingMessage.BorderFocusColor = System.Drawing.Color.HotPink;
            this.dtbNowPlayingMessage.BorderRadius = 15;
            this.dtbNowPlayingMessage.BorderSize = 2;
            this.dtbNowPlayingMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtbNowPlayingMessage.ForeColor = System.Drawing.Color.White;
            this.dtbNowPlayingMessage.IsFocused = false;
            this.dtbNowPlayingMessage.IsPasswordChar = false;
            this.dtbNowPlayingMessage.IsPlaceholder = true;
            this.dtbNowPlayingMessage.Location = new System.Drawing.Point(299, 574);
            this.dtbNowPlayingMessage.Margin = new System.Windows.Forms.Padding(4);
            this.dtbNowPlayingMessage.Multiline = false;
            this.dtbNowPlayingMessage.Name = "dtbNowPlayingMessage";
            this.dtbNowPlayingMessage.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.dtbNowPlayingMessage.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.dtbNowPlayingMessage.PlaceholderText = "Here you go! <beatmap_url>";
            this.dtbNowPlayingMessage.Size = new System.Drawing.Size(250, 32);
            this.dtbNowPlayingMessage.TabIndex = 29;
            this.dtbNowPlayingMessage.Texts = "";
            this.dtbNowPlayingMessage.UnderlinedStyle = true;
            // 
            // dtbOsuIrcMessage
            // 
            this.dtbOsuIrcMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(53)))));
            this.dtbOsuIrcMessage.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.dtbOsuIrcMessage.BorderFocusColor = System.Drawing.Color.HotPink;
            this.dtbOsuIrcMessage.BorderRadius = 15;
            this.dtbOsuIrcMessage.BorderSize = 2;
            this.dtbOsuIrcMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtbOsuIrcMessage.ForeColor = System.Drawing.Color.White;
            this.dtbOsuIrcMessage.IsFocused = false;
            this.dtbOsuIrcMessage.IsPasswordChar = false;
            this.dtbOsuIrcMessage.IsPlaceholder = true;
            this.dtbOsuIrcMessage.Location = new System.Drawing.Point(299, 533);
            this.dtbOsuIrcMessage.Margin = new System.Windows.Forms.Padding(4);
            this.dtbOsuIrcMessage.Multiline = false;
            this.dtbOsuIrcMessage.Name = "dtbOsuIrcMessage";
            this.dtbOsuIrcMessage.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.dtbOsuIrcMessage.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.dtbOsuIrcMessage.PlaceholderText = "[<user_sent>] > [https://osu.ppy.sh/b/<beatmap_id> <artist> - <title> [<version>]" +
    "] <music_note_emoji> <length> <star_emoji> <star_rating> BPM:<bpm> AR:<ar> OD:<o" +
    "d>";
            this.dtbOsuIrcMessage.Size = new System.Drawing.Size(250, 32);
            this.dtbOsuIrcMessage.TabIndex = 27;
            this.dtbOsuIrcMessage.Texts = "";
            this.dtbOsuIrcMessage.UnderlinedStyle = true;
            // 
            // dtbTwitchMessage
            // 
            this.dtbTwitchMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(53)))));
            this.dtbTwitchMessage.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.dtbTwitchMessage.BorderFocusColor = System.Drawing.Color.HotPink;
            this.dtbTwitchMessage.BorderRadius = 15;
            this.dtbTwitchMessage.BorderSize = 2;
            this.dtbTwitchMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtbTwitchMessage.ForeColor = System.Drawing.Color.White;
            this.dtbTwitchMessage.IsFocused = false;
            this.dtbTwitchMessage.IsPasswordChar = false;
            this.dtbTwitchMessage.IsPlaceholder = true;
            this.dtbTwitchMessage.Location = new System.Drawing.Point(299, 492);
            this.dtbTwitchMessage.Margin = new System.Windows.Forms.Padding(4);
            this.dtbTwitchMessage.Multiline = false;
            this.dtbTwitchMessage.Name = "dtbTwitchMessage";
            this.dtbTwitchMessage.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.dtbTwitchMessage.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.dtbTwitchMessage.PlaceholderText = "[RECEIVED] > <user_sent> [<ranked_status>] <artist> - <title> [<version>] <music_" +
    "note_emoji> <length> <star_emoji> <star_rating> BPM:<bpm> AR:<ar> OD:<od>";
            this.dtbTwitchMessage.Size = new System.Drawing.Size(250, 32);
            this.dtbTwitchMessage.TabIndex = 25;
            this.dtbTwitchMessage.Texts = "";
            this.dtbTwitchMessage.UnderlinedStyle = true;
            // 
            // dtbStarLimit
            // 
            this.dtbStarLimit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(53)))));
            this.dtbStarLimit.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.dtbStarLimit.BorderFocusColor = System.Drawing.Color.HotPink;
            this.dtbStarLimit.BorderRadius = 15;
            this.dtbStarLimit.BorderSize = 2;
            this.dtbStarLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtbStarLimit.ForeColor = System.Drawing.Color.White;
            this.dtbStarLimit.IsFocused = false;
            this.dtbStarLimit.IsPasswordChar = false;
            this.dtbStarLimit.IsPlaceholder = true;
            this.dtbStarLimit.Location = new System.Drawing.Point(299, 451);
            this.dtbStarLimit.Margin = new System.Windows.Forms.Padding(4);
            this.dtbStarLimit.Multiline = false;
            this.dtbStarLimit.Name = "dtbStarLimit";
            this.dtbStarLimit.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.dtbStarLimit.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.dtbStarLimit.PlaceholderText = "12.99";
            this.dtbStarLimit.Size = new System.Drawing.Size(250, 32);
            this.dtbStarLimit.TabIndex = 23;
            this.dtbStarLimit.Texts = "";
            this.dtbStarLimit.UnderlinedStyle = true;
            // 
            // dbSave
            // 
            this.dbSave.BackColor = System.Drawing.Color.Green;
            this.dbSave.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.dbSave.BorderRadius = 20;
            this.dbSave.BorderSize = 0;
            this.dbSave.FlatAppearance.BorderSize = 0;
            this.dbSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dbSave.Font = new System.Drawing.Font("Franklin Gothic Medium", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dbSave.ForeColor = System.Drawing.Color.White;
            this.dbSave.Location = new System.Drawing.Point(580, 606);
            this.dbSave.Name = "dbSave";
            this.dbSave.Size = new System.Drawing.Size(140, 40);
            this.dbSave.TabIndex = 21;
            this.dbSave.Text = "Save";
            this.dbSave.UseVisualStyleBackColor = false;
            this.dbSave.Click += new System.EventHandler(this.dbSave_Click);
            // 
            // dtbOsuClientSecret
            // 
            this.dtbOsuClientSecret.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(53)))));
            this.dtbOsuClientSecret.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.dtbOsuClientSecret.BorderFocusColor = System.Drawing.Color.HotPink;
            this.dtbOsuClientSecret.BorderRadius = 15;
            this.dtbOsuClientSecret.BorderSize = 2;
            this.dtbOsuClientSecret.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtbOsuClientSecret.ForeColor = System.Drawing.Color.White;
            this.dtbOsuClientSecret.IsFocused = false;
            this.dtbOsuClientSecret.IsPasswordChar = true;
            this.dtbOsuClientSecret.IsPlaceholder = true;
            this.dtbOsuClientSecret.Location = new System.Drawing.Point(299, 410);
            this.dtbOsuClientSecret.Margin = new System.Windows.Forms.Padding(4);
            this.dtbOsuClientSecret.Multiline = false;
            this.dtbOsuClientSecret.Name = "dtbOsuClientSecret";
            this.dtbOsuClientSecret.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.dtbOsuClientSecret.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.dtbOsuClientSecret.PlaceholderText = "Osu Client Secret";
            this.dtbOsuClientSecret.Size = new System.Drawing.Size(250, 32);
            this.dtbOsuClientSecret.TabIndex = 20;
            this.dtbOsuClientSecret.Texts = "";
            this.dtbOsuClientSecret.UnderlinedStyle = true;
            // 
            // dtbOsuClientId
            // 
            this.dtbOsuClientId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(53)))));
            this.dtbOsuClientId.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.dtbOsuClientId.BorderFocusColor = System.Drawing.Color.HotPink;
            this.dtbOsuClientId.BorderRadius = 15;
            this.dtbOsuClientId.BorderSize = 2;
            this.dtbOsuClientId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtbOsuClientId.ForeColor = System.Drawing.Color.White;
            this.dtbOsuClientId.IsFocused = false;
            this.dtbOsuClientId.IsPasswordChar = false;
            this.dtbOsuClientId.IsPlaceholder = true;
            this.dtbOsuClientId.Location = new System.Drawing.Point(299, 369);
            this.dtbOsuClientId.Margin = new System.Windows.Forms.Padding(4);
            this.dtbOsuClientId.Multiline = false;
            this.dtbOsuClientId.Name = "dtbOsuClientId";
            this.dtbOsuClientId.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.dtbOsuClientId.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.dtbOsuClientId.PlaceholderText = "Osu Client Id";
            this.dtbOsuClientId.Size = new System.Drawing.Size(250, 32);
            this.dtbOsuClientId.TabIndex = 18;
            this.dtbOsuClientId.Texts = "";
            this.dtbOsuClientId.UnderlinedStyle = true;
            // 
            // dtbBanchoPassword
            // 
            this.dtbBanchoPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(53)))));
            this.dtbBanchoPassword.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.dtbBanchoPassword.BorderFocusColor = System.Drawing.Color.HotPink;
            this.dtbBanchoPassword.BorderRadius = 15;
            this.dtbBanchoPassword.BorderSize = 2;
            this.dtbBanchoPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtbBanchoPassword.ForeColor = System.Drawing.Color.White;
            this.dtbBanchoPassword.IsFocused = false;
            this.dtbBanchoPassword.IsPasswordChar = true;
            this.dtbBanchoPassword.IsPlaceholder = true;
            this.dtbBanchoPassword.Location = new System.Drawing.Point(299, 328);
            this.dtbBanchoPassword.Margin = new System.Windows.Forms.Padding(4);
            this.dtbBanchoPassword.Multiline = false;
            this.dtbBanchoPassword.Name = "dtbBanchoPassword";
            this.dtbBanchoPassword.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.dtbBanchoPassword.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.dtbBanchoPassword.PlaceholderText = "Password";
            this.dtbBanchoPassword.Size = new System.Drawing.Size(250, 32);
            this.dtbBanchoPassword.TabIndex = 16;
            this.dtbBanchoPassword.Texts = "";
            this.dtbBanchoPassword.UnderlinedStyle = true;
            // 
            // dtbBanchoUsername
            // 
            this.dtbBanchoUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(53)))));
            this.dtbBanchoUsername.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.dtbBanchoUsername.BorderFocusColor = System.Drawing.Color.HotPink;
            this.dtbBanchoUsername.BorderRadius = 15;
            this.dtbBanchoUsername.BorderSize = 2;
            this.dtbBanchoUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtbBanchoUsername.ForeColor = System.Drawing.Color.White;
            this.dtbBanchoUsername.IsFocused = false;
            this.dtbBanchoUsername.IsPasswordChar = false;
            this.dtbBanchoUsername.IsPlaceholder = true;
            this.dtbBanchoUsername.Location = new System.Drawing.Point(299, 287);
            this.dtbBanchoUsername.Margin = new System.Windows.Forms.Padding(4);
            this.dtbBanchoUsername.Multiline = false;
            this.dtbBanchoUsername.Name = "dtbBanchoUsername";
            this.dtbBanchoUsername.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.dtbBanchoUsername.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.dtbBanchoUsername.PlaceholderText = "Username";
            this.dtbBanchoUsername.Size = new System.Drawing.Size(250, 32);
            this.dtbBanchoUsername.TabIndex = 14;
            this.dtbBanchoUsername.Texts = "";
            this.dtbBanchoUsername.UnderlinedStyle = true;
            // 
            // dtbGOsuMemoryPath
            // 
            this.dtbGOsuMemoryPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(53)))));
            this.dtbGOsuMemoryPath.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.dtbGOsuMemoryPath.BorderFocusColor = System.Drawing.Color.HotPink;
            this.dtbGOsuMemoryPath.BorderRadius = 15;
            this.dtbGOsuMemoryPath.BorderSize = 2;
            this.dtbGOsuMemoryPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtbGOsuMemoryPath.ForeColor = System.Drawing.Color.White;
            this.dtbGOsuMemoryPath.IsFocused = false;
            this.dtbGOsuMemoryPath.IsPasswordChar = false;
            this.dtbGOsuMemoryPath.IsPlaceholder = true;
            this.dtbGOsuMemoryPath.Location = new System.Drawing.Point(299, 246);
            this.dtbGOsuMemoryPath.Margin = new System.Windows.Forms.Padding(4);
            this.dtbGOsuMemoryPath.Multiline = false;
            this.dtbGOsuMemoryPath.Name = "dtbGOsuMemoryPath";
            this.dtbGOsuMemoryPath.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.dtbGOsuMemoryPath.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.dtbGOsuMemoryPath.PlaceholderText = "http://127.0.0.1:24050/json";
            this.dtbGOsuMemoryPath.Size = new System.Drawing.Size(250, 32);
            this.dtbGOsuMemoryPath.TabIndex = 12;
            this.dtbGOsuMemoryPath.Texts = "";
            this.dtbGOsuMemoryPath.UnderlinedStyle = true;
            // 
            // dtbTwitchChannel
            // 
            this.dtbTwitchChannel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(53)))));
            this.dtbTwitchChannel.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.dtbTwitchChannel.BorderFocusColor = System.Drawing.Color.HotPink;
            this.dtbTwitchChannel.BorderRadius = 15;
            this.dtbTwitchChannel.BorderSize = 2;
            this.dtbTwitchChannel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtbTwitchChannel.ForeColor = System.Drawing.Color.White;
            this.dtbTwitchChannel.IsFocused = false;
            this.dtbTwitchChannel.IsPasswordChar = false;
            this.dtbTwitchChannel.IsPlaceholder = true;
            this.dtbTwitchChannel.Location = new System.Drawing.Point(299, 205);
            this.dtbTwitchChannel.Margin = new System.Windows.Forms.Padding(4);
            this.dtbTwitchChannel.Multiline = false;
            this.dtbTwitchChannel.Name = "dtbTwitchChannel";
            this.dtbTwitchChannel.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.dtbTwitchChannel.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.dtbTwitchChannel.PlaceholderText = "Channel";
            this.dtbTwitchChannel.Size = new System.Drawing.Size(250, 32);
            this.dtbTwitchChannel.TabIndex = 10;
            this.dtbTwitchChannel.Texts = "";
            this.dtbTwitchChannel.UnderlinedStyle = true;
            // 
            // dtbTwitchPassword
            // 
            this.dtbTwitchPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(53)))));
            this.dtbTwitchPassword.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.dtbTwitchPassword.BorderFocusColor = System.Drawing.Color.HotPink;
            this.dtbTwitchPassword.BorderRadius = 15;
            this.dtbTwitchPassword.BorderSize = 2;
            this.dtbTwitchPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtbTwitchPassword.ForeColor = System.Drawing.Color.White;
            this.dtbTwitchPassword.IsFocused = false;
            this.dtbTwitchPassword.IsPasswordChar = true;
            this.dtbTwitchPassword.IsPlaceholder = true;
            this.dtbTwitchPassword.Location = new System.Drawing.Point(299, 164);
            this.dtbTwitchPassword.Margin = new System.Windows.Forms.Padding(4);
            this.dtbTwitchPassword.Multiline = false;
            this.dtbTwitchPassword.Name = "dtbTwitchPassword";
            this.dtbTwitchPassword.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.dtbTwitchPassword.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.dtbTwitchPassword.PlaceholderText = "Password";
            this.dtbTwitchPassword.Size = new System.Drawing.Size(250, 32);
            this.dtbTwitchPassword.TabIndex = 8;
            this.dtbTwitchPassword.Texts = "";
            this.dtbTwitchPassword.UnderlinedStyle = true;
            // 
            // dtbTwitchUsername
            // 
            this.dtbTwitchUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(53)))));
            this.dtbTwitchUsername.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.dtbTwitchUsername.BorderFocusColor = System.Drawing.Color.HotPink;
            this.dtbTwitchUsername.BorderRadius = 15;
            this.dtbTwitchUsername.BorderSize = 2;
            this.dtbTwitchUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtbTwitchUsername.ForeColor = System.Drawing.Color.White;
            this.dtbTwitchUsername.IsFocused = false;
            this.dtbTwitchUsername.IsPasswordChar = false;
            this.dtbTwitchUsername.IsPlaceholder = true;
            this.dtbTwitchUsername.Location = new System.Drawing.Point(299, 123);
            this.dtbTwitchUsername.Margin = new System.Windows.Forms.Padding(4);
            this.dtbTwitchUsername.Multiline = false;
            this.dtbTwitchUsername.Name = "dtbTwitchUsername";
            this.dtbTwitchUsername.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.dtbTwitchUsername.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.dtbTwitchUsername.PlaceholderText = "Username";
            this.dtbTwitchUsername.Size = new System.Drawing.Size(250, 32);
            this.dtbTwitchUsername.TabIndex = 6;
            this.dtbTwitchUsername.Texts = "";
            this.dtbTwitchUsername.UnderlinedStyle = true;
            // 
            // tsUseUpdater
            // 
            this.tsUseUpdater.AutoSize = true;
            this.tsUseUpdater.Location = new System.Drawing.Point(308, 80);
            this.tsUseUpdater.MinimumSize = new System.Drawing.Size(20, 30);
            this.tsUseUpdater.Name = "tsUseUpdater";
            this.tsUseUpdater.OffBackColor = System.Drawing.Color.Gray;
            this.tsUseUpdater.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.tsUseUpdater.OnBackColor = System.Drawing.Color.MediumSlateBlue;
            this.tsUseUpdater.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.tsUseUpdater.Size = new System.Drawing.Size(87, 30);
            this.tsUseUpdater.TabIndex = 3;
            this.tsUseUpdater.Text = "toggleSlider1";
            this.tsUseUpdater.UseVisualStyleBackColor = true;
            // 
            // dtbPrefix
            // 
            this.dtbPrefix.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(53)))));
            this.dtbPrefix.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.dtbPrefix.BorderFocusColor = System.Drawing.Color.HotPink;
            this.dtbPrefix.BorderRadius = 15;
            this.dtbPrefix.BorderSize = 2;
            this.dtbPrefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtbPrefix.ForeColor = System.Drawing.Color.White;
            this.dtbPrefix.IsFocused = false;
            this.dtbPrefix.IsPasswordChar = false;
            this.dtbPrefix.IsPlaceholder = true;
            this.dtbPrefix.Location = new System.Drawing.Point(299, 41);
            this.dtbPrefix.Margin = new System.Windows.Forms.Padding(4);
            this.dtbPrefix.Multiline = false;
            this.dtbPrefix.Name = "dtbPrefix";
            this.dtbPrefix.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.dtbPrefix.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.dtbPrefix.PlaceholderText = "!";
            this.dtbPrefix.Size = new System.Drawing.Size(250, 32);
            this.dtbPrefix.TabIndex = 1;
            this.dtbPrefix.Texts = "";
            this.dtbPrefix.UnderlinedStyle = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(1010, 508);
            this.Controls.Add(this.dtbStarLimitMessage);
            this.Controls.Add(this.lblStarLimitMessage);
            this.Controls.Add(this.dtbNowPlayingMessage);
            this.Controls.Add(this.lblNowPlayingMessage);
            this.Controls.Add(this.dtbOsuIrcMessage);
            this.Controls.Add(this.lblOsuIrcMessage);
            this.Controls.Add(this.dtbTwitchMessage);
            this.Controls.Add(this.lblTwitchMessage);
            this.Controls.Add(this.dtbStarLimit);
            this.Controls.Add(this.lblStarLimit);
            this.Controls.Add(this.dbSave);
            this.Controls.Add(this.dtbOsuClientSecret);
            this.Controls.Add(this.lblOsuClientSecret);
            this.Controls.Add(this.dtbOsuClientId);
            this.Controls.Add(this.lblOsuClientId);
            this.Controls.Add(this.dtbBanchoPassword);
            this.Controls.Add(this.lblBanchoPassword);
            this.Controls.Add(this.dtbBanchoUsername);
            this.Controls.Add(this.lblBanchoUsername);
            this.Controls.Add(this.dtbGOsuMemoryPath);
            this.Controls.Add(this.lblGOsuMemoryPath);
            this.Controls.Add(this.dtbTwitchChannel);
            this.Controls.Add(this.lblTwitchChannel);
            this.Controls.Add(this.dtbTwitchPassword);
            this.Controls.Add(this.lblTwitchPassword);
            this.Controls.Add(this.dtbTwitchUsername);
            this.Controls.Add(this.lblTwitchUsername);
            this.Controls.Add(this.lblConfigurationSettings);
            this.Controls.Add(this.tsUseUpdater);
            this.Controls.Add(this.lblUseUpdater);
            this.Controls.Add(this.dtbPrefix);
            this.Controls.Add(this.lblPrefix);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblPrefix;
        private CustomControls.DesignTextBox dtbPrefix;
        private Label lblUseUpdater;
        private CustomControls.ToggleSlider tsUseUpdater;
        private Label lblConfigurationSettings;
        private Label lblTwitchUsername;
        private CustomControls.DesignTextBox dtbTwitchUsername;
        private Label lblTwitchPassword;
        private CustomControls.DesignTextBox dtbTwitchPassword;
        private Label lblTwitchChannel;
        private CustomControls.DesignTextBox dtbTwitchChannel;
        private Label lblGOsuMemoryPath;
        private CustomControls.DesignTextBox dtbGOsuMemoryPath;
        private Label lblBanchoUsername;
        private CustomControls.DesignTextBox dtbBanchoUsername;
        private Label lblBanchoPassword;
        private CustomControls.DesignTextBox dtbBanchoPassword;
        private Label lblOsuClientId;
        private CustomControls.DesignTextBox dtbOsuClientId;
        private Label lblOsuClientSecret;
        private CustomControls.DesignTextBox dtbOsuClientSecret;
        private CustomControls.DesignButton dbSave;
        private Label lblStarLimit;
        private CustomControls.DesignTextBox dtbStarLimit;
        private Label lblTwitchMessage;
        private CustomControls.DesignTextBox dtbTwitchMessage;
        private Label lblOsuIrcMessage;
        private CustomControls.DesignTextBox dtbOsuIrcMessage;
        private Label lblNowPlayingMessage;
        private CustomControls.DesignTextBox dtbNowPlayingMessage;
        private Label lblStarLimitMessage;
        private CustomControls.DesignTextBox dtbStarLimitMessage;
    }
}