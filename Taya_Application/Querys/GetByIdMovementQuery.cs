namespace Taya_Application.Querys
{
    using System;
    using MediatR;
    using Taya_Helper.DTOs;

    public class GetByIdMovementQuery : IRequest<MovementDto>
    {
        public Guid MovementId { get; set; }

        public GetByIdMovementQuery(Guid id)
        { 
            MovementId = id;
        }
    }
}
