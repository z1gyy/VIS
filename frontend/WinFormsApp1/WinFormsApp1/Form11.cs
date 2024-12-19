using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string idCtenarText = textBox1.Text;        // ID čtenáře (jako text, konvertujeme na číslo)
            string jmeno = textBox2.Text;              // Jméno
            string prijmeni = textBox3.Text;           // Příjmení
            string vekText = textBox4.Text;            // Věk (jako text, konvertujeme na číslo)
            string telefon = textBox5.Text;            // Telefon
            string email = textBox6.Text;              // Email
            string jeStudentText = textBox7.Text;      // Je student (očekáváme "1" nebo "0")
            string mesto = textBox8.Text;              // Město
            string ulice = textBox9.Text;              // Ulice
            string cpText = textBox10.Text;            // Číslo popisné (jako text, konvertujeme na číslo)
            string pscText = textBox11.Text;           // PSČ (jako text, konvertujeme na číslo)
            string poznamka = textBox12.Text;          // Poznámka

            // Validace vstupů
            if (string.IsNullOrWhiteSpace(jmeno) || string.IsNullOrWhiteSpace(prijmeni))
            {
                MessageBox.Show("Jméno a příjmení jsou povinné.");
                return;
            }

            if (!int.TryParse(idCtenarText, out int idCtenar))
            {
                MessageBox.Show("ID čtenáře musí být číslo.");
                return;
            }

            if (!int.TryParse(vekText, out int vek))
            {
                MessageBox.Show("Věk musí být číslo.");
                return;
            }

            if (!int.TryParse(jeStudentText, out int jeStudent))
            {
                MessageBox.Show("Hodnota 'je student' musí být '1' nebo '0'.");
                return;
            }

            if (!int.TryParse(cpText, out int cp))
            {
                MessageBox.Show("Číslo popisné musí být číslo.");
                return;
            }

            if (!int.TryParse(pscText, out int psc))
            {
                MessageBox.Show("PSČ musí být číslo.");
                return;
            }

            try
            {
                // Použití ActiveRecord pro získání připojení
                using (var connection = ActiveRecord.GetConnection())
                {
                    connection.Open();

                    // SQL příkaz pro aktualizaci záznamu v tabulce Ctenar
                    string query = @"
                UPDATE Ctenar
                SET 
                    Jmeno = @Jmeno,
                    Prijmeni = @Prijmeni,
                    Vek = @Vek,
                    Telefon = @Telefon,
                    Email = @Email,
                    Je_Student = @Je_Student,
                    Mesto = @Mesto,
                    Ulice = @Ulice,
                    CP = @CP,
                    PSC = @PSC,
                    Poznamka = @Poznamka
                WHERE ID_Ctenar = @ID_Ctenar";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        // Přiřazení parametrů
                        command.Parameters.AddWithValue("@ID_Ctenar", idCtenar);
                        command.Parameters.AddWithValue("@Jmeno", jmeno);
                        command.Parameters.AddWithValue("@Prijmeni", prijmeni);
                        command.Parameters.AddWithValue("@Vek", vek);
                        command.Parameters.AddWithValue("@Telefon", telefon);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Je_Student", jeStudent);
                        command.Parameters.AddWithValue("@Mesto", mesto);
                        command.Parameters.AddWithValue("@Ulice", ulice);
                        command.Parameters.AddWithValue("@CP", cp);
                        command.Parameters.AddWithValue("@PSC", psc);
                        command.Parameters.AddWithValue("@Poznamka", poznamka);

                        // Provedení příkazu
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Čtenář s ID {idCtenar} byl úspěšně aktualizován.");
                        }
                        else
                        {
                            MessageBox.Show($"Čtenář s ID {idCtenar} nebyl nalezen.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Ošetření chyb
                MessageBox.Show("Chyba při aktualizaci čtenáře v databázi: " + ex.Message);
            }

        }
    }
}
