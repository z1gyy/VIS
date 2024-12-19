using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Kniha_Zanr : ActiveRecord
    {
        public int Zanr_id_zanru { get; set; }
        public int Kniha_isbn { get; set; }

        public override bool Save()
        {
            using (var connection = GetConnection())
            {
                var command = new SQLiteCommand("INSERT INTO kniha_zanr (zanr_id_zanru, kniha_isbn) VALUES (@ZanrId, @KnihaIsbn)", connection);
                command.Parameters.AddWithValue("@ZanrId", Zanr_id_zanru);
                command.Parameters.AddWithValue("@KnihaIsbn", Kniha_isbn);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public override bool Update()
        {
            using (var connection = GetConnection())
            {
                var command = new SQLiteCommand("UPDATE kniha_zanr SET kniha_isbn = @KnihaIsbn WHERE zanr_id_zanru = @ZanrId", connection);
                command.Parameters.AddWithValue("@ZanrId", Zanr_id_zanru);
                command.Parameters.AddWithValue("@KnihaIsbn", Kniha_isbn);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public override bool Delete()
        {
            using (var connection = GetConnection())
            {
                var command = new SQLiteCommand("DELETE FROM kniha_zanr WHERE zanr_id_zanru = @ZanrId AND kniha_isbn = @KnihaIsbn", connection);
                command.Parameters.AddWithValue("@ZanrId", Zanr_id_zanru);
                command.Parameters.AddWithValue("@KnihaIsbn", Kniha_isbn);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }
    }

}
