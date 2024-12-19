using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Získáme hodnoty z textových polí
            string name = textBox1.Text;
            string email = textBox2.Text;
            string password = textBox3.Text;
            string confirmPassword = textBox4.Text;

            // Ověření, zda hesla odpovídají
            if (password != confirmPassword)
            {
                MessageBox.Show("Hesla se neshodují.");
                return;
            }

            // Vytvoření hashovaného hesla
            string hashedPassword = HashPassword(password);

            // Uložení dat do souboru
            SaveUserData(name, email, hashedPassword);

            MessageBox.Show("Registrace byla úspěšná.");
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

        private void SaveUserData(string name, string email, string hashedPassword)
        {
            // Cesta k souboru
            string path = "users.txt";

            // Záznam do souboru
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine($"Name: {name}");
                writer.WriteLine($"Email: {email}");
                writer.WriteLine($"Password: {hashedPassword}");
                writer.WriteLine();
            }
        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
