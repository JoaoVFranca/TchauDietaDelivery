using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Classes
{
    internal class Carrinho
    {
        public Carrinho(string email) {
            emailProprietario = email;
        }

        public void setPedido(Pedido pedido)
        {
            this.pedido = pedido;
        }

        public Pedido pedido;
        public string emailProprietario;
    }
}
