using Clean.Output.Port.Data.Entities;
using Clean.Output.Port.Data.Repositories;
using Company.Framework.Data.Mongo.Context;
using Company.Framework.Data.Mongo.Repository;

namespace Clean.Output.Adapter.Data.Repositories
{
    public class ActionRepository : CoreOptionalMongoRepository<ActionEntity, Guid>, IActionRepository
    {
        public ActionRepository(IMongoDbContext dbContext) : base(dbContext, "actions")
        {
        }
    }
}
