using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Classes
{
    internal class User
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }

        public User() { }

        public string toString()
        {
            string result = string.Empty;
            Type myType = this.GetType();
            foreach (PropertyInfo prop in myType.GetProperties())
            {
                result += $"{prop.Name}={prop.GetValue(this)};";
            }
            return result;
        }

    }
}
