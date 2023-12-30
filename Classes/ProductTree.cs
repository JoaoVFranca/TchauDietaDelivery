using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Classes
{
    internal class ProductTreeNode
    {
        public Product Data { get; set; }
        public ProductTreeNode Left { get; set; }
        public ProductTreeNode Right { get; set; }

        public ProductTreeNode(Product data)
        {
            Data = data;
        }
    }
    internal class ProductTree
    {

        private ProductTreeNode root;
        public ProductTree()
        {
            root = null;
        }

        public void Insert(Product data)
        {
            root = Insert(root, data);
        }

        private ProductTreeNode Insert(ProductTreeNode root, Product data)
        {
            if (root == null)
            {
                root = new ProductTreeNode(data);
                return root;
            }

            if (data.Id < root.Data.Id)
            {
                root.Left = Insert(root.Left, data);
            }
            else if (data.Id > root.Data.Id)
            {
                root.Right = Insert(root.Right, data);
            }

            return root;
        }

        public void InOrderTraversal()
        {
            InOrderTraversal(root);
        }

        private void InOrderTraversal(ProductTreeNode root)
        {
            if (root != null)
            {
                InOrderTraversal(root.Left);
                Console.WriteLine($"Id: {root.Data.Id}, Name: {root.Data.Nome}, Price: {root.Data.Preco}");
                InOrderTraversal(root.Right);
            }
        }

        public Product GetProductById(int id)
        {
            return GetProductById(root, id);
        }

        private Product GetProductById(ProductTreeNode root, int id)
        {
            if (root == null || root.Data.Id == id)
            {
                return root?.Data.Copy();
            }

            if (id < root.Data.Id)
            {
                return GetProductById(root.Left, id);
            }

            return GetProductById(root.Right, id);
        }

        public Product[] GetProductsOrdered()
        {
            List<Product> products = new List<Product>();
            InOrder(root, products);
            return products.ToArray();
        }

        private void InOrder(ProductTreeNode root, List<Product> products)
        {
            if (root != null)
            {
                InOrder(root.Left, products);
                products.Add(root.Data.Copy());
                InOrder(root.Right, products);
            }
        }
    }
}
