using PostgresGraphqlDemo.API.Models;

namespace PostgresGraphqlDemo.API.BusinessService
{
    public class AuditService : IAuditService
    {
        public void SetCreationAudit(AuditableEntity entity, string username)
        {
            entity.CreatedBy = username;
            entity.CreatedAt = DateTime.UtcNow;
        }

        public void SetModificationAudit(AuditableEntity entity, string username)
        {
            entity.ModifiedBy = username;
            entity.ModifiedAt = DateTime.UtcNow;
        }
    }
}
