﻿namespace ASM2.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int AvailableQuantity { get; set; }
        public int Status { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Supplier { get; set; }
        public string Description { get; set; }
        public virtual ICollection<BillDetails> BillDetails { get; set; }
        public virtual ICollection<CartDetail> CartDetails { get; set; }
    }
}
