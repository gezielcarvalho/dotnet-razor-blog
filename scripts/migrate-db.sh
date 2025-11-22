#!/bin/bash

# Run database migrations inside the container
echo "Running database migrations..."

docker compose exec web dotnet ef database update

echo ""
echo "Migrations completed!"
