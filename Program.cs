using CurrencyConverter.Data;
using CurrencyConverter.Data.Services.Implementations;
using CurrencyConverter.Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace CurrencyConverter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
           

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(setupAction =>
            {
                setupAction.AddSecurityDefinition("MonifyBearerAuth", new OpenApiSecurityScheme() 
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    Description = "Paste JWT here."
                });

                setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "MonifyBearerAuth" } //Tiene que coincidir con el id seteado arriba en la definición
                            }, new List<string>() }
                });
            });

            builder.Services.AddDbContext<CurrencyConverterContext>(dbContextOptions => dbContextOptions.UseSqlite(
            builder.Configuration["ConnectionStrings:CurrencyConverterApiDBConnectionString"]));
            builder.Services.AddAuthentication("Bearer") //"Bearer" es el tipo de autenticación que tenemos que elegir después en PostMan para pasarle el token
            .AddJwtBearer(options => //Acá definimos la configuración de la autenticación. le decimos qué cosas queremos comprobar. La fecha de expiración se valida por defecto.
            {
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Authentication:Issuer"],
                    ValidAudience = builder.Configuration["Authentication:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
                };
            }
            );

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminAccount", policy => policy.RequireClaim("role", "Admin"));
            });

            builder.Services.AddScoped< ICurrencyService, CurrencyService>();
            builder.Services.AddScoped<IUserService, UserService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(
              options => options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()
                  );

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}