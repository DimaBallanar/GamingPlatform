using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Models
{
    public class User
    {
        public int Id { get;  }
        public string Name { get; set; }
        public string Password { get; set; }

        [JsonConstructor]
        public User(int id, string name, string password)
        {
            Id = id;
            Name = name;
            Password = password;

        }
    }
}
