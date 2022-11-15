using BlazorHRM.Models;
using BlazorHRM.Repositories;

namespace BlazorHRM.Services
{
    public class EmpService
    {
        private EmpRepository _empRepository;
        private EmpLoginRepository _empLogRepository;
        private EmpModel _empModel { get; set; } = new EmpModel();
        private List<EmpModel> _empList { get; set; } = new List<EmpModel>();
        private List<EmpLoginModel> _empLogList { get; set; } = new List<EmpLoginModel>();
        public EmpService(EmpRepository empRepo)
        {
            _empRepository = empRepo;
        }

        public List<EmpModel> GetAllEmps()
        {
            _empList = _empRepository.GetAllEmps();
            return _empList;
        }
        public EmpModel AddEmp(EmpModel lm)
        {
            _empModel = _empRepository.AddEmp(lm);
            return _empModel;
        }
        public EmpModel DeleteEmp(EmpModel lm)
        {
            _empModel = _empRepository.DelEmp(lm);
            return _empModel;
        }
        public EmpModel IsAdmin(EmpModel lm)
        {
            _empModel = _empRepository.IsAdmin(lm);
            return _empModel;
        }
        public List<EmpModel> CheckAdmin()
        {
            _empList = _empRepository.GetAdmins();
            return _empList;
        }
        public List<EmpLoginModel> EmpLogins()
        {
            _empLogList = _empLogRepository.GetEmpLogs();
            return _empLogList;
        }
    }
}
