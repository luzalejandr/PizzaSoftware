using MediatR;
using PizzaSoft.Application.Common.Interfaces.Persistence;
using PizzaSoft.Domain.Common;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaSoft.Application.Topping
{

    public class CreateTopping : IRequest<BaseResponse<string>>
    {
        public string Name { get; set; }
        public bool Status { get; set; }
    }
    public class CreateToppingHandler : IRequestHandler<CreateTopping, BaseResponse<string>>
    {
        private readonly IAppdbcontext _applicationDbContext;

        public CreateToppingHandler(IAppdbcontext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<BaseResponse<string>> Handle(CreateTopping request, CancellationToken cancellationToken)
        {

            Domain.Entities.Topping topping = new Domain.Entities.Topping
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Status = request.Status

            };

            var result = await _applicationDbContext.CreateTopping(topping);
            return new BaseResponse<string>(string.Empty);
        }
    }
}
