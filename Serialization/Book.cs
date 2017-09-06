using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    [Serializable]
    public class Book
    {
        public string title { get; set; }
        public double price { get; set; }
        public string author { get; set; }
        public int year { get; set; }

        public Book(string title, double price, string author, int year)
        {
            this.title = title;
            this.price = price;
            this.author = author;
            this.year = year;
        }
    }
}
