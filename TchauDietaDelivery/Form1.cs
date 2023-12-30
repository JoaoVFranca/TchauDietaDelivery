using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Classes;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ENTRAR_Click(object sender, EventArgs e)
        {

            string email = textBox2.Text;
            string pass = textBox1.Text;

            if (email == String.Empty || pass == String.Empty)
            {
                MessageBox.Show("Favor informar todos os campos.","Campos obrigatórios");
                return;
            }

            UserManager UM = new UserManager();

            int result = UM.Login(email,pass);

            switch (result)
            {
                case 0:
                    this.ProcessLogin();
                    break;
                case 1:
                    MessageBox.Show("Senha incorreta.", "Falha no login");
                    break;
                case 2:
                    MessageBox.Show("Usuário não encontrado.", "Falha no login");
                    break;
            }
        }

        private void ProcessLogin()
        {
            Program.carrinho = new Carrinho(UserManager.LoggedUserEmail);
            Pedido PedidoExistente = OrderManager.GetPedidoByEmail(UserManager.LoggedUserEmail);
            MessageBox.Show("Bem vindo/a!", "Sucesso!");

            if (PedidoExistente != null)
            {
                if (PedidoExistente.Status == Pedido.StatusRecebido)
                {
                    OrderManager.DeletePedidoByEmail(UserManager.LoggedUserEmail);
                }
                else
                {
                    Program.carrinho.setPedido(PedidoExistente);
                    this.Hide();
                    Form6 form = new Form6();
                    form.ShowDialog();
                    this.Close();
                    return;
                }
            }
            this.Hide();
            Form3 form3 = new Form3();
            form3.ShowDialog();
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            CADASTRO telaCadastro = new CADASTRO();
            this.Hide();
            telaCadastro.ShowDialog();
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.UseSystemPasswordChar = !checkBox1.Checked;
        }
    }
}
