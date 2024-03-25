using Libriary_BAL.Services;
using Libriary_BAL.Services.IService;
using Libriary_BAL.Utilities.AutoMapperProfiles;
using Libriary_DAL.Data;
using Libriary_DAL.Repositories.IRepositories;
using Libriary_DAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AutoMapper;
using FluentValidation.AspNetCore;
using FluentValidation;
using Libriary_BAL.Validators;

namespace Libriary_API.Extensions
{
    public static class ServicesConfiguration
    {
        public static void AddAuthentication(this IServiceCollection services, IConfiguration configuration) =>
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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
                .AddScoped<IIssueService, IssueService>();
        }
        public static void AddIdentityDbContext(this IServiceCollection services) => services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql("Host=localhost;Port=5432;Database=TraineeLibrary;Username=postgres;Password=9100");
        });
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
                    .AddValidatorsFromAssemblyContaining<IssueToUpdateDTOValidator>();

            services.AddFluentValidationAutoValidation();
        }
    }
}
