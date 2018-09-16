using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace SecureApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IdentityController>();
            services.AddMvcCore()
                .AddAuthorization()
                .AddJsonFormatters();

            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "http://localhost:5000";
                    options.RequireHttpsMetadata = false;

                    options.ApiName = "api1";
                });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
