using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class PersonDal : IPersonDal
    {
        private string connectionString;

        public PersonDal(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public PersonDTO CreatePerson(PersonDTO person)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into Person (FirstName, LastName, Gender, Address, Phone, BankCard, RowInsertTime, RowUpdateTime) output INSERTED.PersonID values (@firstName, @lastName, @gender, @address, @phone, @bankCard, @rowInsertTime, @rowUpdateTime)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@firstName", person.FirstName);
                comm.Parameters.AddWithValue("@lastName", person.LastName);
                comm.Parameters.AddWithValue("@gender", person.Gender);
                comm.Parameters.AddWithValue("@address", person.Address);
                comm.Parameters.AddWithValue("@phone", person.Phone);
                comm.Parameters.AddWithValue("@bankCard", person.BankCard);
                comm.Parameters.AddWithValue("@rowInsertTime", person.RowInsertTime);
                comm.Parameters.AddWithValue("@rowUpdateTime", person.RowUpdateTime);
                conn.Open();

                person.PersonID = Convert.ToInt32(comm.ExecuteScalar());
                return person;
            }
        }

        public void DeletePerson(int id)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from Person where PersonID = @id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@id", id);
                conn.Open();

                comm.ExecuteNonQuery();
            }
        }

        public List<PersonDTO> GetAllPersons()
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from Person";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<PersonDTO> user = new List<PersonDTO>();
                while (reader.Read())
                {
                    user.Add(new PersonDTO
                    {
                        PersonID = (int)reader["PersonID"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Gender = (bool)reader["Gender"],
                        Address = reader["Address"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        BankCard = (byte[])reader["BankCard"],
                        RowInsertTime = (DateTime)reader["RowInsertTime"],
                        RowUpdateTime = (DateTime)reader["RowUpdateTime"]
                    });
                }
                return user;
            }
        }

        public PersonDTO GetPersonById(int id)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                PersonDTO person = new PersonDTO();
                comm.CommandText = $"select * from Person where PersonID = {id}";
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    person = new PersonDTO
                    {
                        PersonID = (int)reader["PersonID"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Gender = (bool)reader["Gender"],
                        Address = reader["Address"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        BankCard = (byte[])reader["BankCard"],
                        RowInsertTime = (DateTime)reader["RowInsertTime"],
                        RowUpdateTime = (DateTime)reader["RowUpdateTime"]
                    };
                }
                return person;
            }
        }

        public PersonDTO UpdatePerson(PersonDTO person)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "update Person set FirstName = @firstName, LastName = @lastName, Gender = @gender, Address = @address, Phone = @phone, BankCard = @bankCard, RowInsertTime = @rowInsertTime, RowUpdateTime = @rowUpdateTime";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@firstName", person.FirstName);
                comm.Parameters.AddWithValue("@lastName", person.LastName);
                comm.Parameters.AddWithValue("@gender", person.Gender);
                comm.Parameters.AddWithValue("@address", person.Address);
                comm.Parameters.AddWithValue("@phone", person.Phone);
                comm.Parameters.AddWithValue("@bankCard", person.BankCard);
                comm.Parameters.AddWithValue("@rowInsertTime", person.RowInsertTime);
                comm.Parameters.AddWithValue("@rowUpdateTime", person.RowUpdateTime);
                conn.Open();

                person.PersonID = Convert.ToInt32(comm.ExecuteScalar());
                return person;

            }
        }
    }
}
