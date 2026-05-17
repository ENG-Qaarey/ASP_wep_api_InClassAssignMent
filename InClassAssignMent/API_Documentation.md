# InClassAssignMent API Documentation

This document outlines the available API endpoints for the `InClassAssignMent` Web API, as well as essential database migration commands.

## Essential EF Core Migration Commands

- **Update Database (Apply Migrations):** `dotnet ef database update`
- **Create New Migration:** `dotnet ef migrations add <MigrationName>`
- **Remove Last Migration:** `dotnet ef migrations remove`

---

## API Endpoints

### 1. Customers API (`/api/Customers`)

#### `GET /api/Customers`
- **Description:** Retrieves a list of all customers, including their owned vehicles.
- **Response:** `200 OK` (JSON array of `Customar` objects)

#### `GET /api/Customers/{id}`
- **Description:** Retrieves a specific customer by their ID.
- **Parameters:** `id` (integer) - The customer's ID.
- **Response:** `200 OK` (JSON object) or `404 Not Found`

#### `POST /api/Customers`
- **Description:** Creates a new customer.
- **Request Body:** JSON object containing `Name`, `Email`, and `Phone`.
- **Response:** `201 Created`

---

### 2. Vehicles API (`/api/Vehicles`)

#### `GET /api/Vehicles`
- **Description:** Retrieves a list of all vehicles, including the customer they belong to and their associated service types.
- **Response:** `200 OK` (JSON array of `Vehicles` objects)

#### `GET /api/Vehicles/{id}`
- **Description:** Retrieves a specific vehicle by its ID.
- **Parameters:** `id` (integer) - The vehicle's ID.
- **Response:** `200 OK` (JSON object) or `404 Not Found`

#### `POST /api/Vehicles`
- **Description:** Creates a new vehicle and associates it with a customer.
- **Request Body:** JSON object containing `Make`, `Model`, `Year`, and `CustomarId`.
- **Response:** `201 Created`

---

### 3. Service Types API (`/api/ServiceTypes`)

#### `GET /api/ServiceTypes`
- **Description:** Retrieves a list of all available service types (e.g., Oil Change, Tire Rotation).
- **Response:** `200 OK` (JSON array of `ServiceType` objects)

#### `GET /api/ServiceTypes/{id}`
- **Description:** Retrieves a specific service type by its ID.
- **Parameters:** `id` (integer) - The service type's ID.
- **Response:** `200 OK` (JSON object) or `404 Not Found`

#### `POST /api/ServiceTypes`
- **Description:** Creates a new service type.
- **Request Body:** JSON object containing `Name`, `Description`, and `Cost`.
- **Response:** `201 Created`

---

### 4. Vehicle Service Types API (`/api/VehicleServiceTypes`)

#### `GET /api/VehicleServiceTypes`
- **Description:** Retrieves a list of all service records (which vehicle got which service).
- **Response:** `200 OK` (JSON array of `VehicleServiceType` objects, including `Vehicle` and `ServiceType` details)

#### `POST /api/VehicleServiceTypes`
- **Description:** Creates a new service record connecting a vehicle and a service type.
- **Request Body:** JSON object containing `VehicleId`, `ServiceTypeId`, and `ServiceDate`.
- **Response:** `200 OK`
