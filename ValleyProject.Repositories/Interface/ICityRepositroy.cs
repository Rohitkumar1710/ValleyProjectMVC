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
         public  City GetById(int id);
         public void Update(City city);
         public void Save(City city);
        public void Delete(int id);
     }
}
