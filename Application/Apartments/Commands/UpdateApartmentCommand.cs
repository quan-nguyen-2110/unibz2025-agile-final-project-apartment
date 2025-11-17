using Application.Interfaces;
using MediatR;

namespace Application.Apartments.Commands;

public class UpdateApartmentCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string Code { get; set; } = default!;
    public string Address { get; set; } = default!;
    public int Floor { get; set; }
    public double Area { get; set; }
    public decimal Price { get; set; }

    public UpdateApartmentCommand() { }

    public class UpdateApartmentHandler : IRequestHandler<UpdateApartmentCommand, bool>
    {
        private readonly IApartmentRepository _repo;

        public UpdateApartmentHandler(IApartmentRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(UpdateApartmentCommand request, CancellationToken cancellationToken)
        {
            var apt = await _repo.GetByIdAsync(request.Id);

            if (apt == null)
                return false;

            apt.Code = request.Code;
            apt.Address = request.Address;
            apt.Floor = request.Floor;
            apt.Area = request.Area;
            apt.Price = request.Price;

            await _repo.UpdateAsync(apt);

            return true;
        }
    }
}