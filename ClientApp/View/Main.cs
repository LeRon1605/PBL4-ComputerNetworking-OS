using ClientApp.Models;
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
        private void lbInput_Click(object sender, EventArgs e)
        {

        }

        private void lbHistory_Click(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string data = txtInput.Text;
            client.Send(data);
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
                client = new Client()
                {
                    OnReceiveMessage = receiveData
                };
                string ipAddress = txtIpAddress.Text;
                int port = Convert.ToInt32(txtPort.Text);
                try
                {
                    client.Connect(ipAddress, port);
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
            Invoke(new MethodInvoker(() =>
            {
                txtResult.Text = data;  
            }));
        }

        private void txtIpAddress_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
