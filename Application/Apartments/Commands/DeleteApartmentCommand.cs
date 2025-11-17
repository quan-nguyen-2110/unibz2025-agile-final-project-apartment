using Application.Interfaces;
using MediatR;

namespace Application.Apartments.Commands;

public class DeleteApartmentCommand : IRequest<bool>
{
    public int Id { get; set; }

    public DeleteApartmentCommand(int id)
    {
        Id = id;
    }

    public class DeleteApartmentHandler : IRequestHandler<DeleteApartmentCommand, bool>
    {
        private readonly IApartmentRepository _repo;

        public DeleteApartmentHandler(IApartmentRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(DeleteApartmentCommand request, CancellationToken cancellationToken)
        {
            await _repo.DeleteAsync(request.Id);
            return true;
        }
    }
}