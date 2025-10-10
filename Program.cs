using Database_ClassesApi.Data;
using Microsoft.EntityFrameworkCore;

// Tạo builder để cấu hình ứng dụng với argument truyền vào (args)
var builder = WebApplication.CreateBuilder(args);

// Lấy chuỗi kết nối database từ appsettings.json theo key "DefaultConnection"
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Đăng ký DbContext AppDbContext vào DI container với cấu hình SQL Server và chuỗi kết nối
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Đăng ký service cho controller (API controller)
builder.Services.AddControllers();

// Đăng ký Swagger để tạo tài liệu API tự động và hỗ trợ UI kiểm thử API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Xây dựng ứng dụng từ builder
var app = builder.Build();

// Cấu hình middleware pipeline xử lý HTTP request
if (app.Environment.IsDevelopment())
{
    // Chỉ bật Swagger ở môi trường phát triển để xem và test API
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Chuyển hướng HTTP sang HTTPS tự động
app.UseHttpsRedirection();

// Kích hoạt middleware ủy quyền (authorization)
app.UseAuthorization();

// Đăng ký route cho các API controller xử lý request
app.MapControllers();

// Chạy ứng dụng, bắt đầu lắng nghe incoming HTTP requests
app.Run();


