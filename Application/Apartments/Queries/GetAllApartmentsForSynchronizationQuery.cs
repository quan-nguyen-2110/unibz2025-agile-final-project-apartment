using Application.Apartments.Queries.DTOs;
using Domain.Interfaces.IRepository;
using MediatR;

namespace Application.Apartments.Queries
{
    public class GetAllApartmentsForSynchronizationQuery : IRequest<List<object>>
    {

        public class GetForSynchronizationHandler : IRequestHandler<GetAllApartmentsForSynchronizationQuery, List<object>>
        {
            private readonly IApartmentRepository _aptRepo;

            public GetForSynchronizationHandler(IApartmentRepository repo)
            {
                _aptRepo = repo;
            }

            public async Task<List<object>> Handle(GetAllApartmentsForSynchronizationQuery request, CancellationToken cancellationToken)
            {
                List<object> result = new List<object>();
                var apartments = await _aptRepo.GetAllAsync();
                foreach (var apt in apartments)
                {
                    Object obj = new
                    {
                        Id = apt.Id,
                        Title = apt.Title.Trim(),
                        Address = apt.Address.Trim(),
                        Price = apt.Price,
                        Description = apt.Description?.Trim(),
                        Base64Image = apt.ApartmentImages.FirstOrDefault()?.Base64Image
                    };

                    result.Add(obj);
                }

                return result;
            }
        }
    }
}
