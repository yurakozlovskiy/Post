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
    public class AdoTypesRepository : ITypesRepository
    {
        public void Add(Types type)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AdoPostEntities"].ConnectionString;
            string cmd = string.Format("insert into Types(Id, Name)" +
                "values ('{0}')", type.Name);

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

        public IEnumerable<Types> GetAll()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AdoPostEntities"].ConnectionString;
            string cmd = "select * from Types";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = cmd;

                var reader = command.ExecuteReader();
                var result = new List<Types>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result.Add(new Types
                        {
                            Id = Convert.ToInt64(reader["Id"].ToString()),
                            Name = reader["Name"].ToString()

                        });
                    }

                }

                connection.Close();
                return result;
            }
        }

        public void Remove(Types types)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AdoPostEntities"].ConnectionString;
            string cmd = string.Format("delete from Types where Id = {0}", types.Id);
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
        public void Update(Types types)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AdoPostEntities"].ConnectionString;
            string cmd = string.Format("update People set Type = 'Example' where Id = {0}", types.Id);

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
