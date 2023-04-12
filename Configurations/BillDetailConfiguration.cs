using ASM2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASM2.Configurations
{
    public class BillDetailConfiguration:IEntityTypeConfiguration<BillDetails>
    { 
        public void Configure(EntityTypeBuilder<BillDetails> builder)
        {
            builder.Property(p=>p.Quantity).IsRequired().HasColumnType("int");
            builder.HasKey(p => p.Id);
            builder.HasOne(p=>p.Bill).WithMany(p => p.BillDetails).HasForeignKey(p=>p.IdHD).HasConstraintName("FK_HD");
            builder.HasOne(p => p.Product).WithMany(p => p.BillDetails).HasForeignKey(p => p.IdSP).HasConstraintName("FK_SP");

        }
    }
}
