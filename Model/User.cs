using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Библиотека.Model
{
    public class User
    {
        public User(int id, string name, string surname, List<Book> BookList)
        {
            Id = id;
            Name = name;
            Surname = surname;
            this.BookList = BookList;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Book> BookList { get; set; }
    }
  
}
