using ASM2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASM2.Configurations
{
    public class CartDetailConfiguration : IEntityTypeConfiguration<CartDetail>
    {
        public void Configure(EntityTypeBuilder<CartDetail> builder)
        {
            builder.HasKey(p=>p.Id);
            builder.HasOne(p=>p.Product).WithMany(p=>p.CartDetails).HasForeignKey(p=>p.IdSP);
            builder.HasOne(p=>p.Cart).WithMany(p=>p.CartDetails).HasForeignKey(p=>p.UserId);
        }
    }
}
