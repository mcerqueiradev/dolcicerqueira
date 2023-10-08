using wapp_dolcicerqueira.Domain.Entities;
using wapp_dolcicerqueira.Repositories.Interfaces;
using System;
using System.Data;
using System.Data.SqlClient;

namespace wapp_dolcicerqueira.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository 
    {
        private const string _connectionString = @"Server=localhost\SQLEXPRESS;Database=DolciCerqueira;Trusted_Connection=True;";
        private readonly SqlConnection _sqlConnection = new SqlConnection(_connectionString);
        public Order GetById(int id)
        {
            Order orderResult = null;

            string query = "GetOrderById";

            SqlParameter searchParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@OrderID",
                DbType = DbType.Int32,
                Value = id
            };

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            sqlCommand.Parameters.Add(searchParam);

            _sqlConnection.Open();

            SqlDataReader readerTable = sqlCommand.ExecuteReader();

            while (readerTable.Read())
            {
                orderResult = new Order
                {
                    OrderID = Convert.ToInt32(readerTable["OrderID"]),
                    FK_ProductID = Convert.ToInt32(readerTable["FK_ProductID"]),
                    OrderPrice = Convert.ToDecimal(readerTable["OrderPrice"]),
                };
            }

            _sqlConnection.Close();

            return orderResult;
        }

        public Order Add(Order order)
        {
            string query = "AddOrder";

            SqlParameter idParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@OrderID",
                DbType = DbType.Int32,
                Value = order.OrderID
            };

            SqlParameter prodParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@FK_ProductID",
                Value = order.FK_ProductID
            };

            SqlParameter priceParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@OrderPrice",
                Value = order.OrderPrice
            };

            SqlParameter dateParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@OrderDate",
                Value = order.OrderDate
            };

            SqlParameter fkUserParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@FK_AuthorId",
                Value = order.FK_AuthorId
            };

            SqlParameter statusParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@OrderStatus",
                Value = order.OrderStatus
            };

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            sqlCommand.Parameters.Add(idParam);
            sqlCommand.Parameters.Add(prodParam);
            sqlCommand.Parameters.Add(priceParam);
            sqlCommand.Parameters.Add(dateParam);
            sqlCommand.Parameters.Add(fkUserParam);
            sqlCommand.Parameters.Add(statusParam);

            _sqlConnection.Open();

            order.OrderID = Convert.ToInt32(sqlCommand.ExecuteNonQuery());

            _sqlConnection.Close();

            return order;
        }

        public Order Update(Order order)
        {
            string query = "UpdateOrder";


            SqlParameter idParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@OrderID",
                DbType = DbType.Int32,
                Value = order.OrderID
            };

            SqlParameter prodParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@FK_ProductID",
                Value = order.FK_ProductID
            };

            SqlParameter priceParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@OrderPrice",
                Value = order.OrderPrice
            };

            SqlParameter dateParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@OrderDate",
                Value = order.OrderDate
            };

            SqlParameter fkUserParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@FK_AuthorId",
                Value = order.FK_AuthorId
            };

            SqlParameter statusParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@OrderStatus",
                Value = order.OrderStatus
            };

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            sqlCommand.Parameters.Add(idParam);
            sqlCommand.Parameters.Add(prodParam);
            sqlCommand.Parameters.Add(priceParam);
            sqlCommand.Parameters.Add(dateParam);
            sqlCommand.Parameters.Add(fkUserParam);
            sqlCommand.Parameters.Add(statusParam);

            _sqlConnection.Open();

            sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();

            return order;
        }

        public void Delete(int id)
        {
            string query = "DeleteOrder";

            SqlParameter idParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@OrderID",
                DbType = DbType.Int32,
                Value = id
            };

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            sqlCommand.Parameters.Add(idParam);

            _sqlConnection.Open();

            sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

    }
}
