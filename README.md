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
* JQuery, Bootstrap, and D3 for data graph


The site is a POC demo and simple coding patterns are used forgoing any clean architecture patterns at this time to help facilitate rapid prototyping.

## Admin site
* ToDo: Graph uses mock data, backing data could be loaded via ajax
* ToDo: Admin invite and blocking users

https://smartac20190718103234.azurewebsites.net/

User: admin@smartac.com
Password: Password#01

*Main Pages

https://smartac20190718103234.azurewebsites.net/Devices

https://smartac20190718103234.azurewebsites.net/Admin

*Identity Management -limitation no email service setup for POC

https://smartac20190718103234.azurewebsites.net/Identity/Account/Login
https://smartac20190718103234.azurewebsites.net/Identity/Account/ForgotPassword
https://smartac20190718103234.azurewebsites.net/identity/Account/Manage


## REST based Open API using JSON payloads
* To Do: JWT bear tokens used for Authentication

*Live API end points - recommend using Postman while running admin site to view SignalR Notification in realtime for /api/Data POST action.


https://smartac20190718103234.azurewebsites.net/swagger/index.html

https://smartac20190718103234.azurewebsites.net/api/Data
https://smartac20190718103234.azurewebsites.net/api/Register

```
HTTP Verb : POST
Path /api/Data
Payload JSON
{
  "serialNumber": "string",
  "firmwareVersion": "string"
}
```
deviceId returned from Registration should be used in /api/Data payload
sensorId should test with BA0849DF-6A72-42E9-93B0-7716299726BB
until schema and registration allows for multiple sensors
```
HTTP Verb : POST
Path /api/Data
Payload JSON
{
  "deviceId": "56c60bf0-3535-44f7-aaa0-dbf6455913c5",
  "sensorId": "BA0849DF-6A72-42E9-93B0-7716299726BB",
  "temperature": 10,
  "humidity": 20,
  "carbonMonoxideLevel": 110,
  "status": "ok"
}
```
