using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace UsagiConnect.WForms.CustomControls
{
    public partial class DesignTextBox : UserControl
    {
        private Color borderColor = Color.MediumSlateBlue;
        private Color borderFocusColor = Color.HotPink;
        private Color placeholderColor = Color.DarkGray;
        private string placeholderText = string.Empty;
        private int borderSize = 2;
        private int borderRadius = 0;
        private bool underlinedStyle = false;
        private bool isFocused = false;
        private bool isPlaceholder = false;
        private bool isPasswordChar = false;

        public event EventHandler _TextChanged;

        public DesignTextBox()
        {
            InitializeComponent();
        }

        public Color BorderColor { get => borderColor; set { borderColor = value; this.Invalidate(); } }
        public Color BorderFocusColor { get => borderFocusColor; set { borderFocusColor = value; } }
        public Color PlaceholderColor { get => placeholderColor; set { placeholderColor = value; if (isPlaceholder) textBox1.ForeColor = value; } }
        public override Color BackColor { get { return base.BackColor; }  set { base.BackColor = value; textBox1.BackColor = value; } }
        public override Color ForeColor { get { return base.ForeColor; } set { base.ForeColor = value; textBox1.ForeColor = value; } }
        public override Font Font { get { return base.Font; } set { base.Font = value; textBox1.Font = value; if (this.DesignMode) UpdateControlHeight(); } }
        public string PlaceholderText { get => placeholderText; set { placeholderText = value; textBox1.Text = string.Empty; SetPlaceHolder(); } }
        public string Texts { get { if (isPlaceholder) return string.Empty; else return textBox1.Text; } set { RemovePlaceholder(); textBox1.Text = value; SetPlaceHolder(); } }
        public int BorderSize { get => borderSize; set { borderSize = value; if (value >= 1) { borderSize = value; this.Invalidate(); } } }
        public int BorderRadius { get => borderRadius; set { borderRadius = value; this.Invalidate(); } }
        public bool UnderlinedStyle { get => underlinedStyle; set { underlinedStyle = value; this.Invalidate(); } }
        public bool IsFocused { get => isFocused; set { isFocused = value; this.Invalidate(); } }
        public bool IsPlaceholder { get => isPlaceholder; set { isPlaceholder = value; this.Invalidate(); } }
        public bool IsPasswordChar { get => isPasswordChar; set { isPasswordChar = value; if (!isPlaceholder) textBox1.UseSystemPasswordChar = value; } }
        public bool Multiline { get { return textBox1.Multiline; } set { textBox1.Multiline = value; } }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.DesignMode)
                UpdateControlHeight();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;

            if (borderRadius > 1)
            {
                Rectangle rectBorderSmooth = this.ClientRectangle;
                Rectangle rectBorder = Rectangle.Inflate(rectBorderSmooth, -borderSize, -borderSize);
                int smoothSize = borderSize > 0 ? borderSize : 1;

                using (GraphicsPath pathBorderSmooth = GetFigurePath(rectBorderSmooth, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
                using (Pen penBorderSmooth = new Pen(this.Parent.BackColor, smoothSize))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    this.Region = new Region(pathBorderSmooth);
                    if (borderRadius > 15) SetTextBoxRoundedRegion();
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
                    if (isFocused) penBorder.Color = borderFocusColor;

                    if (underlinedStyle)
                    {
                        graphics.DrawPath(penBorderSmooth, pathBorderSmooth);
                        graphics.SmoothingMode = SmoothingMode.None;
                        graphics.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    }
                    else
                    {
                        graphics.DrawPath(penBorderSmooth, pathBorderSmooth);
                        graphics.DrawPath(penBorder, pathBorder);
                    }
                }
            }
            else
            {
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    this.Region = new Region(this.ClientRectangle);
                    penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                    if (isFocused) penBorder.Color = borderFocusColor;

                    if (underlinedStyle)
                        graphics.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    else
                        graphics.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
                }
            }
        }

        private void SetPlaceHolder()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) && placeholderText != string.Empty)
            {
                isPlaceholder = true;
                textBox1.Text = placeholderText;
                textBox1.ForeColor = placeholderColor;
                if (isPasswordChar)
                    textBox1.UseSystemPasswordChar = false;
            }
        }

        private void RemovePlaceholder()
        {
            if (isPlaceholder && placeholderText != string.Empty)
            {
                isPlaceholder = false;
                textBox1.Text = string.Empty;
                textBox1.ForeColor = this.ForeColor;
                if (isPasswordChar)
                    textBox1.UseSystemPasswordChar = true;
            }
        }

        private GraphicsPath GetFigurePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void SetTextBoxRoundedRegion()
        {
            GraphicsPath pathText;
            if (Multiline)
            {
                pathText = GetFigurePath(textBox1.ClientRectangle, borderRadius - borderSize);
                textBox1.Region = new Region(pathText);
            }
            else
            {
                pathText = GetFigurePath(textBox1.ClientRectangle, borderSize * 2);
                textBox1.Region = new Region(pathText);
            }
            pathText.Dispose();
        }

        private void UpdateControlHeight()
        {
            if (textBox1.Multiline == false)
            {
                int textHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;
                textBox1.Multiline = true;
                textBox1.MinimumSize = new Size(0, textHeight);
                textBox1.Multiline = false;
                this.Height = textBox1.Height + this.Padding.Top + this.Padding.Bottom;
            }    
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _TextChanged?.Invoke(sender, e);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            isFocused = true;
            this.Invalidate();
            if (isPasswordChar)
                textBox1.UseSystemPasswordChar = false;
            RemovePlaceholder();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            isFocused = false;
            this.Invalidate();
            if (isPasswordChar)
                textBox1.UseSystemPasswordChar = true;
            SetPlaceHolder();
        }
    }
}