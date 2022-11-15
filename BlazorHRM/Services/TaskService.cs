using BlazorHRM.Models;
using BlazorHRM.Repositories;

namespace BlazorHRM.Services
{
    public class TaskService
    {
        private AdminRepository _adminRepository;
        private List<TaskModel> _taskList { get; set; } = new List<TaskModel>();
        public TaskService(AdminRepository adminRepo)
        {
            _adminRepository = adminRepo;
        }

        public List<TaskModel> GetAll()
        {
            _taskList = _adminRepository.GetAllTasks();
            return _taskList;
        }
    }
}
