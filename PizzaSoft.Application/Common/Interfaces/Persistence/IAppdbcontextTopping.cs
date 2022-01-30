using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSoft.Application.Common.Interfaces.Persistence
{
    public partial interface IAppdbcontext
    {
        Task<Domain.Entities.Topping> CreateTopping(Domain.Entities.Topping topping );

        Task<List<Domain.Entities.Topping>> GetToppings();

        Task<string> DeleteToppings(Guid id);

        Task<Domain.Entities.Topping> GetToppingById(Guid  Id);
    }
}
