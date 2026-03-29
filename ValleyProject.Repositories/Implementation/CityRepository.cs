using DataAccessLayer.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValleyProject.Entities.Model;
using ValleyProject.Repositories.Interface;

namespace ValleyProject.Repositories.Implementation
{
    public class CityRepository : ICityRepositroy
    {
        private readonly DataContext _context;
        public CityRepository(DataContext dataContext)
        {
            _context = dataContext; // Fix assignment
        }
        public async Task<List<City>> GetAll()
        {
            try
            {
                var result = await _context.cities.Include(x=>x.State).ThenInclude(y=> y.Country).ToListAsync();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public  async Task<City> GetById(int id)
        {
            try
            {
                var result =await _context.cities.FindAsync(id);
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task Update(City city)
        {
            try
            {
                _context.cities.Update(city);
               await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task Save(City city)
        {
            try
            {
                _context.cities.Add(city);
               await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task Delete(int id)
        {
            try
            {
                var result =await _context.cities.FindAsync(id);
                if (result != null)
                {
                    _context.cities.Remove(result);
                   await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
