using Models.Entities;
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
            DgvHistory.DataSource = new List<ResponseLog>();
            dgvClient.DataSource = new List<Client>();
            server = new Server()
            {
                OnReceiveData = UpdateRequest,
                OnClientConnectionStateChanged = UpdateClient
            };
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            if (!server.IsListening())
            {
                string ipAddress = txtIpAddress.Text;
                int port = Convert.ToInt32(txtPort.Text);
                try
                {
                    server.Listen(ipAddress, port);
                    ConnectionStateChanged(true);
                }
                catch(SocketException)
                {
                    MessageBox.Show($"Can't start server on {ipAddress}:{port}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                server.Disconnect();
                ConnectionStateChanged(false);
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

        public void UpdateRequest(List<ResponseLog> requests)
        {
            DgvHistory.Invoke(new MethodInvoker(delegate
            {
                DgvHistory.DataSource = null;
                DgvHistory.DataSource = requests;
            }));
        }

        public void ConnectionStateChanged(bool state)
        {
            txtIpAddress.Enabled = !state;
            txtPort.Enabled = !state;
            lbState.Text = state ? "Listening" : "Idle";
            lbState.BackColor = state ? Color.Green : Color.IndianRed;
            btnListen.Text = state ? "Shut down" : "Start";
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            server.Disconnect();
        }
    }
}
