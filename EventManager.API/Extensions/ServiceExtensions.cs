using EventManager.API.Mappings;
using EventManager.API.Validations.Events;
using EventManager.BLL.Mappings;
using EventManager.BLL.Services;
using EventManager.BLL.Services.Interfaces;
using EventManager.DAL.Caching;
using EventManager.DAL.Contexts;
using EventManager.DAL.Entities;
using EventManager.DAL.UnitOfWork;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace EventManager.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(configs =>
            {
                configs.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Event API",
                    Version = "v1",
                    Description = "An API to perform operations with events",
                    Contact = new OpenApiContact
                    {
                        Name = "Bagrat Antonyan",
                        Email = "bag.antonyan@gmail.com",
                        Url = new Uri("https://github.com/bagantonyan")
                    }
                });
            });
        }

        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EventDbContext>(
                options => options.UseSqlite(configuration.GetConnectionString("EventsDb")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<ICacheService<BaseEntity>, CacheService<BaseEntity>>();

            services.AddAutoMapper(config =>
            {
                config.AddProfile<ApiMappingProfile>();
                config.AddProfile<BLLMappingProfile>();
            });
        }

        public static void AddFluentValidation(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(CreateEventRequestModelValidator).Assembly);
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
        }

        public static void AddCorsConfigs(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }
    }
}