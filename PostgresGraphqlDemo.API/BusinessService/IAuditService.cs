using PostgresGraphqlDemo.API.Models;

namespace PostgresGraphqlDemo.API.BusinessService
{
    public interface IAuditService
    {
        void SetCreationAudit(AuditableEntity entity, string username);

        void SetModificationAudit(AuditableEntity entity, string username);
    }
}
