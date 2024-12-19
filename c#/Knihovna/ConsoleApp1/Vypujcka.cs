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
        public DateTime Datum_pujceni { get; set; }
        public DateTime Datum_vraceni { get; set; }
        public DateTime? Datum_skutecneho_vraceni { get; set; }
        public int Ctenar_id_ctenar { get; set; }
        public int Exemplar_id_exemplare { get; set; }

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
    }
}
