

using System;

namespace PizzaSoft.Api.Contracts
{
    public class PizzaData
    {

        public string Name { get; set; }
        public string Detail { get; set; }
        public double Price { get; set; }
        public Guid[] Toppings { get; set; }
        public bool Status { get; set; }

    }
}
