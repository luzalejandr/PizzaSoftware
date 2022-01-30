using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSoft.Application.Common.Interfaces.Persistence
{
    public partial interface IAppdbcontext
    {
        Task<List<Domain.Entities.Pizza>> GetPizzas();
        Task<Domain.Entities.Pizza> CreatePizza(Domain.Entities.Pizza pizza);

        Task<string> DeletePizza(Guid id);

        Task<Domain.Entities.Pizza> GetPizzaById(Guid id);


        Task<Domain.Entities.Pizza> AddToppingtoPizza(Guid idPizza, Guid[] IdToppings );


    }
}
