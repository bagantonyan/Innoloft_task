using EventManager.DAL.Entities;
using EventManager.DAL.UnitOfWork;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using EventManager.DAL.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EventManager.API.Extensions
{
    public static class ApplicationExtensions
    {
        public static void AddSwagger(this WebApplication app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(configs =>
            {
                configs.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API V1");
            });
        }

        public static async Task<WebApplication> MigrateDatabase(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                using (var dbContext = scope.ServiceProvider.GetRequiredService<EventDbContext>())
                {
                    await dbContext.Database.MigrateAsync();
                }
            }

            return app;
        }

        public static async Task<WebApplication> AddUsersFromExternalAPI(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                using (var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>())
                {
                    if (await unitOfWork.UserRepository.IsEmpty())
                    {
                        var users = await GetUsersFromExternalAPI();
                        await unitOfWork.UserRepository.AddRangeAsync(users);
                        await unitOfWork.SaveChangesAsync();
                    }
                }
            }

            return app;
        }

        private static async Task<IEnumerable<User>> GetUsersFromExternalAPI()
        {
            var users = new List<User>();

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://jsonplaceholder.typicode.com/users/");
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                var jsonUsers = JsonConvert.DeserializeObject<IEnumerable<JObject>>(result);

                foreach (var jsonUser in jsonUsers)
                {
                    var country = (JObject)jsonUser["company"];
                    var companyName = (string)country["name"];

                    var user = User.CreateUser(
                        (string)jsonUser["name"],
                        (string)jsonUser["username"],
                        (string)jsonUser["email"],
                        (string)jsonUser["phone"],
                        companyName);

                    users.Add(user);
                }
            }

            return users;
        }
    }
}