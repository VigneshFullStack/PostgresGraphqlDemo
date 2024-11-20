namespace PostgresGraphqlDemo.API.Models
{
    public class Employee : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public decimal Salary { get; set; }
    }
}
