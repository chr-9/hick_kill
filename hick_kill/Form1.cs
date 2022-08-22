using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace hick_kill
{
    public partial class Form1 : Form
    {
        NotifyIcon notifyIcon;
        public Form1()
        {
            this.ShowInTaskbar = false;
            this.setComponents();
        }


        private void setComponents()
        {
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = Properties.Resources.kill;
            notifyIcon.Visible = true;
            notifyIcon.Text = "";

            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem.Text = "&Quit";
            toolStripMenuItem.Click += ToolStripMenuItem_Click;
            contextMenuStrip.Items.Add(toolStripMenuItem);
            notifyIcon.ContextMenuStrip = contextMenuStrip;

            notifyIcon.MouseDoubleClick += NotifyIcon_Click;
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process[] ps = System.Diagnostics.Process.GetProcessesByName("hick");
            foreach (System.Diagnostics.Process p in ps)
            {
                p.Kill();
            }
        }


        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}