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
    }
}
