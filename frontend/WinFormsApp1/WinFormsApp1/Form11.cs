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
            // Získání hodnot z textových polí
            string idCtenarText = textBox1.Text;        // ID čtenáře (jako text, konvertujeme na číslo)
            string jmeno = textBox2.Text;              // Jméno
            string prijmeni = textBox3.Text;           // Příjmení
            string vek = textBox4.Text;            // Věk (jako text, konvertujeme na číslo)
            string telefon = textBox5.Text;            // Telefon
            string email = textBox6.Text;              // Email
            string jeStudent = textBox7.Text;      // Je student (očekáváme "1" nebo "0")
            string mesto = textBox8.Text;              // Město
            string ulice = textBox9.Text;              // Ulice
            string cp = textBox10.Text;            // Číslo popisné (jako text, konvertujeme na číslo)
            string psc = textBox11.Text;           // PSČ (jako text, konvertujeme na číslo)
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

            if (string.IsNullOrWhiteSpace(vek))
            {
                MessageBox.Show("Věk je povinný.");
                return;
            }


            try
            {
                var ctenar = new Ctenar(idCtenar, jmeno, prijmeni, vek, telefon, email, jeStudent, mesto, ulice, cp, psc, poznamka);

                if (ctenar.Update())
                {
                    MessageBox.Show("Čtenář byl úspěšně aktualizován.");
                }
                else
                {
                    MessageBox.Show("Chyba při aktualizování čtenáře.");
                }
            }
            catch (Exception ex)
            {
                // Ošetření chyb
                MessageBox.Show("Chyba při aktualizování čtenáře v databáze: " + ex.Message);
            }


        }
    }
}
