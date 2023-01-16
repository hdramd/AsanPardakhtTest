using AsanPardakhtTest.Application.Addresses.Commands.CreateAddress;
using AsanPardakhtTest.Application.Addresses.Commands.UpdateAddress;
using AsanPardakhtTest.Application.Addresses.Queries.GetAddressesByProviance;
using AsanPardakhtTest.Application.Addresses.Queries.GetAddressesWithPaginationQuery;
using AsanPardakhtTest.Application.Addresses.Queries.Models;
using AsanPardakhtTest.Application.Common.Models;
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

            return Created(string.Empty, result.Data);
        }

        /// <summary>
        /// Update address
        /// </summary>
        /// <response code="204">if update address done successfully</response>
        /// <response code="400">if validation failed</response>
        /// <response code="500">if an unexpected error happen</response>
        [ProducesResponseType(typeof(int), 204)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(Result), 500)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateAddressCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            var result = await Mediator.Send(command);

            if (result.Succeeded == false)
                return BadRequest(result);

            return NoContent();
        }

        /// <summary>
        /// Get paginated list of addresses
        /// </summary>
        /// <response code="200">Return a paginated list of addresses</response>
        /// <response code="500">if an unexpected error happen</response>
        [ProducesResponseType(typeof(Result<PaginatedList<AddressDto>>), 200)]
        [ProducesResponseType(typeof(Result), 500)]
        [HttpGet(nameof(GetPaginatedList))]
        public async Task<IActionResult> GetPaginatedList([FromQuery] GetAddressesWithPaginationQuery query)
        {
            var result = await Mediator.Send(query);

            if (result.Succeeded == false)
                return BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Get by proviance name
        /// </summary>
        /// <response code="200">Return a list af addresses when created in 10 past minutes</response>
        /// <response code="500">if an unexpected error happen</response>
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(typeof(Result), 500)]
        [HttpGet(nameof(GetByProviance))]
        public async Task<IActionResult> GetByProviance([FromQuery] GetAddressesByProvianceQuery query)
        {
            var result = await Mediator.Send(query);

            if (result.Succeeded == false)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
