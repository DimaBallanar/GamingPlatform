using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Menu
{
    public static class Menu
    {

        public string Login()
        {
            System.Console.Write("введите логин: ");
            string? login = Console.ReadLine();
            System.Console.Write("введите пароль:");
            string? pass = Console.ReadLine();
            return login;
        }

        public string Password()
        {

        }
    }
}
