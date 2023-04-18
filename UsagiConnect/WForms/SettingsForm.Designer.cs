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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.designButton1 = new UsagiConnect.WForms.CustomControls.DesignButton();
            this.toggleSlider2 = new UsagiConnect.WForms.CustomControls.ToggleSlider();
            this.toggleSlider1 = new UsagiConnect.WForms.CustomControls.ToggleSlider();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(76, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 13);
            this.textBox1.TabIndex = 1;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Location = new System.Drawing.Point(36, 56);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(55, 13);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.Text = "linkLabel1";
            LinkLabel.Link link = new LinkLabel.Link();
            link.LinkData = "https://osu.ppy.sh/beatmapsets/966339#osu/2023927";
            linkLabel1.Links.Add(link);
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLinkClicked);
            // 
            // designButton1
            // 
            this.designButton1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.designButton1.BorderColor = System.Drawing.Color.Black;
            this.designButton1.BorderRadius = 20;
            this.designButton1.BorderSize = 3;
            this.designButton1.FlatAppearance.BorderSize = 0;
            this.designButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.designButton1.ForeColor = System.Drawing.Color.White;
            this.designButton1.Location = new System.Drawing.Point(299, 304);
            this.designButton1.Name = "designButton1";
            this.designButton1.Size = new System.Drawing.Size(206, 73);
            this.designButton1.TabIndex = 5;
            this.designButton1.Text = "designButton1";
            this.designButton1.UseVisualStyleBackColor = false;
            // 
            // toggleSlider2
            // 
            this.toggleSlider2.ForeColor = System.Drawing.Color.Coral;
            this.toggleSlider2.Location = new System.Drawing.Point(285, 181);
            this.toggleSlider2.MinimumSize = new System.Drawing.Size(45, 22);
            this.toggleSlider2.Name = "toggleSlider2";
            this.toggleSlider2.OffBackColor = System.Drawing.Color.Gray;
            this.toggleSlider2.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.toggleSlider2.OnBackColor = System.Drawing.Color.MediumSlateBlue;
            this.toggleSlider2.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.toggleSlider2.Size = new System.Drawing.Size(87, 40);
            this.toggleSlider2.SolidStyle = false;
            this.toggleSlider2.TabIndex = 4;
            this.toggleSlider2.Text = "toggleSlider2";
            this.toggleSlider2.UseVisualStyleBackColor = true;
            // 
            // toggleSlider1
            // 
            this.toggleSlider1.AutoSize = true;
            this.toggleSlider1.Location = new System.Drawing.Point(188, 141);
            this.toggleSlider1.MinimumSize = new System.Drawing.Size(30, 22);
            this.toggleSlider1.Name = "toggleSlider1";
            this.toggleSlider1.OffBackColor = System.Drawing.Color.WhiteSmoke;
            this.toggleSlider1.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.toggleSlider1.OnBackColor = System.Drawing.Color.MediumSlateBlue;
            this.toggleSlider1.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.toggleSlider1.Size = new System.Drawing.Size(87, 22);
            this.toggleSlider1.TabIndex = 3;
            this.toggleSlider1.Text = "toggleSlider1";
            this.toggleSlider1.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(49)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(755, 508);
            this.Controls.Add(this.designButton1);
            this.Controls.Add(this.toggleSlider2);
            this.Controls.Add(this.toggleSlider1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private CustomControls.ToggleSlider toggleSlider1;
        private CustomControls.ToggleSlider toggleSlider2;
        private CustomControls.DesignButton designButton1;
    }
}