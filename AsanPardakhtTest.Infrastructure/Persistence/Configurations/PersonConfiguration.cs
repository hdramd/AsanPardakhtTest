using AsanPardakhtTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AsanPardakhtTest.Infrastructure.Persistence.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(x => x.FirstName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.NationalId)
                .HasMaxLength(11)
                .IsRequired();

            builder.HasIndex(x => x.NationalId)
                .IsUnique();

            builder.HasMany(x => x.Addresses)
                .WithOne(x => x.Person).HasForeignKey(x => x.PersonId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
