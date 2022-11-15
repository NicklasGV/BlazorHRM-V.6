using BlazorHRM.Models;
using BlazorHRM.Pages;
using BlazorHRM.Repositories;

namespace BlazorHRM.Services
{
    public class LoginService
    {
        private LoginRepository _loginRepository;
        private LoginModel _loginModel { get; set; } = new LoginModel();
        private List<LoginModel> _loginList { get; set; } = new List<LoginModel>();
        public LoginService(LoginRepository loginRepo)
        {
            _loginRepository = loginRepo;
        }

        public LoginModel AddLogin(LoginModel lm)
        {
            _loginModel = _loginRepository.AddLogin(lm);
            return _loginModel;
        }

        public List<LoginModel> GetPWS()
        {
            _loginList = _loginRepository.GetPWS();
            return _loginList;
        }
    }
}
