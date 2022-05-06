using API__CRUD_.Models;

namespace API__CRUD_.DataAccess
{
    public class EfOrderDal : EF_EntityRepositoryBase<Orders, Buydata_DbContext>, IOrderDal
    {
        public List<OrderModel> GetOrderwithDetailts()
        {
            using (var context = new Buydata_DbContext())
            {
                var productModel = from o in context.Orders
                                   join c in context.Customers
                                   on o.CustomerIdinOrders equals c.Idcustomer
                                   select new OrderModel
                                   {
                              
                                       OrderID=o.Idorder,
                                       CustomerName=c.CustomerName,
                                       CompanyName=c.CompanyName,
                                       Country=c.Country,
                                       ShipName=o.ShipName
                                   };

                return productModel.ToList();
            }
        }
    }
}
