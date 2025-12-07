
using Microsoft.EntityFrameworkCore;
using Project1.Data;
using Project1.Mappings;
using Project1.Repository;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Project1
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

            builder.Services.AddDbContext<Project1DbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Project1ConnectionString"))
            );

            // inject the Repository
            builder.Services.AddScoped<IRegionRepo, RegionImpl>();
            builder.Services.AddScoped<IWalkRepo, WalkRepoImpl>();


            // Inject the Automapper 
            builder.Services.AddAutoMapper(typeof(AutoMapperprofiles));


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
