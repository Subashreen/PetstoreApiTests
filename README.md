# 🐾 Petstore API Test Suite (C# + RestSharp + NUnit)

This project is a clean, professional-grade test suite for the [Swagger Petstore API](https://petstore.swagger.io/)

-  C# (.NET 9)
-  RestSharp (API client)
-  NUnit (test framework)

It demonstrates how to perform **Add → Read → Delete** operations on the `/pet` endpoint with retry logic and null safety — ideal for showcasing API automation skills in interviews or portfolios.

---
##  Features

- **POST /pet**: Adds a new pet with a unique ID
- **GET /pet/{id}**: Retrieves the pet by ID (with retry logic)
- **DELETE /pet/{id}**: (Optional) Deletes the pet
- **Null-safe** and warning-free
- **Console output** shows the added pet ID for manual verification

---
##  How to Run

1. Clone this repo or copy the code into a new project:

   ```bash
   dotnet new classlib -n PetstoreApiTests
   cd PetstoreApiTests


2. Add dependencies:

dotnet add package RestSharp
dotnet add package NUnit
dotnet add package NUnit3TestAdapter
dotnet add package Microsoft.NET.Test.Sdk
dotnet add package

3. Replace PetTests with the test file in this repo.
4. Run the test:
dotnet test
Verifying the Pet in Swagger UI
After running the test, copy the printed pet ID from the console:
 ~~~~~~~~~~~ Pet added with ID: 1698851234567
Then:
1. 	Go to https://petstore.swagger.io
2. 	Use  GET/pet/{petId} and paste the ID
3. 	You should see the pet details if it was persisted
 ~~~~~~~~~~~ Project Structure
PetstoreApiTests/
├── PetstoreApiTests.csproj
└── PetTests.cs
📌 Notes
- The Petstore API is a public demo — persistence is not guaranteed
- Retry logic is included to handle flakiness
- Delete section is optional and can be re-enabled
🙌 Author
Subashree Natarajan
UI Automation & API Testing Enthusiast

