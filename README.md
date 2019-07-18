# SmartACapi
# Smart AC POC

Device API and Admin Website demo

## Based on Microsoft Azure ASP.Net Core
* ASP.Net Core 2.2
* EntityFramework 
* SQL Server
* Web API and MVC
* SwaggerOpenAPI documentation
* SignalR for Alert notifications


The site is a POC demo and simple coding patterns are used forgoing any clean architecture patterns at this time to help facilitate rapid prototyping.

REST based Open API using JSON payloads
To Do: JWT bear tokens used for Authentication
HTTP Verb : POST
Path /api/Data
Payload JSON
{
  "serialNumber": "string",
  "firmwareVersion": "string"
}

HTTP Verb : POST
Path /api/Data
Payload JSON
{
  "deviceId": "56c60bf0-3535-44f7-aaa0-dbf6455913c5",
  "sensorId": "c6dadd52-35ce-4262-b1a2-4ae68b8d8c05",
  "temperature": 10,
  "humidity": 20,
  "carbonMonoxideLevel": 110,
  "status": "ok"
}
