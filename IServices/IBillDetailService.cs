using ASM2.Models;


namespace ASM2.IServices
{
    public interface IBillDetailService
    {
        public bool CreateBillDetail(BillDetails p);
        public bool UpdateBillDetail(BillDetails p);
        public bool DeleteBillDetail(Guid id);
        public List<BillDetails> GetAllBillDetails();
        public BillDetails GetBillDetailById(Guid id);
        public List<BillDetails> GetBillDetailByName(string name);
    }
}
