using System.ComponentModel.DataAnnotations.Schema;

namespace PostgresGraphqlDemo.API.Models
{
    public class Employee : AuditableEntity
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("age")]
        public int Age { get; set; }
        [Column("gender")]
        public string Gender { get; set; }
        [Column("salary")]
        public decimal Salary { get; set; }
    }
}
