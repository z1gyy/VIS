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
        public int Pocet_stran { get; set; }
        public string Nakladatel { get; set; }
        public string Datum_vydani { get; set; }
        public string Je_bestseller { get; set; }
        public string Poznamka { get; set; }

        public Kniha() { }

        public Kniha(int isbn, string nazev, int pocetStran, string nakladatel, string datumVydani, string jeBestseller, string poznamka)
        {
            Isbn = isbn;
            Nazev = nazev;
            Pocet_stran = pocetStran;
            Nakladatel = nakladatel;
            Datum_vydani = datumVydani;
            Je_bestseller = jeBestseller;
            Poznamka = poznamka;
        }

        public static List<Kniha> GetAll()
        {
            List<Kniha> knihy = new List<Kniha>();

            try
            {
                using (var connection = ActiveRecord.GetConnection())
                {
                    connection.Open();

                    using (var command = new SQLiteCommand("SELECT * FROM Kniha", connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                knihy.Add(new Kniha
                                {
                                    Isbn = Convert.ToInt32(reader["Isbn"]),
                                    Nazev = reader["Nazev"].ToString(),
                                    Pocet_stran = Convert.ToInt32(reader["Pocet_stran"]),
                                    Nakladatel = reader["Nakladatel"].ToString(),
                                    Datum_vydani = reader["Datum_vydani"].ToString(),
                                    Je_bestseller = reader["Je_bestseller"].ToString(),
                                    Poznamka = reader["Poznamka"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Chyba při načítání dat: {ex.Message}");
            }

            return knihy;
        }


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
