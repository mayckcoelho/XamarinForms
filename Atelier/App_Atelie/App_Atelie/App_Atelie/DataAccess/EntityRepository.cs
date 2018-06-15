using App_Atelie.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data.Common;

namespace App_Atelie.DataAccess
{
    public class EntityRepository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : EntityBase<TKey>
    {
        public EntityRepository(EntityContext context)
        {
            _context = context ?? throw new ArgumentNullException("O argumento DbContext passado como parâmetro não pode ser nulo");
        }

        private EntityContext _context;

        #region Methods
        public void Add(TEntity Entity)
        {
            if (Entity != null)
            {
                _context.Add(Entity);
                _context.SaveChanges();
            }
        }

        private bool TryValidate(TEntity Entity, out List<ValidationResult> results)
        {
            var context = new ValidationContext(Entity, serviceProvider: null, items: null);
            results = new List<ValidationResult>();
            return Validator.TryValidateObject(Entity, context, results, validateAllProperties: true);
        }

        public void Delete(TEntity Entity)
        {
            if (Entity != null)
            {
                var currentEntity = Get(Entity.Id);
                _context.Set<TEntity>().Remove(currentEntity);
                _context.SaveChanges();
            }
        }

        public void Update(TEntity Entity)
        {
            if (Entity != null)
            {
                _context.Set<TEntity>().Update(Entity);
                _context.SaveChanges();
            }
        }

        public TEntity Get(TKey id)
        {
            string sid = Convert.ToString(id);
            TEntity entity = _context.Set<TEntity>().AsNoTracking().Where(p => p.Id.ToString() == sid).Select(e => e).FirstOrDefault();
            return entity;
        }

        public IEnumerable<TEntity> GetMany(IEnumerable<TKey> Keys)
        {
            return _context.Set<TEntity>().AsNoTracking().Where(p => Keys.Contains(p.Id)).Select(e => e).AsEnumerable();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsNoTracking().AsEnumerable();
        }
        #endregion

        #region Implementation
        /// <summary>
        /// Libera os recursos.
        /// </summary>
        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }
        #endregion Implementation

        #region Properties
        public EntityContext Context { get { return (_context as EntityContext); } }

        public DbSet<TEntity> Repository { get { return _context.Set<TEntity>(); } }
        #endregion Properties
    }
}
