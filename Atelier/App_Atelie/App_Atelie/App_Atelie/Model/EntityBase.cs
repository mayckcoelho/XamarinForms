using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_Atelie.Model
{
    public abstract class EntityBase<TKey> : IEntityType<TKey>
    {
        #region Attributes
        private EntityState _entityState = EntityState.Unchanged;
        private TKey _id;
        #endregion

        #region Properties
        [Key]
        public virtual TKey Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        [NotMapped]
        public virtual EntityState EntityState
        {
            get { return _entityState; }
            set { _entityState = value; }
        }
        #endregion

        public static bool ValidateDataAnnotations<T>(this T entity, out ICollection<ValidationResult> results)
        {
            var context = new ValidationContext(entity, serviceProvider: null, items: null);
            results = new List<ValidationResult>();
            return Validator.TryValidateObject(entity, context, results, validateAllProperties: true);
        }
    }
}
