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
    public class UserDal :IUserDal
    {
        private string connectionString;

        public UserDal(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public UserDTO CreateUser(UserDTO user)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into User (Login, Email, Password, Status, PersonID, RoleID, RowInsertTime, RowUpdateTime) output INSERTED.UserID values (@login, @email, @password, @status, @personId, @roleId, @rowInsertTime, @rowUpdateTime)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@login", user.Login);
                comm.Parameters.AddWithValue("@email", user.Email);
                comm.Parameters.AddWithValue("@password", user.Password);
                comm.Parameters.AddWithValue("@status", user.Status);
                comm.Parameters.AddWithValue("@personId", user.PersonID);
                comm.Parameters.AddWithValue("@roleId", user.RoleID);
                comm.Parameters.AddWithValue("@rowInsertTime", user.RowInsertTime);
                comm.Parameters.AddWithValue("@rowUpdateTime", user.RowUpdateTime);
                conn.Open();

                user.UserID = Convert.ToInt32(comm.ExecuteScalar());
                return user;
            }
        }

        public void DeleteUser(int id)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from User where UserID = @id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@id", id);
                conn.Open();

                comm.ExecuteNonQuery();
            }
        }

        public List<UserDTO> GetAllUser()
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from User";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<UserDTO> user = new List<UserDTO>();
                while (reader.Read())
                {
                    user.Add(new UserDTO
                    {
                        UserID = (int)reader["UserID"],
                        Login = reader["Login"].ToString(),
                        Email = reader["Email"].ToString(),
                        Password = (byte[])reader["Password"],
                        Status = (bool)reader["Status"],
                        PersonID = (int)reader["PersonID"],
                        RoleID = (int)reader["RoleID"],
                        RowInsertTime = (DateTime)reader["RowInsertTime"],
                        RowUpdateTime = (DateTime)reader["RowUpdateTime"]
                    });
                }
                return user;
            }
        }

        public UserDTO GetUserById(int id)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                UserDTO user = new UserDTO();
                comm.CommandText = $"select * from User where UserID = {id}";
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    user = new UserDTO
                    {
                        UserID = (int)reader["UserID"],
                        Login = reader["Login"].ToString(),
                        Email = reader["Email"].ToString(),
                        Status = (bool)reader["Status"],
                        Password = (byte[])reader["Password"],
                        PersonID = (int)reader["PersonID"],
                        RoleID = (int)reader["RoleID"],
                        RowInsertTime = (DateTime)reader["RowInsertTime"],
                        RowUpdateTime = (DateTime)reader["RowUpdateTime"]
                    };
                }
                return user;
            }
        }

        public bool Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public UserDTO UpdateUser(UserDTO user)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "update User set Login = @login, Email = @email, Password = @password, Status = @status, PersonID = @personID, RoleID = @roleID, RowInsertTime = @rowInsertTime, RowUpdateTime = @rowUpdateTime";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@login", user.Login);
                comm.Parameters.AddWithValue("@email", user.Email);
                comm.Parameters.AddWithValue("@password", user.Password);
                comm.Parameters.AddWithValue("@status", user.Status);
                comm.Parameters.AddWithValue("@personID", user.PersonID);
                comm.Parameters.AddWithValue("@roleID", user.RoleID);
                comm.Parameters.AddWithValue("@rowInsertTime", user.RowInsertTime);
                comm.Parameters.AddWithValue("@rowUpdateTime", user.RowUpdateTime);
                conn.Open();
                user.UserID = Convert.ToInt32(comm.ExecuteScalar());
                return user;
            }
        }
    }
}