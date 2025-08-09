using Microsoft.EntityFrameworkCore;
using RepositoryPattern.ApplicationLayer.Interfaces;
using RepositoryPattern.ApplicationLayer.Mapping;
using RepositoryPattern.ApplicationLayer.Services;
using RepositoryPattern.DomainLayer.Interfaces;
using RepositoryPattern.InfrastructureLayer;
using RepositoryPattern.InfrastructureLayer.Repositories;
using RepositoryPattern.WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName))
);

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// Register UnitOfWork and repositories (Infrastructure)
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IDepartmentRespository, DepartmentRespository>();
builder.Services.AddScoped<ILogHistoryRepository, LogHistoryRepository>();

// Register Application layer services
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<ILogHistoryService, LogHistoryService>();

// Swagger/OpenAPI support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<EmployeeActionLoggingMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
