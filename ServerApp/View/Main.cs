using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerApp.View
{
    public partial class Main : Form
    {
        private Server server;
        public Main()
        {
            InitializeComponent();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            if (server == null)
            {
                string ipAddress = txtIpAddress.Text;
                int port = Convert.ToInt32(txtPort.Text);
                try
                {
                    server = new Server(ipAddress, port)
                    {
                        RequestProcessHanlder = UpdateRequest,
                        ClientConnectedHandler = UpdateClient
                    };
                    server.Listen();
                    OnServerListeningHandler();
                }
                catch(SocketException)
                {
                    MessageBox.Show($"Can't start server on {ipAddress}:{port}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                server.Disconnect();
                server = null;
                OnServerShutDownHandler();
            }
        }

        public void UpdateClient(List<Client> clients)
        {
            Invoke(new MethodInvoker(delegate
            {
                dgvClient.DataSource = null;
                dgvClient.DataSource = clients;
            }));
        }

        public void UpdateRequest(List<Request> requests)
        {
            DgvHistory.Invoke(new MethodInvoker(delegate
            {
                DgvHistory.DataSource = null;
                DgvHistory.DataSource = requests;
            }));
        }

        private void OnServerListeningHandler()
        {
            txtIpAddress.Enabled = false;
            txtPort.Enabled = false;
            lbState.Text = "Listening";
            lbState.BackColor = Color.Green;
            btnListen.Text = "Shut down";
        }

        private void OnServerShutDownHandler()
        {
            txtIpAddress.Enabled = true;
            txtPort.Enabled = true;
            lbState.Text = "Idle";
            lbState.BackColor = Color.IndianRed;
            btnListen.Text = "Listening";
        }
    }
}
