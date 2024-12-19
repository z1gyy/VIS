using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Data.SQLite;

namespace WinFormsApp1
{
    public partial class Form3 : Form
    {
        bool admin = false;
        public Form3()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Získáme hodnoty z textových polí
            string username = textBox1.Text; // Předpokládáme, že textBox1 je pro jméno
            string password = textBox3.Text; // Předpokládáme, že textBox3 je pro heslo

            // Ověření, zda zadané jméno a heslo jsou správné
            if (AuthenticateUser(username, password))
            {
                if (admin)
                {
                    admin = false;
                    Form5 form5 = new Form5();
                    form5.Show();
                }
                else
                {
                    string email = GetUserEmail(username);
                    LoadBooksForReader(email);
                }
            }
            else
            {
                MessageBox.Show("Neplatné jméno nebo heslo.");
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            string path = "users.txt"; // Cesta k souboru, kde jsou uložené údaje
            string path2 = "admins.txt"; // Cesta k souboru, kde jsou uložené údaje

            if (File.Exists(path))
            {
                if (username.StartsWith("knihovnik"))
                {
                    string[] lines = File.ReadAllLines(path2);

                    string storedUsername = null;
                    string storedHashedPassword = null;

                    // Projdeme všechny řádky v souboru a hledáme odpovídající záznamy
                    foreach (string line in lines)
                    {
                        if (line.StartsWith("Name:"))
                        {
                            storedUsername = line.Substring(5).Trim(); // Extrahujeme jméno
                        }
                        else if (line.StartsWith("Password:"))
                        {
                            storedHashedPassword = line.Substring(9).Trim(); // Extrahujeme hash hesla
                        }

                        // Pokud máme obojí, můžeme pokračovat
                        if (storedUsername != null && storedHashedPassword != null)
                        {
                            // Pokud se jméno shoduje, zkontrolujeme heslo
                            if (storedUsername.Equals(username, StringComparison.OrdinalIgnoreCase))
                            {
                                string hashedPassword = HashPassword(password);
                                admin = true;
                                return storedHashedPassword.Equals(hashedPassword);
                            }
                        }
                    }
                }
                else
                {
                    string[] lines = File.ReadAllLines(path);

                    string storedUsername = null;
                    string storedHashedPassword = null;

                    // Projdeme všechny řádky v souboru a hledáme odpovídající záznamy
                    foreach (string line in lines)
                    {
                        if (line.StartsWith("Name:"))
                        {
                            storedUsername = line.Substring(5).Trim(); // Extrahujeme jméno
                        }
                        else if (line.StartsWith("Password:"))
                        {
                            storedHashedPassword = line.Substring(9).Trim(); // Extrahujeme hash hesla
                        }

                        // Pokud máme obojí, můžeme pokračovat
                        if (storedUsername != null && storedHashedPassword != null)
                        {
                            // Pokud se jméno shoduje, zkontrolujeme heslo
                            if (storedUsername.Equals(username, StringComparison.OrdinalIgnoreCase))
                            {
                                string hashedPassword = HashPassword(password);
                                return storedHashedPassword.Equals(hashedPassword);
                            }
                        }
                    }
                }
            }

            return false; // Pokud nenajdeme odpovídající záznam
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Převod hesla na pole bytů
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Převod na hexadecimální řetězec
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }

        private string GetUserEmail(string username)
        {
            string path = "users.txt"; // Cesta k souboru uživatelů

            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);

                // Procházení všech řádků v souboru
                for (int i = 0; i < lines.Length; i++)
                {
                    // Pokud řádek začíná "Name:" a jméno odpovídá hledanému uživatelskému jménu
                    if (lines[i].StartsWith("Name:") && lines[i].Substring(5).Trim().Equals(username, StringComparison.OrdinalIgnoreCase))
                    {
                        // Pokud je další řádek pro e-mail
                        if (i + 1 < lines.Length && lines[i + 1].StartsWith("Email:"))
                        {
                            return lines[i + 1].Substring(6).Trim(); // Vrátí e-mail
                        }
                    }
                }
            }

            return null; // Pokud e-mail nenalezen
        }

        private void LoadBooksForReader(string email)
        {
            try
            {
                using (var connection = new SQLiteConnection("Data Source=C:\\Users\\Žigy-san\\Desktop\\vis\\dbs\\dbs.db;Version=3;")) // SQLite připojení
                {
                    connection.Open();
                    // SQL dotaz na vyhledání knih podle e-mailu čtenáře
                    var command = new SQLiteCommand("SELECT Id_ctenar, Email FROM Ctenar WHERE Email = @Email", connection);
                    command.Parameters.AddWithValue("@Email", email);

                    var reader = command.ExecuteReader();
                    var dataTable = new DataTable();
                    dataTable.Load(reader);
                    if (dataTable.Rows.Count > 0)
                    {
                        int id_ctenar = Convert.ToInt32(dataTable.Rows[0]["id_ctenar"]);
                        Form4 form4 = new Form4(id_ctenar);
                        form4.Show();
                        //MessageBox.Show("Ok " + dataTable.Rows.Count);

                    }
                    else
                    {
                        MessageBox.Show("Účet není aktivován zajděte prosím do svojí knihovny pro více informací.");
                    }
                }

            }
            
            catch (Exception ex)
            {
                MessageBox.Show("Účet není aktivován zajděte prosím do svojí knihovny pro více informací." );
            }
        }
    }
}
