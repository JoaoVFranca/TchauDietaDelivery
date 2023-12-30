using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Classes;

class OrderNode
{
    public Pedido data;
    public OrderNode next;
    public OrderNode prev;

    public OrderNode(Pedido order)
    {
        this.data = order;
    }
}

namespace WindowsFormsApp1.Classes
{
    internal class OrderLinkedList
    {
        private int count = 0;
        private OrderNode first = null;
        private OrderNode last = null;
        public OrderLinkedList() { }

        public void AddLast(Pedido order)
        {
            if (isEmpty())
            {
                first = new OrderNode(order);
                last = first;
            }
            else
            {
                last.next = new OrderNode(order);
                last.next.prev = last;
                last = last.next;
            }

            count++;
        }

        public void AddFirst(Pedido order)
        {
            if (isEmpty())
            {
                first = new OrderNode(order);
                last = first;
            }
            else
            {
                OrderNode newNode = new OrderNode(order);
                first.prev = newNode;
                newNode.next = first;
                first = newNode;
            }

            count++;
        }

        public Pedido RemoveFirst()
        {
            if (isEmpty()) { return null; }

            Pedido save = first.data;

            if (count == 1)
            {
                first = null;
                last = null;
            }
            else
            {
                first = first.next;
                first.prev = null;
            }

            count--;

            return save;
        }

        public Pedido RemoveLast()
        {
            if (isEmpty()) { return null; }

            Pedido save = last.data;

            if (count == 1)
            {
                first = null;
                last = null;
            }
            else
            {
                last = last.prev;
                last.next = null;
            }

            count--;

            return save;
        }

        public bool isEmpty()
        {
            return count == 0;
        }

        public Pedido GetLast()
        {
            return last?.data;
        }

        public Pedido GetFirst()
        {
            return first?.data;
        }

        public Pedido FindByEmail(string Email)
        {
            OrderNode current = first;
            while (current != null)
            {
                if (current.data.EmailSolicitante == Email)
                    return current.data;
                current = current.next;
            }
            return null;
        }

        public void RemoveByEmail(string Email)
        {
            if (isEmpty() || Email == String.Empty) { return; }

            OrderNode current = first;
            while (current != null)
            {
                if (current.data.EmailSolicitante == Email)
                {
                    if (current.next != null)
                        current.next.prev = current.prev;
                    if (current.prev != null)
                        current.prev.next = current.next;
                    current.next = null;
                    current.prev = null;
                    count--;
                    return;
                }       
                current = current.next;
            }
        }

        public string toString()
        {
            string result = String.Empty;
            OrderNode current = first;
            while (current != null)
            {
                result += $"{current.data.toString()}\n";
                current = current.next;
            }
            return result;
        }
    }
}
