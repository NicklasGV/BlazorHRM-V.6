using BlazorHRM.Models;
using BlazorHRM.Repositories;

namespace BlazorHRM.Services
{
    public class DepService
    {
        private DepRepository _depRepository;
        private List<DepartmentModel> _depsList { get; set; } = new List<DepartmentModel>();
        public DepService(DepRepository depRepo)
        {
            _depRepository = depRepo;
        }

        public List<DepartmentModel> GetAll()
        {
            _depsList = _depRepository.GetAll();
            return _depsList;
        }
    }
}
