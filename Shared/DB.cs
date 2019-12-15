using System;
using System.Collections.Generic;
using System.IO;
using Mono.Data.Sqlite;

namespace Shared
{
    public class DB
    {
        string tableName;
        SqliteConnection connection;

        public DB(string fileName, string tableName)
        {
            this.tableName = tableName;
            this.connection = new SqliteConnection($"data source={fileName}.db3");

            if (File.Exists($"./{fileName}.db3") == false)
            {
                SqliteConnection.CreateFile($"{fileName}.db3");

                connection.Open();
                SqliteCommand command = new SqliteCommand(connection);
                command.CommandText = $"CREATE TABLE IF NOT EXISTS [{tableName}] ( [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [Key] NVARCHAR(2048)  NULL, [Value] VARCHAR(2048)  NULL )";
                command.ExecuteNonQuery();
                connection.Close();
                Console.WriteLine("database created");
            }
        }


        public Dictionary<DateTime, int> GetAllDataFromDB()
        {
            Dictionary<DateTime, int> result = new Dictionary<DateTime, int>();

            connection.Open();

            SqliteCommand command = new SqliteCommand(connection);

            command.CommandText = $"Select * FROM {tableName}";
            SqliteDataReader reader = command.ExecuteReader();

            foreach (var i in reader)
            {
                var bla = reader.VisibleFieldCount;
                result.Add(DateTime.Parse(reader["Key"].ToString()), Int32.Parse(reader["Value"].ToString()));
            }

            connection.Close();

            return result;
        }


        public void InsertRowIntoDB(string key, string value)
        {
            connection.Open();

            SqliteCommand command = new SqliteCommand(connection);
            command.CommandText = $"INSERT INTO {tableName} (Key,Value) Values ('{key}','{value}')";
            command.ExecuteNonQuery(); // Execute the query

            connection.Close();
        }

    }
}
