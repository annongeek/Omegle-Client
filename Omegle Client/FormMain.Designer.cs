﻿namespace Omegle_Client
{
    partial class FormMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.startSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startSessionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textChat = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textOutPut = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startSessionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(495, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // startSessionToolStripMenuItem
            // 
            this.startSessionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startSessionToolStripMenuItem1,
            this.disconnectSessionToolStripMenuItem,
            this.reconnectToolStripMenuItem});
            this.startSessionToolStripMenuItem.Name = "startSessionToolStripMenuItem";
            this.startSessionToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.startSessionToolStripMenuItem.Text = "Main";
            // 
            // startSessionToolStripMenuItem1
            // 
            this.startSessionToolStripMenuItem1.Name = "startSessionToolStripMenuItem1";
            this.startSessionToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.startSessionToolStripMenuItem1.Text = "Connect";
            this.startSessionToolStripMenuItem1.Click += new System.EventHandler(this.startSessionToolStripMenuItem1_Click);
            // 
            // disconnectSessionToolStripMenuItem
            // 
            this.disconnectSessionToolStripMenuItem.Name = "disconnectSessionToolStripMenuItem";
            this.disconnectSessionToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.disconnectSessionToolStripMenuItem.Text = "Disconnect";
            this.disconnectSessionToolStripMenuItem.Click += new System.EventHandler(this.disconnectSessionToolStripMenuItem_Click);
            // 
            // reconnectToolStripMenuItem
            // 
            this.reconnectToolStripMenuItem.Name = "reconnectToolStripMenuItem";
            this.reconnectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.reconnectToolStripMenuItem.Text = "Reconnect";
            this.reconnectToolStripMenuItem.Click += new System.EventHandler(this.reconnectToolStripMenuItem_Click);
            // 
            // textChat
            // 
            this.textChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textChat.Location = new System.Drawing.Point(12, 36);
            this.textChat.Name = "textChat";
            this.textChat.Size = new System.Drawing.Size(471, 339);
            this.textChat.TabIndex = 11;
            this.textChat.Text = "";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(417, 381);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textOutPut
            // 
            this.textOutPut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textOutPut.Location = new System.Drawing.Point(12, 384);
            this.textOutPut.Name = "textOutPut";
            this.textOutPut.Size = new System.Drawing.Size(399, 20);
            this.textOutPut.TabIndex = 12;
            this.textOutPut.TextChanged += new System.EventHandler(this.textOutPut_TextChanged);
            this.textOutPut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textOutPut_KeyDown);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 407);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.textChat);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textOutPut);
            this.Name = "FormMain";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem startSessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startSessionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem disconnectSessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reconnectToolStripMenuItem;
        private System.Windows.Forms.RichTextBox textChat;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textOutPut;
    }
}

