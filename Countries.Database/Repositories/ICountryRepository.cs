using System.Collections.Generic;

namespace Countries.Database.Repositories
{
    /// <summary>
    /// Provides CRUD actions with database entity
    /// </summary>
    public interface IRepository<T> where T: class
    {
        /// <summary>
        /// get all entities
        /// </summary>
        /// <returns>Collection of entities</returns>
        public IEnumerable<T> Get();

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Get(long id);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">updated entity</param>
        public void Update(T entity);

        /// <summary>
        /// Create entity
        /// </summary>
        /// <param name="entity">new entity</param>
        public void Create(T entity);

        /// <summary>
        /// Delete entity from db
        /// </summary>
        /// <param name="id">deleted entity id</param>
        public void Delete(long id);
    }
}
