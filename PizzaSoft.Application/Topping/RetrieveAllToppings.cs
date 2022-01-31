using MediatR;
using PizzaSoft.Application.Common.Interfaces.Persistence;
using PizzaSoft.Domain.Common;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaSoft.Application.Topping
{

    public class RetrieveAllToppings : IRequest<BaseResponse<List<Domain.Entities.Topping>>>
    {


    }
    public class RetrieveAllToppingsHandler : IRequestHandler<RetrieveAllToppings, BaseResponse<List<Domain.Entities.Topping>>>
    {
        private readonly IAppdbcontext _applicationDbContext;

        public RetrieveAllToppingsHandler(IAppdbcontext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<BaseResponse<List<Domain.Entities.Topping>>> Handle(RetrieveAllToppings request, CancellationToken cancellationToken)
        {
            var toppingData = await _applicationDbContext.GetToppings();
            return new BaseResponse<List<Domain.Entities.Topping>>(toppingData);

        }
    }
}
