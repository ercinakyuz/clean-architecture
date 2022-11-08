using Company.Framework.Core.Error;
using Company.Framework.Domain.Model.Exception;

namespace Clean.Domain.Adapter.Model.Aggregate.Builder.Error
{
    public static class ActionBuilderErrors
    {
        public static AggregateBuilderException ActionNotFound = new(new CoreError("ACABE-1", "Action not found"));
    }
}
