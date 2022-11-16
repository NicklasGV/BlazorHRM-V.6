namespace BlazorHRM.Models
{
    public class TaskModel
    {
        public string Task { get; set; } = string.Empty;
        public int EmployeeId { get; set; }
        public int RequestId { get; set; }
        public string FirstName { get; set; }
        public string Desc { get; set; }
        public bool IsComplete { get; set; } = false;
    }
}
