using BusinessObject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAcess
{
    public class OrderDA
    {
        string _connectionString = ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString;
        SqlConnection _connection;
        public List<BusinessObjectOrder> GetOrderDetails(List<BusinessObjectOrder> bo)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetOrderDetails", _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                BusinessObjectOrder order;
                while (reader.Read())
                {
                    order = new BusinessObjectOrder()
                    {
                        PurchaseAmount = Convert.ToDecimal(reader["purch_amt"]),
                        CustomerId = Convert.ToInt32(reader["customer_id"]),
                        SalesmanId = Convert.ToInt32(reader["salesman_id"])
                    };
                    bo.Add(order);
                }
            }
            return bo;
        }
        public int InsertOrder(BusinessObjectOrder bo)
        {
            int result;
            using (_connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddOrder", _connection);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramPurchAmt = new SqlParameter()
                {
                    ParameterName = "@purch_amt",
                    Value = bo.PurchaseAmount
                };
                cmd.Parameters.Add(paramPurchAmt);

                SqlParameter paramOrdDate = new SqlParameter()
                {
                    ParameterName = "@ord_date",
                    Value = bo.OrderDate
                };
                cmd.Parameters.Add(paramOrdDate);

                SqlParameter paramCustId = new SqlParameter()
                {
                    ParameterName = "@cust_id",
                    Value = bo.CustomerId
                };
                cmd.Parameters.Add(paramCustId);

                SqlParameter paramSalesId = new SqlParameter()
                {
                    ParameterName = "@sales_id",
                    Value = bo.SalesmanId
                };
                cmd.Parameters.Add(paramSalesId);
                _connection.Open();
                result = cmd.ExecuteNonQuery();

            };
            return result;
        }
    }
}
