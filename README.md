
# .NET 8 Web Application

This is a .NET 8 web application that allows employers to create a program and an application form for candidates. The application form consists of various types of questions, such as Paragraph, Yes/No, Dropdown, Multiple Choice, Date, and Number. The application uses RESTful APIs to implement CRUD (Create, Read, Update, Delete) operations for managing the questions and receiving candidate submissions. The data is stored in Azure Cosmos DB, a NoSQL database.

## Technologies used
- ASP.NET Core
- Azure Cosmos DB

## Versions
- .NET : 8

## Usage
- Clone the repository.
- Set up Azure Cosmos DB Emulator for local testing.
- Run the application and test the CRUD APIs using Swagger (or tools like Postman).
- Refer to the API documentation for endpoint details.

## Object Reference
- Employee →  This likely represents an employer who creates programs and manages application forms. The `/api/employee` endpoints handle CRUD operations for employees.
- Questions → This represents a question within an application form. The `/api/questions` endpoints handle CRUD operations for questions.
- Answer →  This represents a candidate's answer to a specific question within a submitted application using `/api/answer` API. 

## API Reference

| Endpoint | HTTP Method     | Result                |
| :-------- | :------- | :------------------------- |
| `/api/employee` | `POST` | Add an Employee |
| `/api/employee/:id` | `GET` | Get an Employee |
| `/api/employee/:id` | `DELETE` | Delete an Employee |
| `/api/employee/:id` | `PUT` | Update an Employee |
| `/api/questions` | `POST` | Add a Question |
| `/api/questions/:id` | `GET` | Get a Question |
| `/api/questions/employee/:id` | `DELETE` | Get a Question from Employee |
| `/api/questions/:id` | `PUT` | Update a Question |
| `/api/answer` | `POST` | Add a UserAnswer |
| `/api/answer/:id` | `GET` | Get a UserAnswer |
| `/api/answer/:id` | `DELETE` | Delete a UserAnswer |
| `/api/answer/:id` | `PUT` | Update a UserAnswer |
