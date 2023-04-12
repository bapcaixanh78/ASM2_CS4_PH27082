using ASM2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASM2.Configurations
{
    public class BillConfiguration: IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("Bill");
            builder.HasKey(p => new { p.Id });
            builder.Property(p=>p.Status).HasColumnType("int").IsRequired();
            builder.HasOne(p => p.User).WithMany(p => p.Bills).HasForeignKey(p => p.UserId);
        }
    }
}
