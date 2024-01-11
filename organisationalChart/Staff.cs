using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace organisationalChart
{
    internal class Staff
    {
    public string Name { get; set; }
        public string Role { get; set; }
        public Staff ReportsTo { get; set; }

        public Staff(string name, string role)
        {
            Name = name;
            Role = role;
        }

        public override string ToString()
        {
            return $"{Name} - {Role}";
        }
    }
}
