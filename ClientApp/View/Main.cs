using ClientApp.Models;
using ClientApp.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace ClientApp.View
{
    public partial class Main : Form
    {
        private Client client;
        public Main()
        {
            InitializeComponent();
            InitLanguageSelector();
            DgvHistory.DataSource = new List<Request>();
        }
        private void InitLanguageSelector()
        {
            CbbLanguages.Items.AddRange(new CbbItem[]
            {
               new CbbItem { Key = "vi", Text = "Việt Nam" },
               new CbbItem { Key = "en", Text = "English" },
               new CbbItem { Key = "sp", Text = "Spain" },
            });
            CbbLanguages.SelectedIndex = 0;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (client != null && client.IsConnected())
            {
                string data = txtInput.Text;
                client.Send(data);
            }
            else
            {
                MessageBox.Show("You haven't connected to server yet", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClientDisconnectToServer();
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            
            if(client != null)
            {
                client.Disconnect();
                client = null;
                ClientDisconnectToServer();
            }
            else
            {
                string ipAddress = txtIpAddress.Text;
                int port = Convert.ToInt32(txtPort.Text);
                try
                {
                    client = new Client(ipAddress, port)
                    {
                        OnReceiveMessage = receiveData,
                        OnDisconnected = Disconnected
                    };
                    ClientConnectToServer();
                }
                catch (SocketException)
                {
                    MessageBox.Show("Can't connect to server", "notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }        
            }
        }

        private void ClientConnectToServer()
        {
            txtIpAddress.Enabled = false;
            txtPort.Enabled = false;
            lbConnecting.Text = "Connecting";
            lbConnecting.BackColor = Color.Green;
            btnConnect.Text = "Disconnect";
        }

        private void ClientDisconnectToServer()
        {
            txtIpAddress.Enabled = true;
            txtPort.Enabled = true;
            lbConnecting.Text = "Idle";
            lbConnecting.BackColor = Color.IndianRed;
            btnConnect.Text = "Connect";
        }

        private void receiveData(string data) 
        {
            DgvHistory.Invoke(new MethodInvoker(() =>
            {
                txtResult.Text = data;
                DgvHistory.DataSource = null;
                DgvHistory.DataSource = RequestRepository.GetInstance().Repository;
            }));
        }

        private void Disconnected()
        {
            Invoke(new MethodInvoker(() =>
            {
                MessageBox.Show("Server has been shut down", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClientDisconnectToServer();
            }));
        }
    }
}
