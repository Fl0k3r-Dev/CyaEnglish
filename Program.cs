using CyaEnglish.Data;
using CyaEnglish.Repositorios;
using CyaEnglish.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.Extensions.Configuration;

namespace CyaEnglish
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
            builder.Services.AddSwaggerGen();

            builder.Services.AddEntityFrameworkMySql()
                .AddDbContextPool<CyaEnglishDbContext>
                (options =>
                    {
                        var connetionString = builder.Configuration.GetConnectionString("DataBase");
                        options.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString));
                    });

            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

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
        }
    }
}