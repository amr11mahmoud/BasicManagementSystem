using BasicMangementSystem.Web.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace BasicMangementSystem.Web.Startup
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddAuthentication(options =>
            //{ 
            //    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer();

            //services.AddAuthorization();
            services.AddControllers();
            services.AddDbContext<MangementSystemDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("Defualt")));
            services.AddSwaggerGen(C =>
            {
                C.SwaggerDoc(name:"v1", new OpenApiInfo { Title = "Basic Management System API", Version = "v1" });
                C.SwaggerDoc(name:"v2", new OpenApiInfo { Title = "Basic Management System API", Version = "v2" });
            });
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseAuthentication();
            //app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Basic Management System API V1");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "Basic Management System API V2");
            });

            app.MapGet("/", () =>
            {
                return "Hello World!";
            });

        }
    }
}
