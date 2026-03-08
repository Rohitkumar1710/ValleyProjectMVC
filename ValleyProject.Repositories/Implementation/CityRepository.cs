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
            dataContext = _context;
        }
        public async Task<List<City>> GetAll()
        {
            try
            {
                var result = await _context.cities.ToListAsync();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<City> GetById(int id)
        {
            try
            {
                var result = _context.cities.FirstOrDefault(x => x.Id == id);
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public void Update(City city)
        {
            try
            {
                _context.cities.Update(city);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public void Save(City city)
        {
            try
            {
                _context.cities.Add(city);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void Delete(int id)
        {
            try
            {
                var result = _context.cities.FirstOrDefault(x => x.Id == id);
                if (result != null)
                {
                    _context.cities.Remove(result);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
