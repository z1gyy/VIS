﻿using ConsoleApp1;
using System.Data.SQLite;
using System.Text;
namespace WinFormsApp1
{
    public partial class Form4 : Form
    {
        bool load_1 = false;
        bool load_2 = false;
        private int id_ctenare;

        public Form4(int id_ctenar)
        {
            id_ctenare = id_ctenar;
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            LoadData();
            StyleButtons();

            // Nastylujeme DataGridView
            StyleDataGridView();

            // Nastylujeme celý formulář
            StyleForm();

            // Nastavíme DataGridView na režim pouze pro čtení
            dataGridView1.ReadOnly = true;

            // Zabráníme výběru více řádků
            dataGridView1.MultiSelect = false;

            // Zakážeme výběr buněk
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadData()
        {
            var knihy = Kniha.GetAll();
            /*
            if (knihy == null || !knihy.Any())
            {
                MessageBox.Show("Žádná data nebyla načtena!");
                return;
            }
            */
            dataGridView1.DataSource = knihy.Select(k => new
            {
                k.Isbn,
                k.Nazev,
                k.Pocet_stran,
                k.Nakladatel,
                k.Datum_vydani,
                k.Je_bestseller,
                k.Poznamka
            }).ToList();
            HideUnwantedColumns();
            load_1 = true;
            load_2 = false;
        }

        private void LoadBorrowings()
        {
                // Načtení výpůjček pomocí metody VypujckaById
                var vypujcky = new Vypujcka().VypujckaById(id_ctenare);

                // Přímo přiřazení výpůjček k DataGridView pomocí LINQ
                dataGridView1.DataSource = vypujcky.Select(v => new
                {
                    v.Id_vypujcka,
                    v.Datum_pujceni,
                    v.Datum_vraceni
                }).ToList();


                load_2 = true;
                load_1 = false;
        }

        private void HideUnwantedColumns()
        {
            // Skrytí sloupců, které nechceme zobrazit
            dataGridView1.Columns["Je_bestseller"].Visible = false;
            dataGridView1.Columns["Poznamka"].Visible = false;
            dataGridView1.Columns["Datum_vydani"].Visible = false;
        }

        private void StyleDataGridView()
        {
            // Změníme barvu pozadí pro DataGridView
            dataGridView1.BackgroundColor = Color.FromArgb(255, 255, 255, 255); // Bílá barva pro transparentní pozadí
            dataGridView1.DefaultCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.SkyBlue;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Změníme vzhled hlaviček sloupců
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204); // Modrá barva
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // Změníme okraje sloupců
            dataGridView1.RowTemplate.Height = 35; // Vyšší řádky pro lepší vzhled
            dataGridView1.BorderStyle = BorderStyle.None;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.RowsDefaultCellStyle.Padding = new Padding(5); // Přidání paddingu pro lepší vzhled

            // Přidáme jemný stín
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void StyleForm()
        {
            // Nastavíme pozadí formuláře na obrázek s mraky
            this.BackgroundImage = Image.FromFile("background.jpg"); 
            this.BackgroundImageLayout = ImageLayout.Stretch; // Nastaví obrázek, aby se roztáhl na celé pozadí

            // Nastavení fontu pro celý formulář
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Přidání jemného stínu pro celý formulář pro efekt hloubky
            this.DoubleBuffered = true;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Vytvoření pera pro kreslení obdélníku se zaoblenými rohy
            Pen pen = new Pen(Color.Black, 3);
            int cornerRadius = 20;  // Zaoblení rohů

            // Kreslení obdélníku se zaoblenými rohy
            e.Graphics.DrawArc(pen, 0, 0, cornerRadius, cornerRadius, 180, 90); // Horní levý roh
            e.Graphics.DrawArc(pen, panel1.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90); // Horní pravý roh
            e.Graphics.DrawArc(pen, 0, panel1.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90); // Dolní levý roh
            e.Graphics.DrawArc(pen, panel1.Width - cornerRadius, panel1.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90); // Dolní pravý roh

            // Kreslení čar pro spoje mezi rohy
            e.Graphics.DrawLine(pen, cornerRadius, 0, panel1.Width - cornerRadius, 0); // Horní hrana
            e.Graphics.DrawLine(pen, panel1.Width, cornerRadius, panel1.Width, panel1.Height - cornerRadius); // Pravá hrana
            e.Graphics.DrawLine(pen, panel1.Width - cornerRadius, panel1.Height, cornerRadius, panel1.Height); // Spodní hrana
            e.Graphics.DrawLine(pen, 0, panel1.Height - cornerRadius, 0, cornerRadius); // Levá hrana
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // Vytvoření pera pro kreslení
            Pen pen = new Pen(Color.FromArgb(0, 122, 204), 2);  // Tmavě modrá barva pro horní panel

            // Kreslení zaobleného obdélníku pro horní menu
            int cornerRadius = 20;  // Radius pro zaoblené rohy

            // Kreslení hran panelu s zaoblenými rohy
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;  // Zajištění hladkého vykreslování

            // Kreslení horního panelu se zaoblenými rohy
            e.Graphics.DrawArc(pen, 0, 0, cornerRadius, cornerRadius, 180, 90); // Levý horní roh
            e.Graphics.DrawArc(pen, panel2.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90); // Pravý horní roh
            e.Graphics.DrawLine(pen, cornerRadius, 0, panel2.Width - cornerRadius, 0); // Horní okraj
            e.Graphics.DrawLine(pen, panel2.Width, cornerRadius, panel2.Width, panel2.Height); // Pravý okraj

            // Kreslení spodního okraje panelu
            e.Graphics.DrawLine(pen, 0, panel2.Height - 1, panel2.Width, panel2.Height - 1); // Spodní okraj

            // Přidání pozadí do panelu
            panel2.BackColor = Color.FromArgb(0, 122, 204);  // Tmavě modrá barva pozadí
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            // Vytvoření pera pro kreslení rámečku
            Pen pen = new Pen(Color.FromArgb(200, 200, 200), 2);  // Světle šedý rámeček

            // Kreslení zaobleného rámečku pro detail
            int cornerRadius = 15;  // Radius pro zaoblené rohy detailního panelu

            // Kreslení rámečku kolem panelu
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;  // Zajištění hladkého vykreslování
            e.Graphics.DrawArc(pen, 0, 0, cornerRadius, cornerRadius, 180, 90); // Levý horní roh
            e.Graphics.DrawArc(pen, panel3.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90); // Pravý horní roh
            e.Graphics.DrawLine(pen, cornerRadius, 0, panel3.Width - cornerRadius, 0); // Horní okraj
            e.Graphics.DrawLine(pen, panel3.Width, cornerRadius, panel3.Width, panel3.Height - cornerRadius); // Pravý okraj
            e.Graphics.DrawLine(pen, panel3.Width - cornerRadius, panel3.Height, cornerRadius, panel3.Height); // Spodní okraj
            e.Graphics.DrawLine(pen, 0, panel3.Height - cornerRadius, 0, cornerRadius); // Levý okraj

            // Nastavení pozadí panelu pro detail
            panel3.BackColor = Color.White;  // Světle šedé pozadí pro lepší čitelnost textu


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void StyleButtons()
        {

            // Tlačítko 3
            button3.BackColor = Color.WhiteSmoke;
            button3.ForeColor = Color.Black;
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 2;
            button3.FlatAppearance.BorderColor = Color.FromArgb(0, 122, 204); // Modrý rámeček
            button3.Font = new Font("Segoe UI", 12);
            button3.Padding = new Padding(10);


            // Tlačítko 4
            button4.BackColor = Color.WhiteSmoke;
            button4.ForeColor = Color.Black;
            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 2;
            button4.FlatAppearance.BorderColor = Color.FromArgb(0, 122, 204); // Modrý rámeček
            button4.Font = new Font("Segoe UI", 12);
            button4.Padding = new Padding(10);


            // Tlačítko 5
            button5.BackColor = Color.WhiteSmoke;
            button5.ForeColor = Color.Black;
            button5.FlatStyle = FlatStyle.Flat;
            button5.FlatAppearance.BorderSize = 2;
            button5.FlatAppearance.BorderColor = Color.FromArgb(0, 122, 204); // Modrý rámeček
            button5.Font = new Font("Segoe UI", 12);
            button5.Padding = new Padding(10);


            // Tlačítko 6
            button6.BackColor = Color.WhiteSmoke;
            button6.ForeColor = Color.Black;
            button6.FlatStyle = FlatStyle.Flat;
            button6.FlatAppearance.BorderSize = 2;
            button6.FlatAppearance.BorderColor = Color.FromArgb(0, 122, 204); // Modrý rámeček
            button6.Font = new Font("Segoe UI", 12);
            button6.Padding = new Padding(10);

            // Tlačítko 1(7)
            button1.BackColor = Color.WhiteSmoke;
            button1.ForeColor = Color.Black;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 2;
            button1.FlatAppearance.BorderColor = Color.FromArgb(0, 122, 204); // Modrý rámeček
            button1.Font = new Font("Segoe UI", 12);
            button1.Padding = new Padding(10);

        }




        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.BackColor = Color.FromArgb(0, 105, 160); // Tmavší modrá při najetí
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.BackColor = Color.WhiteSmoke; // Zůstane transparentní pozadí
        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {
            // Vytvoření pera pro kreslení
            Pen pen = new Pen(Color.FromArgb(0, 122, 204), 2);  // Tmavě modrá barva pro horní panel

            // Kreslení zaobleného obdélníku pro horní menu
            int cornerRadius = 20;  // Radius pro zaoblené rohy

            // Kreslení hran panelu s zaoblenými rohy
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;  // Zajištění hladkého vykreslování

            // Kreslení horního panelu se zaoblenými rohy
            e.Graphics.DrawArc(pen, 0, 0, cornerRadius, cornerRadius, 180, 90); // Levý horní roh
            e.Graphics.DrawArc(pen, panel2.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90); // Pravý horní roh
            e.Graphics.DrawLine(pen, cornerRadius, 0, panel2.Width - cornerRadius, 0); // Horní okraj
            e.Graphics.DrawLine(pen, panel2.Width, cornerRadius, panel2.Width, panel2.Height); // Pravý okraj

            // Kreslení spodního okraje panelu
            e.Graphics.DrawLine(pen, 0, panel2.Height - 1, panel2.Width, panel2.Height - 1); // Spodní okraj

            // Přidání pozadí do panelu
            panel2.BackColor = Color.FromArgb(0, 122, 204);  // Tmavě modrá barva pozadí
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            LoadBorrowings();
            textBox1.Hide();
            textBox2.Hide(); 
            textBox3.Hide();
            textBox4.Hide();
            textBox5.Hide();
            textBox6.Hide();
            textBox7.Hide();

            Podrobnosti.Hide();
            label1.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
            label8.Hide();
    }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (!load_2)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    var selectedRow = dataGridView1.SelectedRows[0];
                    var selectedBook = selectedRow.DataBoundItem as dynamic;

                    if (selectedBook != null)
                    {
                        textBox1.Text = selectedBook.Isbn.ToString();
                        textBox2.Text = selectedBook.Nazev;
                        textBox3.Text = selectedBook.Pocet_stran.ToString();
                        textBox4.Text = selectedBook.Nakladatel;
                        textBox5.Text = selectedBook.Datum_vydani;
                        textBox6.Text = selectedBook.Je_bestseller;
                        textBox7.Text = selectedBook.Poznamka;
                    }
                }
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            textBox1.Show();
            textBox2.Show();
            textBox3.Show();
            textBox4.Show();
            textBox5.Show();
            textBox6.Show();
            textBox7.Show();

            Podrobnosti.Show();
            label1.Show();
            label3.Show();
            label4.Show();
            label5.Show();
            label6.Show();
            label7.Show();
            label8.Show();
            LoadData();
        }
    }
}
