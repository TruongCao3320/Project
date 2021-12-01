using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public OrderObject GetOrderByID(int orderID) => OrderDAO.Instance.GetOrderByID(orderID);
        public IEnumerable<OrderObject> GetOrders() => OrderDAO.Instance.GetOrderList();

        public void InsertOrder(OrderObject order) =>OrderDAO.Instance.AddNew(order);
        public void DeletOrder(int orderId) => OrderDAO.Instance.Delete(orderId);
        public void UpdateOrder(OrderObject order) => OrderDAO.Instance.Update(order);
    }
}
