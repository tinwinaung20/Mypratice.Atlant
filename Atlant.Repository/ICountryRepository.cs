using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atlant.Model;

namespace Atlant.Repository
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        Country GetById(int Id);
    }
}
