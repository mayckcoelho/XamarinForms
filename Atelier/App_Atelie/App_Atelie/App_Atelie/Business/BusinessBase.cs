using App_Atelie.DataAccess;
using Microsoft.EntityFrameworkCore;
using App_Atelie.Helpers;
using App_Atelie.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace App_Atelie.Business
{
    public abstract class BusinessBase<TEntity, TKey> : IDisposable
        // where TKey : struct
        where TEntity : EntityBase<TKey>
    {
        internal EntityRepository<TEntity, TKey> _repository;
        public EntityRepository<TEntity, TKey> Repository { get { return _repository; } }

        public BusinessBase()
        {
            _repository = new EntityRepository<TEntity, TKey>(new EntityContext());
        }

        public virtual List<TEntity> ToList()
        {
            return _repository.GetAll().ToList();
        }

        public virtual IQueryable<TEntity> GetQuery()
        {
            return _repository.GetQuery();
        }

        public virtual IEnumerable<TEntity> GetEntitiesByIds(IEnumerable<TKey> keys)
        {
            if (keys == null || keys.Any() == false)
                return new HashSet<TEntity>();
            else
                return _repository.GetMany(keys);
        }

        public virtual TEntity GetEntityById(TKey key)
        {
            //return _repository.GetEntity(key) ?? GetNewEntity();
            throw new NotImplementedException();
        }

        public virtual TEntity GetNewEntity(object[] parameters = null)
        {
            TEntity entity = ReflectionHelper.Instantiate<TEntity>(parameters);
            entity.EntityState = EntityState.Added;
            return entity;
        }

        public virtual List<TEntity> ToList(IEnumerable<TKey> keys)
        {
            return this.GetEntitiesByIds(keys).ToList();
        }

        public virtual void AddEntity(TEntity entity)
        {
            this.Validate(entity);
            _repository.Add(entity);
        }

        public virtual void UpdateEntity(TEntity entity)
        {
            this.Validate(entity);
            _repository.Update(entity);
        }

        public virtual void DeleteEntity(TEntity entity)
        {
            this.Validate(entity);
            _repository.Delete(entity);
        }

        public virtual void Validate(TEntity entity)
        {
            if (!_repository.TryValidate(entity, out List<ValidationResult> validateResults))
                throw new ArgumentException(string.Join("\r\n", validateResults.Select(e => e.ErrorMessage).ToArray()));
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
