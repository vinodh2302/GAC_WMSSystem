using Microsoft.EntityFrameworkCore;
using WMSSystems.Models;
using WMSSystems.Services;

namespace ERPSystems
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.WebHost.UseUrls("http://0.0.0.0:80");
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                ?? "Server=localhost,1433;Database=WMSSystemsDb;User=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;";

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseSwagger();
            app.UseSwaggerUI();

            

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
