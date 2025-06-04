using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    public class Abonent
    {
        public string Name { get; set; }
        public string Number { get; set; }

        public Abonent(string name, string number)
        {
                Name = name;
                Number = number; 
        }
    }
}
