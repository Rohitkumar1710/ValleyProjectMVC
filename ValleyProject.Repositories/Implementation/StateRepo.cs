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
        public void AddState(State state)
        {
            try
            {
                _context.states.Add(state);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<State> GetAllStates()
        {
            try
            {
                return _context.states.Include(x=>x.Country).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public State GetStateById(int id)
        {
            try
            {
                return _context.states.FirstOrDefault(s => s.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public State GetStateByName(string name)
        {
            try
            {
                return _context.states.FirstOrDefault(s => s.Name == name);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void UpdateState(State state)
        {
            try
            {
                _context.states.Update(state);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void DeleteState(int id)
        {
            try
            {
                var state = _context.states.FirstOrDefault(s => s.Id == id);
                if (state != null)
                {
                    _context.states.Remove(state);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
