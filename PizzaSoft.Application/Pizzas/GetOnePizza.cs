using MediatR;
using PizzaSoft.Application.Common.Interfaces.Persistence;
using PizzaSoft.Domain.Common;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaSoft.Application.Pizzas
{
    public class GetOnePizza : IRequest<BaseResponse<Domain.Entities.Pizza>>
    {
        public Guid Id { get; set; }
    }

    public class GetOnePizzaHandler : IRequestHandler<GetOnePizza, BaseResponse<Domain.Entities.Pizza>>
    {
        private readonly IAppdbcontext _applicationDbContext;

        public GetOnePizzaHandler(IAppdbcontext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<BaseResponse<Domain.Entities.Pizza>> Handle(GetOnePizza request, CancellationToken cancellationToken)
        {
            var pizzaData = await _applicationDbContext.GetPizzaById(request.Id);

            if (pizzaData == null)

                return new BaseResponse<Domain.Entities.Pizza>("Error300", "That pizza doesnt exist");
            else
                return new BaseResponse<Domain.Entities.Pizza>(pizzaData);

        }
    }
}
