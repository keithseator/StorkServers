using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace StorkServers
{
    class RemoteDesktopControllerTabPage : TabPage
    {
        private AxMSTSCLib.AxMsRdpClient8NotSafeForScripting rdp = null;

        protected override void OnCreateControl()
        {
            rdp = new AxMSTSCLib.AxMsRdpClient8NotSafeForScripting();

            rdp.OnDisconnected += new AxMSTSCLib.IMsTscAxEvents_OnDisconnectedEventHandler(rdpc_OnDisconnected);
            this.Controls.Add(rdp);
            rdp.Dock = DockStyle.Fill;
            base.OnCreateControl();
        }

        void rdpc_OnDisconnected(object sender, AxMSTSCLib.IMsTscAxEvents_OnDisconnectedEvent e)
        {
            ((TabControl)this.Parent).TabPages.Remove(this);
            //sqlCon.rdpCount--;
        }

        private void SetRdpClientProperties()
        {
            //string pathToCredent = Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%\\Remote Desktop Console\\Cred\\Cred_id.txt");
            //string decryptedUserName = "";
            //string decryptedPassword = "";
            //MessageBox.Show(System.IO.File.Exists(pathToCredent) ? "File exists." : "File does not exist.");

            // Read the encrypted credentials from Cred_id.txt then decrypt them to two strings
            //if (File.Exists(pathToCredent))
            //{
            //    string[] lines = System.IO.File.ReadAllLines(pathToCredent);
            //    SimpleAES aes = new SimpleAES();
            //    decryptedUserName = aes.DecryptString(lines[0]);
            //    decryptedPassword = aes.DecryptString(lines[1]);
            //}

            //rdp.Server = parMachine.Name;
            //rdp.UserName = decryptedUserName;
            //rdp.Domain = "rbg";

            rdp.Server = "192.168.80.11";
            rdp.UserName = "administrator";
            rdp.Domain = "k";

            //rdp.AdvancedSettings8.ClearTextPassword = decryptedPassword;
            //rdp.AdvancedSettings8.EnableCredSspSupport = true;

            rdp.AdvancedSettings8.ClearTextPassword = "a";
            rdp.AdvancedSettings8.EnableCredSspSupport = true;
            rdp.AdvancedSettings8.NegotiateSecurityLayer = true;

            rdp.Dock = DockStyle.Fill;
        }

        public void Connect(Server serverNameorIP)
        {
            //MessageBox.Show(serverNameorIP.Name);
            SetRdpClientProperties();
            rdp.Server = serverNameorIP.IP_Address;
            rdp.Connect();
        }
    }
}
