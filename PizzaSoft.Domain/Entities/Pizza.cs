using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSoft.Domain.Entities
{
    public class Pizza
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public double Price { get; set; }
        public Guid[] Toppings { get; set; }
        public bool Status { get; set; }


    }
}
