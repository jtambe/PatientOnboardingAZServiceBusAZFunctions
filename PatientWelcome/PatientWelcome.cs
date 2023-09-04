using System;
using System.Text.Json;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using PatientServices.Models;

namespace PatientWelcome
{
    public static class PatientWelcome
    {
        [FunctionName("PatientWelcome")]
        public static void Run([ServiceBusTrigger("patientonboarding", "PatientWelcome", Connection = "PatientOnboardingConnString")]string msg, ILogger _logger)
        {
            
            try
            {
                _logger.LogInformation($"This is PatientWelcome AZ function");
                var patient = JsonSerializer.Deserialize<Patient>(msg);
                _logger.LogInformation($"PatientWelcome AZ function processed patient: {msg}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception {ex}", ex.Message);
            }
        }
    }
}
