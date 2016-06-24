using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atlant.Model;
using Atlant.Repository;

namespace Atlant.Service
{
    public class CountryService : EntityService<Country>, ICountryService
    {
        IUnitOfWork _unitofWork;
        ICountryRepository _countryRepository;

        public CountryService(IUnitOfWork unitOfWork, ICountryRepository repository) 
            : base(unitOfWork, repository)
        {
            _unitofWork = unitOfWork;
            _countryRepository = repository;
        }

        public Country GetById(int Id)
        {
            return _countryRepository.GetById(Id);
        }
    }
}
