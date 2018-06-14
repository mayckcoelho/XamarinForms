using App_Atelie.Model;
using System.Collections.Generic;
using System.Linq;

namespace App_Atelie.DataAccess
{
    public interface IRepository<TEntity, TKey>
        where TEntity : IEntityType<TKey>
    {
        #region Methods
        void Add(TEntity Entity);
        void Delete(TEntity Entity);
        void Update(TEntity Entity);

        TEntity Get(TKey id);
        IEnumerable<TEntity> GetMany(IEnumerable<TKey> Keys);
        IEnumerable<TEntity> GetAll();

        IQueryable<TEntity> AsQueryable();
        #endregion Methods
    }
}
