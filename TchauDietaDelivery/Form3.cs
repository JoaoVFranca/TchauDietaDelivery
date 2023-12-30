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
    public partial class Form3 : Form
    {

        public Form3()
        {
            ProductManager.FetchAllProducts();
            OrderManager.FetchOrders();

            InitializeComponent();

            this.PreencheCards();
        }

        private void PreencheCards()
        {
            Product[] produtos = ProductManager.GetAllProducts();
            produtos = InsertionSort.Sort(produtos);

            Label[] camposNome = { nome1, nome2, nome3, nome4, nome5, nome6, nome7, nome8 };
            PictureBox[] camposFoto = { foto1, foto2, foto3, foto4, foto5, foto6, foto7, foto8 };
            Label[] camposPreco = { preco1, preco2, preco3, preco4, preco5, preco6, preco7, preco8 };

            for (int i = 0; i < produtos.Length; i++)
            {
                camposNome[i].Text = produtos[i].Nome;
                camposFoto[i].Image = produtos[i].GetImageObject();
                camposPreco[i].Text = "R$" + produtos[i].Preco.ToString("0.00");
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            NumericUpDown[] camposQuant = { quant1, quant2, quant3, quant4, quant5, quant6, quant7, quant8 };

            int quantidadeTotal = 0;

            Product[] produtos = ProductManager.GetAllProducts();
            produtos = InsertionSort.Sort(produtos);

            ProductLinkedList listaProdutos = new ProductLinkedList();
            for (int i = 0; i < produtos.Length; i++)
            {
                if (camposQuant[i].Value > 0)
                {
                    quantidadeTotal += (int) camposQuant[i].Value;
                    produtos[i].Quantidade = (int)camposQuant[i].Value;
                    listaProdutos.AddLast(produtos[i]);
                }
            }

            if (quantidadeTotal <= 0)
            {
                MessageBox.Show("Favor selecionar ao menos uma unidade de algum produto.", "Selecione os produtos");
                return;
            }

            Pedido novoPedido = new Pedido(UserManager.LoggedUserEmail);
            novoPedido.SetProdutos(listaProdutos);

            Program.carrinho.setPedido(novoPedido);

            Form4 TelaAcompanhamentos = new Form4();
            TelaAcompanhamentos.ShowDialog();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
