using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValleyProject.Entities.Model;

namespace ValleyProject.Repositories.Interface
{
    public interface ICountryRepo
    {
       Task< IEnumerable<Country>> GetAll();
        Task<Country> GetById(int id);
        Task Update(Country country);
        Task Save(Country country);
        Task Delete(Country country);
    }
}
