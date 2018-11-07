using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace StorkServers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            RemoteDesktopControllerTabPage insRdpTp = new RemoteDesktopControllerTabPage();
            //insRdpTp.Text = _curServer.Name;
            this.tabControl1.ItemSize = new Size(100, 19);
            this.tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabPages.Add(insRdpTp);
            tabControl1.SelectTab(insRdpTp);
            insRdpTp.Connect();
            //sqlCon.rdpCount++;
            //tsbDisconnect.Enabled = true;
        }
    }
}
