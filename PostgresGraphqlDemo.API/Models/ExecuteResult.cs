using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostgresGraphqlDemo.API.Models
{
    [NotMapped]
    [Keyless]
    public class ExecuteResult
    {
        public int Result { get; set; }
    }
}
