
using MediatR;
using PizzaSoft.Application.Common.Interfaces.Persistence;
using PizzaSoft.Domain.Common;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaSoft.Application.Pizzas
{
    public class RetrieveAllPizzas: IRequest<BaseResponse<List<Domain.Entities.Pizza>>>
    {


    }
    public class RetrieveAllPizzasHandler : IRequestHandler<RetrieveAllPizzas, BaseResponse<List<Domain.Entities.Pizza>>>
    {
        private readonly IAppdbcontext _applicationDbContext;

        public RetrieveAllPizzasHandler(IAppdbcontext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<BaseResponse<List<Domain.Entities.Pizza>>> Handle(RetrieveAllPizzas request, CancellationToken cancellationToken)
        {
            var pizzaData = await _applicationDbContext.GetPizzas();
            return new BaseResponse<List<Domain.Entities.Pizza>>(pizzaData);

            //string a = "f";
            //string b = "g";
            //List<Domain.Entities.Pizza> listpizzas = new List<Domain.Entities.Pizza>();
            //listpizzas.Add(new Domain.Entities.Pizza() {  Detail="aaaa", Id=Guid.NewGuid(), Name="pizza1", Price=30, Status= true});
            //listpizzas.Add(new Domain.Entities.Pizza() {  Detail="bbbb", Id = Guid.NewGuid(), Name = "pizza2", Price = 50, Status = true });
            ////return new BaseResponse<List<Domain.Entities.Pizza>>(listpizzas);
            //return new BaseResponse<List<Domain.Entities.Pizza>>(listpizzas);

        }
    }
}
