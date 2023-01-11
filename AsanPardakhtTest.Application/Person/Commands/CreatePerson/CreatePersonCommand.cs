using AsanPardakhtTest.Application.Common.Interfaces;
using MediatR;

namespace AsanPardakhtTest.Application.Persons.Commands.CreatePerson
{
    public class CreatePersonCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalId { get; set; }
    }

    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public CreatePersonCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = Person.Create(request.FirstName, request.LastName);
            _context.People.Add(person);
            await _context.SaveChangesAsync(cancellationToken);
            return person.Id;
        }
    }
}
