using BlazorHRM.Models;
using BlazorHRM.Repositories;

namespace BlazorHRM.Services
{
    public class TaskService
    {
        private AdminRepository _adminRepository;
        private List<TaskModel> _taskList { get; set; } = new List<TaskModel>();
        private TaskModel _taskModel { get; set; } = new TaskModel();
        public TaskService(AdminRepository adminRepo)
        {
            _adminRepository = adminRepo;
        }

        public List<TaskModel> GetAll()
        {
            _taskList = _adminRepository.GetAllTasks();
            return _taskList;
        }

        public TaskModel GetReqs(int empId, int reqId) 
        {
            _taskModel = _adminRepository.GetRequests(empId, reqId);
            return _taskModel;
        }
    }
}
