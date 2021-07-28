namespace Weelo.API
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.OpenApi.Models;
    using Weelo.API.Filters;
    using Weelo.API.UseCases.v1.Authentication;
    using Weelo.API.UseCases.v1.Owner.CreateOwner;
    using Weelo.API.UseCases.v1.Owner.GetAllOwners;
    using Weelo.API.UseCases.v1.Property.ChangePropertyPrice;
    using Weelo.API.UseCases.v1.Property.CreateProperty;
    using Weelo.API.UseCases.v1.Property.DeleteProperty;
    using Weelo.API.UseCases.v1.Property.GetAllProperties;
    using Weelo.API.UseCases.v1.Property.UpdateProperty;
    using Weelo.API.UseCases.v1.PropertyImage.AddPropertyImage;
    using Weelo.Infrastructure.EntityFrameworkDataAccess;

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
            services.AddDbContext<WeeloContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = 
                    $"{Configuration.GetValue<string>("Redis:Server")}:{Configuration.GetValue<int>("Redis:Port")}";
            });
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Weelo.API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. 
                                Enter 'Bearer' [space] and then your token in the text input below.
                                Example: 'Bearer {token}'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
            });

            var key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("SecretKey"));

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddCors();
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(BusinessExceptionFilter));
                options.EnableEndpointRouting = false;
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<LoginPresenter, LoginPresenter>();
            services.AddScoped<CreateOwnerPresenter, CreateOwnerPresenter>();
            services.AddScoped<GetAllOwnersPresenter, GetAllOwnersPresenter>();
            services.AddScoped<ChangePropertyPricePresenter, ChangePropertyPricePresenter>();
            services.AddScoped<CreatePropertyPresenter, CreatePropertyPresenter>();
            services.AddScoped<DeletePropertyPresenter, DeletePropertyPresenter>();
            services.AddScoped<UpdatePropertyPresenter, UpdatePropertyPresenter>();
            services.AddScoped<GetAllPropertiesPresenter, GetAllPropertiesPresenter>();
            services.AddScoped<AddPropertyImagePresenter, AddPropertyImagePresenter>();

            services.AddScoped<Application.Boundaries.Login.IOutputPort>(x => x.GetRequiredService<LoginPresenter>());
            services.AddScoped<Application.Boundaries.Owner.CreateOwner.IOutputPort>(x => x.GetRequiredService<CreateOwnerPresenter>());
            services.AddScoped<Application.Boundaries.Owner.GetAllOwners.IOutputPort>(x => x.GetRequiredService<GetAllOwnersPresenter>());
            services.AddScoped<Application.Boundaries.Property.ChangePropertyPrice.IOutputPort>(x => x.GetRequiredService<ChangePropertyPricePresenter>());
            services.AddScoped<Application.Boundaries.Property.CreateProperty.IOutputPort>(x => x.GetRequiredService<CreatePropertyPresenter>());
            services.AddScoped<Application.Boundaries.Property.DeleteProperty.IOutputPort>(x => x.GetRequiredService<DeletePropertyPresenter>());
            services.AddScoped<Application.Boundaries.Property.UpdateProperty.IOutputPort>(x => x.GetRequiredService<UpdatePropertyPresenter>());
            services.AddScoped<Application.Boundaries.Property.GetAllProperties.IOutputPort>(x => x.GetRequiredService<GetAllPropertiesPresenter>());
            services.AddScoped<Application.Boundaries.PropertyImage.AddPropertyImage.IOutputPort>(x => x.GetRequiredService<AddPropertyImagePresenter>());

            services.AddScoped<Application.Boundaries.Login.IUseCase, Application.UseCases.Login.LoginUseCase>();
            services.AddScoped<Application.Boundaries.Owner.CreateOwner.IUseCase, Application.UseCases.Owner.CreateOwnerUseCase>();
            services.AddScoped<Application.Boundaries.Owner.GetAllOwners.IUseCase, Application.UseCases.Owner.GetAllOwnersUseCase>();
            services.AddScoped<Application.Boundaries.Property.ChangePropertyPrice.IUseCase, Application.UseCases.Property.ChangePropertyPriceUseCase>();
            services.AddScoped<Application.Boundaries.Property.CreateProperty.IUseCase, Application.UseCases.Property.CreatePropertyUseCase>();
            services.AddScoped<Application.Boundaries.Property.DeleteProperty.IUseCase, Application.UseCases.Property.DeletePropertyUseCase>();
            services.AddScoped<Application.Boundaries.Property.UpdateProperty.IUseCase, Application.UseCases.Property.UpdatePropertyUseCase>();
            services.AddScoped<Application.Boundaries.Property.GetAllProperties.IUseCase, Application.UseCases.Property.GetAllPropertiesUseCase>();
            services.AddScoped<Application.Boundaries.PropertyImage.AddPropertyImage.IUseCase, Application.UseCases.PropertyImage.AddPropertyImageUseCase>();

            services.AddScoped<Application.Gateway.IOwnerGateway, Infrastructure.EntityFrameworkDataAccess.Adapter.OwnerRepositoryAdapter>();
            services.AddScoped<Application.Gateway.IPropertyGateway, Infrastructure.EntityFrameworkDataAccess.Adapter.PropertyRepositoryAdapter>();
            services.AddScoped<Application.Gateway.IPropertyImageGateway, Infrastructure.EntityFrameworkDataAccess.Adapter.PropertyImageRepositoryAdapter>();
            services.AddScoped<Application.Gateway.IPropertyTraceGateway, Infrastructure.EntityFrameworkDataAccess.Adapter.PropertyTraceRepositoryAdapter>();
            
            services.AddScoped<Infrastructure.EntityFrameworkDataAccess.Service.IOwnerService, Infrastructure.EntityFrameworkDataAccess.Service.OwnerService>();
            services.AddScoped<Infrastructure.EntityFrameworkDataAccess.Service.IPropertyService, Infrastructure.EntityFrameworkDataAccess.Service.PropertyService>();
            services.AddScoped<Infrastructure.EntityFrameworkDataAccess.Service.IPropertyImageService, Infrastructure.EntityFrameworkDataAccess.Service.PropertyImageService>();
            services.AddScoped<Infrastructure.EntityFrameworkDataAccess.Service.IPropertyTraceService, Infrastructure.EntityFrameworkDataAccess.Service.PropertyTraceService>();

            services.AddScoped<Application.Services.IUnitOfWork, Weelo.Infrastructure.EntityFrameworkDataAccess.UnitOfWork>();

            services.AddScoped<Infrastructure.EntityFrameworkDataAccess.Repository.EntityRepository.IOwnerRepository, Infrastructure.EntityFrameworkDataAccess.Repository.EntityRepository.OwnerRepository>();
            services.AddScoped<Infrastructure.EntityFrameworkDataAccess.Repository.EntityRepository.IPropertyRepository, Infrastructure.EntityFrameworkDataAccess.Repository.EntityRepository.PropertyRepository>();
            services.AddScoped<Infrastructure.EntityFrameworkDataAccess.Repository.EntityRepository.IPropertyImageRepository, Infrastructure.EntityFrameworkDataAccess.Repository.EntityRepository.PropertyImageRepository>();
            services.AddScoped<Infrastructure.EntityFrameworkDataAccess.Repository.EntityRepository.IPropertyTraceRepository, Infrastructure.EntityFrameworkDataAccess.Repository.EntityRepository.PropertyTraceRepository>();

            services.AddScoped<Infrastructure.EntityFrameworkDataAccess.Service.Cache.EntityCache.IOwnerCacheService, Infrastructure.EntityFrameworkDataAccess.Service.Cache.EntityCache.OwnerCacheService>();
            services.AddScoped<Infrastructure.EntityFrameworkDataAccess.Service.Cache.EntityCache.IPropertyCacheService, Infrastructure.EntityFrameworkDataAccess.Service.Cache.EntityCache.PropertyCacheService>();
            services.AddScoped<Infrastructure.EntityFrameworkDataAccess.Service.Cache.EntityCache.IPropertyImageCacheService, Infrastructure.EntityFrameworkDataAccess.Service.Cache.EntityCache.PropertyImageCacheService>();
            services.AddScoped<Infrastructure.EntityFrameworkDataAccess.Service.Cache.EntityCache.IPropertyTraceCacheService, Infrastructure.EntityFrameworkDataAccess.Service.Cache.EntityCache.PropertyTraceCacheService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Weelo.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(
                options => options
                    .WithOrigins("http://localhost:3000")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
            );

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseMvc();
        }
    }
}
