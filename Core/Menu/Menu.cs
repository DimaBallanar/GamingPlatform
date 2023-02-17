using Core.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Menu
{
    public class Menus
    {
        public Menus() { }

        public string Login()
        {
            System.Console.Write("введите логин: ");
            string? login = Console.ReadLine();
            return login;
        }

        public string Password()
        {
            System.Console.Write("введите пароль:");
            string? pass = Console.ReadLine();
            return pass;
        }
        public void FirstMenu()
        {
            Console.WriteLine("Меню входа");
            Console.WriteLine("1 Новый игрок");
            Console.WriteLine("2 Уже зарегистрирован");
            if(Console.ReadLine().Equals(1))
            {
                UserRepo user=new UserRepo();
                user.Registr();
            }
        }
    }
}
