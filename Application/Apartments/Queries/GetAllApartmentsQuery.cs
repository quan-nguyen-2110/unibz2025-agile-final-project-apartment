using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Apartments.Queries
{
    public class GetAllApartmentsQuery : IRequest<List<Apartment>>
    {

        public class GetAllApartmentsHandler : IRequestHandler<GetAllApartmentsQuery, List<Apartment>>
        {
            private readonly IApartmentRepository _repo;

            public GetAllApartmentsHandler(IApartmentRepository repo)
            {
                _repo = repo;
            }

            public Task<List<Apartment>> Handle(GetAllApartmentsQuery request, CancellationToken cancellationToken)
            {
                return _repo.GetAllAsync();
            }
        }
    }
}
