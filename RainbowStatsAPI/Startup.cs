using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RainbowStatsAPI.Seeders;

namespace RainbowStatsAPI
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
            services.AddControllers();
            services.AddCors(options => options.AddPolicy("development", configurePolicy => configurePolicy.AllowAnyOrigin()));
            services.AddDbContext<RainbowStatsContext>(options => options.UseSqlite("Data Source=rainbowstats.db"));
            services.AddScoped<IRainbowStatsContext>(provider => provider.GetService<RainbowStatsContext>());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "RainbowStatsAPI", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, RainbowStatsContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("development");
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RainbowStatsAPI v1"));
                
                SeedDatabase(context);
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            
        }
        
        public void SeedDatabase(RainbowStatsContext context)
        {
            OperatorsSeeder.Seed(context);
            WeaponsSeeder.Seed(context);
            OperatorsWeaponsSeeder.Seed(context);
        }
    }
}