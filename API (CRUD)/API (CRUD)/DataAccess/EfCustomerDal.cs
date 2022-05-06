using API__CRUD_.Models;

namespace API__CRUD_.DataAccess
{
    public class EfCustomerDal : EF_EntityRepositoryBase<Customers, Buydata_DbContext>, ICustomerDal
    {
    }
}
