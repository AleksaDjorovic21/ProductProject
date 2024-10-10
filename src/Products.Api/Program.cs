using Microsoft.EntityFrameworkCore;
using Products.Core.Interfaces;
using Products.Infrastructure.Persistence;
using Products.Infrastructure.Repositories; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Assuming you have a connection string set in appsettings.json
builder.Services.AddDbContext<ProductsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); 


// Register repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>(); 
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers(); 

app.Run();
