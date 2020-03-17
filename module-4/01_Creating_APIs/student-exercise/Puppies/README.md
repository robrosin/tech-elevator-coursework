Puppies is a web application which allow a user to list puppies available for adoption, add new puppies to the list, and view the detail of a single puppy.

You are asked to create a new public api for the puppies application.  A client program will be able to create, read, update and delete puppies.  Specifically, you are to implement the following actions:

Method | URL | Description | Returns
--- | --- | --- | ---
GET | /api/puppies | List all puppies | JSON collection containing a list of all puppies
GET | /api/puppies/{id} | Get a single puppy by id | JSON object representing puppy with id={id}. 404 if not found.
POST | /api/puppies | Add a new puppy | 201 Created, plus the object created. If error, 400 Bad Request and JSON error object
PUT | /api/puppies/{id} | Update an existing puppy | 200 OK. If error, 400 Bad Request and error object
DELETE | /api/puppies/{id} | Delete an existing puppy | 200 OK.

You can create your api by simply adding a new api controller to the existing project (rather than creating a new project).
* Right-click on the Controllers folder and select *Add -> Controller*...
* In the dialog, select **API Controller - Empty** and click Add.
* Name the controller *PuppiesApiController*.

As you create your api, use PostMan to verify the methods work as you expect.  


*No puppies were harmed in the creation of this exercise.*