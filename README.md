# ContactManagerApi
Web Api for contact management
Created Web Api for managing contact information.

Project Architecture Description:
The Solution has the following projects:
1. ContactManagerApi (Web Project)
2. BusinessEntities (Class Library)
3. BusinessServices  (Class Library)
4. DataAccess (Class Library)
5. ApiTest (Test Project)

ContactManagerApi is the WebApi project and has the API controllers.
ContactManagerApi references BusinessServices for executing the business logic.
The reference to BusinessServices has been passed using Dependency Injection.
DataAccess library handles the database operations.
ApiTest is a project to test the BusinessServices.



---------------------------------------------------------------------------------------------------
Steps to run the application:
1. Create a database on SQL Server or use an existing database.
2. Run the script in the scripts folder. This will create database table required for data storage.
3. Search and find the database connectionString "EvolentTestEntities".
4. Point this connectionString to the database created in step-2.
5. Run the application using Visual Studio 2013 or higher. Or the API can be hosted in IIS.
6. The API can be tested using Postman or some other API testing tool.
7. The API has following methods.
	URL: /api/addcontact
	Description: Adds a contact to the database.
	HTTP verb: POST
	Parameters: Request Body
	{
		"id": 0,
		"firstName": "TestFirstName",
		"lastName": "TestLastName",
		"email": "test@gmail.com",
		"phoneNumber": "9900887744",
		"status": true
	}
	--------------------------------------------
	
	URL: /api/contactlist
	Description: Gets the list of active contacts
	HTTP verb: GET
	Parameters: None
	
	--------------------------------------------
	URL: /api/editcontact
	Description: Updates the contact for the matching Id.
	HTTP verb: POST
	Parameters: Request Body
	{
		"id": 2,
		"firstName": "TestFirstName",
		"lastName": "TestLastName",
		"email": "test@gmail.com",
		"phoneNumber": "9900887744",
		"status": true
	}
	--------------------------------------------
	URL: /api/deletecontact/{id}
	Description: Changes the status to Inactive by changing the status flag to "false".
	HTTP verb: POST
	Parameters: FromUri {id}
	E.g. /api/deletecontact/2
	--------------------------------------------



