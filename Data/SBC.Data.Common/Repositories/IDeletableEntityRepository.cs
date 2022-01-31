namespace SBC.Data.Common.Repositories
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using SBC.Data.Common.Models;

    public interface IDeletableEntityRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IDeletableEntity
    {
        IQueryable<TEntity> AllWithDeleted();

        IQueryable<TEntity> AllAsNoTrackingWithDeleted();

        void HardDelete(TEntity entity);

        void Undelete(TEntity entity);

        Task FirstOrDefaultAsync(Func<object, bool> p);
    }
}
