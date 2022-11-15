namespace BlazorHRM.Services
{
    public class GlobalService
    {
        public bool IsLoggedIn { get; set; } = false;

        public bool IsAdmin { get; set; } = false;
        public int CurrentEmployeeId { get; set; }
        public string CurrentEmployeeFirstName { get; set; }
        public string CurrentEmployeeLastName { get; set; }
        public int CurrentEmployeeLoginId { get; set; }
        public string CurrentEmployeeDepartmentName { get; set; }
        public int CurrentEmployeeDepartmentId { get; set; }
    }
}
