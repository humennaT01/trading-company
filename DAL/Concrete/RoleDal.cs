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
    public class RoleDal : IRoleDal
    {
        private string connectionString;

        public RoleDal(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public RoleDTO CreateRole(RoleDTO role)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into Role (Role, RowInsertTime) output INSERTED.RoleID values (@roleName, @rowInsertTime)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@roleName", role.RoleName);
                comm.Parameters.AddWithValue("@year", role.RowInsertTime);
                conn.Open();

                role.RoleID = Convert.ToInt32(comm.ExecuteScalar());
                return role;
            }
        }

        public void DeleteRole(int id)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from Role where RoleID = @id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@id", id);
                conn.Open();

                comm.ExecuteNonQuery();
            }
        }

        public List<RoleDTO> GetAllRole()
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from Role";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<RoleDTO> role = new List<RoleDTO>();
                while (reader.Read())
                {
                    role.Add(new RoleDTO
                    {
                        RoleID = (int)reader["RoleID"],
                        RoleName = reader["RoleName"].ToString(),
                        RowInsertTime = (DateTime)reader["RowInsertTime"]
                    });
                }

                return role;
            }
        }

        public RoleDTO GetRoleById(int id)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                RoleDTO role = new RoleDTO();
                comm.CommandText = $"select * from Role where RoleID = {id}";
                SqlDataReader reader = comm.ExecuteReader();
                while(reader.Read()){
                    role = new RoleDTO
                    {
                        RoleID = Convert.ToInt32(reader["RoleID"]),
                        RoleName = reader["RoleName"].ToString(),
                        RowInsertTime = (DateTime)reader["RowInsertTime"]
                    };
                }
                return role;
            }
        }

        public RoleDTO UpdateRole(RoleDTO role)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "update User set RoleName = @roleName, RowInsertTime = @rowInsertTime";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@roleName", role.RoleName);
                comm.Parameters.AddWithValue("@rowInsertTime", role.RowInsertTime);
                conn.Open();
                role.RoleID = Convert.ToInt32(comm.ExecuteScalar());
                return role;
            }

        }
    }
}

