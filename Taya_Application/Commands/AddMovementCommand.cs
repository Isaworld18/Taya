namespace Taya_Application.Commands
{
    using System;
    using MediatR;
    using Taya_Helper.DTOs;

    public class AddMovementCommand : IRequest<Guid?>
    {
        public MovementDto Movement { get; set; }

        public AddMovementCommand(MovementDto entity)
        {
            Movement = entity;
        }
    }
}
