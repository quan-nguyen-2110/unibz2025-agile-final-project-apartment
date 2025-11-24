using Application.Apartments.Queries.DTOs;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Apartments.Queries
{
    public class GetAllApartmentsQuery : IRequest<List<ApartmentDto>>
    {

        public class GetAllApartmentsHandler : IRequestHandler<GetAllApartmentsQuery, List<ApartmentDto>>
        {
            private readonly IApartmentRepository _aptRepo;
            private readonly IApartmentImageRepository _aptImageRepo;

            public GetAllApartmentsHandler(IApartmentRepository repo, IApartmentImageRepository aptImgRepo)
            {
                _aptRepo = repo;
                _aptImageRepo = aptImgRepo;
            }

            public async Task<List<ApartmentDto>> Handle(GetAllApartmentsQuery request, CancellationToken cancellationToken)
            {
                List<ApartmentDto> result = new List<ApartmentDto>();
                var apartments = await _aptRepo.GetAllAsync();
                foreach(var apt in apartments)
                {
                    ApartmentDto dto = new ApartmentDto
                    {
                        Id = apt.Id,
                        Code = apt.Code,
                        Address = apt.Address,
                        Floor = apt.Floor,
                        Area = apt.Area,
                        Price = apt.Price,
                        Title = apt.Title,
                        Bedrooms = apt.Bedrooms,
                        Bathrooms = apt.Bathrooms,
                        Description = apt.Description,
                        AvailableFrom = apt.AvailableFrom,
                        Amenities = apt.Amenities.Split(',').ToList(),

                        Base64Images = await _aptImageRepo.GetBase64ImagesByApartmentIdAsync(apt.Id)
                    };

                    result.Add(dto);
                }

                return result;
            }
        }
    }
}
