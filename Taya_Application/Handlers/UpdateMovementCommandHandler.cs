namespace Taya_Application.Handlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Taya_Application.Commands;
    using Taya_Domain.Interfaces;
    using Taya_Infraestructure.Mapper;

    public class UpdateMovementCommandHandler : IRequestHandler<UpdateMovementCommand, Guid?>
    {
        private readonly IMovementRepository _repository;

        public UpdateMovementCommandHandler(IMovementRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid?> Handle(UpdateMovementCommand request, CancellationToken cancellationToken)
        {
            await _repository.Update(MovementMapper.ToEntity(request.MovementData), cancellationToken);

            return request.MovementData.Id;
        }
    }
}
