using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Classes
{
    internal class UserManager
    {

        public static string LoggedUserEmail = String.Empty;

        private static UserLinkedList AllUsers;

        private string _file_path = Program.root_path + "\\Arquivos\\users.txt";

        public UserManager() {
            this.FetchAllUsers();
        }

        /* Retorno da função de login
         * 0 -> Usuário encontrado e senha correta, login feito!
         * 1 -> Usuário encontrado e senha incorreta, login falho!
         * 2 -> Usuário não encontrado no arquivo, login falho!
        */
        public int Login(string email, string password)
        {
            User logginUser = AllUsers.FindByEmail(email);

            if (logginUser == null) { return 2; }

            if (PasswordHash.Verify(password,logginUser.Senha) == false) { return 1; }

            LoggedUserEmail = logginUser.Email;

            return 0;
        }

        public User FindByEmail(string email) {
            return AllUsers.FindByEmail(email);
        }

        public int Logout()
        {
            LoggedUserEmail = String.Empty;
            return 0;
        }

        /* Retorno da função de login
         * 0 -> Usuário cadastrado com sucesso
         * 1 -> Email já cadastrado
        */
        public int Cadastrar(User newUser)
        {
            if (AllUsers.FindByEmail(newUser.Email) != null) { return 1; }

            AllUsers.AddLast(newUser);

            this.SaveAllToFile();

            return 0;
        }

        private void SaveAllToFile()
        {
            using (StreamWriter file_writer = new StreamWriter(_file_path))
            {
                file_writer.WriteLine(AllUsers.toString());
            }
        }

        private void FetchAllUsers()
        {
            if (AllUsers != null) { return; } 

            AllUsers = new UserLinkedList();

            string[] userData = File.ReadAllLines(this._file_path);

            foreach (string data in userData) // Percorrendo usuarios
            {
                this.SetUserData(data);
            }
        }

        private void SetUserData(string uData)
        {
            if (uData == String.Empty) { return; }

            Type userType = typeof(User);
            User newUser = new User();
            string[] tuplas = uData.Split(';');

            foreach (string tupla in tuplas) // Percorrendo propriedades dos usuarios
            {
                string[] values = tupla.Split('=');

                if (values.Length != 2) { continue; }

                PropertyInfo pInfo = userType.GetProperty(values[0]);

                if (pInfo != null)
                {
                    pInfo.SetValue(newUser, values[1]);
                }
            }

            AllUsers.AddLast(newUser);
        }
    }
}
