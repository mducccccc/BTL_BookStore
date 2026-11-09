using System;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

namespace BTL.DAL
{
    public static class DatabaseHelper
    {
        private const string ConnectionStringName = "QLChoThueSach";
        private static string _connectionString;

        static DatabaseHelper()
        {
            try
            {
                var connStr = ConfigurationManager.ConnectionStrings[ConnectionStringName]?.ConnectionString;
                if (!string.IsNullOrWhiteSpace(connStr))
                {
                    _connectionString = connStr;
                }
                else
                {
                    // Fallback mặc định nếu chưa cấu hình trong App.config
                    _connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QLChoThueSach;Integrated Security=True;TrustServerCertificate=True;";
                }
            }
            catch
            {
                _connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QLChoThueSach;Integrated Security=True;TrustServerCertificate=True;";
            }
        }

        public static string ConnectionString
        {
            get => _connectionString;
            set => _connectionString = value;
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public static bool TestConnection(out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                using var conn = GetConnection();
                conn.Open();
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public static DataTable ExecuteQuery(string query, SqlParameter[]? parameters = null, CommandType commandType = CommandType.Text)
        {
            var dt = new DataTable();
            using var conn = GetConnection();
            using var cmd = new SqlCommand(query, conn);
            cmd.CommandType = commandType;

            if (parameters != null && parameters.Length > 0)
            {
                cmd.Parameters.AddRange(parameters);
            }

            using var da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static int ExecuteNonQuery(string query, SqlParameter[]? parameters = null, CommandType commandType = CommandType.Text)
        {
            using var conn = GetConnection();
            using var cmd = new SqlCommand(query, conn);
            cmd.CommandType = commandType;

            if (parameters != null && parameters.Length > 0)
            {
                cmd.Parameters.AddRange(parameters);
            }

            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public static object? ExecuteScalar(string query, SqlParameter[]? parameters = null, CommandType commandType = CommandType.Text)
        {
            using var conn = GetConnection();
            using var cmd = new SqlCommand(query, conn);
            cmd.CommandType = commandType;

            if (parameters != null && parameters.Length > 0)
            {
                cmd.Parameters.AddRange(parameters);
            }

            conn.Open();
            return cmd.ExecuteScalar();
        }

        public static DataTable ExecuteStoredProcedure(string spName, SqlParameter[]? parameters = null)
        {
            return ExecuteQuery(spName, parameters, CommandType.StoredProcedure);
        }

        public static int ExecuteStoredProcedureNonQuery(string spName, SqlParameter[]? parameters = null)
        {
            return ExecuteNonQuery(spName, parameters, CommandType.StoredProcedure);
        }
    }
}
