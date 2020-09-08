using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using DB;
using Repositories.AbstractProducts;

namespace Repositories.Products
{
    public class AdoStatusRepository : IStatusRepository
    {
        public void Add(DeliveryStatus status)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AdoPostEntities"].ConnectionString;
            string cmd = string.Format("insert into Types(Id, Name)" +
                "values ('{0}')", status.Status);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = cmd;

                int number = command.ExecuteNonQuery();
                connection.Close();

                //Console.WriteLine("\nAdd new person \n", number);
            }
        }

        public IEnumerable<DeliveryStatus> GetAll()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AdoPostEntities"].ConnectionString;
            string cmd = "select * from DeliveryStatus";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = cmd;

                var reader = command.ExecuteReader();
                var result = new List<DeliveryStatus>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result.Add(new DeliveryStatus
                        {
                            Id = Convert.ToInt64(reader["Id"].ToString()),
                            Status = reader["Status"].ToString()

                        });
                    }

                }

                connection.Close();
                return result;
            }
        }

        public void Remove(DeliveryStatus status)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AdoPostEntities"].ConnectionString;
            string cmd = string.Format("delete from DeliveryStatus where Id = {0}", status.Id);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = cmd;

                int number = command.ExecuteNonQuery();
                connection.Close();

                //Console.WriteLine("\nRemove person with Id={0}\n", people.Id);
            }
        }

        public void Update(DeliveryStatus status)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AdoPostEntities"].ConnectionString;
            string cmd = string.Format("update DeliveryStatus set Status = 'Example' where Id = {0}", status.Id);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = cmd;

                int number = command.ExecuteNonQuery();
                connection.Close();

                //Console.WriteLine("\nUpdate person with Id = {0}\n", people.Id);
            }
        }
    }
}
