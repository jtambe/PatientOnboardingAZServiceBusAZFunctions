
// See https://aka.ms/new-console-template for more information
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;

Console.WriteLine("This is Dead Letter Queue Handler");

// Create a ConfigurationBuilder
var builder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

// Build the configuration
var configuration = builder.Build();

// Retrieve the connection string from the configuration
string connectionString = configuration.GetConnectionString("PatientOnboardingConnString")!;


await using var client = new ServiceBusClient(connectionString);


ServiceBusReceiver dlq = client.CreateReceiver("patientonboarding", "PatientIntake", new ServiceBusReceiverOptions { SubQueue = SubQueue.DeadLetter });

while(true)
{
    var msg = await dlq.ReceiveMessageAsync();
    if(msg is null ) break;
    Console.WriteLine(msg.Body.ToString());
    await dlq.CompleteMessageAsync(msg);
}


Console.ReadKey();

