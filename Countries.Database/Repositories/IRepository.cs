using Domain.Models;
using System.Collections.Generic;

namespace Countries.Database.Repositories
{
    /// <summary>
    /// Provides CRUD actions with country
    /// </summary>
    public interface ICountryRepository
    {
        /// <summary>
        /// get all entities
        /// </summary>
        /// <returns>Collection of countries</returns>
        public IEnumerable<Country> Get();

        /// <summary>
        /// get entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Country Get(long id);

        /// <summary>
        /// Update entity from CountryDisplayModel
        /// </summary>
        /// <param name="entity"></param>
        public void Update(CountryDisplayModel entity);

        /// <summary>
        /// Create entity from CountryDisplayModel
        /// </summary>
        /// <param name="entity"></param>
        public void Create(CountryDisplayModel entity);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        public void Update(Country entity);

        /// <summary>
        /// Create entity 
        /// </summary>
        /// <param name="entity"></param>
        public void Create(Country entity);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">entity id</param>
        public void Delete(long id);
    }
}
