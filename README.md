# ASP.NET Web API Project

## Overview

This is an ASP.NET Web API project designed to provide a robust API for managing products. It includes CRUD operations and uses best practices for error handling, logging, and mapping.

## Table of Contents

- [Features](#features)
- [Prerequisites](#prerequisites)
- [Setup and Installation](#setup-and-installation)
- [API Endpoints](#api-endpoints)
- [DTOs](#dtos)
- [Mapping Profiles](#mapping-profiles)
- [Entities](#entities)
- [Services](#services)
- [Repositories](#repositories)
- [Logging and Error Handling](#logging-and-error-handling)
- [Contributing](#contributing)
- [License](#license)

## Features

- **CRUD Operations**: Create, Read, Update, and Delete products.
- **Error Handling**: Consistent error handling with logging.
- **DTO Mapping**: Uses AutoMapper to map between DTOs and entities.

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) 7.0 or later
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or any other database provider configured

## Setup and Installation

1. **Clone the repository:**
   ```bash
   git clone https://github.com/yourusername/yourrepository.git
   cd yourrepository
   ```

2. Restore the NuGet packages:

```bash
dotnet restore
```
3. Update the database connection string in appsettings.json if needed.

4. Run the application:

```bash
dotnet run
```
5. Access the API: Open your browser or API client (e.g., SwaggerUI) and navigate to http://localhost:5000/api/products.

### API Endpoints
-**Get All Products**
Endpoint: GET /api/products
Description: Retrieves a list of all products.
Responses:
200 OK: Returns a list of products.
500 Internal Server Error: Logs error if retrieval fails.

-**Get Product By ID**
Endpoint: GET /api/products/{id}
Description: Retrieves a product by its ID.
Parameters:
id (int): The ID of the product.
Responses:
200 OK: Returns the product if found.
404 Not Found: If the product with the given ID does not exist.
500 Internal Server Error: Logs error if retrieval fails.

-**Create Product**
Endpoint: POST /api/products
Description: Creates a new product.
Request Body: ProductDTO object.
Responses:
201 Created: Returns the created product.
500 Internal Server Error: Logs error if creation fails.

-**Update Product**
Endpoint: PUT /api/products/{id}
Description: Updates an existing product.
Parameters:
id (int): The ID of the product to be updated.
Request Body: ProductDTO object with updated values.
Responses:
204 No Content: If the update is successful.
404 Not Found: If the product with the given ID does not exist.
500 Internal Server Error: Logs error if update fails.

--**Delete Product**
Endpoint: DELETE /api/products/{id}
Description: Deletes a product by its ID.
Parameters:
id (int): The ID of the product to be deleted.
Responses:
204 No Content: If the deletion is successful.
404 Not Found: If the product with the given ID does not exist.
500 Internal Server Error: Logs error if deletion fails.

### Contributing
If you'd like to contribute to this project, please fork the repository and submit a pull request. Make sure to follow the coding guidelines and include appropriate tests for your changes.

### License
This project is licensed under the MIT License.
