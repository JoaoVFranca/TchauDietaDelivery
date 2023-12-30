using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Classes
{
    internal class InsertionSort
    {

        // implementando insertion sort
        public static Product[] Sort(Product[] produtos)
        {
            for (int i = 1; i < produtos.Length; i++)
            {
                Product aux = produtos[i];
                int j = i - 1;

                while (j >= 0 && produtos[j].Preco > aux.Preco)
                {
                    produtos[j + 1] = produtos[j];
                    j = j - 1;
                }
                produtos[j + 1] = aux;
            }
            return produtos;
        }
    }
}
