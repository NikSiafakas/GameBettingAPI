using GameBettingAPI.GameData;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GameBettingAPI
{
    public class Startup
    {
        private IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                    .AddNewtonsoftJson(opts => { opts.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter()); });      // enable enum-string conversion
            services.AddSwaggerGen();
            services.AddSwaggerGenNewtonsoftSupport();                                                                                                  // enable enum-string conversion

            services.AddDbContext<MySqlDatabaseContext>(opt => opt.UseSqlServer(_configuration.GetConnectionString("GameBetSqlDbConnectionString")));
            services.AddScoped<IMatchData, SqlMatchData>();
            services.AddScoped<IMatchOddsData, SqlMatchOddsData>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger();
            // specify the Swagger JSON endpoint
            app.UseSwaggerUI(a => a.SwaggerEndpoint("/swagger/v1/swagger.json", "GameBettingAPI"));

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
