using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Countries.Database.Repositories
{
    public class RegionRepository : IRepository<Region>
    {
        private readonly CountryContext _context;

        public RegionRepository(CountryContext context)
        {
            _context = context;
        }

        public IEnumerable<Region> Get()
        {
            return _context.Regions;
        }

        public Region Get(long id)
        {
            return _context.Regions.Find(id);
        }

        public void Update(Region region)
        {
            _context.Entry(region).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public void Create(Region region)
        {
            _context.Regions.Add(region);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var region = _context.Regions.Find(id);
            _context.Regions.Remove(region);
            _context.SaveChanges();
        }

     }
}
