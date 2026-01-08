namespace Taya_Application.Handlers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Taya_Application.Querys;
    using Taya_Domain.Interfaces;
    using Taya_Helper.DTOs;
    using Taya_Infraestructure.Mapper;

    public class GetByFiltersMovementQueryHandler : IRequestHandler<GetByFiltersMovementQuery, IEnumerable<MovementDto>>
    {
        private readonly IMovementRepository _repository;

        public GetByFiltersMovementQueryHandler(IMovementRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MovementDto>> Handle(GetByFiltersMovementQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetBy(request.MovementFilter, cancellationToken);

            return [.. (from m in data select MovementMapper.ToDto(m))];
        }
    }
}
