using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValleyProject.Entities.Model;

namespace ValleyProject.Repositories.Interface
{
    public interface ICityRepositroy
     {
         public Task<List<City>> GetAll();
         public  Task<City> GetById(int id);
         public Task Update(City city);
         public Task Save(City city);
        public Task Delete(int id);
     }
}
