using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Omegle_Client
{
    public partial class FormMain : Form
    {
        private float fontSize = 9;
        private string fontName = "Tahoma";
        public static OmegleLibrary _omegle;
        public Thread typingWorker; //This is to handleing our typing in the textOutPut.
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

        private void startSessionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _omegle.Connect();
        }

        private void disconnectSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _omegle.Disconnect();
        }

        private void reconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _omegle.Reconnect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _omegle.SendMessage(textOutPut.Text);
            Chat("Self: ", Color.Blue, FontStyle.Bold, false);
            Chat(textOutPut.Text, Color.Black, FontStyle.Regular, true);
            textOutPut.Text = "";
        }

        void TypingHandle()
        {
            if (textOutPut.Text != "")
            {
                _omegle.StartTyping();
            }
            else
            {
                _omegle.StopTyping();
            }
        }

        private void textOutPut_TextChanged(object sender, EventArgs e)
        {
            typingWorker = new Thread(new ThreadStart(TypingHandle));
            typingWorker.Start();
        }

        private void textOutPut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }
    }
}
