using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Menu
{
    public  class Menus
    {

        public  string Login()
        {
            System.Console.Write("введите логин: ");
            string? login = Console.ReadLine();            
            return login;
        }

        public  string Password()
        {
            System.Console.Write("введите пароль:");
            string? pass = Console.ReadLine();
            return pass;
        }
    }
}
