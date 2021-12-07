using EmployeeASAP.BL.IServices;
using EmployeeASAP.BL.Services;
using EmployeeASAP.Data.DAL.IPersistance;
using EmployeeASAP.Data.DAL.IRepositories;
using EmployeeASAP.Data.DAL.Persistance;
using EmployeeASAP.Data.DAL.Repositories;
using EmployeeASAP.Data.Models;
using EmployeeASAP.Data.Models.Seed;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace EmployeeASAP.API
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
            services.AddCors(options =>
            {
                options.AddPolicy("CORS",
                    corsPolicyBuilder => corsPolicyBuilder.WithOrigins("*")
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

           
            services.AddDbContext<EmployeeASAPContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IDbFactory, DbFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddScoped<IEmployeeServices, EmployeeServices>();
            services.AddScoped<IAddressServices, AddressServices>();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Employee ASAP API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env , EmployeeASAPContext context)
        {
            app.UseCors("CORS");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            SeedData.SeedEmployeeData(context);

            app.UseHttpsRedirection();

            app.UseRouting();


            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee ASAP V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
