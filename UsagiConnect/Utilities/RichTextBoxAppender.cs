using System.Drawing;
using System.Windows.Forms;
using log4net.Appender;
using log4net.Core;

namespace UsagiConnect.Utilities
{
    public class RichTextBoxAppender : AppenderSkeleton
    {
        private RichTextBox _textBox;
        public RichTextBox AppenderTextBox { get { return _textBox; } set { _textBox = value; } }
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
            if (_textBox == null)
            {
                if (string.IsNullOrEmpty(FormName) || string.IsNullOrEmpty(TextBoxName)) return;

                Form form = Application.OpenForms[FormName];
                if (form == null) return;

                _textBox = (RichTextBox)FindControlRecursive(form, TextBoxName);
                if (_textBox == null) return;

                form.FormClosing += (s, e) => _textBox = null;
            }

            _textBox.BeginInvoke((MethodInvoker)delegate
            {
                if (loggingEvent.Level == Level.Debug)
                {
                    _textBox.SelectionStart = _textBox.TextLength;
                    _textBox.SelectionLength = 0;
                    _textBox.SelectionColor = Color.RoyalBlue;
                    _textBox.AppendText(RenderLoggingEvent(loggingEvent));
                    _textBox.SelectionColor = _textBox.ForeColor;
                }
                else if (loggingEvent.Level == Level.Info)
                {
                    _textBox.SelectionStart = _textBox.TextLength;
                    _textBox.SelectionLength = 0;
                    _textBox.SelectionColor = Color.Black;
                    _textBox.AppendText(RenderLoggingEvent(loggingEvent));
                    _textBox.SelectionColor = _textBox.ForeColor;
                }
                else if (loggingEvent.Level == Level.Warn)
                {
                    _textBox.SelectionStart = _textBox.TextLength;
                    _textBox.SelectionLength = 0;
                    _textBox.SelectionColor = Color.DarkOrange;
                    _textBox.AppendText(RenderLoggingEvent(loggingEvent));
                    _textBox.SelectionColor = _textBox.ForeColor;
                }
                else if (loggingEvent.Level == Level.Error)
                {
                    _textBox.SelectionStart = _textBox.TextLength;
                    _textBox.SelectionLength = 0;
                    _textBox.SelectionColor = Color.DarkRed;
                    _textBox.AppendText(RenderLoggingEvent(loggingEvent));
                    _textBox.SelectionColor = _textBox.ForeColor;
                }
                else if (loggingEvent.Level == Level.Fatal)
                {
                    _textBox.SelectionStart = _textBox.TextLength;
                    _textBox.SelectionLength = 0;
                    _textBox.SelectionColor = Color.Crimson;
                    _textBox.AppendText(RenderLoggingEvent(loggingEvent));
                    _textBox.SelectionColor = _textBox.ForeColor;
                }
                else
                {
                    _textBox.AppendText(RenderLoggingEvent(loggingEvent));
                }
            });
        }
    }
}