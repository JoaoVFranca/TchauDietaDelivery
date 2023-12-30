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
    public partial class CADASTRO : Form
    {
        public CADASTRO()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void onButton2Click(object sender, EventArgs e) // Botão de cadastro
        {

            string[] values =
            {
                textBox1.Text, // Nome
                textBox7.Text, // Celular
                textBox9.Text, // Email
                textBox8.Text, // Senha
                textBox6.Text, // Confirmar Senha            
                textBox2.Text, // Rua
                textBox3.Text, // Bairro
                textBox4.Text, // Cidade
                textBox5.Text // Numero
            };

            foreach (string value in values)
            {
                if (value == String.Empty)
                {
                    MessageBox.Show("Favor informar todos os campos.", "Campos obrigatórios");
                    return;
                }
            }

            if (values[3] != values[4])
            {
                MessageBox.Show("As senhas estão diferentes.", "Senha não coerente");
                return;
            }

            User newUser = new User();
            newUser.Nome = values[0];
            newUser.Celular = values[1];
            newUser.Email = values[2];

            newUser.Senha = PasswordHash.Create(values[3]);

            newUser.Rua = values[5];
            newUser.Bairro = values[6];
            newUser.Cidade = values[7];
            newUser.Numero = values[8];

            UserManager UM = new UserManager();
            int result = UM.Cadastrar(newUser);

            if (result == 0)
            {
                DialogResult DR = MessageBox.Show("Usuário cadastrado com sucesso.", "Sucesso!");
                if (DR == DialogResult.OK) {
                    this.Hide();
                    Form1 form1 = new Form1();
                    form1.ShowDialog();
                    this.Close();
                }
            }
            else if (result == 1)
            {
                MessageBox.Show("Este email já está cadastrado.", "Falha!");
            }
        }
    }
}
