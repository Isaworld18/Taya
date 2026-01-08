namespace Taya_Application.Querys
{
    using System.Collections.Generic;
    using MediatR;
    using Taya_Helper.DTOs;
    using Taya_Helper.Filters;

    public class GetByFiltersMovementQuery : IRequest<IEnumerable<MovementDto>>
    {
        public MovementFilter MovementFilter { get; set; }

        public GetByFiltersMovementQuery(MovementFilter movementFilter)
        {
            MovementFilter = movementFilter;
        }
    }
}
