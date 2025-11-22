@echo off
echo Starting dotnet-razor-blog with Docker Compose...
docker-compose up -d

echo.
echo Waiting for SQL Server to be ready...
timeout /t 10 /nobreak > nul

echo.
echo Application started successfully!
echo Web app: http://localhost:5151
echo SQL Server: localhost:1433
echo.
echo To view logs: docker-compose logs -f
echo To stop: docker-compose down
