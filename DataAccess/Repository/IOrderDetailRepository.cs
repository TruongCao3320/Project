using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetailObject> GetOrderDetail();
        OrderDetailObject GetOrderDetailByID(int detailID);
       // void InsertOrderDetail(OrderDetailObject detail);
        //void DeletOrderDetail(int detail);
        //void UpdateOrderDetail(OrderDetailObject detail);
    }
}
