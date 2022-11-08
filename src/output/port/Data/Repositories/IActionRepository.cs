using Clean.Output.Port.Data.Entities;
using Company.Framework.Data.Repository;

namespace Clean.Output.Port.Data.Repositories
{
    public interface IActionRepository : IOptionalRepository<ActionEntity, Guid>
    {
    }
}
