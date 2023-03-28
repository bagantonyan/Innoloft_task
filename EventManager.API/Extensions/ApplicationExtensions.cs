namespace EventManager.API.Extensions
{
    public static class ApplicationExtensions
    {
        public static void AddSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(configs =>
            {
                configs.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API V1");
            });
        }
    }
}