using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Classes;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        public static readonly string root_path = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
        public static Carrinho carrinho;
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ApplicationExit += OnAppExit;
            Application.Run(new Form1());
        }

        private static void OnAppExit(object sender, EventArgs e)
        {
            OrderManager.SaveAllOrders();
        }

    }
}
