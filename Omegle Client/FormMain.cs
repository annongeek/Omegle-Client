using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Omegle_Client
{
    public partial class FormMain : Form
    {
        private float fontSize = 9;
        private string fontName = "Tahoma";
        public static OmegleLibrary _omegle;
        public FormMain()
        {
            InitializeComponent();
        }

        public void Chat(string text, Color color, FontStyle style, bool newLine)
        {
            textChat.Invoke(new MethodInvoker(() => textChat.SelectionStart = textChat.TextLength));
            textChat.Invoke(new MethodInvoker(() => textChat.SelectionStart = textChat.TextLength));
            textChat.Invoke(new MethodInvoker(() => textChat.SelectionFont = new Font(fontName, fontSize, style)));
            textChat.Invoke(new MethodInvoker(() => textChat.SelectionColor = color));
            if (newLine)
                textChat.Invoke(new MethodInvoker(() => textChat.SelectedText = text + Environment.NewLine));
            else
                textChat.Invoke(new MethodInvoker(() => textChat.SelectedText = text));
            textChat.Invoke(new MethodInvoker(() => textChat.SelectionStart = textChat.TextLength));
            textChat.Invoke(new MethodInvoker(() => textChat.ScrollToCaret()));
        }
    }
}
