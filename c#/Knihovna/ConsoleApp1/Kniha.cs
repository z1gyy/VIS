using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Kniha : ActiveRecord
    {
        public int Isbn { get; set; }
        public string Nazev { get; set; }
        public string Pocet_stran { get; set; }
        public string Nakladatel { get; set; }
        public DateTime Datum_vydani { get; set; }
        public string Je_bestseller { get; set; }
        public string Poznamka { get; set; }

        public override bool Save()
        {
            using (var connection = GetConnection())
            {
                var command = new SQLiteCommand("INSERT INTO kniha (isbn, nazev, pocet_stran, nakladatel, datum_vydani, je_bestseller, poznamka) VALUES (@Isbn, @Nazev, @PocetStran, @Nakladatel, @DatumVydani, @JeBestseller, @Poznamka)", connection);
                command.Parameters.AddWithValue("@Isbn", Isbn);
                command.Parameters.AddWithValue("@Nazev", Nazev);
                command.Parameters.AddWithValue("@PocetStran", Pocet_stran);
                command.Parameters.AddWithValue("@Nakladatel", Nakladatel);
                command.Parameters.AddWithValue("@DatumVydani", Datum_vydani);
                command.Parameters.AddWithValue("@JeBestseller", Je_bestseller);
                command.Parameters.AddWithValue("@Poznamka", Poznamka);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public override bool Update()
        {
            using (var connection = GetConnection())
            {
                var command = new SQLiteCommand("UPDATE kniha SET nazev = @Nazev, pocet_stran = @PocetStran, nakladatel = @Nakladatel, datum_vydani = @DatumVydani, je_bestseller = @JeBestseller, poznamka = @Poznamka WHERE isbn = @Isbn", connection);
                command.Parameters.AddWithValue("@Isbn", Isbn);
                command.Parameters.AddWithValue("@Nazev", Nazev);
                command.Parameters.AddWithValue("@PocetStran", Pocet_stran);
                command.Parameters.AddWithValue("@Nakladatel", Nakladatel);
                command.Parameters.AddWithValue("@DatumVydani", Datum_vydani);
                command.Parameters.AddWithValue("@JeBestseller", Je_bestseller);
                command.Parameters.AddWithValue("@Poznamka", Poznamka);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public override bool Delete()
        {
            using (var connection = GetConnection())
            {
                var command = new SQLiteCommand("DELETE FROM kniha WHERE isbn = @Isbn", connection);
                command.Parameters.AddWithValue("@Isbn", Isbn);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }
    }

}
