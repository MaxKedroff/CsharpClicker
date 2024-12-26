# ASP.NET Clicker Game

**Description**  
This project is a learning application developed as part of the "Development on ASP.NET" course. It is a clicker game that demonstrates key concepts and features of web development using ASP.NET and integrates a relational database for persistent data storage.

---

## Features
- **User Authentication:** Secure login and registration system using ASP.NET Identity.
- **Game Mechanics:** Incremental clicker gameplay with real-time score updates.
- **Database Integration:** Persistent storage for user progress and game data using Entity Framework Core.
- **Basic Design:** Optimized UI for desktop and mobile devices.

---

## Tech Stack
- **Backend:** ASP.NET Core
- **Frontend:** Razor Pages / Blazor (or specify if another framework is used)
- **Database:** SQL Server with Entity Framework Core
- **Authentication:** ASP.NET Identity
- **Hosting:** (Specify if deployed, e.g., Azure, IIS, etc.)

---

## Setup Instructions
1. **Clone the Repository**
   ```bash
   git clone <repository-url>
   cd <repository-folder>

2. **Configure the Database and run**
   ```bash
   dotnet ef database update
   dotnet run
---

## Development Notes  
The project was iteratively enhanced during the course, focusing on
- implementing best practices for ASP.NET development.
- Strengthening knowledge of Entity Framework Core for database interactions.

---

## Future Provements
The following features are planned or could be implemented:
- Deployment to a cloud platform.
- adding multiplayer module with websockets
