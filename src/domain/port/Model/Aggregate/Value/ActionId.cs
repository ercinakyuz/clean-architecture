using Company.Framework.Core.Identity;

namespace Clean.Domain.Port.Model.Aggregate.Value
{
    public class ActionId : CoreId<ActionId, Guid>
    {
        public ActionId()
        {
            
        }
        public ActionId(Guid value) : base(value)
        {
        }

        public ActionId(IdGenerationType generationType) : base(generationType)
        {
        }
    }
}
