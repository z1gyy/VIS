using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Exemplar : ActiveRecord
    {
        public int Id_exemplare { get; set; }
        public int Kniha_isbn { get; set; }

        public override bool Save()
        {
            using (var connection = GetConnection())
            {
                var command = new SQLiteCommand("INSERT INTO exemplar (id_exemplare, kniha_isnb) VALUES (@Id, @KnihaIsbn)", connection);
                command.Parameters.AddWithValue("@Id", Id_exemplare);
                command.Parameters.AddWithValue("@KnihaIsbn", Kniha_isbn);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public override bool Update()
        {
            using (var connection = GetConnection())
            {
                var command = new SQLiteCommand("UPDATE exemplar SET kniha_isbn = @KnihaIsbn WHERE id_exemplare = @Id", connection);
                command.Parameters.AddWithValue("@Id", Id_exemplare);
                command.Parameters.AddWithValue("@KnihaIsbn", Kniha_isbn);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public override bool Delete()
        {
            using (var connection = GetConnection())
            {
                var command = new SQLiteCommand("DELETE FROM exemplar WHERE id_exemplare = @Id", connection);
                command.Parameters.AddWithValue("@Id", Id_exemplare);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}
