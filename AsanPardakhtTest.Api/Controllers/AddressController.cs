using AsanPardakhtTest.Application.Addresses.Commands.CreateAddress;
using AsanPardakhtTest.Application.Addresses.Queries.GetAddressesByProviance;
using AsanPardakhtTest.Application.Common.Models;
using AsanPardakhtTest.Application.Persons.Commands.CreatePerson;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AsanPardakhtTest.Api.Controllers
{
    public class AddressController : BaseController
    {
        public AddressController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Create a new address
        /// </summary>
        /// <response code="201">if create address done successfully</response>
        /// <response code="400">if validation failed</response>
        /// <response code="500">if an unexpected error happen</response>
        [ProducesResponseType(typeof(int), 201)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(Result), 500)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateAddressCommand command)
        {
            var result = await Mediator.Send(command);

            if (result.Succeeded == false)
                return BadRequest(result);

            return Created(Url.Link("", new { id = result.Data }), result.Data);
        }

        /// <summary>
        /// Get by proviance name
        /// </summary>
        /// <response code="200">Return a list af addresses when created in 10 past minutes</response>
        /// <response code="500">if an unexpected error happen</response>
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(typeof(Result), 500)]
        [HttpGet]
        public async Task<IActionResult> GetByProviance([FromQuery] GetAddressesByProvianceQuery command)
        {
            var result = await Mediator.Send(command);

            if (result.Succeeded == false)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
