using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RestCode_WebApplication.Domain.Persistence.Contexts;
using RestCode_WebApplication.Domain.Repositories;
using RestCode_WebApplication.Domain.Services;
using RestCode_WebApplication.Extensions;
using RestCode_WebApplication.Persistence.Repositories;
using RestCode_WebApplication.Services;

namespace RestCode_WebApplication
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
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("restcode-api-in-memory");
                //options.UseMySQL("server=localhost;database=supermarket;user=root;password=password");
                //options.UseMySQL(Configuration.GetConnectionString("MySQLConnection"));
                //options.UseMySQL(Configuration.GetConnectionString("AzureMySQLConnection"));
            });

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddScoped<IConsultantRepository, ConsultantRepository>();
            services.AddScoped<IPublicationRepository, PublicationRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IConsultancyRepository, ConsultancyRepository>();
            services.AddScoped<IAssignmentRepository, AssignmentRepository>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<ISaleDetailRepository, SaleDetailRepository>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IRestaurantService, RestaurantService>();
            services.AddScoped<IConsultantService, ConsultantService>();
            services.AddScoped<IPublicationService, PublicationService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IConsultancyService, ConsultancyService>();
            services.AddScoped<IAssignmentService, AssignmentService>();
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<ISaleService, SaleService>();
            services.AddScoped<ISaleDetailService, SaleDetailService>();

            //services.AddSwaggerGen(c => {
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "RestCode API", Version = "v1" });
            //});

            services.AddAutoMapper(typeof(Startup));

            //services.AddRouting(options => options.LowercaseUrls = true);
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddCustomSwagger();

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

            //CORS Configuration
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            //Authentication Support
            app.UseAuthentication();
            app.UseAuthorization();
            //----
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseCustomeSwagger();
        }
    }
}
