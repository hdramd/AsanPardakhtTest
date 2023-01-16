using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AsanPardakhtTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public readonly IMediator Mediator;
        public BaseController(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}
