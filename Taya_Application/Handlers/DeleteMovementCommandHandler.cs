namespace Taya_Application.Handlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Taya_Application.Commands;
    using Taya_Domain.Interfaces;

    public class DeleteMovementCommandHandler : IRequestHandler<DeleteMovementCommand, bool>
    {
        private readonly IMovementRepository _repository;

        public DeleteMovementCommandHandler(IMovementRepository repository)
        { 
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteMovementCommand request, CancellationToken cancellationToken)
        {
            bool result = true;

            try
            {
                var entity = _repository.GetByid(request.MovementId, cancellationToken);

                _repository.Delete(entity, cancellationToken);
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }
    }
}
