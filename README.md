# CMS .NET Razor

A modern Content Management System (CMS) built with ASP.NET Core 8.0 and Razor Pages. This application provides a complete blogging platform with an admin interface for managing blog posts, with plans to evolve into a full-featured CMS.

## Features

- **Blog Post Management**: Full CRUD operations for blog posts through an admin interface
- **Rich Content**: Support for headings, content, featured images, and short descriptions
- **URL Handling**: Custom URL handles for SEO-friendly URLs
- **Tagging System**: Tag support for categorizing blog posts
- **Visibility Control**: Toggle post visibility (published/draft)
- **Entity Framework Core**: Database management with migrations
- **Repository Pattern**: Clean architecture with repository abstraction
- **ReCAPTCHA Integration**: Security configuration for form submissions

## Technology Stack

- **Framework**: ASP.NET Core 8.0
- **UI**: Razor Pages
- **Database**: SQL Server
- **ORM**: Entity Framework Core 9.0.0
- **Frontend**: Bootstrap, jQuery
- **Pattern**: Repository Pattern with Dependency Injection

## Project Structure

```
cms-dotnet-razor/
├── Data/
│   └── AppDbContext.cs              # Database context
├── Models/
│   ├── Domain/
│   │   ├── BlogPost.cs              # Blog post entity
│   │   └── Tag.cs                   # Tag entity
│   ├── ViewModels/
│   │   └── AddBlogPost.cs           # View model for adding posts
│   ├── RecaptchaSettings.cs         # ReCAPTCHA configuration
│   └── RecaptchaResponse.cs         # ReCAPTCHA response model
├── Repositories/
│   ├── IBlogPostRepository.cs       # Repository interface
│   └── BlogRepository.cs            # Repository implementation
├── Pages/
│   ├── Admin/
│   │   └── BlogPosts/               # Admin CRUD pages
│   │       ├── Add.cshtml
│   │       ├── Edit.cshtml
│   │       ├── Delete.cshtml
│   │       └── List.cshtml
│   ├── Shared/
│   │   └── _Layout.cshtml           # Main layout
│   ├── Index.cshtml                 # Home page
│   └── Privacy.cshtml               # Privacy page
├── Migrations/                      # EF Core migrations
├── wwwroot/                         # Static files (CSS, JS, libraries)
└── Program.cs                       # Application entry point
```

## Data Models

### BlogPost

- **Id**: Unique identifier (Guid)
- **Heading**: Blog post title
- **PageTitle**: SEO page title
- **Content**: Full blog post content
- **ShortDescription**: Summary/excerpt
- **FeaturedImageUrl**: Featured image URL
- **UrlHandle**: SEO-friendly URL slug
- **PublishedDate**: Publication date
- **Author**: Author name
- **Visible**: Visibility flag (published/draft)

### Tag

- **Id**: Unique identifier (Guid)
- **Name**: Tag name
- **BlogPostId**: Foreign key to BlogPost

## Prerequisites

### Running Locally

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Express, Developer, or LocalDB)

### Running with Docker

- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- [Docker Compose](https://docs.docker.com/compose/install/) (included with Docker Desktop)

## Getting Started

### Option 1: Docker (Recommended)

The easiest way to run the application is using Docker Compose, which sets up both the application and SQL Server automatically.

#### Quick Start

**Windows:**

```bash
scripts\start-docker.bat
```

**Linux/Mac:**

```bash
chmod +x scripts/start-docker.sh
./scripts/start-docker.sh
```

#### Manual Docker Commands

```bash
# Start the application and database
docker compose up -d

# View logs
docker compose logs -f

# Stop the application
docker compose down
```

The application will be available at http://localhost:5151

#### Run Database Migrations

After starting the containers, run migrations:

**Windows:**

```bash
scripts\migrate-db.bat
```

**Linux/Mac:**

```bash
chmod +x scripts/migrate-db.sh
./scripts/migrate-db.sh
```

### Option 2: Local Development

#### 1. Clone the Repository

```bash
git clone https://github.com/gezielcarvalho/cms-dotnet-razor.git
cd cms-dotnet-razor
```

#### 2. Configure Database Connection

Update the connection string in `appsettings.json` (create if not exists):

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=BlogDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

#### 3. Apply Database Migrations

```bash
dotnet restore
dotnet ef database update
```

#### 4. Run the Application

```bash
dotnet run
```

The application will be available at:

- HTTPS: https://localhost:7167
- HTTP: http://localhost:5151

## VSCode Debugging

This project includes full VSCode debugging support for both local and Docker environments.

### Debug Configurations Available

1. **.NET Core Launch (web)** - Debug locally without Docker
2. **Docker .NET Launch** - Debug inside a Docker container
3. **.NET Core Attach** - Attach to a running process

### Debugging with Docker

1. Open the project in VSCode
2. Press `F5` or go to Run and Debug
3. Select "Docker .NET Launch"
4. The application will build, start in a container, and attach the debugger

You can set breakpoints in your code, and they will work seamlessly inside the container.

### VSCode Tasks Available

- **build** - Build the project
- **publish** - Publish the project
- **watch** - Run with hot reload
- **docker-build: debug** - Build debug Docker image
- **docker-build: release** - Build production Docker image
- **docker compose-up** - Start with docker compose
- **docker compose-down** - Stop docker compose
- **docker compose-up-debug** - Start debug environment
- **docker compose-down-debug** - Stop debug environment

## Docker Information

### Docker Files

- **Dockerfile** - Production-optimized multi-stage build
- **Dockerfile.debug** - Development image with debugging tools
- **docker-compose.yml** - Production environment setup
- **docker-compose.debug.yml** - Debug environment with volume mounting
- **.dockerignore** - Files excluded from Docker builds

### Docker Images Used

- **App**: `mcr.microsoft.com/dotnet/aspnet:8.0` (runtime)
- **Build**: `mcr.microsoft.com/dotnet/sdk:8.0` (build)
- **Database**: `mcr.microsoft.com/mssql/server:2022-latest`

### Environment Variables

The Docker setup uses these environment variables (configured in docker-compose.yml):

```env
ASPNETCORE_ENVIRONMENT=Development
ASPNETCORE_URLS=http://+:8080
ConnectionStrings__DefaultConnection=Server=sqlserver;Database=BlogDb;User Id=sa;Password=YourStrong@Passw0rd;TrustServerCertificate=True;MultipleActiveResultSets=true
```

**Important:** Change the SA_PASSWORD in production!

### Docker Commands

```bash
# Build the production image
docker build -t cms-dotnet-razor .

# Build the debug image
docker build -f Dockerfile.debug -t cms-dotnet-razor:debug .

# Run the production container
docker run -p 5151:8080 cms-dotnet-razor

# View running containers
docker ps

# View logs
docker logs cms-dotnet-razor

# Stop and remove containers
docker compose down -v
```

## Development

### Creating New Migrations

When you modify the database schema, create a new migration:

```bash
dotnet ef migrations add <MigrationName>
```

### Applying Migrations

Apply pending migrations to the database:

```bash
dotnet ef database update
```

### Removing Last Migration

If you need to remove the last migration (before applying it):

```bash
dotnet ef migrations remove
```

### Build the Project

```bash
dotnet build
```

### Run in Development Mode

```bash
dotnet run --environment Development
```

## Admin Features

Access the admin interface at `/Admin/BlogPosts/List` to:

- View all blog posts
- Add new blog posts
- Edit existing posts
- Delete posts

## Configuration

### ReCAPTCHA Settings

Configure ReCAPTCHA in `appsettings.json`:

```json
{
  "Recaptcha": {
    "SiteKey": "your-site-key",
    "SecretKey": "your-secret-key"
  }
}
```

## License

This project is licensed under the terms specified in the LICENSE.txt file.

## Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request
