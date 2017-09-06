using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    [Serializable]
    public class Person
    {
        public string name { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public int year { get; set; }

        public Person(string name, string lastName, string phone, int year )
        {
            this.name = name;
            this.lastName = lastName;
            this.phone = phone;
            this.year = year;
        }
    }
}
