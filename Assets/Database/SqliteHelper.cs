using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;

namespace Assets.Database
{
    public class SqliteHelper
    {
        private const string Tag = "SqliteHelper:\t";

        private const string DatabaseName = "GamesDb.db";

        public string DbConnectionString;
        public IDbConnection DbConnection;

        public SqliteHelper()
        {
            DbConnectionString = "URI=file:" + Application.persistentDataPath + "/" + DatabaseName;
            Debug.Log("db_connection_string" + DbConnectionString);
            DbConnection = new SqliteConnection(DbConnectionString);
            DbConnection.Open();
        }

        ~SqliteHelper()
        {
            DbConnection.Close();
        }

        // virtual functions
        public virtual IDataReader GetDataById(string tableName, string columnName, int id)
        {
            Debug.Log(Tag + "This function is not implemented");
            throw null;
        }

        public virtual IDataReader GetDataByString(string tableName, string columnName, string str)
        {
            Debug.Log(Tag + "This function is not implemented");
            throw null;
        }

        public virtual void DeleteDataById(string tableName, string columnName, int id)
        {
            Debug.Log(Tag + "This function is not implemented");
            throw null;
        }

        public virtual void DeleteDataByString(string tableName, string columnName, string str)
        {
            Debug.Log(Tag + "This function is not implemented");
            throw null;
        }

        public virtual IDataReader GetAllData()
        {
            Debug.Log(Tag + "This function is not implemented");
            throw null;
        }

        public virtual void DeleteAllData()
        {
            Debug.Log(Tag + "This function is not implemented");
            throw null;
        }

        public virtual IDataReader GetNumOfRows()
        {
            Debug.Log(Tag + "This function is not implemented");
            throw null;
        }

        //helper functions
        public IDbCommand GetDbCommand()
        {
            return DbConnection.CreateCommand();
        }

        public IDataReader GetAllData(string tableName)
        {
            IDbCommand dbcmd = DbConnection.CreateCommand();
            dbcmd.CommandText =
                "SELECT * FROM " + tableName;
            IDataReader reader = dbcmd.ExecuteReader();
            return reader;
        }

        public void DeleteAllData(string tableName)
        {
            IDbCommand dbcmd = DbConnection.CreateCommand();
            dbcmd.CommandText = "DROP TABLE IF EXISTS " + tableName;
            dbcmd.ExecuteNonQuery();
        }

        public IDataReader GetNumOfRows(string tableName)
        {
            IDbCommand dbcmd = DbConnection.CreateCommand();
            dbcmd.CommandText =
                "SELECT COALESCE(MAX(id)+1, 0) FROM " + tableName;
            IDataReader reader = dbcmd.ExecuteReader();
            return reader;
        }

        public void Close()
        {
            DbConnection.Close();
        }
    }
}