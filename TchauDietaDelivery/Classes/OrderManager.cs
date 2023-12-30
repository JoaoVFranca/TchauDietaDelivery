using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Classes
{
    internal class OrderManager
    {
        private static OrderLinkedList AllOrders;

        private static string file_path = Program.root_path + "\\Arquivos\\pedidos.txt";

        public OrderManager() {
            FetchOrders();
        }

        public static void FetchOrders()
        {
            if (AllOrders != null) { return; }

            AllOrders = new OrderLinkedList();

            string[] allOrders = File.ReadAllLines(file_path);

            foreach (string line in allOrders)
            {
                if (line == String.Empty) { continue; }
                Pedido novoPedido = new Pedido();
                novoPedido.FillByString(line);
                AllOrders.AddLast(novoPedido);
            }
        }

        public static Pedido GetPedidoByEmail(string email)
        {
            if (AllOrders == null) { FetchOrders(); }
            return AllOrders.FindByEmail(email);
        }

        public static void DeletePedidoByEmail(string email)
        {
            if (AllOrders == null) { FetchOrders(); }
            if (AllOrders.isEmpty()) { return; }
            AllOrders.RemoveByEmail(email);
        }

        public static void AddOrderToList(Pedido novo)
        {
            if (AllOrders == null) { FetchOrders(); }

            AllOrders.AddLast(novo);
        }

        public static void SaveAllOrders()
        {
            if (AllOrders == null || AllOrders.isEmpty()) { return; }
            using (StreamWriter file_writer = new StreamWriter(file_path))
            {
                file_writer.WriteLine(AllOrders.toString());
            }
        }
    }
}
