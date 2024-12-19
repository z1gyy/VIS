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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Získání hodnot z textových polí
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

                    // SQL příkaz pro vytvoření nového záznamu v tabulce Ctenar
                    string query = @"
        INSERT INTO Ctenar 
        (ID_Ctenar, Jmeno, Prijmeni, Vek, Telefon, Email, Je_Student, Mesto, Ulice, CP, PSC, Poznamka)
        VALUES 
        (@ID_Ctenar, @Jmeno, @Prijmeni, @Vek, @Telefon, @Email, @Je_Student, @Mesto, @Ulice, @CP, @PSC, @Poznamka)";

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
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Čtenář byl úspěšně přidán do databáze.");
            }
            catch (Exception ex)
            {
                // Ošetření chyb
                MessageBox.Show("Chyba při přidávání čtenáře do databáze: " + ex.Message);
            }

        }
    }
}
