using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValleyProject.Entities.Model;

namespace ValleyProject.Repositories.Interface
{
    public interface IStateRepo
    {
       public Task AddState(State state);
       public  Task<List<State>> GetAllStates();
       public Task<State> GetStateById(int id);
       public Task<State> GetStateByName(string name);
       public Task UpdateState(State state);
       public Task DeleteState(int id);

    }
}
