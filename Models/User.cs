using System.ComponentModel.DataAnnotations;

namespace ASM2.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        //public Guid RoleId { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public int Status { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        //public virtual Role Role { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
