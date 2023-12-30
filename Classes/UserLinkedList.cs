using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Classes;

internal class UserNode
{
    public User data;
    public UserNode next;
    public UserNode prev;

    public UserNode(User user)
    {
        this.data = user;
    }
}

namespace WindowsFormsApp1.Classes
{
    internal class UserLinkedList
    {
        private int count = 0;
        private UserNode first = null;
        private UserNode last = null;
        public UserLinkedList() { }

        public void AddLast(User user)
        {
            if (isEmpty())
            {
                first = new UserNode(user);
                last = first;
            }
            else
            {
                last.next = new UserNode(user);
                last.next.prev = last;
                last = last.next;
            }

            count++;
        }

        public void AddFirst(User user)
        {
            if (isEmpty())
            {
                first = new UserNode(user);
                last = first;
            }
            else
            {
                UserNode newNode = new UserNode(user);
                first.prev = newNode;
                newNode.next = first;
                first = newNode;
            }

            count++;
        }

        public User RemoveFirst()
        {
            if (isEmpty()) { return null; }

            User save = first.data;

            if (count == 1)
            {
                first = null;
                last = null;
            } else
            {
                first = first.next;
                first.prev = null;
            }

            count--;

            return save;
        }

        public User RemoveLast()
        {
            if (isEmpty()) { return null; }

            User save = last.data;
            
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

        public User GetLast()
        {
            return last?.data;
        }

        public User GetFirst()
        {
            return first?.data;
        }

        public User FindByEmail(string Email)
        {
            UserNode current = first;
            while (current != null)
            {
                if (current.data.Email == Email)
                    return current.data;
                current = current.next;
            }
            return null;
        }

        public string toString()
        {
            string result = String.Empty;
            UserNode current = first;
            while (current != null)
            {
                result += $"{current.data.toString()}\n";
                current = current.next;
            }
            return result;
        }
    }
}
