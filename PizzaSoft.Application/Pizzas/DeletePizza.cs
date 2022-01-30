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
 
    public class DeletePizza : IRequest<BaseResponse<string>>
    {
        public Guid Id { get; set; }
    }

    public class DeletePizzaHandler : IRequestHandler<DeletePizza, BaseResponse<string>>
    {
        private readonly IAppdbcontext _applicationDbContext;
  

        public DeletePizzaHandler(IAppdbcontext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
           
        }

        public async Task<BaseResponse<string>> Handle(DeletePizza request, CancellationToken cancellationToken)
        {        

            var result = await _applicationDbContext.DeletePizza(request.Id);
            return new BaseResponse<string>(string.Empty);
        }
    }
}
