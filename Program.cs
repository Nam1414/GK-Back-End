using Microsoft.EntityFrameworkCore;
using StudentClassApi.Data;


var builder = WebApplication.CreateBuilder(args);


// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Use In-Memory DB for quick demo (no external DB setup needed)
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("DemoDb"));


var app = builder.Build();


// Enable Swagger UI (shows Models schemas and allows testing POST/GET)
app.UseSwagger();
app.UseSwaggerUI();


app.MapControllers();
app.Run();