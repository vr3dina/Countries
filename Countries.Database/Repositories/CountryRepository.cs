using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Countries.Database.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly CountryContext _context;

        public CountryRepository(CountryContext context)
        {
            _context = context;
        }

        public void Create(Country entity)
        {
            _context.Countries.Add(entity);
            _context.SaveChanges();
        }

        public void Create(CountryDisplayModel entity)
        {
            var country = new Country()
            {
                Name = entity.Name,
                Code = entity.Alpha3Code,
                Area = entity.Area,
                Population = entity.Population
            };

            var capital = _context.Cities.SingleOrDefault(city => city.Name == entity.Capital);
            if (capital == null)
            {
                capital = new City() { Name = entity.Capital };
                _context.Cities.Add(capital);
                _context.SaveChanges();
            }
            country.Capital = capital;

            var region = _context.Regions.SingleOrDefault(r => r.Name == entity.Region);
            if (region == null)
            {
                region = new Region() { Name = entity.Region };
                _context.Regions.Add(region);
                _context.SaveChanges();
            }
            country.Region = region;

            var savedCountry = _context.Countries.SingleOrDefault(c => c.Code == entity.Alpha3Code);
            if (savedCountry != null)
                Update(savedCountry);
            else
                Create(country);

            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var entity = _context.Countries.Find(id);
            _context.Countries.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Country> Get()
        {
            return _context.Countries.Include(c => c.Capital).Include(c => c.Region);
        }

        public Country Get(long id)
        {
            return _context.Countries.Find(id);
        }

        public void Update(Country entity)
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

        public void Update(CountryDisplayModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
