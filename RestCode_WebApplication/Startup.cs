using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RestCode_WebApplication.Domain.Persistence.Contexts;
using RestCode_WebApplication.Domain.Repositories;
using RestCode_WebApplication.Domain.Services;
using RestCode_WebApplication.Extensions;
using RestCode_WebApplication.Persistence.Repositories;
using RestCode_WebApplication.Services;
using RestCode_WebApplication.Settings;

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
            services.ActiveCors();
            services.AddCustomSwagger();
            services.AddControllers();

            services.AddDbContext<AppDbContext>(options =>
            {
                //options.UseInMemoryDatabase("supermarket-api-in-memory");
                //options.UseMySQL("server=localhost;database=supermarket;user=root;password=password");
                options.UseMySQL(Configuration.GetConnectionString("MySQLConnection"));
                //options.UseMySQL(Configuration.GetConnectionString("AzureMySQLConnection"));
            });

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // JSON Web Tokne Configuration
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            // Authentication Services Configuration
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
                .AddJwtBearer(jwt =>
                {
                    jwt.RequireHttpsMetadata = false;
                    jwt.SaveToken = true;
                    jwt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
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

            services.AddScoped<IProfileService, ProfileService>();
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

            services.AddAutoMapper(typeof(Startup));
            services.AddRouting(options => options.LowercaseUrls = true);
           

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
            app.UseCors(x => x.SetIsOriginAllowed(origin => true)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());

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
