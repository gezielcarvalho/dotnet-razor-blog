# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY ["cms-dotnet-razor.csproj", "./"]
RUN dotnet restore "cms-dotnet-razor.csproj"

# Copy everything else and build
COPY . .
RUN dotnet build "cms-dotnet-razor.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "cms-dotnet-razor.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "cms-dotnet-razor.dll"]
