using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Core.Menu;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace Core.Repo
{
    public class UserRepo : Menus
    {
        private int CountId;
        List<User> Users = new List<User>();

        //private string[] Lines = File.ReadAllLines($"{AppDomain.CurrentDomain.BaseDirectory}DT.txt");

        public UserRepo()
        {
           
            var serializeoptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            using StreamReader sr1 = new StreamReader($"{AppDomain.CurrentDomain.BaseDirectory}DT.txt");
            string line = sr1.ReadLine();
            while (line != null)
            {
                User user = JsonSerializer.Deserialize<User>(line, serializeoptions);
                Users.Add(user);
                line = sr1.ReadLine();
            }
        }
        private User Search()
        {
            string name = Login();
            string pass = Password();
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pass))
            {
                Console.WriteLine("ERROR");
                return null;
            }

            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].Name == name && Users[i].Password == pass)
                {
                    // Console.WriteLine("Login Succesful");
                    return Users[i];
                }
            }
            // System.Console.WriteLine("ERROR input");
            return null;
        }
        public bool Exist(User user)
        {

            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].Name == name && Users[i].Password == pass)
                {
                    // Console.WriteLine("Login Succesful");
                    return Users[i];
                }
            }

        }
        public User Registr()
        {
            string name = Login();
            string pass = Password();
            if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(pass))
            {
                return null;
            }
            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].Name == name)
                {
                    Console.WriteLine("Попробуйте еще раз");
                    return null;
                }
            }
            User newUser = new User(CountId++, name, pass);
            //users.Add(newUser);

            File.AppendAllText($"{AppDomain.CurrentDomain.BaseDirectory}DT.txt", $"{newUser}");
            Console.WriteLine("Регистрация завершена");
            return newUser;



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
                using StreamReader sr1 = new StreamReader($"{AppDomain.CurrentDomain.BaseDirectory}DT.txt");
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
                StreamWriter sw1 = new StreamWriter($"{AppDomain.CurrentDomain.BaseDirectory}DT.txt");
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


