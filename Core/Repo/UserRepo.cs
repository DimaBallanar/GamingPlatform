using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Core.Menu;
using System.IO;
using System.Text.Json;

namespace Core.Repo
{
    public class UserRepo : Menus
    {


        //private string[] Lines = File.ReadAllLines($"{AppDomain.CurrentDomain.BaseDirectory}DT.txt");

        public UserRepo()
        {
            List<User> users = new List<User>();
            var serializeoptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            using StreamReader sr1 = new StreamReader($"{AppDomain.CurrentDomain.BaseDirectory}DT.txt");
            string line = sr1.ReadLine();
            while (line != null)
            {
                User user = JsonSerializer.Deserialize<User>(line, serializeoptions);
                users.Add(user);
                line = sr1.ReadLine();
            }
        }
        private bool Search(List<User?> users)
        {
           string name = Login();
           string  pass = Password();
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pass))
            {
                Console.WriteLine("ERROR");
                return false;
            }

            for (int i = 0; i <= users.Count; i++)
            {
                if (users[i].Name == name && users[i].Password == pass)
                {
                   // Console.WriteLine("Login Succesful");
                    return true;
                }
            }
           // System.Console.WriteLine("ERROR input");
            return false;
        }
        public bool Registr(List<User?> users)
        {
            string name = Login();
            string pass = Password();
            if (SearchSimple(name, pass))
            {
                File.AppendAllText($"{AppDomain.CurrentDomain.BaseDirectory}DT.txt", $"\n{name},{pass}");
                Console.WriteLine("Регистрация завершена");
                return true;
            }
            Console.WriteLine("Попробуйте еще раз");
            return Registr();

        }
        private bool SearchSimple(string? name, string? password)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
            {
                System.Console.WriteLine("ERROR");
                return Registr();
            }
            for (int i = 0; i < Lines.Length; i++)
            {
                string[] strings = Lines[i].Split(',');
                if (strings[0] == name)
                {
                    Console.WriteLine("такой пользователь уже существует");
                    return Registr();
                }
            }
            return true;
        }
        public User Update(User userUpdate)
        {
            List<User> userList = GetAll();
            for (int i = 0; i < userList.Count; i++)
            {
                if (userList[i].Name.Equals(userUpdate.Name))
                {
                    userList[i] = userUpdate;

                }
            }
            if (UpdateFile(userList))
            {
                return userUpdate;
            }
            return null;
        }
        public User Delete(User delUser)
        {
            List<User?> userList = GetAll();
            for (int i = 0; i < userList.Count; i++)
            {
                if (userList[i].Name.Equals(delUser.Name))
                {
                    userList[i] = null;
                }
            }
            if (UpdateFile(userList))
            {
                return delUser;
            }
            return null;
        }
        private List<User> GetAll()
        {
            List<User> users = new List<User>();
            var serializeoptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            try
            {
                using StreamReader sr1 = new StreamReader($"{path}users.txt");
                string line = sr1.ReadLine();
                while (line != null)
                {
                    User user = JsonSerializer.Deserialize<User>(line, serializeoptions);
                    users.Add(user);
                    line = sr1.ReadLine();
                }
                sr1.Close();
                return users;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }
        private bool UpdateFile(List<User?> userList)
        {
            try
            {
                var serializeoptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                StreamWriter sw1 = new StreamWriter($"{path}users.txt");
                for (int i = 0; i < userList.Count; i++)
                {
                    if (userList[i] != null)
                    {
                        string json = JsonSerializer.Serialize<User>(userList[i], serializeoptions);
                        sw1.WriteLine(json);
                    }
                }
                sw1.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}


