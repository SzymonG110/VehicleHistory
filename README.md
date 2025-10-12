# VehicleHistory

VehicleHistory is a modern web application designed to help users easily manage and track their vehicle history. The system enables registering vehicles and storing detailed records of purchases, repairs, fueling, and photos related to each vehicle.

Built using C# and ASP.NET Core with a vertical slice architecture, this project emphasizes modularity, scalability, and maintainability.

## Features

- Register and manage multiple vehicles per user
- Record vehicle purchase dates, repairs, and fueling history
- Secure user authentication and authorization with JWT and refresh tokens
- Clean, feature-based vertical slice code organization for better development experience

## Technologies Used

- C# and ASP.NET Core 9
- Entity Framework Core for data access
- JWT and Refresh Token authentication

## Getting Started

To run the project locally:

1. Clone the repository:
```
git clone https://github.com/SzymonG110/VehicleHistory.git
```
2. Open the solution with Visual Studio or VS Code.
3. Set up the database connection string etc. in `appsettings.json`.
4. Run database migrations with:
```
dotnet ef database update
```
5. Launch the app:
```
dotnet run
```
6. Open your browser at `http://localhost:5092`.

## License

This project is licensed under the Apache License 2.0 — see the [LICENSE](https://github.com/SzymonG110/VehicleHistory/blob/main/LICENSE) file for details.

---

Developed and maintained by Szymon Górnikowski
