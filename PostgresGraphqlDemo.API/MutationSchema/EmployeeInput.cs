namespace PostgresGraphqlDemo.API.Models
{
    public class EmployeeInput : AuditableEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public decimal Salary { get; set; }
    }
}
