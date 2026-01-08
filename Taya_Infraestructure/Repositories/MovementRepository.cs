namespace Taya_Infraestructure.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Taya_Domain.Entities;
    using Taya_Domain.Interfaces;
    using Taya_Helper.Filters;
    using Taya_Infraestructure.Database;

    public class MovementRepository : IMovementRepository
    {
        private readonly Taya_DbContext _DbContext = new();

        public async Task<Guid?> Add(Movement entity, CancellationToken cancellationToken)
        {
            await _DbContext.Movements.AddAsync(entity, cancellationToken);
            _DbContext.SaveChanges();

            return entity.Id;
        }

        public void Delete(Movement entity, CancellationToken cancellationToken)
        {
            _DbContext.Movements.Remove(entity);
            _DbContext.SaveChanges();
        }

        public async Task<IEnumerable<Movement>> GetAll(BaseFilter filter, CancellationToken cancellationToken)
        {
            return await _DbContext.Movements
                                   .Skip(filter.Page)
                                   .Take(filter.Size)
                                   .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Movement>> GetBy(MovementFilter filter, CancellationToken cancellationToken)
        {
            var query = _DbContext.Movements;

            if (filter.OperationDate.HasValue)
            {
                query = (DbSet<Movement>)query.Where(q => q.OperationDate == filter.OperationDate.Value);
            }

            if (filter.ValueDate.HasValue)
            {
                query = (DbSet<Movement>)query.Where(q => q.ValueDate == filter.ValueDate.Value);
            }

            if (filter.Amount.HasValue)
            {
                query = (DbSet<Movement>)query.Where(q => q.Amount == filter.Amount.Value);
            }

            if (!string.IsNullOrEmpty(filter.Category))
            {
                query = (DbSet<Movement>)query.Where(q => q.Category.ToLower() == filter.Category.ToLower());
            }

            if (!string.IsNullOrEmpty(filter.Description))
            {
                query = (DbSet<Movement>)query.Where(q => q.Description.ToLower() == filter.Description.ToLower());
            }

            return await query.Skip(filter.Page).Take(filter.Size).ToListAsync(cancellationToken);
        }

        public Movement? GetByid(Guid id, CancellationToken cancellationToken)
        {
            return (Movement?)(_DbContext.Movements.Select(m => m.Id == id));
        }

        public async Task Update(Movement entity, CancellationToken cancellationToken)
        {
            _DbContext.Movements.Update(entity);
            await _DbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
