using MediatR;
using PizzaSoft.Application.Common.Interfaces.Persistence;
using PizzaSoft.Domain.Common;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaSoft.Application.Topping
{

    public class DeleteTopping : IRequest<BaseResponse<string>>
    {
        public Guid Id { get; set; }
    }

    public class DeleteToppingHandler : IRequestHandler<DeleteTopping, BaseResponse<string>>
    {
        private readonly IAppdbcontext _applicationDbContext;


        public DeleteToppingHandler(IAppdbcontext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;

        }

        public async Task<BaseResponse<string>> Handle(DeleteTopping request, CancellationToken cancellationToken)
        {

            var result = await _applicationDbContext.DeleteToppings(request.Id);
            return new BaseResponse<string>(string.Empty);
        }
    }
}
