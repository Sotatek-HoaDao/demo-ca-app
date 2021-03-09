using demo_ca_app.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace demo_ca_app.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Movie> Movies { get; set; }

        DbSet<Rating> Ratings { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
