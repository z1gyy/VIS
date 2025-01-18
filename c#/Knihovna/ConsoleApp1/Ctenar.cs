using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Ctenar : ActiveRecord
    {
        public int Id_ctenar { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public string Vek { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Je_student { get; set; }
        public string Mesto { get; set; }
        public string Ulice { get; set; }
        public string Cp { get; set; }
        public string Psc { get; set; }
        public string Poznamka { get; set; }

        public Ctenar() { }

        public Ctenar(int idCtenar, string jmeno, string prijmeni, string vek, string telefon, string email,
              string jeStudent, string mesto, string ulice, string cp, string psc, string poznamka)
        {
            Id_ctenar = idCtenar;
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            Vek = vek;
            Telefon = telefon;
            Email = email;
            Je_student = jeStudent;
            Mesto = mesto;
            Ulice = ulice;
            Cp = cp;
            Psc = psc;
            Poznamka = poznamka;
        }

        public override bool Save()
        {
            using (var connection = GetConnection())
            {
                var command = new SQLiteCommand("INSERT INTO ctenar (id_ctenar, jmeno, prijmeni, vek, telefon, email, je_student, mesto, ulice, cp, psc, poznamka) VALUES (@Id, @Jmeno, @Prijmeni, @Vek, @Telefon, @Email, @JeStudent, @Mesto, @Ulice, @Cp, @Psc, @Poznamka)", connection);
                command.Parameters.AddWithValue("@Id", Id_ctenar);
                command.Parameters.AddWithValue("@Jmeno", Jmeno);
                command.Parameters.AddWithValue("@Prijmeni", Prijmeni);
                command.Parameters.AddWithValue("@Vek", Vek);
                command.Parameters.AddWithValue("@Telefon", Telefon);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@JeStudent", Je_student);
                command.Parameters.AddWithValue("@Mesto", Mesto);
                command.Parameters.AddWithValue("@Ulice", Ulice);
                command.Parameters.AddWithValue("@Cp", Cp);
                command.Parameters.AddWithValue("@Psc", Psc);
                command.Parameters.AddWithValue("@Poznamka", Poznamka);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public override bool Update()
        {
            using (var connection = GetConnection())
            {
                var command = new SQLiteCommand("UPDATE ctenar SET jmeno = @Jmeno, prijmeni = @Prijmeni, vek = @Vek, telefon = @Telefon, je_student = @JeStudent, mesto = @Mesto, ulice = @Ulice, cp = @Cp, psc = @Psc, poznamka = @Poznamka WHERE id_ctenar = @Id", connection);
                command.Parameters.AddWithValue("@Id", Id_ctenar);
                command.Parameters.AddWithValue("@Jmeno", Jmeno);
                command.Parameters.AddWithValue("@Prijmeni", Prijmeni);
                command.Parameters.AddWithValue("@Vek", Vek);
                command.Parameters.AddWithValue("@Telefon", Telefon);
                command.Parameters.AddWithValue("@JeStudent", Je_student);
                command.Parameters.AddWithValue("@Mesto", Mesto);
                command.Parameters.AddWithValue("@Ulice", Ulice);
                command.Parameters.AddWithValue("@Cp", Cp);
                command.Parameters.AddWithValue("@Psc", Psc);
                command.Parameters.AddWithValue("@Poznamka", Poznamka);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public override bool Delete()
        {
            using (var connection = GetConnection())
            {
                var command = new SQLiteCommand("DELETE FROM ctenar WHERE id_ctenar = @Id", connection);
                command.Parameters.AddWithValue("@Id", Id_ctenar);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public static List<Ctenar> GetAll()
        {
            List<Ctenar> ctenari = new List<Ctenar>();

            try
            {
                using (var connection = ActiveRecord.GetConnection())
                {
                    connection.Open();

                    using (var command = new SQLiteCommand("SELECT * FROM Ctenar", connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ctenari.Add(new Ctenar
                                {
                                    Id_ctenar = Convert.ToInt32(reader["Id_ctenar"]),
                                    Jmeno = reader["Jmeno"].ToString(),
                                    Prijmeni = reader["Prijmeni"].ToString(),
                                    Vek = reader["Vek"].ToString(),
                                    Telefon = reader["Telefon"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    Je_student = reader["Je_student"].ToString(),
                                    Mesto = reader["Mesto"].ToString(),
                                    Ulice = reader["Ulice"].ToString(),
                                    Cp = reader["Cp"].ToString(),
                                    Psc = reader["Psc"].ToString(),
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

            return ctenari;
        }


        public int LoadReaderIdByEmail(string email)
        {
            using (var connection = GetConnection())
            {
                var command = new SQLiteCommand("SELECT Id_ctenar FROM Ctenar WHERE Email = @Email", connection);
                command.Parameters.AddWithValue("@Email", email);
                connection.Open();
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return reader.GetInt32(0);
                }
                else
                {
                    return -1; 
                }
            }
        }
    }
}
