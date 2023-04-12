using ASM2.Models;
using Newtonsoft.Json;

namespace ASM2.Services
{
    public static class SessionService
    {
        
        public static List<Product> GetObjFromSession(ISession session, string key)
        {
            string jsonData = session.GetString(key);
            if (jsonData == null)
            {
                return new List<Product>();
            }
            else
            {
                var products = JsonConvert.DeserializeObject<List<Product>>(jsonData);
                return products;
            }
        }

        public static List<Product> GetProductFromSession(ISession session, string key)
        {
            var jsonData = session.GetString(key);
            if (jsonData == null)
            {
                return new List<Product>();
            }
            else
            {
                var product = JsonConvert.DeserializeObject<List<Product>>(jsonData);
                return product;
            }
        }

        public static List<CartDetail> GetCartDetailFromSession(ISession session, string key)
        {
            var jsonData = session.GetString(key);
            if (jsonData == null)
            {
                return new List<CartDetail>();
            }
            else
            {
                var product = JsonConvert.DeserializeObject<List<CartDetail>>(jsonData);
                return product;
            }
        }

        public static void SetObjToSession(ISession session, string key, object data)
        {
            var jsonData = JsonConvert.SerializeObject(data);
            session.SetString(key, jsonData);
        }

        public static bool CheckObjInList(Guid id, List<Product> products)
        {
            return products.Any(x => x.Id == id);
        }
        public static bool CheckObjInListCart(Guid id, List<CartDetail> Carts)
        {
            List<Guid> lst = Carts.Select(c=>c.IdSP).ToList();
            return lst.Any(x => x == id);
        }



    }
}
