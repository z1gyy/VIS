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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Získání hodnot z textových polí
            string isbn = textBox1.Text;              // ISBN
            string nazev = textBox2.Text;             // Název
            string pocetStranText = textBox3.Text;    // Počet stran (jako text, konvertujeme na číslo)
            string nakladatel = textBox4.Text;        // Nakladatel
            string datumVydaniText = textBox5.Text;   // Datum vydání (jako text, konvertujeme na datum)
            string jeBestsellerText = textBox6.Text;  // Bestseller (očekáváme "1" nebo "0")
            string poznamka = textBox7.Text;          // Poznámka

            // Validace vstupů
            if (string.IsNullOrWhiteSpace(isbn) || string.IsNullOrWhiteSpace(nazev))
            {
                MessageBox.Show("ISBN a název knihy jsou povinné.");
                return;
            }

            if (!int.TryParse(pocetStranText, out int pocetStran))
            {
                MessageBox.Show("Počet stran musí být číslo.");
                return;
            }

            if (!DateTime.TryParse(datumVydaniText, out DateTime datumVydani))
            {
                MessageBox.Show("Datum vydání musí být ve správném formátu (např. YYYY-MM-DD).");
                return;
            }

            if (!int.TryParse(jeBestsellerText, out int jeBestseller))
            {
                MessageBox.Show("Hodnota bestseller musí být '1' nebo '0'.");
                return;
            }

            try
            {
                // Použití ActiveRecord pro získání připojení
                using (var connection = ActiveRecord.GetConnection())
                {
                    connection.Open();

                    // SQL příkaz pro vytvoření nového záznamu v tabulce Kniha
                    string query = @"
                INSERT INTO Kniha (ISBN, Nazev, Pocet_Stran, Nakladatel, Datum_Vydani, Je_Bestseller, Poznamka)
                VALUES (@ISBN, @Nazev, @PocetStran, @Nakladatel, @DatumVydani, @JeBestseller, @Poznamka)";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        // Přiřazení parametrů
                        command.Parameters.AddWithValue("@ISBN", isbn);
                        command.Parameters.AddWithValue("@Nazev", nazev);
                        command.Parameters.AddWithValue("@PocetStran", pocetStran);
                        command.Parameters.AddWithValue("@Nakladatel", nakladatel);
                        command.Parameters.AddWithValue("@DatumVydani", datumVydani.ToString("yyyy-MM-dd")); // Formátování na SQL datum
                        command.Parameters.AddWithValue("@JeBestseller", jeBestseller);
                        command.Parameters.AddWithValue("@Poznamka", poznamka);

                        // Provedení příkazu
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Kniha byla úspěšně přidána do databáze.");
            }
            catch (Exception ex)
            {
                // Ošetření chyb
                MessageBox.Show("Chyba při přidávání knihy do databáze: " + ex.Message);
            }
        }

    }
}
