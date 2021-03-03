
using System;
using System.IdentityModel.Tokens.Jwt;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;

using RMotownFestival.Api.Options;
using RMotownFestival.DAL;

namespace RMotownFestival.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.Configure<AppSettingsOptions>(Configuration);

            services.AddCors();
            services.AddControllers();

            services.AddDbContext<MotownDbContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
             sqlServerOptionsAction: sqlOptions =>
             {
                 sqlOptions.EnableRetryOnFailure(
                     maxRetryCount: 10,
                      maxRetryDelay: TimeSpan.FromSeconds(30),
                      errorNumbersToAdd: null
                     );
             }));

            services.AddApplicationInsightsTelemetry(Configuration["APPINSIGHTS_INSTRUMENTATIONKEY"]);

            // Adds Microsoft Identity platform (AAD v2.0) support to protect this Api
            services.AddMicrosoftIdentityWebApiAuthentication(Configuration, "AzureAd");

            services.AddBlobStorageClient(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // THIS IS NOT A SECURE CORS POLICY, DO NOT USE IN PRODUCTION
            app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
