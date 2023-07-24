using BusinessObject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DataAcess
{
    public class CustomerDA
    {
        string _connectionString = ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString;
        SqlConnection _connection;
        public List<BusinessObjectCustomer> GetCustomerDetails(List<BusinessObjectCustomer> bo)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetCustomerDetails", _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                BusinessObjectCustomer customer;
                while (reader.Read())
                {
                    customer = new BusinessObjectCustomer()
                    {
                        CustName = reader["cust_name"].ToString(),
                        City = reader["city"].ToString(),
                        Grade = Convert.ToInt32(reader["grade"]),
                        SalesmanId = Convert.ToInt32(reader["salesman_id"])
                    };
                    bo.Add(customer);
                }
            }
            return bo;
        }
        public int InsertCustomer(BusinessObjectCustomer bo)
        {
            int result;
            using (_connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddCustomer", _connection);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramCustName = new SqlParameter()
                {
                    ParameterName = "@cust_name",
                    Value = bo.CustName
                };
                cmd.Parameters.Add(paramCustName);

                SqlParameter paramCity  = new SqlParameter()
                {
                    ParameterName = "@city",
                    Value = bo.City
                };
                cmd.Parameters.Add(paramCity);

                SqlParameter paramGrade = new SqlParameter()
                {
                    ParameterName = "@grade",
                    Value = bo.Grade
                };
                cmd.Parameters.Add(paramGrade);

                SqlParameter paramSalesId = new SqlParameter()
                {
                    ParameterName = "@salesman_id",
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
