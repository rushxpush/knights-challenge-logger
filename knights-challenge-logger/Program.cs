using Confluent.Kafka;
using knights_challenge_logger.Consumers;

System.Diagnostics.Debug.WriteLine("--------Test----------");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var config = new ConsumerConfig
{
    BootstrapServers = "localhost:9092",
    GroupId = "auth-log-consumer-group",
    AutoOffsetReset = AutoOffsetReset.Earliest,
    EnableAutoCommit = false
};

// Register Kafka consumer in Dependency Injection
builder.Services.AddSingleton<IConsumer<string, string>>(sp =>
{

    var consumer = new ConsumerBuilder<string, string>(config)
        .SetKeyDeserializer(Deserializers.Utf8)
        .SetValueDeserializer(Deserializers.Utf8)
        .Build();
    System.Diagnostics.Debug.WriteLine("consumer: " + consumer);
    return consumer;
});


// Register background worker
builder.Services.AddHostedService<AuthLogConsumer>();



builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
