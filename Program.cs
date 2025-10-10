using Microsoft.EntityFrameworkCore;
using StudentAPI.Data;
using AutoMapper;
using StudentAPI.AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//  Cấu hình DbContext 
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//  AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

//  Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();  
app.UseAuthorization();

app.MapControllers();

app.Run();
