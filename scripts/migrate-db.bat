@echo off
echo Running database migrations...

docker compose exec web dotnet ef database update

echo.
echo Migrations completed!
