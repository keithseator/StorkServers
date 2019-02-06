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

        public static List<Location> locations = new List<Location>();
        public static List<Server> servers = new List<Server>();


        public MainConsole()
        {
            InitializeComponent();

            LoadTree();

        }

        void LoadTree()
        {
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
            }
            treeViewServers.ExpandAll();

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            var treeViewServer = treeViewServers.SelectedNode.Text;
            Server selectedServer = servers.Find(s => s.Name == treeViewServer);

            RemoteDesktopControllerTabPage insRdpTp = new RemoteDesktopControllerTabPage();
            this.tabControl1.ItemSize = new Size(100, 19);
            this.tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabPages.Add(insRdpTp);
            tabControl1.SelectTab(insRdpTp);
            insRdpTp.Connect(selectedServer);
        }

        private void btnAddServer(object sender, EventArgs e)
        {
            MessageBox.Show("hello");
        }
    }
}
