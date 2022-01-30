using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSoft.Domain.Entities
{
    public class Topping
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Status  { get; set; }
    }
}
