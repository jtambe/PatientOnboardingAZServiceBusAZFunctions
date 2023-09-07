# PatientOnboarding project uses AZ functions and AZ Service Bus with single Topic that has multiple subscriptions



This Code shows a basic demo of AZ functions and AZ Service Bus

. Timer based AZ function named PatientOnboarding generates patient messages to onboard <br/>
. ServiceBusTrigger AZ function named PatientWelcome is supposedly created for sending Welcome email <br/>
. ServiceBusTrigger AZ function named PatientIntake is supposedly created for Adding Patient Data in system <br/>
. Patient Services is a class library project that is generating mock data for patients using C# Bogus library <br/>


`patientonboarding` is a single topic that acts as Publisher in the system <br/>
`patientonboarding` topic has 2 subscribers in this setup viz `PatientIntake` and `PatientWelcome` <br/>

`DeadLetterQueueHandler` handles Dead Letter Queue messages and marks them as completed<br/>


