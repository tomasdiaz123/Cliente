using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using TESTE;

namespace ServidorForm
{
    public partial class Server : Form
    {
        int cnt = 0;
        int num;
        byte[] data = new byte[1024];
         UdpClient newsock = new UdpClient(new IPEndPoint(IPAddress.Any, 9050));
        IPEndPoint mandar = new IPEndPoint(IPAddress.Any, 8080);
        public Server()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            num = rnd.Next(1, 100);
            lstMensagens.Items.Clear();
            lstMensagens.Items.Add("A aguardar...");
            data = newsock.Receive(ref mandar);
            string resposta = "";
            lstMensagens.Items.Add(Encoding.ASCII.GetString(data, 0, data.Length));
            do
            {
                
                data = newsock.Receive(ref mandar);
                string ola = Encoding.ASCII.GetString(data, 0, data.Length);
                if (ola=="Jogar")
                {
                    cnt++;
                    if(cnt%2==0)
                    {
                        resposta = "ataque";
                    }
                }
                else
                {
                    data = newsock.Receive(ref mandar);
                    data = Encoding.ASCII.GetBytes(resposta);
                    newsock.Send(data, data.Length, mandar);
                    
                }
                    lstMensagens.Items.Add(resposta);
                    data = Encoding.ASCII.GetBytes(resposta);

                    newsock.Send(data, data.Length, mandar);
                    data = newsock.Receive(ref mandar);
                    resposta = Encoding.ASCII.GetString(data, 0, data.Length);
                    
            } while (resposta != "Fim");


        }

        private void btnSend_Click(object sender, EventArgs e)
        {
          
                
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Server_Load(object sender, EventArgs e)
        {

        }

        private void lstMensagens_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }

