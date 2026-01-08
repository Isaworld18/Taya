namespace Taya_Application.Querys
{
    using System.Collections.Generic;
    using MediatR;
    using Taya_Helper.DTOs;
    using Taya_Helper.Filters;

    public class GetAllMovementQuery : IRequest<IEnumerable<MovementDto>>
    {
        public BaseFilter BaseFilter { get; set; }

        public GetAllMovementQuery(BaseFilter filter)
        { 
            BaseFilter = filter;
        }
    }
}
