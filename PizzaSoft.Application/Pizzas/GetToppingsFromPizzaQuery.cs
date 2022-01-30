using MediatR;
using PizzaSoft.Application.Common.Interfaces.Persistence;
using PizzaSoft.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaSoft.Application.Pizzas
{

    public class GetToppingsFromPizzaQuery : IRequest<BaseResponse<List<Domain.Entities.Topping>>>
    {
        public Guid Id { get; set; }

    }
    public class GetToppingsFromPizzaQueryHandler : IRequestHandler<GetToppingsFromPizzaQuery, BaseResponse<List<Domain.Entities.Topping>>>
    {
        private readonly IAppdbcontext _applicationDbContext;

        public GetToppingsFromPizzaQueryHandler(IAppdbcontext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<BaseResponse<List<Domain.Entities.Topping>>> Handle(GetToppingsFromPizzaQuery request, CancellationToken cancellationToken)
        {
            
            var result1 = await _applicationDbContext.GetPizzaById(request.Id);
            
            Domain.Entities.Topping topping = new Domain.Entities.Topping();
           
            List<Domain.Entities.Topping> listToppings = new List<Domain.Entities.Topping>();
            
            for (int i = 0; i <= result1.Toppings.Length - 1; i++)
            {
                topping = await _applicationDbContext.GetToppingById(result1.Toppings[i]);
                listToppings.Add(topping);
            }      

            return new BaseResponse<List<Domain.Entities.Topping>>(listToppings);

        }
    }
}
