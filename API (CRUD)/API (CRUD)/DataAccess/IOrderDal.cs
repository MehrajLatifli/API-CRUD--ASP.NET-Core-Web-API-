using API__CRUD_.Models;

namespace API__CRUD_.DataAccess
{
    public interface IOrderDal : IEntityRepository<Orders>
    {
        List<OrderModel> GetOrderwithDetailts();
    }
}
