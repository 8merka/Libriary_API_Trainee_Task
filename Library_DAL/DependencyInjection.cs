using Libriary_DAL.Data;
using Libriary_DAL.Repositories;
using Libriary_DAL.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Libriary_DAL
{
    public static class DependencyInjection
    {
        public static void RegisterDALDependencies(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql("Host=localhost;Port=5432;Database=TraineeLibrary;Username=postgres;Password=9100");
            });
            services
                .AddScoped<IBookRepository, BookRepository>()
                .AddScoped<IAuthorRepository, AuthorRepository>()
                .AddScoped<IGenreRepository, GenreRepository>()
                .AddScoped<IIssueRepository, IssueRepository>();
        }
    }
}
