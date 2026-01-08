namespace Taya_Application.Handlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Taya_Application.Querys;
    using Taya_Domain.Interfaces;
    using Taya_Helper.DTOs;
    using Taya_Infraestructure.Mapper;

    public class GetByIdMovementQueryHandler : IRequestHandler<GetByIdMovementQuery, MovementDto>
    {
        private readonly IMovementRepository _repository;

        public GetByIdMovementQueryHandler(IMovementRepository repository)
        { 
            _repository = repository;
        }

        public async Task<MovementDto> Handle(GetByIdMovementQuery request, CancellationToken cancellationToken)
        {
            var data = _repository.GetByid(request.MovementId, cancellationToken);

            return MovementMapper.ToDto(data != null ? data : new Taya_Domain.Entities.Movement());
        }
    }
}
