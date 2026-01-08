namespace Taya_Application.Handlers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MediatR;
    using Taya_Application.Querys;
    using Taya_Domain.Interfaces;
    using Taya_Helper.DTOs;
    using Taya_Infraestructure.Mapper;

    public class GetAllMovementQueryHandler : IRequestHandler<GetAllMovementQuery, IEnumerable<MovementDto>>
    {
        private readonly IMovementRepository _repository;

        public GetAllMovementQueryHandler(IMovementRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MovementDto>> Handle(GetAllMovementQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAll(request.BaseFilter, cancellationToken);

            return [.. (from m in data select MovementMapper.ToDto(m))];
        }
    }
}
