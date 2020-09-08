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
    public class AdoCarRepository : ICarsRepository
    {
        public void Add(Cars car)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AdoPostEntities"].ConnectionString;
            string cmd = string.Format("insert into Cars(Brand, Number, Year)" +
                "values('{0}','{1}','{2}')", car.Brand, car.Number, car.Year);

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

        public IEnumerable<Cars> GetAll()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AdoPostEntities"].ConnectionString;
            string cmd = "select * from Cars";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = cmd;

                var reader = command.ExecuteReader();
                var car = new List<Cars>();

                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        car.Add(new Cars()
                        {
                            Id = Convert.ToInt64(reader["Id"].ToString()),
                            Brand = reader["Brand"].ToString(),
                            Number = reader["Number"].ToString(),
                            Year = (DateTime)reader["Year"]
                        });

                    }
                }

                connection.Close();
                return car;
            }
        }

        public void Remove(Cars car)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AdoPostEntities"].ConnectionString;
            string cmd = string.Format("delete from Cars where Id={0}", car.Id);

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

        public void Update(Cars car)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AdoPostEntities"].ConnectionString;
            string cmd = string.Format("update Cars set Number='BC1488AC' where Id={0}", car.Id);

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
    }
}
