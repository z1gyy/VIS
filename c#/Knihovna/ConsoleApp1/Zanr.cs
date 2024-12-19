using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Zanr : ActiveRecord
    {
        public int Id_zanru { get; set; }
        public string Nazev { get; set; }

        public override bool Save()
        {
            using (var connection = GetConnection())
            {
                var command = new SQLiteCommand("INSERT INTO zanr (id_zanru, nazev) VALUES (@Id, @Nazev)", connection);
                command.Parameters.AddWithValue("@Id", Id_zanru);
                command.Parameters.AddWithValue("@Nazev", Nazev);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public override bool Update()
        {
            using (var connection = GetConnection())
            {
                var command = new SQLiteCommand("UPDATE zanr SET nazev = @Nazev WHERE id_zanru = @Id", connection);
                command.Parameters.AddWithValue("@Id", Id_zanru);
                command.Parameters.AddWithValue("@Nazev", Nazev);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public override bool Delete()
        {
            using (var connection = GetConnection())
            {
                var command = new SQLiteCommand("DELETE FROM zanr WHERE id_zanru = @Id", connection);
                command.Parameters.AddWithValue("@Id", Id_zanru);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }
    }

}
