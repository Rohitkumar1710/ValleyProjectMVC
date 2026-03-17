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
        List<Country> GetAll();
        Country GetById(int id);
        void Update(Country country);
        void Save(Country country);
        void Delete(Country country);
    }
}
