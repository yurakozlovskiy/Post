using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;
using Repositories.AbstractProducts;
using System.Data.SqlClient;
using System.Configuration;

namespace Repositories.Products
{
    public class AdoAddressesRepository : IAddressesRepository
    {
        public void Add(Addresses address)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AdoPostEntities"].ConnectionString;
            string cmd = string.Format("insert into Addresses(Country, City, Oblast, Region, House, Flat, Street)" +
                "values('{0}','{1}','{2}','{3}',{4},{5},'{6}')", address.Country, address.City, address.Oblast,
                address.Region, address.House, address.Flat, address.Street);

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = cmd;

                int number = command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public IEnumerable<Addresses> GetAll()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AdoPostEntities"].ConnectionString;
            string cmd = "select * from Addresses";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = cmd;

                var reader = command.ExecuteReader();
                var result = new List<Addresses>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result.Add(new Addresses
                        {
                            Id = Convert.ToInt64(reader["Id"].ToString()),
                            Country = reader["Country"].ToString(),
                            City = reader["City"].ToString(),
                            Oblast = reader["Oblast"].ToString(),
                            Region = reader["House"].ToString(),
                            House = Convert.ToInt32(reader["House"].ToString()),
                            Flat = reader["Flat"] != null ? Convert.ToInt32(reader["Flat"].ToString()) : (int?)null,
                            Street = reader["Street"].ToString()
                        });
                    }

                }

                connection.Close();
                return result;
            }
        }

        public void Remove(Addresses address)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AdoPostEntities"].ConnectionString;
            string cmd = string.Format("delete from Addresses where Id={0}", address.Id);

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = cmd;

                int number = command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Update(Addresses address)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AdoPostEntities"].ConnectionString;
            string cmd = string.Format("update Addresses set House = 20 where Id = {0}", address.Id);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = cmd;

                int number = command.ExecuteNonQuery();
                connection.Close();

                Console.WriteLine("\nUpdate person with Id = {0}\n", address.Id);
            }
        }
    }
}
