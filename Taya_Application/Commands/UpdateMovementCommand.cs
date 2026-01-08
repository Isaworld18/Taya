namespace Taya_Application.Commands
{
    using System;
    using MediatR;
    using Taya_Helper.DTOs;

    public class UpdateMovementCommand : IRequest<Guid?>
    {
        public MovementDto MovementData { get; set; }

        public UpdateMovementCommand(MovementDto dto)
        { 
            MovementData = dto;
        }
    }
}
