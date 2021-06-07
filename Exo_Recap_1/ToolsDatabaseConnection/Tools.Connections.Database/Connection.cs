using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace Tools.Connections.Database
{
    public class Connection
    {
        private readonly DbProviderFactory _providerFactory;
        private readonly string _connectionString;

        public Connection(DbProviderFactory providerFactory, string connectionString)
        {
            _providerFactory = providerFactory;
            _connectionString = connectionString;
        }

        public int ExecuteNonQuery(Command command)
        {
            using (SqlConnection dbConnection = CreateConnection())
            {
                using (SqlCommand dbCommand = CreateCommand(command, dbConnection))
                {
                    dbConnection.Open();

                    return dbCommand.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<TResult> ExecuteReader<TResult>(Command command, Func<IDataRecord, TResult> selector)
        {
            using (SqlConnection dbConnection = CreateConnection())
            {
                using (SqlCommand dbCommand = CreateCommand(command, dbConnection))
                {
                    dbConnection.Open();

                    using(SqlDataReader dbDataReader = dbCommand.ExecuteReader())
                    {
                        while(dbDataReader.Read())
                        {
                            yield return selector(dbDataReader);
                        }
                    }
                }
            }
        }
        public object ExecuteScalar(Command command)
        {
            using (SqlConnection dbConnection = CreateConnection())
            {
                using (SqlCommand dbCommand = CreateCommand(command, dbConnection))
                {
                    dbConnection.Open();
                    object o = dbCommand.ExecuteNonQuery();
                    return o is DBNull ? null : o;
                }
            }
        }

        public DataTable GetDataTable(Command command)
        {
            using (SqlConnection dbConnection = CreateConnection())
            {
                using (SqlCommand dbCommand = CreateCommand(command, dbConnection))
                {
                    using (SqlDataAdapter dbDataAdapter = new SqlDataAdapter())
                    {
                        dbDataAdapter.SelectCommand = dbCommand;
                        DataTable dataTable = new DataTable();
                        dbDataAdapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }

        private SqlConnection CreateConnection()
        {
            SqlConnection dbConnection = new SqlConnection();
            dbConnection.ConnectionString = _connectionString;

            return dbConnection;
        }

        private SqlCommand CreateCommand(Command command, SqlConnection dbConnection)
        {
            SqlCommand dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = command.Query;

            if (command.IsStoredProcedure)
                dbCommand.CommandType = CommandType.StoredProcedure;

            foreach (KeyValuePair<string, object> kvp in command.Parameters)
            {
                SqlParameter dbParameter = new SqlParameter();
                dbParameter.ParameterName = kvp.Key;
                dbParameter.Value = kvp.Value;

                dbCommand.Parameters.Add(dbParameter);
            }

            return dbCommand;
        }
    }
}
