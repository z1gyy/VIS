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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
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
                // Vytvoření nového objektu Kniha
                var kniha = new Kniha(int.Parse(isbn), nazev, pocetStran, nakladatel, datumVydani.ToString("yyyy-MM-dd"), jeBestseller == 1 ? "1" : "0", poznamka);

                if (kniha.Update())
                {
                    MessageBox.Show("Kniha byla úspěšně aktualizována.");
                }
                else
                {
                    MessageBox.Show("Chyba při aktualizování knihy.");
                }
            }
            catch (Exception ex)
            {
                // Ošetření chyb
                MessageBox.Show("Chyba při aktualizování knihy v databáze: " + ex.Message);
            }

        }
    }
}
