using BusinessObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailDAO :BaseDAL
    {
        private static OrderDetailDAO instance = null;
        private static readonly object instanceLock = new object();
        private OrderDetailDAO() { }
        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                    return instance;
                }
            }

        }
        public IEnumerable<OrderDetailObject> GetOrderDetailList()
        {

            IDataReader dataReader = null;
            string SQLSelect = "Select OrderID,ProductID,UnitPrice,Quantity,Discount from OrderDetail";
            var orders = new List<OrderDetailObject>();
            try
            {
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    orders.Add(new OrderDetailObject
                    {
                        OrderID = dataReader.GetInt32(0),
                        ProductID=dataReader.GetInt32(1),
                        UnitPrice=dataReader.GetDecimal(2),
                        Quantity=dataReader.GetInt32(3),
                        Discount=dataReader.GetDouble(4)
                    });
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return orders;
        }
        public OrderDetailObject GetOrderDetailByID(int orderDetailID)
        {
            OrderDetailObject order = null;

            IDataReader dataReader = null;
            string SQLSelect = "Select OrderID,ProductID,UnitPrice,Quantity,Discount from OrderDetail where OrderID=@OrderID";
            try
            {
                var param = dataProvider.CreateParameter("@OrderID", 10, orderDetailID, DbType.Int32);
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                if (dataReader.Read())
                {
                    order = new OrderDetailObject
                    {
                        OrderID = dataReader.GetInt32(0),
                        ProductID=dataReader.GetInt32(1),
                        UnitPrice=dataReader.GetDecimal(2),
                        Quantity=dataReader.GetInt32(3),
                        Discount=dataReader.GetFloat(4)
                    };
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return order;
        }
    }
}
