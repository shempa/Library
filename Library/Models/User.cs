using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActiv { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
