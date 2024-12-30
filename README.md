# TempusHive

TempusHive is an occasion management API built with ASP.NET Core, following a monolithic modular architecture. It provides a robust, scalable, and maintainable framework for managing occasions, attendees, schedules, and related resources.

## Features

- **Occasion Management**: Create, update, delete, and retrieve occasion details.
- **Attendee Management**: Manage attendee registration, details, and attendance.
- **Schedule Management**: Organize occasion schedules and sessions.
- **Notifications**: Send notifications to attendees.
- **Modular Architecture**: Clear separation of concerns using a modular approach within a monolithic structure.
- **Database Integration**: Supports PostgreSQL for data storage using Entity Framework Core.
- **API Documentation**: Integrated Swagger UI for API exploration and testing.
- **Code Analysis**: Enforced code quality with analyzers and best practices enabled.

---

## Architecture

TempusHive follows a **Monolith Modular Architecture** where the application is divided into distinct modules. Each module encapsulates specific functionality, enabling better maintainability and scalability within the monolithic framework.

### Key Modules:

1. **OccasionModule**: Handles all occasion-related operations.
2. **AttendeeModule**: Manages attendee data and registration workflows.
3. **ScheduleModule**: Organizes occasion schedules and sessions.
4. **NotificationModule**: Handles email and SMS notifications.
5. **CoreModule**: Contains shared services, models, and utilities.

---

## Technologies Used

- **Framework**: ASP.NET Core 8.0
- **Database**: PostgreSQL with Entity Framework Core
- **Language**: C#
- **Architecture**: Monolithic Modular
- **API Documentation**: Swagger / OpenAPI
- **Package Management**: NuGet

---

## Getting Started

### Prerequisites

- .NET 8.0 SDK
- PostgreSQL
- IDE with .NET Core support (e.g., Visual Studio, JetBrains Rider, or Visual Studio Code)

### Installation

1. Clone the repository:

   ```bash
   git clone git@github.com:anjotadena/TempusHive.git
   cd tempushive
   ```

2. Configure the database connection in `appsettings.json`:

   ```json
   {
     "ConnectionStrings": {
       "Database": "Host=localhost;Port=5432;Database=TempusHiveDb;Username=your_username;Password=your_password"
     }
   }
   ```

3. Apply database migrations:

   ```bash
   dotnet ef database update
   ```

4. Run the application:

   ```bash
   dotnet run
   ```

5. Access the API documentation at:

   ```
   http://localhost:5000/swagger
   ```

---

## Usage

### Example Endpoints

#### 1. **Occasions**

- **GET** `/api/occasions`: Retrieve all occasions
- **POST** `/api/occasions`: Create a new event

#### 2. **Attendees**

- **GET** `/api/attendees`: Retrieve all attendees
- **POST** `/api/attendees`: Register a new attendee

#### 3. **Schedules**

- **GET** `/api/schedules`: Retrieve occasion schedules
- **POST** `/api/schedules`: Create a new schedule

---

## Contributing

We welcome contributions! To contribute:

1. Fork the repository.
2. Create a feature branch:
   ```bash
   git checkout -b feature/your-feature-name
   ```
3. Commit your changes:
   ```bash
   git commit -m "Add your feature description"
   ```
4. Push to your branch:
   ```bash
   git push origin feature/your-feature-name
   ```
5. Open a pull request.

---

## License

This project is licensed under the MIT License. See the `LICENSE` file for details.

---

## Contact

For inquiries or support, please contact:

- **Author**: Anjo Tadena
- **Email**: [tadena.anjo@gmail.com](mailto\:tadena.anjo@gmail.com)
- **GitHub**: [Anjo Tadena](https://github.com/anjotadena)

---

### Future Enhancements

- Integration with third-party calendar services.
- Advanced analytics for occasion performance.
- Real-time notifications using SignalR.

---

Thank you for using TempusHive! We hope it simplifies your occasion management processes.
