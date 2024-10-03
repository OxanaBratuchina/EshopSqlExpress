using Microsoft.EntityFrameworkCore;
using Eshop.Infrastructure;
using Eshop.Services;
using Eshop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Eshop.Data.Interfaces;

namespace Eshop
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<IPaymentQueue>(new PaymentQueue());
            builder.Services.AddScoped<ITokenService, TokenService>();

            builder.Services.AddDbContext<EshopContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("EshopContext") ?? throw new InvalidOperationException("Connection string 'EshopContext' not found."))
            //.UseLoggerFactory(ConsoleLoggerFactory.Create()) // Kiril for writing to Console + see AppSetting.json "Microsoft.EntityFrameworkCore.Database": "Information"
            //.EnableSensitiveDataLogging() // Kiril logging of requests
            );

            builder.Services.AddIdentity<AppUser, IdentityRole>(options=>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 10;
            })
            .AddEntityFrameworkStores<EshopContext>();
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme =
                options.DefaultScheme =
                options.DefaultSignOutScheme =
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = builder.Configuration["JWT:Issuer"],
                        ValidateAudience = true,
                        ValidAudience = builder.Configuration["JWT:Audience"],
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"]))

                    };

                });


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
            });
            //builder.Services.AddSwaggerGen(); // replaces by code from TeddySmith/Authorization

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

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
