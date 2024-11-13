# dotnet-razor-blog

This is a simple blog application built with ASP.NET Core 3.1 and Razor Pages. It uses a SQLServer database to store blog posts and comments.

## Getting Started

To get started, you'll need to have the .NET Core 3.1 SDK installed. You can download it [here](https://dotnet.microsoft.com/download/dotnet-core/3.1).

You'll also need to have SQLServer installed. You can download it [here](https://www.microsoft.com/en-us/sql-server/sql-server-downloads).

Once you have the .NET Core SDK and SQLServer installed, you can clone this repository and run the following commands:

```bash
dotnet restore
dotnet ef database update
dotnet run
```

## Development

### Migrations

If you make changes to the database schema, you'll need to create a new migration. You can do this by running the following command:

```bash
dotnet ef migrations add <migration-name>
```

