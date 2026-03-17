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
       public void AddState(State state);
       public  List<State> GetAllStates();
       public State GetStateById(int id);
       public State GetStateByName(string name);
       public void UpdateState(State state);
       public void DeleteState(int id);

    }
}
