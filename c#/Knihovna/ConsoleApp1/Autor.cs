using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Autor : ActiveRecord
    {
        public int id_autora { get; set; }
        public string jmeno { get; set; }
        public string prijmeni { get; set; }

        public override bool Save()
        {
            using (var connection = GetConnection())
            {
                var command = new SQLiteCommand("INSERT INTO autor (id_autora, jmeno, prijmeni) VALUES (@id, @jmeno, @prijmeni)", connection);
                command.Parameters.AddWithValue("@id", id_autora);
                command.Parameters.AddWithValue("@jmeno", jmeno);
                command.Parameters.AddWithValue("@prijmeni", prijmeni);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public override bool Update()
        {
            using (var connection = GetConnection())
            {
                var command = new SQLiteCommand("UPDATE autor SET jmeno = @Jmeno, prijmeni = @Prijmeni WHERE id_autora = @Id", connection);
                command.Parameters.AddWithValue("@Id", id_autora);
                command.Parameters.AddWithValue("@Jmeno", jmeno);
                command.Parameters.AddWithValue("@Prijmeni", prijmeni);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public override bool Delete()
        {
            using (var connection = GetConnection())
            {
                var command = new SQLiteCommand("DELETE FROM autor WHERE id_autora = @Id", connection);
                command.Parameters.AddWithValue("@Id", id_autora);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }
    }

}
