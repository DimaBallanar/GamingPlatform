using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Repo
{
    public  class UserRepo
    {
        
       private string[] Lines = File.ReadAllLines(@"MyDir\DT.txt");
        public UserRepo() { }


        private bool Search(string? login, string? pass)
        {
            
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(pass))
            {
                Console.WriteLine("ERROR");
                return false;
            }
            for (int i = 0; i < Lines.Length; i++)
            {
                string[] strings = Lines[i].Split(',');
                if (strings[0] == login && strings[1] == pass)
                {
                    Console.WriteLine("Login Succesful");
                    return true;
                }
            }
            System.Console.WriteLine("ERROR input");
            return false;
        }
    }
}
