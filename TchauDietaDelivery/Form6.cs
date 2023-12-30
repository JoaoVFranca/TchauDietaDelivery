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
    public partial class Form6 : Form
    {
        private Pedido order;

        public Form6()
        {
            InitializeComponent();
            this.SetPedido();
        }

        private void SetPedido()
        {
            this.order = Program.carrinho.pedido;
            if (this.order == null) { return; }

            UserManager userManager = new UserManager();
            User solicitante = userManager.FindByEmail(this.order.EmailSolicitante);
            infoNome.Text = solicitante.Nome;
            infoCidade.Text = solicitante.Cidade;
            infoBairro.Text = solicitante.Bairro;
            infoRua.Text = solicitante.Rua;
            infoNumero.Text = solicitante.Numero;

            this.infoEmail.Text = this.order.EmailSolicitante;
            this.infoData.Text = this.order.DataCriacao;
            this.infoHorario.Text = this.order.HorarioCriacao;
            this.statusBar.Value = (this.order.Status + 1) * 25;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.order.Status++;
            if (this.order.Status >= 3)
            {
                timer1.Tick -= this.timer1_Tick;
                this.statusBar.Value = 100;
                OrderManager.DeletePedidoByEmail(this.order.EmailSolicitante);
                return;
            }
            this.statusBar.Value = (this.order.Status + 1) * 25;
        }
    }
}
