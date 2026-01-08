namespace Taya_Application.Handlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Taya_Application.Commands;
    using Taya_Domain.Interfaces;
    using Taya_Infraestructure.Mapper;

    public class AddMovementCommandHandler : IRequestHandler<AddMovementCommand, Guid?>
    {
        private readonly IMovementRepository _repository;

        public AddMovementCommandHandler(IMovementRepository movementRepository)
        {
            _repository = movementRepository;
        }

        public async Task<Guid?> Handle(AddMovementCommand request, CancellationToken cancellationToken)
        {
            return await _repository.Add(MovementMapper.ToEntity(request.Movement), cancellationToken);
        }
    }
}
