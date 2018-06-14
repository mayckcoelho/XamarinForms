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
        public EntityRepository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException("O argumento DbContext passado como parâmetro não pode ser nulo");
        }

        private DbContext _context;

        #region Methods


        /// <summary>
        /// Adiciona um novo objeto
        /// </summary>
        /// Entidade
        public void Add(TEntity entity)
        {
            if (entity != null)
            {
                this.changeEntityState(entity, EntityState.Added);
                this.saveChanges(entity);
            }
        }

        /// <summary>
        /// Troca o EntityState de um objeto do contexto do Entity Framework
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="newState"></param>
        private void changeEntityState(dynamic entity, EntityState newState)
        {
            if (entity != null)
            {
                EntityEntry entry = getDbEntityEntry(entity);
                if ((entry != null) && (entry.Entity != null))
                {
                    if (entry.State != newState) entry.State = newState;
                }
            }
        }

        private EntityEntry getDbEntityEntry(dynamic entity)
        {
            return _context.ChangeTracker.Entries().Where(e => Object.Equals((e.Entity as dynamic).CheckKey, entity.CheckKey)).FirstOrDefault() ?? _context.Entry(entity);
        }

        /// <summary>
        /// Fecha a conexão caso esteja aberta
        /// </summary>
        public void CloseConnection(DbConnection conn)
        {
            if ((conn != null) && (conn.State != ConnectionState.Closed))
                conn.Close();
        }

        /// <summary>
        /// Remove o objeto do banco
        /// </summary>
        /// Entidade
        public void Delete(TEntity entity)
        {
            if (entity != null)
            {
                entity.EntityState = EntityState.Deleted;
                this.saveChanges(entity);
            }
        }

        /// <summary>
        /// Exclui um objeto do contexto do Entity Framework
        /// </summary>
        /// <param name="entity"></param>
        public void Detach(dynamic entity)
        {
            if (entity != null)
            {
                EntityEntry entry = this.getDbEntityEntry(entity);
                if ((entry != null) && (entry.Entity != null))
                {
                    entry.State = EntityState.Detached;
                }
            }
        }

        /// <summary>
        /// Retira todos os objetos do contexto
        /// </summary>
        public void DetachAllEntities()
        {
            foreach (dynamic entity in _context.ChangeTracker.Entries())
            {
                _context.Entry(entity.Entity).State = EntityState.Detached;
            }

        }

        /// <summary>
        /// Obtém um objeto do banco
        /// </summary>
        /// ID do objeto
        /// Entidade
        public TEntity Get(TKey id)
        {
            TEntity entity = null;
            if (!this.IsNewKey(id))
                entity = getEntity(id);
            return entity;
        }

        /// <summary>
        /// Obtém uma lista de objetos do banco
        /// </summary>
        /// IDs dos objetos
        /// Entidade
        public IEnumerable<TEntity> GetMany(IEnumerable<TKey> ids)
        {
            return getEntities(ids);
        }

        /// <summary>
        /// Obtém todos os objetos do banco.
        /// </summary>
        /// Lista de entidades
        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsNoTracking().AsEnumerable();
        }

        /// <summary>
        /// Obtém um obeto supostamente existente no banco de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private TEntity getEntity(TKey id)
        {
            string sid = Convert.ToString(id);
            TEntity entity = _context.Set<TEntity>().AsNoTracking().Where(p => p.Id.ToString() == sid).Select(e => e).FirstOrDefault();
            return entity;
        }

        /// <summary>
        /// Obtém uma lista de objetos supostamente existentes no banco de dados
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        private IEnumerable<TEntity> getEntities(IEnumerable<TKey> ids)
        {
            return _context.Set<TEntity>().AsNoTracking().Where(p => ids.Contains(p.Id)).Select(e => e).AsEnumerable();
        }

        /// <summary>
        /// Valida se é um objeto novo
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool IsNewKey(TKey key)
        {
            try
            {
                return Convert.ToDecimal(key.ToString()) <= 0;
            }
            catch (Exception)
            {
                return Object.Equals(key, default(TKey));
            }
        }

        /// <summary>
        /// Possibilita criar uma consulta personalizada utilizando a interface IQueryable
        /// </summary>
        /// Objeto IQueryable
        public virtual IQueryable<TEntity> AsQueryable()
        {
            return _context.Set<TEntity>().AsNoTracking().AsQueryable();
        }

        /// <summary>
        /// Begins a transaction on the underlying store connection
        /// </summary>
        /// <returns>a System.Data.Entity.DbContextTransaction object wrapping access to the underlying store's transaction object</returns>
        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        /// <summary>
        /// Begins a transaction on the underlying store connection
        /// </summary>
        /// <param name="isolationLevel">The database isolation level with which the underlying store transaction will be created</param>
        /// <returns>a System.Data.Entity.DbContextTransaction object wrapping access to the underlying store's transaction object</returns>
        public void BeginTransaction(IsolationLevel isolationLevel)
        {
            _context.Database.BeginTransaction(isolationLevel);
        }

        /// <summary>
        /// Commits the underlying store transaction
        /// </summary>
        public void CommitTransaction()
        {
            _context.Database.CurrentTransaction.Commit();
        }

        /// <summary>
        /// Gets the transaction the underlying store connection is enlisted in. May be null.
        /// </summary>
        /// <returns></returns>
        public IDbContextTransaction CurrentTransaction()
        {
            return _context.Database.CurrentTransaction;
        }

        /// <summary>
        /// Verifica se há uma transação em andamento
        /// </summary>
        /// <returns></returns>
        public bool HasTransaction()
        {
            return _context.Database.CurrentTransaction != null;
        }

        /// <summary>
        /// Rolls back the underlying store transaction
        /// </summary>
        public void Rollback()
        {
            this.DetachAllEntities();
            _context.Database.CurrentTransaction.Rollback();
        }

        /// <summary>
        /// Salva as alterações ocorridas no contexto
        /// </summary>
        private int saveChanges(TEntity entity)
        {
            try
            {
                try
                {
                    int result = _context.SaveChanges();
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception e)
                {
                    if (this.HasValidationErrors())
                        throw new ArgumentException(this.GetValidationErrorMessage(), e);
                    else
                        throw e;
                }
            }
            finally
            {
                this.DetachAllEntities();
            }
        }

        /// <summary>
        /// Persiste uma entidade no banco confirme a opção de commit passada por parâmetro
        /// </summary>
        /// <param name="entity"></param>
        public void SaveEntity(TEntity entity)
        {
            if (entity != null)
            {
                try
                {
                    TKey keyValue = ((IEntityType<TKey>)entity).Id;

                    if (this.IsNewKey(keyValue))
                        this.Add(entity);
                    else
                        this.Update(entity);

                }
                catch (Exception) { throw; }
            }
        }

        /// <summary>
        /// Atualiza um objeto existente
        /// </summary>
        /// Entidade
        public void Update(TEntity entity)
        {
            if (entity != null)
            {
                this.changeEntityState(entity, EntityState.Modified);
                this.saveChanges(entity);
            }
        }
        #endregion Methods

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
