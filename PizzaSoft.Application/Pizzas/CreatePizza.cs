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
    public class CreatePizza : IRequest<BaseResponse<string>>
    {
        public string Name { get; set; }
        public string Detail { get; set; }
        public double Price { get; set; }
        public Guid[] Toppings { get; set; }
        public bool Status { get; set; }

    }
    public class CreatePizzaHandler : IRequestHandler<CreatePizza, BaseResponse<string>>
    {
        private readonly IAppdbcontext _applicationDbContext;

        public CreatePizzaHandler(IAppdbcontext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<BaseResponse<string>> Handle(CreatePizza request, CancellationToken cancellationToken)
        {

            Domain.Entities.Pizza pizza = new Domain.Entities.Pizza
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Detail = request.Detail,
                Price = request.Price,
                Toppings = request.Toppings,
                Status = request.Status

            };

            var result = await _applicationDbContext.CreatePizza(pizza);
            return new BaseResponse<string>(string.Empty);
        }
    }

}
