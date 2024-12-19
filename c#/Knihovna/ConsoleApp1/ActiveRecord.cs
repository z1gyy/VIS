using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace ConsoleApp1
{
    public abstract class ActiveRecord
    {
        protected static readonly string ConnectionString = "Data Source=C:\\Users\\Žigy-san\\Desktop\\vis\\dbs\\dbs.db;Version=3;";

        public abstract bool Save();
        public abstract bool Delete();
        public abstract bool Update();

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(ConnectionString);
        }
    }
}
