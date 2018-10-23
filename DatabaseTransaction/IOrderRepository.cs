using System.Collections.Generic;

namespace DatabaseTransaction
{
    public interface IOrderRepository
    {
        IList<Order> GetAll();
    }
}
