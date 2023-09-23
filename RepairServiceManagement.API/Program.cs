using Microsoft.EntityFrameworkCore;
using RepairServiceManagement.API.Configurations;
using RepairServiceManagement.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add Services to DbContext
var connectionString = builder.Configuration.GetConnectionString("RepairServiceDbConnectionString");
builder.Services.AddDbContext<RepairServiceDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

// Add services to the container.
builder.Services.AddControllers();

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add automapper
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
