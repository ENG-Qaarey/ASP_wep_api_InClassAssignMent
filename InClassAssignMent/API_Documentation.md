# InClassAssignMent API Documentation

## Overview
This is a comprehensive ASP.NET Core Web API built with Entity Framework Core and PostgreSQL. The application manages Customers, Vehicles, and Services.

---

## 🚀 Swagger UI & Postman
- **Swagger UI URL:** `https://localhost:7051/swagger` (View and test your API in the browser)
- **Postman Import URL:** `https://localhost:7051/swagger/v1/swagger.json` (Import into Postman to instantly generate all requests)

---

## 🗄️ Database Commands
The project is configured to use **PostgreSQL**.
Migrations will automatically apply when the application starts up!

If you ever need to manually create new migrations, open your Package Manager Console and run:
```powershell
Add-Migration YourMigrationName
Update-Database
```

---

## 📡 API Endpoints (CRUD)

All controllers fully support **Create (POST)**, **Read (GET)**, **Update (PUT)**, and **Delete (DELETE)** operations.

### 1. Customers
- `GET https://localhost:7051/api/CustomersController` - Get all customers
- `GET https://localhost:7051/api/CustomersController/{id}` - Get a specific customer
- `POST https://localhost:7051/api/CustomersController` - Create a new customer
- `PUT https://localhost:7051/api/CustomersController/{id}` - Update a customer
- `DELETE https://localhost:7051/api/CustomersController/{id}` - Delete a customer

**POST/PUT Body (JSON):**
```json
{
  "name": "string",
  "email": "string",
  "phone": "string"
}
```

### 2. Vehicles
- `GET https://localhost:7051/api/VehiclesController` - Get all vehicles
- `GET https://localhost:7051/api/VehiclesController/{id}` - Get a specific vehicle
- `POST https://localhost:7051/api/VehiclesController` - Create a new vehicle
- `PUT https://localhost:7051/api/VehiclesController/{id}` - Update a vehicle
- `DELETE https://localhost:7051/api/VehiclesController/{id}` - Delete a vehicle

**POST/PUT Body (JSON):**
```json
{
  "make": "string",
  "model": "string",
  "year": 0,
  "customarId": 0
}
```

### 3. Service Types
- `GET https://localhost:7051/api/ServiceTypesController` - Get all service types
- `GET https://localhost:7051/api/ServiceTypesController/{id}` - Get a specific service type
- `POST https://localhost:7051/api/ServiceTypesController` - Create a new service type
- `PUT https://localhost:7051/api/ServiceTypesController/{id}` - Update a service type
- `DELETE https://localhost:7051/api/ServiceTypesController/{id}` - Delete a service type

**POST/PUT Body (JSON):**
```json
{
  "name": "string",
  "description": "string",
  "cost": 0
}
```

### 4. Vehicle Service Types
- `GET https://localhost:7051/api/VehicleServiceTypesController` - Get all service records
- `GET https://localhost:7051/api/VehicleServiceTypesController/{id}` - Get a specific service record
- `POST https://localhost:7051/api/VehicleServiceTypesController` - Create a new service record
- `PUT https://localhost:7051/api/VehicleServiceTypesController/{id}` - Update a service record
- `DELETE https://localhost:7051/api/VehicleServiceTypesController/{id}` - Delete a service record

**POST/PUT Body (JSON):**
```json
{
  "vehicleId": 0,
  "serviceTypeId": 0,
  "serviceDate": "2023-10-01T00:00:00Z"
}
```
*(Note: Ensure your ServiceDate ends with `Z` to denote a UTC timestamp for PostgreSQL)*
