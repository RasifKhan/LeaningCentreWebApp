
using BusinessLogic.Mapper;
using BusinessLogic.Repository;
using BusinessLogic.Repository.IRepository;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace LearningCentreApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Database configuration
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("MyDbConnection")));

            // Repository registration
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

            // AutoMapper configuration
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            // CORS configuration
            builder.Services.AddCors(options => {
                options.AddPolicy("default", policy => {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("default");
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
