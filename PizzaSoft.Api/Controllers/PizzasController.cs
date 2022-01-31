
using Mapster;
using Microsoft.AspNetCore.Mvc;
using PizzaSoft.Api.Contracts;
using PizzaSoft.Application.Pizzas;
using System;
using System.Threading.Tasks;

namespace PizzaSoft.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzasController : ApiControllerBase
    {
        [HttpGet]
        [Route("GetPizzas")]
        public async Task<ActionResult> GetPizzas()
        {
            return Ok(await Mediator.Send(new RetrieveAllPizzas()));
        }

        [HttpPost]
        [Route("CreatePizza")]
        public async Task<ActionResult> CreatePizza(PizzaData pizzaData)
        {
            CreatePizza createUserCommand =
                 pizzaData.Adapt<CreatePizza>();

            return Ok(await Mediator.Send(createUserCommand));
        }

        [HttpDelete]
        [Route("DeletePizza")]
        public async Task<ActionResult> DeletePizza(Guid idPizza)
        {
            DeletePizza deletePizzaCommand = new DeletePizza
            {
                Id = idPizza
            };
            return Ok(await Mediator.Send(deletePizzaCommand));
        }

        [HttpGet]
        [Route("GetPizzaById")]
        public async Task<ActionResult> GetPizzaById(Guid idPizza)
        {
            GetOnePizza getOnePizza = new GetOnePizza();
            getOnePizza.Id = idPizza;

            return Ok(await Mediator.Send(getOnePizza));
        }


        [HttpPut]
        [Route("AddToppingtoPizza")]
        public async Task<ActionResult> AddToppingtoPizza(Guid idPizza, Guid idTopping)
        {
            AddToppingtoPizzaUpdate addToppingtoPizza = new AddToppingtoPizzaUpdate();
            addToppingtoPizza.IdPizza = idPizza;
            addToppingtoPizza.IdTopping = idTopping;

            return Ok(await Mediator.Send(addToppingtoPizza));
        }

        [HttpGet]
        [Route("GetToppingsFromPizza")]
        public async Task<ActionResult> GetToppingsFromPizza(Guid idPizza)
        {
            GetToppingsFromPizzaQuery getToppingsFromPizzaQuery = new GetToppingsFromPizzaQuery();
            getToppingsFromPizzaQuery.Id = idPizza;

            return Ok(await Mediator.Send(getToppingsFromPizzaQuery));
        }



    }
}
