using AsanPardakhtTest.Application.Common.Models;
using AsanPardakhtTest.Application.Persons.Commands.CreatePerson;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AsanPardakhtTest.Api.Controllers
{
    public class PersonController : BaseController
    {
        public PersonController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Create a new person
        /// </summary>
        /// <response code="201">if create person done successfully</response>
        /// <response code="400">if validation failed</response>
        /// <response code="500">if an unexpected error happen</response>
        [ProducesResponseType(typeof(int), 201)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(Result), 500)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreatePersonCommand command)
        {
            var result = await Mediator.Send(command);

            if (result.Succeeded == false)
                return BadRequest(result);

            return Created(Url.Link("", new { id = result.Data }), result.Data);
        }
    }
}
