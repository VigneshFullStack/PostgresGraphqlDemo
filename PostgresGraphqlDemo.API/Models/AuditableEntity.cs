using System.ComponentModel.DataAnnotations.Schema;

namespace PostgresGraphqlDemo.API.Models
{
    public class AuditableEntity
    {
        [Column("created_by")]
        public string? CreatedBy { get; set; }
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
        [Column("modified_by")]
        public string? ModifiedBy { get; set; }
        [Column("modified_at")]
        public DateTime? ModifiedAt { get; set; }
    }
}
