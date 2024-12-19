using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class Form9 : Form
    {
        bool load1 = false;
        bool load2 = false;
        bool load3 = false;
        public Form9(bool load1, bool load2, bool load3)
        {
            this.load1 = load1;
            this.load2 = load2;
            this.load3 = load3;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (load1)
            {
                string id_kniha = textBox1.Text; // ID tabulky k dropnutí

                if (!string.IsNullOrWhiteSpace(id_kniha))
                {
                    try
                    {
                        using (var connection = ActiveRecord.GetConnection())
                        {
                            connection.Open();

                            // SQL příkaz pro DROP TABLE
                            string query = @"DELETE FROM Kniha WHERE ISBN = @id_kniha";

                            using (var command = new SQLiteCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@id_kniha", id_kniha);

                                // Provedení příkazu
                                command.ExecuteNonQuery();
                            }

                            MessageBox.Show($"úspěšně odstraněnos.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Chyba při mazání tabulky Kniha: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Prosím, zadejte platné ID.");
                }
            }
            else if (load2)
            {
                //vypujcka
                // Vypůjčka
                string id_vypujcka = textBox1.Text; // ID tabulky k dropnutí

                if (!string.IsNullOrWhiteSpace(id_vypujcka))
                {
                    try
                    {
                        using (var connection = ActiveRecord.GetConnection())
                        {
                            connection.Open();

                            // SQL příkaz pro DROP TABLE
                            string query = @"DELETE FROM Vypujcka WHERE id_vypujcka = @id_vypujcka";

                            using (var command = new SQLiteCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@id_vypujcka", id_vypujcka);

                                // Provedení příkazu
                                command.ExecuteNonQuery();
                            }

                            MessageBox.Show($"úspěšně odstraněnos.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Chyba při mazání tabulky Vypujcka: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Prosím, zadejte platné ID.");
                }
            }
            else if (load3)
            {
                // Čtenáři
                string id_ctenar = textBox1.Text; // ID tabulky k dropnutí

                if (!string.IsNullOrWhiteSpace(id_ctenar))
                {
                    try
                    {
                        using (var connection = ActiveRecord.GetConnection())
                        {
                            connection.Open();

                            // SQL příkaz pro DROP TABLE
                            string query = @"DELETE FROM Ctenari WHERE id_ctenar = @id_ctenar";

                            using (var command = new SQLiteCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@id_ctenar", id_ctenar);

                                // Provedení příkazu
                                command.ExecuteNonQuery();
                            }

                            MessageBox.Show($"úspěšně odstraněno.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Chyba při mazání tabulky Ctenari: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Prosím, zadejte platné ID.");
                }
            }
            else
            {
                
            }
        }
    }
}
