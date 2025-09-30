# Nuget packages
## Swagger
Swashbuckle.AspNetCore

## Serilog
Serilog.AspNetCore
Serilog.Expressions: for putting the configurations in the appsettings file
Serilog.Sinks.Seq

## Entity Framework
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Microsoft.EntityFrameworkCore.Design

### Scafolding the database
PM> Scaffold-DbContext '{Connection string}' Microsoft.EntityFrameworkCore.SqlServer -ContextDir Data -OutputDir Data
