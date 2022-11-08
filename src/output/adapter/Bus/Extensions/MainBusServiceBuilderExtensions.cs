using Company.Framework.Messaging.Bus.Builder;
using Company.Framework.Messaging.Kafka.Bus.Builder;
using Company.Framework.Messaging.Kafka.Bus.Extensions;
using Company.Framework.Messaging.RabbitMq.Bus.Builder;
using Company.Framework.Messaging.RabbitMq.Bus.Extensions;
using MediatR;

namespace Clean.Output.Adapter.Bus.Extensions
{
    public static class MainBusServiceBuilderExtensions
    {
        public static MainBusServiceBuilder BuildTaskRabbit(this MainBusServiceBuilder mainBusServiceBuilder)
        {
            return mainBusServiceBuilder.AddTaskRabbit().BuildBus().BuildRabbit();
        }
        public static MainBusServiceBuilder BuildTaskRabbitThatConsume<TMessage>(this MainBusServiceBuilder mainBusServiceBuilder, string consumerName) where TMessage : INotification
        {
            return mainBusServiceBuilder.AddTaskRabbit().ThatConsume<TMessage>(consumerName).BuildBus().BuildRabbit();
        }
        public static MainBusServiceBuilder BuildTaskKafka(this MainBusServiceBuilder mainBusServiceBuilder)
        {
            return mainBusServiceBuilder.AddTaskKafka().BuildBus().BuildKafka();
        }
        public static MainBusServiceBuilder BuildTaskKafkaThatConsume<TMessage>(this MainBusServiceBuilder mainBusServiceBuilder, string consumerName) where TMessage : INotification
        {
            return mainBusServiceBuilder.AddTaskKafka().ThatConsume<TMessage>(consumerName).BuildBus().BuildKafka();
        }
        private static KafkaBusServiceBuilder AddTaskKafka(this MainBusServiceBuilder mainBusServiceBuilder)
        {
            return mainBusServiceBuilder.WithKafka().WithBus("TaskKafka");
        }

        private static RabbitBusServiceBuilder AddTaskRabbit(this MainBusServiceBuilder mainBusServiceBuilder)
        {
            return mainBusServiceBuilder.WithRabbit().WithBus("TaskRabbit");
        }
    }
}
