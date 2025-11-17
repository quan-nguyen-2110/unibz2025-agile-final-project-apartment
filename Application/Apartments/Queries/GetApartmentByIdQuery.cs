using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Apartments.Queries;

public class GetApartmentByIdQuery : IRequest<Apartment?>
{
    public int Id { get; set; }

    public GetApartmentByIdQuery(int id)
    {
        Id = id;
    }

    public class GetApartmentByIdHandler : IRequestHandler<GetApartmentByIdQuery, Apartment?>
    {
        private readonly IApartmentRepository _repo;

        public GetApartmentByIdHandler(IApartmentRepository repo)
        {
            _repo = repo;
        }

        public Task<Apartment?> Handle(GetApartmentByIdQuery request, CancellationToken cancellationToken)
        {
            return _repo.GetByIdAsync(request.Id);
        }
    }
}