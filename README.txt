# Banking API with JWT Authentication

This is a simple banking API that demonstrates JWT authentication and account management using .NET 9.

## Features

- JWT Authentication
- Account management
- Clean architecture
- Swagger documentation

## Prerequisites

- .NET 9 SDK
- Your favorite IDE (Visual Studio, VS Code, Rider, etc.)

## How to Run

1. Clone the repository
2. Navigate to the project directory
3. Run the application:

```bash
dotnet run --project BankingApi.API

Open Swagger UI in your browser: https://localhost:5001/swagger (or http://localhost:5000/swagger)

Testing the API
First, authenticate using the /api/Auth/login endpoint with:

Username: testuser

Password: password123

Copy the JWT token from the response

Click the "Authorize" button in Swagger UI and paste the token (prefixed with "Bearer ")

Now you can access the /api/Accounts endpoint to get the account list

