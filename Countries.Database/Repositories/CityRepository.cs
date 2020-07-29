using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Countries.Database.Repositories
{
    public class CityRepository : IRepository<City>
    {
        private readonly CountryContext _context;

        public CityRepository(CountryContext context)
        {
            _context = context;
        }

        public void Create(City entity)
        {
            _context.Cities.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var entity = _context.Cities.Find(id);
            _context.Cities.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<City> Get()
        {
            return _context.Cities;
        }

        public City Get(long id)
        {
            return _context.Cities.Find(id);
        }

        public void Update(City entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
