namespace RetailApi.Models
{
    public class EmployeeDepartment
    {
        public int ID { get; set; }
        public string CODE { get; set; }
        public string DEPT_NAME { get; set; }
        public string COMPANY_ID { get; set; }
        public string COMPANY_NAME { get; set; }
    }
    public class EmployeeDepartmentResponse
    {
        public string flag { get; set; }
        public string message { get; set; }
        public EmployeeDepartment data { get; set; }
    }
}
