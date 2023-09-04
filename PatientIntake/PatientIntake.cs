using System;
using System.Text.Json;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using PatientServices.Models;

namespace PatientIntake
{
    public static class PatientIntake
    {
        //private readonly ILogger<PatientIntake> _logger;

        //public PatientIntake(ILogger<PatientIntake> log)
        //{
        //    _logger = log;
        //}

        [FunctionName("PatientIntake")]
        public  static void Run([ServiceBusTrigger("patientonboarding", "PatientIntake", Connection = "PatientOnboardingConnString")]string msg, ILogger _logger)
        {
            try
            {
                _logger.LogInformation($"This is PatientIntake AZ function");
                var patient = JsonSerializer.Deserialize<Patient>(msg);
                _logger.LogInformation($"PatientIntake AZ function processed patient: {msg}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception {ex}", ex.Message);
            }
            
        }
    }
}
