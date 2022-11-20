using KalorieOnline.Api.Data;
using KalorieOnline.Api.Repositories;
using KalorieOnline.Api.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<CaloriesOnlineDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ShopingOnlineConnection"))
);
builder.Services.AddScoped<IProductRepository, ProductRepository>(); // addScoped po stworzeniu kontrolera
builder.Services.AddScoped<IDayCartRepository, DayCartRepository>();
builder.Services.AddScoped<IUserDataRepository, UserDataRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy => policy.WithOrigins("https://localhost:7270", "https://localhost:7270")
.AllowAnyMethod()
.WithHeaders(HeaderNames.ContentType)

    );

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
