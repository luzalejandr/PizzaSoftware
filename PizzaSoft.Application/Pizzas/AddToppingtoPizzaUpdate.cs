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

    public class AddToppingtoPizzaUpdate : IRequest<BaseResponse<Domain.Entities.Pizza>>
    {
        public Guid IdPizza { get; set; }
        public Guid IdTopping { get; set; }


    }
    public class AddToppingtoPizzaUpdateHandler : IRequestHandler<AddToppingtoPizzaUpdate, BaseResponse<Domain.Entities.Pizza>>
    {
        private readonly IAppdbcontext _applicationDbContext;

        public AddToppingtoPizzaUpdateHandler(IAppdbcontext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<BaseResponse<Domain.Entities.Pizza>> Handle(AddToppingtoPizzaUpdate request, CancellationToken cancellationToken)
        {
              
            

            var toppings = await _applicationDbContext.GetPizzaById(request.IdPizza);
            Guid[] toppingsArray = toppings.Toppings;
            List<Guid> listToppings =toppingsArray.ToList();
            listToppings.Add(request.IdTopping);
            toppingsArray = listToppings.ToArray();

            var result = await _applicationDbContext.AddToppingtoPizza(request.IdPizza, toppingsArray);


            return new BaseResponse<Domain.Entities.Pizza>(result);
        }
    }
}
