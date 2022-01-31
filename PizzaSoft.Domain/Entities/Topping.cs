using System;

namespace PizzaSoft.Domain.Entities
{
    public class Topping
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
