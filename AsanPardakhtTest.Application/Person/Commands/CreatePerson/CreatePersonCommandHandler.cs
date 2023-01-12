using AsanPardakhtTest.Application.Common.Interfaces;
using AsanPardakhtTest.Application.Common.Models;
using AsanPardakhtTest.Domain.Entities;
using MediatR;

namespace AsanPardakhtTest.Application.Persons.Commands.CreatePerson
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;
        public CreatePersonCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<int>> Handle(CreatePersonCommand request,
            CancellationToken cancellationToken)
        {
            var person = Person.Create(request.FirstName, 
                request.LastName, request.NationalId);
            _context.People.Add(person);
            await _context.SaveChangesAsync(cancellationToken);
            return Result.Successfull(person.Id);
        }
    }
}
