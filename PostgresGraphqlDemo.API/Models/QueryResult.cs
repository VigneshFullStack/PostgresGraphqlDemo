using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostgresGraphqlDemo.API.Models
{
    [NotMapped]
    [Keyless]
    public class QueryResult
    {
        public string? JsonResult { get; set; }
    }
}
