namespace Desafio_A__Educacao.Extensions
{
    public static class CorsExtensions
    {
        public static void ApplyCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowOnlySomeOrigins",
                configurePolicy: policy =>
                        {
                            policy.WithOrigins("https://localhost:3000", "http://localhost:3000")
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                        });
            });
        }
    }
}
