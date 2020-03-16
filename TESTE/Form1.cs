using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TESTE
{
    public partial class Form1 : Form
    {
        Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        byte[] data = new byte[1024];
        EndPoint mandar = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);
        EndPoint Remote = (EndPoint)new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);
        char[,] poisicoes = new char[10, 10];
        char[] Colunas =  { 'A', 'B', 'C', 'D', 'E', 'F','G', 'H', 'I', 'J' };
        public Form1()
        {
            InitializeComponent();
        }

        private void brnInserir_Click(object sender, EventArgs e)
        {
            bool T;
           
            
                    char[] LOL =new char[5];
                    for(int idx=0;idx<5;idx++)
                    {
                        string LOL2 = cmbNavios.SelectedItem.ToString();
                        LOL[idx]= LOL2[idx];
                    }

            if (chkVertical.Checked == true)
                T = EscreverNaviosV(LOL[0]);
            else
                    T=EscreverNaviosH(LOL[0]);
            if (T == false)
            {
                MessageBox.Show("ERRO ESPACO INSUFECIENTE", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                if (LOL[4] == '1')
                    cmbNavios.Items.RemoveAt(cmbNavios.SelectedIndex);
                else
                {
                    int dada;
                    dada = Convert.ToInt32(LOL[4]);
                    dada = dada - 49;

                    string texto = "";
                    for (int idx2 = 0; idx2 < 5; idx2++)
                    {
                        if (idx2 != 4)
                            texto += LOL[idx2];
                        else
                            texto += dada;
                    }
                    
                    texto += ')';
                    cmbNavios.Items.RemoveAt(cmbNavios.SelectedIndex);
                    cmbNavios.Items.Add(texto);
                    cmbNavios.Text = texto;
                   
                }
                     if (cmbNavios.Items.Count == 0)
                        btnFeito.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
        }

        private void cmbNavios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private bool EscreverNaviosH(char cnt)
        {
            int cntL;
            string navio = "lbl" + txtColunaD.Text.ToUpper() + txtLinhas.Text;
            for(cntL=0; ;cntL++)
            {
                if (txtColunaD.Text.ToUpper() == Colunas[cntL].ToString())
                    break;
            }
            if(cnt=='5')
            {
                if (cntL >= 6)
                    return false;
            }
            if (cnt == '4')
            {
                if (cntL >= 7)
                    return false;
            }
            if (cnt == '3')
            {
                if (cntL >= 8)
                    return false;
            }
            if (cnt == '2')
            {
                if (cntL >= 9)
                    return false;
            }

            foreach (Control espaco in groupBox1.Controls)
            {
                if (cnt == '5')
                {

                    if (espaco.Name == navio || espaco.Name == "lbl" + Colunas[cntL + 1] + txtLinhas.Text || espaco.Name == "lbl" + Colunas[cntL + 2] + txtLinhas.Text || espaco.Name == "lbl" + Colunas[cntL + 3] + txtLinhas.Text ||
                         espaco.Name == "lbl" + Colunas[cntL + 4] + txtLinhas.Text)
                    {
                        poisicoes[cntL, Convert.ToInt32(txtLinhas.Text)] = 'O';
                        poisicoes[cntL+1, Convert.ToInt32(txtLinhas.Text)] = 'O';
                        poisicoes[cntL+2, Convert.ToInt32(txtLinhas.Text)] = 'O';
                        poisicoes[cntL+3, Convert.ToInt32(txtLinhas.Text)] = 'O';
                        poisicoes[cntL+4, Convert.ToInt32(txtLinhas.Text)] = 'O';
                        espaco.Name += 'O';
                        espaco.Text = "0";
                        espaco.Visible = true;
                       
                    }
                }

                if (cnt == '4')
                {
                    if (espaco.Name == navio || espaco.Name == "lbl" + Colunas[cntL + 1] + txtLinhas.Text || espaco.Name == "lbl" + Colunas[cntL + 2] + txtLinhas.Text || espaco.Name == "lbl" + Colunas[cntL + 3] + txtLinhas.Text)
                    {
                        poisicoes[cntL, Convert.ToInt32(txtLinhas.Text)] = 'O';
                        poisicoes[cntL + 1, Convert.ToInt32(txtLinhas.Text)] = 'O';
                        poisicoes[cntL + 2, Convert.ToInt32(txtLinhas.Text)] = 'O';
                        poisicoes[cntL + 3, Convert.ToInt32(txtLinhas.Text)] = 'O';
                        espaco.Name += 'O';
                        espaco.Text = "0";
                        espaco.Visible = true;
                    }
                }
                if ( cnt == '3')
                {
                    if (espaco.Name == navio || espaco.Name == "lbl" + Colunas[cntL + 1] + txtLinhas.Text || espaco.Name == "lbl" + Colunas[cntL + 2] + txtLinhas.Text || espaco.Name == "lbl" )
                    {
                        poisicoes[cntL, Convert.ToInt32(txtLinhas.Text)] = 'O';
                        poisicoes[cntL + 1, Convert.ToInt32(txtLinhas.Text)] = 'O';
                        poisicoes[cntL + 2, Convert.ToInt32(txtLinhas.Text)] = 'O';
                        espaco.Name += 'O';
                        espaco.Text = "0";
                        espaco.Visible = true;
                    }
                }
                if(cnt=='2')
                {
                    if (espaco.Name == navio || espaco.Name == "lbl" + Colunas[cntL + 1] + txtLinhas.Text )
                    {
                        poisicoes[cntL, Convert.ToInt32(txtLinhas.Text)] = 'O';
                        poisicoes[cntL + 1, Convert.ToInt32(txtLinhas.Text)] = 'O';
                        espaco.Name += 'O';
                        espaco.Text = "0";
                        espaco.Visible = true;
                    }
                }
                
            }
            return true;
        }
        private bool EscreverNaviosV(char cnt)
        {
            int cntL;
            string navio = "lbl" + txtColunaD.Text.ToUpper() + txtLinhas.Text;
            for (cntL = 0; ; cntL++)
            {
                if (txtColunaD.Text.ToUpper() == Colunas[cntL].ToString())
                    break;
            }
            if (cnt == '5')
            {
                if (Convert.ToInt32(txtLinhas.Text) >= 6)
                    return false;
            }
            if (cnt == '4')
            {
                if (Convert.ToInt32(txtLinhas.Text) >= 7)
                    return false;
            }
            if (cnt == '3')
            {
                if (Convert.ToInt32(txtLinhas.Text) >= 8)
                    return false;
            }
            if (cnt == '2')
            {
                if (Convert.ToInt32(txtLinhas.Text) >= 9)
                    return false;
            }

            foreach (Control espaco in groupBox1.Controls)
            {
                if (cnt == '5')
                {
                    
                    if (espaco.Name == navio || espaco.Name == "lbl" + Colunas[cntL] + Convert.ToString(Convert.ToInt32(txtLinhas.Text) + 1) || espaco.Name == "lbl" + Colunas[cntL] + Convert.ToString(Convert.ToInt32(txtLinhas.Text) + 2) || espaco.Name == "lbl" + Colunas[cntL] + Convert.ToString(Convert.ToInt32(txtLinhas.Text) + 3) ||
                         espaco.Name == "lbl" + Colunas[cntL] + Convert.ToString(Convert.ToInt32(txtLinhas.Text) + 4))
                    {
                        poisicoes[cntL, Convert.ToInt32(txtLinhas.Text)]='O';
                        poisicoes[cntL, Convert.ToInt32(txtLinhas.Text)+1] = 'O';
                        poisicoes[cntL, Convert.ToInt32(txtLinhas.Text)+2] = 'O';
                        poisicoes[cntL, Convert.ToInt32(txtLinhas.Text)+3] = 'O';
                        poisicoes[cntL, Convert.ToInt32(txtLinhas.Text)+4] = 'O';
                        espaco.Name += 'O';
                        espaco.Text = "0";
                        espaco.Visible = true;
                    }
                }

                if (cnt == '4')
                {
                    if (espaco.Name == navio || espaco.Name == "lbl" + Colunas[cntL] + Convert.ToString(Convert.ToInt32(txtLinhas.Text) + 1) || espaco.Name == "lbl" + Colunas[cntL] + Convert.ToString(Convert.ToInt32(txtLinhas.Text) + 2) || espaco.Name == "lbl" + Colunas[cntL] + Convert.ToString(Convert.ToInt32(txtLinhas.Text) + 3))
                    {
                        poisicoes[cntL, Convert.ToInt32(txtLinhas.Text)] = 'O';
                        poisicoes[cntL, Convert.ToInt32(txtLinhas.Text) + 1] = 'O';
                        poisicoes[cntL, Convert.ToInt32(txtLinhas.Text) + 2] = 'O';
                        poisicoes[cntL, Convert.ToInt32(txtLinhas.Text) + 3] = 'O';
                        espaco.Name += 'O';
                        espaco.Text = "0";
                        espaco.Visible = true;
                    }
                }
                if (cnt == '3')
                {
                    if (espaco.Name == navio || espaco.Name == "lbl" + Colunas[cntL] + Convert.ToString(Convert.ToInt32(txtLinhas.Text) + 1) || espaco.Name == "lbl" + Colunas[cntL] + Convert.ToString(Convert.ToInt32(txtLinhas.Text) + 2))
                    {
                        poisicoes[cntL, Convert.ToInt32(txtLinhas.Text)] = 'O';
                        poisicoes[cntL, Convert.ToInt32(txtLinhas.Text) + 1] = 'O';
                        poisicoes[cntL, Convert.ToInt32(txtLinhas.Text) + 2] = 'O';
                        espaco.Name += 'O';
                        espaco.Text = "0";
                        espaco.Visible = true;
                    }
                }
                if (cnt == '2')
                {
                    if (espaco.Name == navio || espaco.Name == "lbl" + Colunas[cntL] + Convert.ToString(Convert.ToInt32(txtLinhas.Text) + 1))
                    {
                        poisicoes[cntL, Convert.ToInt32(txtLinhas.Text)] = 'O';
                        poisicoes[cntL, Convert.ToInt32(txtLinhas.Text) + 1] = 'O';
                        espaco.Name += 'O';
                        espaco.Text = "0";
                        espaco.Visible = true;
                    }
                }

            }
            return true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Atacar();
            int cntL;
            string input = txtColunaI.Text+txtLinhaI.Text, stringData;

            byte[] ola = new byte[1024];
            Data data = new Data();
            data.strMessage = input;
            ola = data.ToByte();
            server.BeginSendTo(ola, 0, ola.Length, SocketFlags.None, mandar,
                                    new AsyncCallback(OnSend), mandar);
            lblPosiçao.Text = "Defender";
            
            
            lblPosiçao.Text = "Atacar";
        }

        private void Atacar()
        {
            int cntL;
            string navio = "lbl" + txtColunaI.Text.ToUpper() + txtLinhaI.Text+"I";
            for (cntL = 0; ; cntL++)
            {
                if (txtColunaI.Text.ToUpper() == Colunas[cntL].ToString())
                    break;
            }
            foreach (Control espaco in groupBox1.Controls)
            {
                if (espaco.Name == navio )
                {

                    espaco.Text = "0";
                    espaco.Visible = true;
                }
            }

        }

        private void txtColunaD_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsLetter(ch) && ch != 8)
            {
                e.Handled = true;
            }

        }

        private void btnFeito_Click(object sender, EventArgs e)
        {
            string input = "Jogar", stringData;
          
            server.SendTo(Encoding.ASCII.GetBytes(input), Remote);
            if (lblPosiçao.Enabled == false)
            {
                lblPosiçao.Enabled = true;
            }
            foreach (Label espaco in groupBox1.Controls)
            {
                espaco.ForeColor = Color.Gray;
            }
            byte[] ola = new byte[1024];
            Data data = new Data();
            data.strMessage = input;
            ola = data.ToByte();
            server.BeginReceiveFrom(ola, 0, ola.Length, SocketFlags.None, ref mandar,
                                    new AsyncCallback(OnSend), mandar);
            
            btnFeito.Text = "Fim";
            
        }

        public void OnSend(IAsyncResult ar)
        {
            try
            {
                server.EndSend(ar);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Servidor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }   
        private void Atacado(string cord)
        {
            int cntL;
            string recv = cord;
            for (cntL = 0; ; cntL++)
            {
                if (recv[0] == Colunas[cntL])
                    break;
            }
            foreach (Control espaco in groupBox1.Controls)
            {
                if (espaco.Name == "lbl" + Colunas[cntL] + recv[1])
                {
                    if (poisicoes[cntL, Convert.ToInt32(recv[1])] == 'O')
                    {
                        espaco.ForeColor = Color.Red;
                    }
                    else
                    {
                        espaco.Visible = true;
                    }
                }
            }
        }
        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                IPEndPoint ipeSender = new IPEndPoint(IPAddress.Any, 0);
                EndPoint epSender = (EndPoint)ipeSender;

                server.EndReceiveFrom(ar, ref epSender);

                //Transformar o array de bytes recebido do utilizador num objecto de dados
                Data msgReceived = new Data(data);
                Atacado(msgReceived.strMessage);
            }
            catch
            {

            }
        }
        private void txtLinhas_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }

        }
            }

    class Data
    {
        public Data()
        {
            this.cmdCommand = Command.Null;
            this.strMessage = null;
            this.strName = null;
        }

        //Converte os bytes num objecto do tipo Data
        public Data(byte[] data)
        {
            //4 bytes para o comando
            this.cmdCommand = (Command)BitConverter.ToInt32(data, 0);

            //5-8 segundos bytes para o nome
            int nameLen = BitConverter.ToInt32(data, 4);

            //9-12 para a mensagem
            int msgLen = BitConverter.ToInt32(data, 8);

            //Garantir que a string strName passou para o array de bytes
            if (nameLen > 0)
                this.strName = Encoding.UTF8.GetString(data, 12, nameLen);
            else
                this.strName = null;

            //Verificar se a mensagem tem conteúdo
            if (msgLen > 0)
                this.strMessage = Encoding.UTF8.GetString(data, 12 + nameLen, msgLen);
            else
                this.strMessage = null;
        }
        public enum Command
        {
            Login,      //Entrada/conectar
            Logout,     //Saída/desconectar
            Message,    //Envio de mensagem para todos os clientes
            List,       //Obter lista dos utilizadores
            Null        //auxiliar
        }
        //Converter a estrutura de dados num array de bytes
        public byte[] ToByte()
        {
            List<byte> result = new List<byte>();

            //primeiros 4 bytes para o comando
            result.AddRange(BitConverter.GetBytes((int)cmdCommand));

            //adicionar o nome
            if (strName != null)
                result.AddRange(BitConverter.GetBytes(strName.Length));
            else
                result.AddRange(BitConverter.GetBytes(0));

            //adicionar mensagem
            if (strMessage != null)
                result.AddRange(BitConverter.GetBytes(strMessage.Length));
            else
                result.AddRange(BitConverter.GetBytes(0));

            if (strName != null)
                result.AddRange(Encoding.UTF8.GetBytes(strName));

            //adicionar a mensagem
            if (strMessage != null)
                result.AddRange(Encoding.UTF8.GetBytes(strMessage));

            return result.ToArray();
        }

        public string strName;      //Nome do cliente no Chat
        public string strMessage;   //Messagem
        public Command cmdCommand;  //Tipo de comando (login, logout, send message, ...)
    }

}
