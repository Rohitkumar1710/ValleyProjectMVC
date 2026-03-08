using DataAccessLayer.ApplicationDbContext;
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
        public List<Country> GetAll()
        {
            try
            {
                return _context.Countries.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public Country GetById(int id)
        {
            try
            {
                var result = _context.Countries.FirstOrDefault(x => x.Id == id);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void Update(Country country)
        {
            try
            {
                _context.Countries.Update(country);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void Save(Country country)
        {
            try
            {
                _context.Countries.Add(country);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void Delete(Country country)
        {
            try
            {
                _context.Countries.Remove(country);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
