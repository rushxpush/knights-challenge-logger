using Confluent.Kafka;

namespace knights_challenge_logger.Consumers
{
    internal class KafkaAuthLogConsumer : BackgroundService
    {

        private readonly ILogger<KafkaAuthLogConsumer> _log;
        private readonly IServiceProvider _serviceProvider;
        private readonly string _topic = "auth-logs";

        public KafkaAuthLogConsumer(ILogger<KafkaAuthLogConsumer> log, IServiceProvider serviceProvider)
        {
            _log = log;
            _serviceProvider = serviceProvider;

            System.Diagnostics.Debug.WriteLine("✅ Kafka Consumer Initialized");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var scope = _serviceProvider.CreateScope();
            var consumer = scope.ServiceProvider.GetRequiredService<IConsumer<string, string>>();
            consumer.Subscribe(_topic);

            System.Diagnostics.Debug.WriteLine($"✅ Subscribed to topic: {_topic}");

            await Task.Yield();

            var i = 0;

            while(!stoppingToken.IsCancellationRequested)
            {

                System.Diagnostics.Debug.WriteLine("....");

                try
                {
                    var consumeResult = consumer.Consume(stoppingToken);
                    System.Diagnostics.Debug.WriteLine($"RAW MESSAGE: {consumeResult?.Message?.Value}");

                    if (consumeResult != null && consumeResult.Message != null)
                    {
                        _log.LogInformation($"📩Received: {consumeResult.Message.Key} - {consumeResult.Message.Value}");
                        System.Diagnostics.Debug.WriteLine($"📩Received: {consumeResult.Message.Key} - {consumeResult.Message.Value}");

                        consumer.Commit();
                    }

                    await Task.Delay(100, stoppingToken);

                }
                catch (ConsumeException e)
                {
                    _log.LogError($"❌Kafka error: {e.Error.Reason}");
                    System.Diagnostics.Debug.WriteLine($"❌Kafka error: {e.Error.Reason}");
                }
                finally
                {
                    //consumer.Close();
                    _log.LogInformation("🛑Kafka Consumer Stopped.");
                    System.Diagnostics.Debug.WriteLine("🛑finally: Kafka Consumer Stopped.");
                }
            }

        }

        public override void Dispose()
        {
            _log.LogError("🛑Kafka Consumer Stopped.");
            System.Diagnostics.Debug.WriteLine("🛑Dispose: Kafka Consumer Stopped.");
            base.Dispose();

        }

    }
}
