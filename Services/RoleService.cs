using ASM2.IServices;
using ASM2.Models;

namespace ASM2.Services
{
    public class RoleService : IRoleService
    {
        ShopDbcontext _dbContext;
        public RoleService()
        {
            _dbContext = new ShopDbcontext();
        }
        public bool CreateRole(Role p)
        {
            try
            {
                _dbContext.Roles.Add(p);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }


        public bool DeleteRole(Guid id)
        {
            try
            {
                //Find(Id) chỉ dùng được khi id là khóa chính
                var role = _dbContext.Roles.FirstOrDefault(x => x.RoleId == id);
                _dbContext.Roles.Remove(role);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public List<Role> GetAllRoles()
        {
            return _dbContext.Roles.ToList();
        }

        public Role GetRoleById(Guid id)
        {
            return _dbContext.Roles.FirstOrDefault(x => x.RoleId == id);
        }

        public List<Role> GetRoleByName(string name)
        {
            return _dbContext.Roles.Where(c => c.RoleName.Contains(name)).ToList();
        }

        public bool UpdateRole(Role p)
        {
            try
            {
                //Find(Id) chỉ dùng được khi id là khóa chính
                var role = _dbContext.Roles.FirstOrDefault(x => x.RoleId == p.RoleId);
                role.RoleName = p.RoleName;
                role.Description = p.Description;
                role.Status = p.Status;
                _dbContext.Roles.Update(role);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }
    }
}
