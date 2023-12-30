using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Classes
{
    internal class Product
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public float Preco { get; set; }

        public string Imagem { get; set; }

        private Image objImage;

        public int Quantidade = 0;

        public Product() { }

        public void SetImageObjectFromFile(string file_name = "")
        {
            if (file_name != String.Empty)
            {
                this.Imagem = file_name;
            }

            string complete_path = Program.root_path + "\\imagens\\" + this.Imagem;

            if (File.Exists(complete_path))
            {
                this.objImage = Image.FromFile(complete_path);
            }

        }

        public void FillByString(string data)
        {
            string[] attrs = data.Split(';');

            foreach (string attr in attrs)
            {
                string[] line = attr.Split('=');

                PropertyInfo propriedade = this.GetType().GetProperty(line[0]);

                if (propriedade == null) { continue; }

                if (propriedade.PropertyType == typeof(string))
                {
                    propriedade.SetValue(this, line[1]);
                }
                else if (propriedade.PropertyType == typeof(float))
                {
                    propriedade.SetValue(this, float.Parse(line[1]));
                }
                else if (propriedade.PropertyType == typeof(int))
                {
                    propriedade.SetValue(this, int.Parse(line[1]));
                }

            }

            this.SetImageObjectFromFile();
        }

        public string toString()
        {
            string result = "";
            Type type = this.GetType();
            foreach (PropertyInfo prop in type.GetProperties())
            {
                result += $"{prop.Name}={prop.GetValue(this)};";
            }
            return result;
        }

        public Image GetImageObject()
        {
            return this.objImage;
        }

        public Product Copy()
        {
            Product product = new Product();
            product.Id = this.Id;
            product.Nome = this.Nome;
            product.Preco = this.Preco;
            product.Imagem = this.Imagem;
            product.objImage = this.objImage;
            return product;
        }
    }
}
