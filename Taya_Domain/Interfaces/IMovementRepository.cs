namespace Taya_Domain.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Taya_Domain.Entities;
    using Taya_Helper.Filters;

    public interface IMovementRepository
    {
       Task<IEnumerable<Movement>> GetAll(BaseFilter filter);

       Task<IEnumerable<Movement>> GetBy(MovementFilter filter);

       Movement? GetByid(Guid id);

       Task<Guid?> Add(Movement entity);

       Task Update(Movement entity);

       void Delete(Movement entity);
    }
}
