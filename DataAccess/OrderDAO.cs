using BusinessObject;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDAO : BaseDAL
    {
        private static OrderDAO instance = null;
        private static readonly object instanceLock = new object();
        private OrderDAO() { }
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }

        }
        public IEnumerable<OrderObject> GetOrderList()
        {

            IDataReader dataReader = null;
            string SQLSelect = "Select OrderID,MemberID,OrderDate,RequiredDate,ShippedDate,Freight from Oder";
            var orders = new List<OrderObject>();
            try
            {
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    orders.Add(new OrderObject
                    {
                        OrderID=dataReader.GetInt32(0),
                        MemberID=dataReader.GetInt32(1),
                        OrderDate=dataReader.GetDateTime(2),
                        RequiredDate=dataReader.GetDateTime(3),
                        ShippedDate=dataReader.GetDateTime(4),
                        Freight=dataReader.GetDecimal(5)
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
        public OrderObject GetOrderByID(int orderID)
        {
              OrderObject order = null;

            IDataReader dataReader = null;
            string SQLSelect = "Select OrderID,MemberID,OrderDate,RequiredDate,ShippedDate,Freight from Oder where OrderID=@OrderID";
            try
            {
                var param = dataProvider.CreateParameter("@OrderID", 10, orderID, DbType.Int32);
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                if (dataReader.Read())
                {
                    order = new OrderObject
                    {
                        OrderID = dataReader.GetInt32(0),
                        MemberID = dataReader.GetInt32(1),
                        OrderDate = dataReader.GetDateTime(2),
                        RequiredDate = dataReader.GetDateTime(3),
                        ShippedDate = dataReader.GetDateTime(4),
                        Freight = dataReader.GetDecimal(5)
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
        public void AddNew(OrderObject order)
        {
            try
            {
                OrderObject ord = GetOrderByID(order.OrderID);
                if (ord == null)
                {
                    string SQLInsert = "Insert Oder values(@OrderID,@MemberID,@OrderDate,@RequiredDate,@ShippedDate,@Freight)";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(dataProvider.CreateParameter("@OrderID", 10, order.OrderID, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@MemberID", 10, order.MemberID, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@OrderDate",20, order.OrderDate, DbType.DateTime));
                    parameters.Add(dataProvider.CreateParameter("@RequiredDate", 20, order.RequiredDate, DbType.DateTime));
                    parameters.Add(dataProvider.CreateParameter("@ShippedDate", 15, order.ShippedDate, DbType.DateTime));
                    parameters.Add(dataProvider.CreateParameter("@Freight", 30, order.Freight, DbType.Decimal));
                    dataProvider.Insert(SQLInsert, CommandType.Text, parameters.ToArray());

                }
                else
                {
                    throw new Exception("Order ID is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        public void Update(OrderObject order)
        {
            try
            {
                OrderObject m = GetOrderByID(order.OrderID);
                if (m != null)
                {
                    string SQLUpdate = "Update Oder set,MemberID=@MemberID,OrderDate=@OrderDate,RequiredDate=@RequiredDate," +
                        "ShippedDate=@ShippedDate,Freight=@Freight where ProductID=@ProductID";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(dataProvider.CreateParameter("@OrderID", 10, order.OrderID, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@MemberID", 10, order.MemberID, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@OrderDate", 20, order.OrderDate, DbType.DateTime));
                    parameters.Add(dataProvider.CreateParameter("@RequiredDate", 20, order.RequiredDate, DbType.DateTime));
                    parameters.Add(dataProvider.CreateParameter("@ShippedDate", 15, order.ShippedDate, DbType.DateTime));
                    parameters.Add(dataProvider.CreateParameter("@Freight", 30, order.Freight, DbType.Decimal));
                    dataProvider.Update(SQLUpdate, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("Order does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        public void Delete(int orderID)
        {
            try
            {
                OrderObject m = GetOrderByID(orderID);
                if (m != null)
                {
                    string SQLDelete = "Delete Oder where OrderID=@OrderID";
                    var param = dataProvider.CreateParameter("@OrderID", 10, orderID, DbType.Int32);
                    dataProvider.Delete(SQLDelete, CommandType.Text, param);
                }
                else
                {
                    throw new Exception("Order does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
