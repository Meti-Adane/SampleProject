using sitesampleproject.Data;
using sitesampleproject.Services;
// Additional using declarations

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlite<AppDBContext>("Data Source=sitesampleprojectdb.db");
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<SalesService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ReportService>();

builder.Services.AddScoped<AuthService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
