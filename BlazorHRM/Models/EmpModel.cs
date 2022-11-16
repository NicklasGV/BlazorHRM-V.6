namespace BlazorHRM.Models
{
    public class EmpModel
    {
        public int Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
        public int LoginId { get; set; }
        public int CityId { get; set; }
        public int DepartmentId { get; set; } = 7;
    }
}
