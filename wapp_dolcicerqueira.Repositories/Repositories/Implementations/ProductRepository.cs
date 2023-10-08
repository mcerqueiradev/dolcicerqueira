using wapp_dolcicerqueira.Domain.Entities;
using wapp_dolcicerqueira.Repositories.Interfaces;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace wapp_dolcicerqueira.Repositories.Implementations
{
    public class ProductRepository : IProductRepository 
    {
        private const string _connectionString = @"Server=localhost\SQLEXPRESS;Database=DolciCerqueira;Trusted_Connection=True;";
        private readonly SqlConnection _sqlConnection = new SqlConnection(_connectionString);
        public Product GetById(int id)
        {
            Product productResult = null;

            string query = "GetProductById";

            SqlParameter searchParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Id",
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
                productResult = new Product
                {
                    Id = Convert.ToInt32(readerTable["Id"]),
                    Name = Convert.ToString(readerTable["Name"]),
                    CategoryId = Convert.ToInt32(readerTable["CategoryId"]),
                    Price = Convert.ToDecimal(readerTable["Price"]),
                };
            }

            _sqlConnection.Close();

            return productResult;
        }

        public Product Add(Product product)
        {
            string query = "AddProduct";

            SqlParameter idParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Id",
                DbType = DbType.Int32,
                Value = product.Id
            };

            SqlParameter nameParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Name",
                Value = product.Name
            };

            SqlParameter catParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@CategoryId",
                Value = product.CategoryId
            };

            SqlParameter priceParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Price",
                Value = product.Price
            };

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            sqlCommand.Parameters.Add(idParam);
            sqlCommand.Parameters.Add(nameParam);
            sqlCommand.Parameters.Add(catParam);
            sqlCommand.Parameters.Add(priceParam);

            _sqlConnection.Open();

            product.Id = Convert.ToInt32(sqlCommand.ExecuteNonQuery());

            _sqlConnection.Close();

            return product;
        }


        public Product Update(Product product)
        {
            string query = "UpdateProduct";

            SqlParameter idParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Id",
                DbType = DbType.Int32,
                Value = product.Id
            };

            SqlParameter nameParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Name",
                Value = product.Name
            };

            SqlParameter catParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@CategoryId",
                Value = product.CategoryId
            };

            SqlParameter priceParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Price",
                Value = product.Price
            };

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            sqlCommand.Parameters.Add(idParam);
            sqlCommand.Parameters.Add(nameParam);
            sqlCommand.Parameters.Add(catParam);
            sqlCommand.Parameters.Add(priceParam);

            _sqlConnection.Open();

            sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();

            return product;
        }

        public void Delete(int id)
        {
            string query = "DeleteProduct";

            SqlParameter idParam = new()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@Id",
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

        public List<Product> GetAll()
        {
            List<Product> productsResult = new List<Product>();

            string query = "GetAllProducts";

            SqlCommand sqlCommand = new(query, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };

            _sqlConnection.Open();

            SqlDataReader readerTable = sqlCommand.ExecuteReader();

            while (readerTable.Read())
            {
                productsResult.Add(
                    new Product
                    {
                        Id = Convert.ToInt32(readerTable["Id"]),
                        Name = Convert.ToString(readerTable["Name"]),
                        CategoryId = Convert.ToInt32(readerTable["CategoryId"]),
                        Price = Convert.ToDecimal(readerTable["Price"]),
                    });
            }

            _sqlConnection.Close();

            return productsResult;
        }
    }
}
