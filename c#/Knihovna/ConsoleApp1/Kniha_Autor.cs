using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Kniha_Autor : ActiveRecord
    {
        public int Autor_id_autora { get; set; }
        public int Kniha_isbn { get; set; }

        public override bool Save()
        {
            using (var connection = GetConnection())
            {
                var command = new SQLiteCommand("INSERT INTO kniha_autor (autor_id_autora, kniha_isbn) VALUES (@AutorId, @KnihaIsbn)", connection);
                command.Parameters.AddWithValue("@AutorId", Autor_id_autora);
                command.Parameters.AddWithValue("@KnihaIsbn", Kniha_isbn);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public override bool Update()
        {
            using (var connection = GetConnection())
            {
                var command = new SQLiteCommand("UPDATE kniha_autor SET kniha_isbn = @KnihaIsbn WHERE autor_id_autora = @AutorId", connection);
                command.Parameters.AddWithValue("@AutorId", Autor_id_autora);
                command.Parameters.AddWithValue("@KnihaIsbn", Kniha_isbn);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public override bool Delete()
        {
            using (var connection = GetConnection())
            {
                var command = new SQLiteCommand("DELETE FROM kniha_autor WHERE autor_id_autora = @AutorId AND kniha_isbn = @KnihaIsbn", connection);
                command.Parameters.AddWithValue("@AutorId", Autor_id_autora);
                command.Parameters.AddWithValue("@KnihaIsbn", Kniha_isbn);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}
