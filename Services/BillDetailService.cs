using ASM2.Models;
using ASM2.IServices;
using ASM2.Models;

namespace ASM2.Services
{
    public class BillDetailService : IBillDetailService
    {
        ShopDbcontext _dbContext;
        public BillDetailService()
        {
            _dbContext = new ShopDbcontext();
        }
        public bool CreateBillDetail(BillDetails p)
        {
            try
            {
                _dbContext.BillDetails.Add(p);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public bool DeleteBillDetail(Guid id)
        {
            try
            {
                //Find(Id) chỉ dùng được khi id là khóa chính
                var bill = _dbContext.BillDetails.FirstOrDefault(x => x.Id == id);
                _dbContext.BillDetails.Remove(bill);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public List<BillDetails> GetAllBillDetails()
        {
            return _dbContext.BillDetails.ToList();
        }

        public BillDetails GetBillDetailById(Guid id)
        {
            return _dbContext.BillDetails.FirstOrDefault(c => c.Id == id);
        }

        public List<BillDetails> GetBillDetailByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateBillDetail(BillDetails p)
        {
            try
            {
                //Find(Id) chỉ dùng được khi id là khóa chính
                var bill = _dbContext.BillDetails.FirstOrDefault(x => x.Id == p.Id);
                bill.IdSP = p.IdSP;
                bill.IdHD = p.IdHD;
                bill.Quantity = p.Quantity;
                bill.Price = p.Price;
                _dbContext.BillDetails.Update(bill);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        BillDetails IBillDetailService.GetBillDetailById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
