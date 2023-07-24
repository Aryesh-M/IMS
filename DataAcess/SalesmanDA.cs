using BusinessObject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DataAcess
{
    public class SalesmanDA
    {
        string _connectionString = ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString;
        SqlConnection _connection;
        public List<BusinessObjectSalesman> GetSalesmanDetails(List<BusinessObjectSalesman> bo)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetSalesmanDetails", _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                BusinessObjectSalesman saleman;
                while (reader.Read())
                {
                    saleman = new BusinessObjectSalesman()
                    {
                        Name = reader["name"].ToString(),
                        City = reader["city"].ToString(),
                        Commission = Convert.ToDecimal(reader["commission"])
                    };
                    bo.Add(saleman);
                }
            }
            return bo;
        }
        public int InsertSalesman(BusinessObjectSalesman bo)
        {
            int result;
            using (_connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddSalesman", _connection);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramName = new SqlParameter()
                {
                    ParameterName = "@name",
                    Value = bo.Name
                };
                cmd.Parameters.Add(paramName);

                SqlParameter paramCity = new SqlParameter()
                {
                    ParameterName = "@city",
                    Value = bo.City
                };
                cmd.Parameters.Add(paramCity);

                SqlParameter paramCommision = new SqlParameter()
                {
                    ParameterName = "@commission",
                    Value = bo.Commission
                };
                cmd.Parameters.Add(paramCommision);

                _connection.Open();
                result = cmd.ExecuteNonQuery();

            };
            return result;
        }
    }
}
