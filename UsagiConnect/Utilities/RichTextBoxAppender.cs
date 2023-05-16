using log4net.Appender;
using log4net.Core;
using System.Drawing;
using System.Windows.Forms;

namespace UsagiConnect.Utilities
{
    public class RichTextBoxAppender : AppenderSkeleton
    {
        private RichTextBox textbox;
        public RichTextBox AppenderTextBox { get { return textbox; } set { textbox = value; } }
        public string FormName { get; set; }
        public string TextBoxName { get; set; }

        private Control FindControlRecursive(Control root, string textBoxName)
        {
            if (root.Name == textBoxName) return root;
            foreach (Control control in root.Controls)
            {
                Control cont = FindControlRecursive(control, textBoxName);
                if (cont != null)
                    return cont;
            }
            return null;
        }

        protected override void Append(LoggingEvent loggingEvent)
        {
            if (textbox == null)
            {
                if (string.IsNullOrEmpty(FormName) || string.IsNullOrEmpty(TextBoxName)) return;

                Form form = Application.OpenForms[FormName];
                if (form == null) return;

                textbox = (RichTextBox)FindControlRecursive(form, TextBoxName);
                if (textbox == null) return;

                form.FormClosing += (s, e) => textbox = null;
            }

            textbox.BeginInvoke((MethodInvoker)delegate
            {
                if (loggingEvent.Level == Level.Debug)
                {
                    textbox.SelectionStart = textbox.TextLength;
                    textbox.SelectionLength = 0;
                    textbox.SelectionColor = Color.RoyalBlue;
                    textbox.AppendText(RenderLoggingEvent(loggingEvent));
                    textbox.SelectionColor = textbox.ForeColor;
                }
                else if (loggingEvent.Level == Level.Info)
                {
                    textbox.SelectionStart = textbox.TextLength;
                    textbox.SelectionLength = 0;
                    textbox.SelectionColor = Color.White;
                    textbox.AppendText(RenderLoggingEvent(loggingEvent));
                    textbox.SelectionColor = textbox.ForeColor;
                }
                else if (loggingEvent.Level == Level.Warn)
                {
                    textbox.SelectionStart = textbox.TextLength;
                    textbox.SelectionLength = 0;
                    textbox.SelectionColor = Color.DarkOrange;
                    textbox.AppendText(RenderLoggingEvent(loggingEvent));
                    textbox.SelectionColor = textbox.ForeColor;
                }
                else if (loggingEvent.Level == Level.Error)
                {
                    textbox.SelectionStart = textbox.TextLength;
                    textbox.SelectionLength = 0;
                    textbox.SelectionColor = Color.DarkRed;
                    textbox.AppendText(RenderLoggingEvent(loggingEvent));
                    textbox.SelectionColor = textbox.ForeColor;
                }
                else if (loggingEvent.Level == Level.Fatal)
                {
                    textbox.SelectionStart = textbox.TextLength;
                    textbox.SelectionLength = 0;
                    textbox.SelectionColor = Color.Crimson;
                    textbox.AppendText(RenderLoggingEvent(loggingEvent));
                    textbox.SelectionColor = textbox.ForeColor;
                }
                else
                {
                    textbox.AppendText(RenderLoggingEvent(loggingEvent));
                }
            });
        }
    }
}