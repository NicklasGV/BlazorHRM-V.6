namespace BlazorHRM.Services
{
    public class GlobalService
    {
        public bool IsLoggedIn { get; set; }

        public bool IsAdmin { get; set; }
        public int CurrentEmployeeId { get; set; }
        public string CurrentEmployeeFirstName { get; set; }
        public string CurrentEmployeeLastName { get; set; }
        public int CurrentEmployeeLoginId { get; set; }
    }
}
