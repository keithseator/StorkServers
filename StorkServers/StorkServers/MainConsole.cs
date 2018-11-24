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
    public partial class MainConsole : Form
    {
        List<Location> locations = new List<Location>();
        List<Server> servers = new List<Server>();


        public MainConsole()
        {
            InitializeComponent();

            DataAccess db = new DataAccess();
            servers = db.GetServers();
            locations = db.GetLocations();

            foreach (Location location in locations)
            {
                treeViewServers.Nodes.Add(location.Location_Name);
            }

            foreach (Server server in servers)
            {
                TreeNode[] treeNodes = treeViewServers.Nodes
                                    .Cast<TreeNode>()
                                    .Where(r => r.Text == server.Location_Name)
                                    .ToArray();

                treeNodes[0].Nodes.Add(server.Name);

                //foreach (TreeNode tr in treeNodes)
                //{
                //    //MessageBox.Show(tr.ToString());
                //    tr.Nodes.Add(server.Name);
                //}
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            RemoteDesktopControllerTabPage insRdpTp = new RemoteDesktopControllerTabPage();
            this.tabControl1.ItemSize = new Size(100, 19);
            this.tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabPages.Add(insRdpTp);
            tabControl1.SelectTab(insRdpTp);
            insRdpTp.Connect();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

        }
    }
}
