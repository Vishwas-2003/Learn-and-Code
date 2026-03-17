# Learn-and-Code

This is a repository for L&C Assignments

## C# Coding Guidelines (Based on Internal Standards)

These guidelines define best practices for writing clean, maintainable, and scalable C# code.
They help ensure consistency, readability, and high-quality development across the team.

---

## 1. Naming Conventions

* Use **PascalCase** for classes, methods, properties, enums, and namespaces. 
* Use **camelCase** for local variables and method parameters. 
* Prefix interfaces with **“I”** (e.g., `IUserService`). 
* Use **meaningful and descriptive names**.
* Avoid abbreviations unless commonly accepted (e.g., Id, Xml). 
* Avoid underscores except for private fields (optional case). 

---

## 2. Code Formatting

* Function length should not exceed **40 lines**. 
* Limit method parameters to **maximum 4 arguments**. 
* Maintain proper **indentation and spacing**.
* Use consistent formatting across the codebase.
* Keep code clean and easy to read.

---

## 3. Class Structure

* Group related methods and properties together. 
* Maintain a consistent order:

  * Fields
  * Constructors
  * Properties
  * Methods
* Use regions only when necessary to separate concerns. 

---

## 4. Dependency Injection

* Prefer **constructor injection** for dependencies. 
* Avoid using `new` keyword directly inside classes. 
* Register dependencies in `ConfigureServices`. 

---

## 5. Error Handling

* Use **structured exception handling (try-catch)**. 
* Return appropriate HTTP status codes.
* Log errors properly for debugging.
* Do not expose sensitive information in error messages.

---

## 6. Data Validation

* Use **data annotations** like `[Required]`, `[StringLength]`. 
* Validate inputs before processing.
* Handle validation errors properly.

---

## 7. Logging and Tracing

* Log important events and errors. 
* Use **structured logging (key-value format)**. 
* Use **correlation IDs** to track requests across systems. 

---

## 8. Security

* Secure APIs using **Authorize attribute**. 
* Always validate data on backend.
* Use HTTPS for communication.
* Prevent vulnerabilities like SQL Injection and XSS. 
* Never hardcode sensitive data (username, password, etc.).
* Encrypt sensitive (PII) data.

---

## 9. API Documentation

* Use **XML comments** for APIs, classes, and methods. 
* Document parameters and return types.
* Use tools like **Swagger** for API documentation. 

---

## 10. Unit Testing

* Write tests for business logic. 
* Cover edge cases and negative scenarios.
* Keep tests independent.
* Follow **AAA pattern (Arrange, Act, Assert)**. 

---

## 11. Pull Request Guidelines

* Keep PRs small and focused.
* Maximum **10 files or 300 lines** per PR. 
* Ensure code is reviewed and tested before merging.

---

## 12. General Best Practices

* Follow **clean code principles**.
* Keep logic simple and avoid over-engineering.
* Write code that is easy to read and maintain.
* Ensure consistency across the codebase.
* Focus on readability over complexity.

---
