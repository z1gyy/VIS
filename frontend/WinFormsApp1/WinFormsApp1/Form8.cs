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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Získání hodnot z textových polí
            string id_vypujckaText = textBox1.Text;         // id_vypujcka (jako text, konvertujeme na číslo)
            string datum_pujceniText = textBox2.Text;       // datum_pujceni (jako text, konvertujeme na datum)
            string datum_vraceniText = textBox3.Text;       // datum_vraceni (jako text, konvertujeme na datum)
            string Ctenar_id_ctenarText = textBox4.Text;    // Ctenar_id_ctenar (jako text, konvertujeme na číslo)
            string Exemplar_id_exemplarText = textBox5.Text; // Exemplar_id_exemplar (jako text, konvertujeme na číslo)

            // Validace vstupů
            if (!int.TryParse(id_vypujckaText, out int id_vypujcka))
            {
                MessageBox.Show("id_vypujcka musí být číslo.");
                return;
            }

            if (!DateTime.TryParse(datum_pujceniText, out DateTime datum_pujceni))
            {
                MessageBox.Show("datum_pujceni musí být ve správném formátu (např. YYYY-MM-DD).");
                return;
            }

            if (!DateTime.TryParse(datum_vraceniText, out DateTime datum_vraceni))
            {
                MessageBox.Show("datum_vraceni musí být ve správném formátu (např. YYYY-MM-DD).");
                return;
            }

            if (!int.TryParse(Ctenar_id_ctenarText, out int Ctenar_id_ctenar))
            {
                MessageBox.Show("Ctenar_id_ctenar musí být číslo.");
                return;
            }

            if (!int.TryParse(Exemplar_id_exemplarText, out int Exemplar_id_exemplar))
            {
                MessageBox.Show("Exemplar_id_exemplar musí být číslo.");
                return;
            }

            try
            {
                Vypujcka vypujcka = new Vypujcka
                {
                    Id_vypujcka = id_vypujcka,
                    Datum_pujceni = datum_pujceni.ToString("yyyy-MM-dd"),
                    Datum_vraceni = datum_vraceni.ToString("yyyy-MM-dd"),
                    Ctenar_id_ctenar = Ctenar_id_ctenar,
                    Exemplar_id_exemplare = Exemplar_id_exemplar
                };

                if (vypujcka.Save())
                {
                    MessageBox.Show("Výpůjčka byla úspěšně přidána do databáze.");
                }
                else
                {
                    MessageBox.Show("Chyba při přidávání výpůjčky do databáze.");
                }
            }
            catch (Exception ex)
            {
                // Ošetření chyb
                MessageBox.Show("Chyba při přidávání výpůjčky do databáze: " + ex.Message);
            }

        }
    }
}
