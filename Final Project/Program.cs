using Final_Project.Data;
using Final_Project.Models;
using System.Reflection.Emit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();
app.Run();

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Product>().HasData(
        new Product { ProductId = 1, Name = "T-Shirt", Price = 19.99M },
        new Product { ProductId = 2, Name = "Jeans", Price = 49.99M }
    );

    modelBuilder.Entity<Customer>().HasData(
        new Customer { CustomerId = 1, Name = "John Doe", Email = "john.doe@example.com" },
        new Customer { CustomerId = 2, Name = "Jane Smith", Email = "jane.smith@example.com" }
    );

    modelBuilder.Entity<Order>().HasData(
        new Order { OrderId = 1, OrderDate = DateTime.UtcNow, CustomerId = 1 },
        new Order { OrderId = 2, OrderDate = DateTime.UtcNow, CustomerId = 2 }
    );
}
