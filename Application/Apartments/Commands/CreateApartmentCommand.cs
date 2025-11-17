using Application.Interfaces;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Apartments.Commands;

public class CreateApartmentCommand : IRequest<int>
{
    public string Code { get; set; } = default!;
    public string Address { get; set; } = default!;
    public int Floor { get; set; }
    public double Area { get; set; }
    public decimal Price { get; set; }

    public CreateApartmentCommand() { }

    public class CreateApartmentHandler : IRequestHandler<CreateApartmentCommand, int>
    {
        private readonly IApartmentRepository _repo;

        public CreateApartmentHandler(IApartmentRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> Handle(CreateApartmentCommand request, CancellationToken cancellationToken)
        {
            var apt = new Apartment
            {
                Code = request.Code,
                Address = request.Address,
                Floor = request.Floor,
                Area = request.Area,
                Price = request.Price
            };

            return await _repo.AddAsync(apt);
        }
    }
}