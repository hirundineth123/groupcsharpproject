using StudentManagementSystem.Core.Exceptions;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace StudentManagementSystem.Core.Data
{
    public static class DatabaseHelper
    {
        private static string GetConnectionString()
        {
            if (ConfigurationManager.ConnectionStrings["StudentDB"] != null &&
                !string.IsNullOrWhiteSpace(ConfigurationManager.ConnectionStrings["StudentDB"].ConnectionString))
            {
                return ConfigurationManager.ConnectionStrings["StudentDB"].ConnectionString;
            }

            // Fallback default for LocalDB
            return @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentDB;Integrated Security=True;";
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }

        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            try
            {
                using (var conn = GetConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DatabaseException("Failed to execute database query.", ex);
            }
        }

        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            try
            {
                using (var conn = GetConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new DatabaseException("Failed to execute database command.", ex);
            }
        }

        public static object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            try
            {
                using (var conn = GetConnection())
                using (var cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
            catch (SqlException ex)
            {
                throw new DatabaseException("Failed to execute database scalar query.", ex);
            }
        }
    }
}
