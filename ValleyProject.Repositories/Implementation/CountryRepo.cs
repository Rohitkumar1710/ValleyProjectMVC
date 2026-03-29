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
    public class CountryRepo:ICountryRepo
    {
        private readonly DataContext _context;

        public CountryRepo(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Country>> GetAll()
        {
            try
            {
               var countries=await _context.Countries.ToListAsync();
                return countries;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Country> GetById(int id)
        {
            try
            {
                var result =await _context.Countries.FindAsync(id);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task Update(Country country)
        {
            try
            {
                _context.Countries.Update(country);
               await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task Save(Country country)
        {
            try
            {
               await _context.Countries.AddAsync(country);
              await  _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task Delete(Country country)
        {
            try
            {
                _context.Countries.Remove(country);
               await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
