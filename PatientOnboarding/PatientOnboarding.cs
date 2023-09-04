using System;
using System.Configuration;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Amqp.Framing;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using PatientServices.Services;

namespace PatientOnboarding
{
    public class PatientOnboarding
    {
        [FunctionName("PatientOnboarding")]
        // every 10 seconds for demo
        public async Task Run([TimerTrigger("*/5 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            try
            {
                log.LogInformation($"This is PatientOnboarding AZ function");

                string connectionString = Environment.GetEnvironmentVariable("PatientOnboardingConnString"); 
                var client = new ServiceBusClient(connectionString);
                var sender = client.CreateSender("patientonboarding");

                var patientService = new PatientService();
                for (int i = 0; i < 3; i++)
                {
                    var patient = patientService.CreatePatient();
                    var body = JsonSerializer.Serialize(patient);
                    var sbMessage = new ServiceBusMessage(body);
                    sbMessage.ApplicationProperties.Add("DateTime", DateTime.UtcNow);
                    await sender.SendMessageAsync(sbMessage);

                }


                Console.WriteLine(DateTime.UtcNow);
                log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            }
            catch (Exception ex)
            {
                log.LogError($"Exception {ex}", ex.Message);

            }
            
        }
    }
}
