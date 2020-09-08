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
    public class AdoPeopleRepository : IPeopleRepository
    {

        
        /*private bool ExecuteNonQueryCommand(string cmd)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PostEntities"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = cmd; 
            }

                return true;
        }*/

        public void Add(People people)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AdoPostEntities"].ConnectionString;
            string cmd = string.Format("insert into People(FirstName, LastName, Age, PhoneNumber, Email)" +
                "values ('{0}','{1}',{2},'{3}','{4}')", people.FirstName, people.LastName, people.Age, people.PhoneNumber,
                people.Email);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = cmd;

                int number = command.ExecuteNonQuery();
                connection.Close();

                Console.WriteLine("\nAdd new person \n",number);
            }
        }

        public People Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<People> GetAll()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AdoPostEntities"].ConnectionString;
            string cmd = "select * from People";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = cmd;

                var reader = command.ExecuteReader();
                var result = new List<People>();

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        result.Add(new People
                        {
                            Id = Convert.ToInt64(reader["Id"].ToString()),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Age = Convert.ToInt32(reader["Age"].ToString()),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            Email = reader["Email"].ToString()
                            
                        });
                    }

                }

                connection.Close();
                return result;
            }

        }

        public void Remove(People people)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AdoPostEntities"].ConnectionString;
            string cmd = string.Format("delete from People where Id = {0}", people.Id);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = cmd;

                int number = command.ExecuteNonQuery();
                connection.Close();

                Console.WriteLine("\nRemove person with Id={0}\n", people.Id);
            }
        }

        public void Update(People people)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AdoPostEntities"].ConnectionString;
            string cmd = string.Format("update People set Age = 20 where Id = {0}", people.Id);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = cmd;

                int number = command.ExecuteNonQuery();
                connection.Close();

                Console.WriteLine("\nUpdate person with Id = {0}\n", people.Id);
            }
        }
    }
}
