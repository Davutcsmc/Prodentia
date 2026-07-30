# Docker Setup Guide

## Overview
This Docker setup runs SQL Server 2022 locally for development purposes using Docker Compose.

---

## Prerequisites

- **Docker Desktop** installed and running
  - Download: https://www.docker.com/products/docker-desktop
  - Verify: `docker --version`

- **.env file** configured (copy from `.env.example`)

---

## Quick Start

### 1. Create `.env` file
Copy-Item .env.example .env
Edit .env and set your password


### 2. Start SQL Server
docker-compose up -d


### 3. Verify it's running
docker-compose ps docker-compose logs sqlserver


### 4. Run migrations 
1. From solution root (prodentia/)
dotnet ef database update --project Infrastructure/Prodentia.Persistance

2. OR from Package Manager Console in Visual Studio
Update-Database -Project Prodentia.Persistance


---

## Connection String

Use this in your `appsettings.Development.json`:
"ConnectionStrings": { "DefaultConnection": "Server=localhost,1433;Database=Prodentia;User Id=sa;Password=<YOUR_PASSWORD_FROM_.env>;Encrypt=false;TrustServerCertificate=true;" }

Replace `<YOUR_PASSWORD_FROM_.env>` with your actual password.

---

## Useful Commands

### Start Services
docker-compose up -d

### Stop Services
docker-compose down

### View Logs
docker-compose logs -f sqlserver

### Stop & Remove All Data (clean slate)
docker-compose down -v

### Connect to SQL Server from CLI
docker exec -it prodentia-sqlserver /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "YourPassword"

### View Running Containers
docker ps


---

## Troubleshooting

### Port 1433 Already in Use
Find what's using port 1433
netstat -ano | findstr :1433
Kill the process
taskkill /PID <PID> /F
OR change port in docker-compose.yml - change "1433:1433" to "1434:1433"


### SQL Server Won't Start
Check logs
docker-compose logs sqlserver
Restart
docker-compose restart sqlserver
Or full restart
docker-compose down -v docker-compose up -d


### Connection Timeout
- Ensure SQL Server is fully started (check healthcheck)
- Verify password is correct in `.env`
- Check firewall isn't blocking port 1433

---

## Environment Files

- **`.env.example`** - Template (commit to repo)
- **`.env`** - Actual secrets (gitignored - never commit)

Always copy `.env.example` to `.env` and fill in actual values.

---

## Development Workflow

1. Start Docker: `docker-compose up -d`
2. Start your API in Visual Studio
3. EF Core migrations run automatically (if configured)
4. API connects to SQL Server in Docker
5. Stop Docker when done: `docker-compose down`

---

## Production Considerations

- Use `docker-compose.prod.yml` for production secrets management
- Never hardcode passwords
- Use Azure SQL Database or managed services in production
- Don't mount volumes in production (use managed backups)

---

## References

- [SQL Server Docker Docs](https://hub.docker.com/_/microsoft-mssql-server)
- [Docker Compose Documentation](https://docs.docker.com/compose/)
- [EF Core Migrations](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/)