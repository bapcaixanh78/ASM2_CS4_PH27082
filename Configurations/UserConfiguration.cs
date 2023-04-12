using ASM2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASM2.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Username).HasColumnType("varchar(256)").IsRequired();
            builder.Property(x => x.Password).HasColumnType("varchar(256)").IsRequired();
            //builder.HasOne(p => p.Role).WithMany(p => p.Users).
            //    HasForeignKey(p => p.RoleId);
            builder.HasAlternateKey(p => p.Username);
        }
    }
}
