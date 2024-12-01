using App.API.Middleware;

namespace App.API.Extensions
{
    public static class MiddlewareExtensions
    {
        public static void ConfigureMiddleware(this WebApplication app)
        {
            app.UseMiddleware<ExceptionMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
             app.UseAuthentication();

            //app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
        }
    }
}
