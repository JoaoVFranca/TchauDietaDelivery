using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using WindowsFormsApp1.Classes;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            Gerarpedido();
            Produtos();
        }

        private void Gerarpedido()
        {
            listView1.Columns.Add("Codigo", 30).TextAlign = HorizontalAlignment.Center;
            listView1.Columns.Add("Descrição", 150);
            listView1.Columns.Add("Quantia", 30).TextAlign= HorizontalAlignment.Center;
            listView1.Columns.Add("Preço", 50).TextAlign = HorizontalAlignment.Right;
            
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.MultiSelect = true;
        }

        public void Produtos()
        {
            Pedido pedido = Program.carrinho.pedido;

            float total = 0;

            pedido.Produtos.Rewind();
            Product produto = pedido.Produtos.GetNext();

            while (produto != null)
            {
                this.addProductToList(produto, ref total);
                produto = pedido.Produtos.GetNext();
            }

            pedido.Acompanhamentos.Rewind();
            produto = pedido.Acompanhamentos.GetNext();

            while (produto != null)
            {
                this.addProductToList(produto, ref total);
                produto = pedido.Acompanhamentos.GetNext();
            }

            this.labelPreco.Text = "R$" + total.ToString("0.00");

        }

        private void addProductToList(Product produto, ref float total)
        {
            string[] item = new string[4];

            item[0] = produto.Id.ToString();
            item[1] = produto.Nome;
            item[2] = produto.Quantidade.ToString();
            item[3] = produto.Preco.ToString("0.00");

            total += (produto.Preco * produto.Quantidade);

            listView1.Items.Add(new ListViewItem(item));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonFNZ_Click(object sender, EventArgs e)
        {
            Pedido order = OrderManager.GetPedidoByEmail(UserManager.LoggedUserEmail);

            if (order != null) {
                Program.carrinho.pedido = order;
                MessageBox.Show("Já existe um pedido na fila para você!", "Acompanhe seu pedido");
            } else { 
                OrderManager.AddOrderToList(Program.carrinho.pedido);
            }
            
            Form6 f = new Form6();
            f.ShowDialog();
        }
    }
}
