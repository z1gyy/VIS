using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Vypujcka : ActiveRecord
    {
        public int Id_vypujcka { get; set; }
        public string Datum_pujceni { get; set; }
        public string Datum_vraceni { get; set; }
        public string? Datum_skutecneho_vraceni { get; set; }
        public int Ctenar_id_ctenar { get; set; }
        public int Exemplar_id_exemplare { get; set; }

        public Vypujcka() { }
        public Vypujcka(int id_vypujcka, string datum_pujceni, string datum_vraceni, string? datum_skutecneho_vraceni, int ctenar_id_ctenar, int exemplar_id_exemplare)
        {
            Id_vypujcka = id_vypujcka;
            Datum_pujceni = datum_pujceni;
            Datum_vraceni = datum_vraceni;
            Datum_skutecneho_vraceni = datum_skutecneho_vraceni;
            Ctenar_id_ctenar = ctenar_id_ctenar;
            Exemplar_id_exemplare = exemplar_id_exemplare;
        }

        public override bool Save()
        {
            using (var connection = GetConnection())
            {
                var command = new SQLiteCommand("INSERT INTO vypujcka (id_vypujcka, datum_pujceni, datum_vraceni, datum_skutecneho_vraceni, ctenar_id_ctenar, exemplar_id_exemplare) VALUES (@Id, @DatumPujceni, @DatumVraceni, @DatumSkutecnehoVraceni, @CtenarId, @ExemplarId)", connection);
                command.Parameters.AddWithValue("@Id", Id_vypujcka);
                command.Parameters.AddWithValue("@DatumPujceni", Datum_pujceni);
                command.Parameters.AddWithValue("@DatumVraceni", Datum_vraceni);
                command.Parameters.AddWithValue("@DatumSkutecnehoVraceni", Datum_skutecneho_vraceni ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@CtenarId", Ctenar_id_ctenar);
                command.Parameters.AddWithValue("@ExemplarId", Exemplar_id_exemplare);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public override bool Update()
        {
            using (var connection = GetConnection())
            {
                var command = new SQLiteCommand("UPDATE vypujcka SET datum_pujceni = @DatumPujceni, datum_vraceni = @DatumVraceni, datum_skutecneho_vraceni = @DatumSkutecnehoVraceni, ctenar_id_ctenar = @CtenarId, exemplar_id_exemplare = @ExemplarId WHERE id_vypujcka = @Id", connection);
                command.Parameters.AddWithValue("@Id", Id_vypujcka);
                command.Parameters.AddWithValue("@DatumPujceni", Datum_pujceni);
                command.Parameters.AddWithValue("@DatumVraceni", Datum_vraceni);
                command.Parameters.AddWithValue("@DatumSkutecnehoVraceni", Datum_skutecneho_vraceni ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@CtenarId", Ctenar_id_ctenar);
                command.Parameters.AddWithValue("@ExemplarId", Exemplar_id_exemplare);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public override bool Delete()
        {
            using (var connection = GetConnection())
            {
                var command = new SQLiteCommand("DELETE FROM vypujcka WHERE id_vypujcka = @Id", connection);
                command.Parameters.AddWithValue("@Id", Id_vypujcka);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public static List<Vypujcka> GetAll()
        {
            List<Vypujcka> vypujcky = new List<Vypujcka>();

            try
            {
                using (var connection = ActiveRecord.GetConnection())
                {
                    connection.Open();

                    using (var command = new SQLiteCommand("SELECT id_vypujcka, datum_pujceni, datum_vraceni, datum_skutecneho_vraceni, ctenar_id_ctenar, exemplar_id_exemplare FROM Vypujcka", connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                vypujcky.Add(new Vypujcka
                                {
                                    Id_vypujcka = Convert.ToInt32(reader["id_vypujcka"]),
                                    Datum_pujceni = reader["datum_pujceni"].ToString(),
                                    Datum_vraceni = reader["datum_vraceni"].ToString(),
                                    Datum_skutecneho_vraceni = reader["datum_skutecneho_vraceni"] as string, 
                                    Ctenar_id_ctenar = Convert.ToInt32(reader["ctenar_id_ctenar"]),
                                    Exemplar_id_exemplare = Convert.ToInt32(reader["exemplar_id_exemplare"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Chyba při načítání výpůjček: {ex.Message}");
            }

            return vypujcky;
        }


        public List<Vypujcka> VypujckaById(int id_ctenar)
        {
            List<Vypujcka> vypujcky = new List<Vypujcka>();

            try
            {
                using (var connection = ActiveRecord.GetConnection())
                {
                    // SQL dotaz pro načtení výpůjček s parametrizací
                    var command = new SQLiteCommand("SELECT id_vypujcka, datum_pujceni, datum_vraceni " +
                                                    "FROM Vypujcka " +
                                                    "WHERE Ctenar_id_ctenar = @IdCtenare;", connection);

                    // Přidání parametru
                    command.Parameters.AddWithValue("@IdCtenare", id_ctenar);

                    connection.Open();
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        // Vytvoření objektu výpůjčky a naplnění daty
                        Vypujcka vypujcka = new Vypujcka
                        {
                            Id_vypujcka = Convert.ToInt32(reader["id_vypujcka"]),
                            Datum_pujceni = reader["datum_pujceni"].ToString(),
                            Datum_vraceni = reader["datum_vraceni"].ToString()
                        };

                        // Přidání výpůjčky do seznamu
                        vypujcky.Add(vypujcka);
                        // Výpis informací o výpůjčce do konzole
                        Console.WriteLine($"Id výpůjčky: {vypujcka.Id_vypujcka}");
                        Console.WriteLine($"Datum půjčení: {vypujcka.Datum_pujceni}");
                        Console.WriteLine($"Datum vrácení: {vypujcka.Datum_vraceni}");
                        Console.WriteLine("------------------------------------------------");
                    }
                }
            }
            catch (Exception ex)
            {
                // V případě chyby logování nebo zpracování
                Console.WriteLine("Chyba při načítání výpůjček: " + ex.Message);
            }

            return vypujcky;
        }
        
    }
}
