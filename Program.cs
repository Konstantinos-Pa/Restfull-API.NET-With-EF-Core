
using Assignment.Service;
using Microsoft.EntityFrameworkCore;
using Assignment.Repository;

namespace Assignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<PostgresDbContext>(option =>
            {
                option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            }); 
            builder.Services.AddSwaggerGen(options =>
            {
                options.CustomSchemaIds(type => type.FullName);
            });

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins("http://localhost:5173") // Frontend URL
                          .AllowAnyMethod()  // GET, POST, etc.
                          .AllowAnyHeader(); // Custom headers
                });
            });



            builder.Services.AddScoped<ICandidatesRepository, CandidatesRepository>();
            builder.Services.AddScoped<IAddressRepository, AddressRepository>();
            builder.Services.AddScoped<ICertificateRepository, CertificatesRepository>();
            builder.Services.AddScoped<IMobileRepository, MobileRepository>();
            builder.Services.AddScoped<IPhotoIdRepository, PhotoIdRepository>();
            builder.Services.AddScoped<ICandidatesAnalyticsRepository, CandidatesAnalyticsRepository>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
