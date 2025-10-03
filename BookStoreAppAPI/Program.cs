using AutoMapper;
using BookStoreAppAPI.Configuration;
using BookStoreAppAPI.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connString = builder.Configuration.GetConnectionString("BookStoreConnection");
builder.Services.AddDbContext<BookStoreDBContext>(options => options.UseSqlServer(connString));

//builder.Services.AddAutoMapper(typeof(MapperConfig));
// Build a temporary ServiceProvider, hogy megkapjuk a loggerFactory-t
ILoggerFactory loggerFactory = builder.Services.BuildServiceProvider().GetRequiredService<ILoggerFactory>();

var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<MapperConfig>();
}, loggerFactory);

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer(); // Need for Swagger
// Swashbuckle Swagger documentation generator
builder.Services.AddSwaggerGen();            // Swashbuckle

builder.Host.UseSerilog(
    (ctx, lc) => lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration)
    );

builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll",
        b => b.AllowAnyMethod()
        .AllowAnyHeader()
        .AllowAnyOrigin());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Swashbuckle JSON endpoint
    app.UseSwagger();

    // Swagger UI endpoint
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Our API V1");
        c.RoutePrefix = ""; // root alatt jelenik meg
    });

    // .NET 9 OpenAPI JSON (optional, if other tool needs)
    //app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
