using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Classes;

class Node
{
    public Product Data { get; set; }
    public Node Next { get; set; }
    public Node Previous { get; set; }

    public Node(Product product)
    {
        Data = product;
    }
}

namespace WindowsFormsApp1.Classes
{
    internal class ProductLinkedList
    {
        private Node first;
        private Node last;
        private int count;

        private Node iterator;

        public bool IsEmpty()
        {
            return count == 0;
        }

        public Product GetFirst()
        {
            if (IsEmpty())
            {
                return null;
            }

            return first.Data;
        }

        public Product GetLast()
        {
            if (IsEmpty())
            {
                return null;
            }

            return last.Data;
        }

        public void AddFirst(Product product)
        {
            Node newNode = new Node(product);

            if (IsEmpty())
            {
                first = newNode;
                last = newNode;
            }
            else
            {
                newNode.Next = first;
                first.Previous = newNode;
                first = newNode;
            }

            count++;
        }

        public void AddLast(Product product)
        {
            Node newNode = new Node(product);

            if (IsEmpty())
            {
                first = newNode;
                last = newNode;
            }
            else
            {
                newNode.Previous = last;
                last.Next = newNode;
                last = newNode;
            }

            count++;
        }

        public Product RemoveFirst()
        {
            if (IsEmpty())
            {
                return null;
            }

            Product removedProduct = first.Data;

            if (count == 1)
            {
                first = null;
                last = null;
            }
            else
            {
                first = first.Next;
                first.Previous = null;
            }

            count--;

            return removedProduct;
        }

        public void Rewind()
        {
            this.iterator = first;
        }

        public Product GetNext()
        {
            if (IsEmpty())
                return null;

            if (this.iterator == null)
            {
                this.iterator = first;
                return null;
            }

            Product save = this.iterator.Data;
            this.iterator = this.iterator.Next;
            return save;
        }

        public Product RemoveLast()
        {
            if (IsEmpty())
            {
                return null;
            }

            Product removedProduct = last.Data;

            if (count == 1)
            {
                first = null;
                last = null;
            }
            else
            {
                last = last.Previous;
                last.Next = null;
            }

            count--;

            return removedProduct;
        }

        public string toStringOnlyId()
        {
            string result = string.Empty;
            Node current = first;
            while (current != null)
            {
                result += current.Data.Id + "q" + current.Data.Quantidade + ",";
                current = current.Next;
            }
            if (result.Length > 0)
            {
                result = result.Remove(result.Length - 1);
            }
            return result;
        }
    }
}
