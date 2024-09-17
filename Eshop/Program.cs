using Microsoft.EntityFrameworkCore;
using Eshop.DataBase;
using Eshop.Services;
using Eshop.Data;

namespace Eshop
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<IPaymentQueue>(new PaymentQueue());


            builder.Services.AddDbContext<EshopContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("EshopContext") ?? throw new InvalidOperationException("Connection string 'EshopContext' not found.")));
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddHostedService<PaymentService>();

            var app = builder.Build();
            var ctx = builder.Services.First(sd => sd.ServiceType == typeof(EshopContext));

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
        }
    }
}
