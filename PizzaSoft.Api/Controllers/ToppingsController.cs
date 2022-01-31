using Mapster;
using Microsoft.AspNetCore.Mvc;
using PizzaSoft.Api.Contracts;
using PizzaSoft.Application.Topping;
using System;
using System.Threading.Tasks;

namespace PizzaSoft.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToppingsController : ApiControllerBase
    {
        [HttpPost]
        [Route("CreateTopping")]
        public async Task<ActionResult> CreateTopping(ToppingData toppingData)
        {
            CreateTopping createToppingCommand =
                 toppingData.Adapt<CreateTopping>();

            return Ok(await Mediator.Send(createToppingCommand));
        }

        [HttpGet]
        [Route("GetToppings")]
        public async Task<ActionResult> GetToppings()
        {
            return Ok(await Mediator.Send(new RetrieveAllToppings()));
        }

        [HttpDelete]
        [Route("DeleteTopping")]
        public async Task<ActionResult> DeleteTopping(Guid idTopping)
        {
            DeleteTopping deleteToppingCommand = new DeleteTopping
            {
                Id = idTopping
            };
            return Ok(await Mediator.Send(deleteToppingCommand));
        }
    }
}
