using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Library.API.Extensions;
using Libriary_BAL.Services;
using Libriary_BAL.Services.IService;
using Libriary_BAL.Utilities.AutoMapperProfiles;
using Libriary_BAL.Validators;
using Libriary_DAL.Data;
using Libriary_DAL.Entities.Models;
using Libriary_DAL.Repositories;
using Libriary_DAL.Repositories.IRepositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Libriary_BAL.Utilities.Exceptions;


namespace Library.API.Extensions
{
    public static class ServicesConfiguration
    {
        
        public static void AddAuthenticationBearer(this IServiceCollection services, IConfiguration configuration) =>
            services.AddAuthentication(options => options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = configuration["Jwt:Issuer"],
                            ValidAudience = configuration["Jwt:Audience"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"])),
                            ClockSkew = TimeSpan.Zero
                        };
                    });
        public static void AddMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
        public static void RegisterBALDependencies(this IServiceCollection services)
        {
            services
                .AddScoped<IAuthorService, AuthorService>()
                .AddScoped<IBookService, BookService>()
                .AddScoped<IGenreService, GenreService>()
                .AddScoped<IIssueService, IssueService>()
                .AddScoped<ITokenService, TokenService>()
                .AddScoped<IAuthService, AuthService>();
        }
        public static void AddIdentityDbContext(this IServiceCollection services, IConfiguration configuration) => services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });
        public static void AddIdentitySupport(this IServiceCollection services) =>
           services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddErrorDescriber<CustomIdentityErrorDescriber>()
            .AddDefaultTokenProviders();
        public static void RegisterDALDependencies(this IServiceCollection services)
        {
            services
                .AddScoped<IBookRepository, BookRepository>()
                .AddScoped<IAuthorRepository, AuthorRepository>()
                .AddScoped<IGenreRepository, GenreRepository>()
                .AddScoped<IIssueRepository, IssueRepository>();

        }
        public static void AddAutoValidation(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<AuthorToUpdateDTOValidator>()
                    .AddValidatorsFromAssemblyContaining<BookToCreateDTOValidator>()
                    .AddValidatorsFromAssemblyContaining<BookToUpdateDTOValidator>()
                    .AddValidatorsFromAssemblyContaining<GenreToUpdateDTOValidator>()
                    .AddValidatorsFromAssemblyContaining<IssueToCreateDTOValidator>()
                    .AddValidatorsFromAssemblyContaining<IssueToUpdateDTOValidator>()
                    .AddValidatorsFromAssemblyContaining<RegisterValidator>();

            services.AddFluentValidationAutoValidation();
        }

       

    }
}
