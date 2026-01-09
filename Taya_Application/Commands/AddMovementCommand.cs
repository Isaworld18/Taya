namespace Taya_Application.Commands
{
    using System;
    using MediatR;
    using Taya_Helper.DTOs;

    /// <summary>
    /// Command to add new movement
    /// </summary>
    public class AddMovementCommand : IRequest<Guid?>
    {
        public MovementDto Movement { get; set; }

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="entity"></param>
        public AddMovementCommand(MovementDto entity)
        {
            Movement = entity;
        }
    }
}
