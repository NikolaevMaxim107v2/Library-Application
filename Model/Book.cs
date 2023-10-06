using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Библиотека.Model
{
    public class Book
    {

        public Book(string author, string name, short arc, int age, int count)
        {
            Author = author;
            Name = name;
            Arc = arc;
            Age = age;
            Count = count;
        }

        public string Author { get; set; }
        public string Name { get; set; }
        public short Arc { get; set; }
        public int Age { get; set; }
        public int Count { get; set; }

    }
}
