
using Microsoft.EntityFrameworkCore;
using store_API.Data;

namespace store_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddCors(o =>
            {
                o.AddPolicy("Frontend", p => p
                    .WithOrigins(
                        "http://localhost:5176",
                        "http://localhost:5175" ,// <-- البورت الجديد
                        "http://localhost:5174", // (اختياري) لو أحيانًا يشتغل عليه
                        "http://localhost:5173"  // (اختياري) احتياطي
                    )
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                );
            });

            


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

         
          

app.UseCors("Frontend");
           


            app.UseAuthorization();



            app.MapControllers();

            app.Run();
        }
    }
}
