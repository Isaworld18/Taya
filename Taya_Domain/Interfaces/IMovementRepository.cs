namespace Taya_Domain.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Taya_Domain.Entities;
    using Taya_Helper.Filters;

    public interface IMovementRepository
    {
       Task<IEnumerable<Movement>> GetAll(BaseFilter filter, CancellationToken cancellationToken);

       Task<IEnumerable<Movement>> GetBy(MovementFilter filter, CancellationToken cancellationToken);

       Movement? GetByid(Guid id, CancellationToken cancellationToken);

       Task<Guid?> Add(Movement entity, CancellationToken cancellationToken);

       Task Update(Movement entity, CancellationToken cancellationToken);

       void Delete(Movement entity, CancellationToken cancellationToken);
    }
}
