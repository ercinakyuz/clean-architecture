using Company.Framework.Messaging.Kafka.AdminClient.Context.Provider;
using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Api.Controllers
{
    [ApiController]
    [Route("kafka")]
    public class KafkaController : ControllerBase
    {
        private readonly IAdminClient _adminClient;

        public KafkaController(IKafkaAdminClientContextProvider kafkaAdminClientContextProvider)
        {
            _adminClient = kafkaAdminClientContextProvider.Resolve("TaskKafka").Resolve<IAdminClient>();
        }

        [HttpDelete]
        public async Task ClearTopics()
        {
            await _adminClient.DeleteTopicsAsync(new[] { "ping-applied" });
        }
    }
}
