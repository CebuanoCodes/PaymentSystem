# PaymentSystem

1. PaymentSystem is a .net core web api that uses entity framework core that returns a specific user and list of payments . 
   User has an account balance and Payment list has Id, Amount, Status,Date and userId.

2. The application does only getting of Users by their Ids.

3. I used Entity Framework (EF) Core because it is a lightweight, extensible, open source version of EF. 
   It also makes the work of dealing with the database easier, since developers can interact with it using .NET objects (models).

**To Use the Application**

1. Download the zip file and Extract in a local folder.

2. First is to create tables and insert values in your local database using the database.txt file,

3. Clean and build and run the application.

4. Using postman, Run https://localhost:5001/api/login using Post 
   with a Body :
   {"Username": "john_admin", "Password":"MyPass_w0rd"}

5. Copy the response (token)

6. Paste the token in the Authorization (using bearer token)

7. Run https://localhost:5001/api/users/2 using Get
