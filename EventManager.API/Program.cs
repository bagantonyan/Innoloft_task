using EventManager.API.Extensions;
using EventManager.API.Filters;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace EventManager.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers(options =>
            {
                options.ReturnHttpNotAcceptable = true;
                options.Filters.Add(new ActionFilter());
                options.Filters.Add(new ProducesAttribute("application/json"));
            });

            builder.Services.AddServices(builder.Configuration);
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddFluentValidation();
            builder.Services.AddCorsConfigs();
            builder.Services.AddSwagger();

            var app = builder.Build();

            app.ConfigureExceptionHandler();

            if (app.Environment.IsProduction())
                app.UseHsts();

            if (app.Environment.IsDevelopment())
                app.AddSwagger();

            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");
            app.UseRouting();

            await app.MigrateDatabase();
            await app.AddUsersFromExternalAPI();

            app.MapControllers();

            app.Run();
        }
    }
}