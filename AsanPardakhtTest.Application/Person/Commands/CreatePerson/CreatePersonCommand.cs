using AsanPardakhtTest.Application.Common.Models;
using MediatR;

namespace AsanPardakhtTest.Application.Persons.Commands.CreatePerson
{
    public class CreatePersonCommand : IRequest<Result<int>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalId { get; set; }
    }
}
