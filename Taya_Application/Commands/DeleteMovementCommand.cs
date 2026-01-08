namespace Taya_Application.Commands
{
    using System;
    using MediatR;

    public class DeleteMovementCommand : IRequest<bool>
    {
        public Guid MovementId { get; set; }

        public DeleteMovementCommand(Guid id)
        {
            MovementId = id;
        }
    }
}
