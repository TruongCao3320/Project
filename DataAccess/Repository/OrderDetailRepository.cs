using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
 

        public OrderDetailObject GetOrderDetailByID(int orderID) => OrderDetailDAO.Instance.GetOrderDetailByID(orderID);
        public IEnumerable<OrderDetailObject> GetOrderDetail() => OrderDetailDAO.Instance.GetOrderDetailList();

       // public void InsertOrderDetail(OrderDetailObject member) => OrderDetailDAO.Instance.AddNew(member);
       // public void DeletMember(int memberId) => MemberDAO.Instance.Delete(memberId);
       // public void UpdateMember(MemberObject member) => MemberDAO.Instance.Update(member);
    }
}
