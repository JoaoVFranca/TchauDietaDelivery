using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Classes;

namespace WindowsFormsApp1.Classes
{
    internal class ProductManager
    {
        public static int MaxProductAmount = 8;
        public static int MaxExtrasAmount = 10;

        private static ProductTree ProductsTree;
        private static ProductTree ExtrasTree;

        private static string normal_path = Program.root_path + "\\Arquivos\\produtos.txt";
        private static string extras_path = Program.root_path + "\\Arquivos\\extras.txt";
        public ProductManager()
        {
            FetchAllProducts();
        }

        public static void FetchAllProducts()
        {
            FetchProducts();
            FetchExtras();
        }

        private static void FetchExtras()
        {
            if (ExtrasTree != null) { return; }

            string[] productsData = File.ReadAllLines(extras_path);

            ExtrasTree = new ProductTree();

            int index = 0;
            foreach (var data in productsData)
            {
                if (index >= MaxExtrasAmount) { break; }

                Product novo_obj = new Product();
                novo_obj.FillByString(data);
                ExtrasTree.Insert(novo_obj);

            }
        }

        private static void FetchProducts()
        {
            if (ProductsTree != null) { return; }   

            ProductsTree = new ProductTree();

            string[] productsData = File.ReadAllLines(normal_path);

            int index = 0;
            foreach (var data in productsData)
            {
                if (index >= MaxProductAmount) { break; }

                Product novo_obj = new Product();
                novo_obj.FillByString(data);
                ProductsTree.Insert(novo_obj);

            }
        }

        public static Product[] GetAllProducts()
        {
            if (ProductsTree == null) { FetchProducts(); }
            return ProductsTree.GetProductsOrdered();
        }

        public static Product[] GetAllExtras()
        {
            if (ExtrasTree == null) { FetchExtras(); }
            return ExtrasTree.GetProductsOrdered();
        }

        public static ProductLinkedList GetListByIds(string ids, bool extras = false)
        {

            if (ProductsTree == null || ExtrasTree == null) { FetchAllProducts(); }

            ProductLinkedList newList = new ProductLinkedList();

            if (ids == String.Empty) { return newList; }

            ProductTree current = (extras == false) ? ProductsTree : ExtrasTree;
            string[] arrayIds = ids.Split(',');

            for (int i = 0; i < arrayIds.Length; i++)
            {
                string[] prod_quant = arrayIds[i].Split('q'); // [0] -> Id do produto, [1] -> quantidade do produto

                if (prod_quant.Length != 2) { continue; }

                Product produto = current.GetProductById(int.Parse(prod_quant[0])); //ProductSearch.Search(current, int.Parse(arrayIds[i]));
                if (produto != null)
                {
                    produto.Quantidade = int.Parse(prod_quant[1]);
                    newList.AddLast(produto);
                }
            }
            return newList;
        }

    }
}
