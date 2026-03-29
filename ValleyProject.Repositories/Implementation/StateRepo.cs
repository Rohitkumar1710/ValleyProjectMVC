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
    public class StateRepo : IStateRepo
    {
        private readonly DataContext _context;

        public StateRepo(DataContext context)
        {
            _context = context;
        }
        public async Task AddState(State state)
        {
            try
            {
                _context.states.Add(state);
               await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<State>> GetAllStates()
        {
            try
            {
                return await _context.states.Include(x=>x.Country).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<State> GetStateById(int id)
        {
            try
            {
                return await _context.states.FindAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<State> GetStateByName(string name)
        {
            try
            {
                return await _context.states.FindAsync(name);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task UpdateState(State state)
        {
            try
            {
                _context.states.Update(state);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task DeleteState(int id)
        {
            try
            {
                var state =await _context.states.FindAsync(id);
                if (state != null)
                {
                    _context.states.Remove(state);
                  await  _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
