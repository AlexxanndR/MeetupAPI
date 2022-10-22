# MeetupAPI

##  Instruction

1. .NET 6.0 is required to run the project.<br>
2. For ease of checking CRUD operations, the "Authorize" attribute before the controller should be commented out.<br> 
![WithoutAuth](Images/Instruction/WithoutAuth.png)<br>
3. To check authorization, the "Authorize" attribute before the controller must be uncommented, and then two projects should be launched at once (IdentityServer и MeetupAPI).<br>
4. The access token is obtained using POSTMAN.<br>
![GetToken](Images/Instruction/GetToken.png)<br>
5. With further use of HTTP methods, the received token must be indicated.<br>
![ЕokenUsage](Images/Instruction/TokenUsage.png)<br>
