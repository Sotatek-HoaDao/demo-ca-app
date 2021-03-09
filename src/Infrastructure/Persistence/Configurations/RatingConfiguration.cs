using demo_ca_app.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace demo_ca_app.Infrastructure.Persistence.Configurations
{
    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            builder.Property(t => t.MovieId)
                .IsRequired();

            builder.Property(t => t.MovieName)
                .IsRequired();
            
            builder.Property(t => t.RatingPoint)
                .IsRequired();
            builder.Property(t => t.UserMail)
                .IsRequired();
        }
    }
}