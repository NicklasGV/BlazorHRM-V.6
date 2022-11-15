using BlazorHRM.Models;
using BlazorHRM.Repositories;

namespace BlazorHRM.Services
{
    public class CityService
    {
        private CityRepository _cityRepository;
        private List<CityModel> _citiesList { get; set; } = new List<CityModel>();
        public CityService(CityRepository cityRepo)
        {
            _cityRepository = cityRepo;
        }

        public List<CityModel> GetAll()
        {
            _citiesList = _cityRepository.GetAll();
            return _citiesList;
        }
    }
}
