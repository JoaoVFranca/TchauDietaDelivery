using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Classes;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            ProductManager.FetchAllProducts();
            OrderManager.FetchOrders();
            InitializeComponent();
            this.PreencheCards();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void PreencheCards()
        {
            Product[] produtos = ProductManager.GetAllExtras();

            produtos = InsertionSort.Sort(produtos);

            Label[] camposNome = { nome1, nome2, nome3, nome4, nome5, nome6, nome7, nome8, nome9, nome10 };
            PictureBox[] camposFoto = { foto1, foto2, foto3, foto4, foto5, foto6, foto7, foto8, foto9, foto10 };
            Label[] camposPreco = { preco1, preco2, preco3, preco4, preco5, preco6, preco7, preco8, preco9, preco10 };

            for (int i = 0; i < produtos.Length; i++)
            {
                camposNome[i].Text = produtos[i].Nome;
                camposFoto[i].Image = produtos[i].GetImageObject();
                camposPreco[i].Text = "R$" + produtos[i].Preco.ToString("0.00");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NumericUpDown[] camposQuant = { qtd1, qtd2, qtd3, qtd4, qtd5, qtd6, qtd7, qtd8, qtd9, qtd10 };

            Product[] produtos = ProductManager.GetAllExtras();
            produtos = InsertionSort.Sort(produtos);

            ProductLinkedList listaProdutos = new ProductLinkedList();
            for (int i = 0; i < produtos.Length; i++)
            {
                if (camposQuant[i].Value > 0)
                {
                    produtos[i].Quantidade = (int)camposQuant[i].Value;
                    listaProdutos.AddLast(produtos[i]);
                }
            }

            Program.carrinho.pedido.SetAcompanhamentos(listaProdutos);

            Form5 f5 = new Form5();
            f5.ShowDialog();
        }
    }
}
