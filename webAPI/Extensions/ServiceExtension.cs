namespace webAPI.Extensions
{
    public static class ServiceExtension
    {
        public static void AddAPIVersionExtensions(this IServiceCollection services)
        {

            services.AddApiVersioning(config => 
            {
                config.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
        }
    }
}
