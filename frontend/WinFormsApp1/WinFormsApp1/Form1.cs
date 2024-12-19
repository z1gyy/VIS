using ConsoleApp1;
using System.Data.SQLite;
using System.Text;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            StyleButtons();

            // Nastylujeme DataGridView
            StyleDataGridView();

            // Nastylujeme celý formuláø
            StyleForm();

            // Nastavíme DataGridView na režim pouze pro ètení
            dataGridView1.ReadOnly = true;

            // Zabráníme výbìru více øádkù
            dataGridView1.MultiSelect = false;

            // Zakážeme výbìr bunìk
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadData()
        {
            using (var connection = ActiveRecord.GetConnection())
            {
                var command = new SQLiteCommand("SELECT Isbn, Nazev, Pocet_Stran, Nakladatel, Datum_vydani, Je_bestseller, Poznamka FROM Kniha", connection);
                connection.Open();
                var book = command.ExecuteReader();
                var dataTable = new System.Data.DataTable();
                dataTable.Load(book);
                dataGridView1.DataSource = dataTable; 
            }
            HideUnwantedColumns();
        }

        private void HideUnwantedColumns()
        {
            // Skrytí sloupcù, které nechceme zobrazit
            dataGridView1.Columns["Je_bestseller"].Visible = false;
            dataGridView1.Columns["Poznamka"].Visible = false;
            dataGridView1.Columns["Datum_vydani"].Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];

                // Naèteme data z vybraného øádku
                string isbn = selectedRow.Cells["Isbn"].Value.ToString();
                string nazev = selectedRow.Cells["Nazev"].Value.ToString();
                string pocetStran = selectedRow.Cells["Pocet_Stran"].Value.ToString();
                string nakladatel = selectedRow.Cells["Nakladatel"].Value.ToString();
                string datum_vydani = selectedRow.Cells["Datum_vydani"].Value.ToString();
                string je_bestseller = selectedRow.Cells["Je_bestseller"].Value.ToString();
                string poznamka = selectedRow.Cells["Poznamka"].Value.ToString();

                // Vyplníme textové boxy s hodnotami
                textBox1.Text = isbn;
                textBox2.Text = nazev;
                textBox3.Text = pocetStran;
                textBox4.Text = nakladatel;
                textBox5.Text = datum_vydani;
                textBox6.Text = je_bestseller;
                textBox7.Text = poznamka;
            }
        }
        private void StyleDataGridView()
        {
            // Zmìníme barvu pozadí pro DataGridView
            dataGridView1.BackgroundColor = Color.FromArgb(255, 255, 255, 255); // Bílá barva pro transparentní pozadí
            dataGridView1.DefaultCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.SkyBlue;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Zmìníme vzhled hlavièek sloupcù
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204); // Modrá barva
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // Zmìníme okraje sloupcù
            dataGridView1.RowTemplate.Height = 35; // Vyšší øádky pro lepší vzhled
            dataGridView1.BorderStyle = BorderStyle.None;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.RowsDefaultCellStyle.Padding = new Padding(5); 

            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void StyleForm()
        {
            // Nastavíme pozadí formuláøe na obrázek s mraky
            this.BackgroundImage = Image.FromFile("background.jpg");  
            this.BackgroundImageLayout = ImageLayout.Stretch; // Nastaví obrázek, aby se roztáhl na celé pozadí

            // Nastavení fontu pro celý formuláø
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Pøidání jemného stínu pro celý formuláø pro efekt hloubky
            this.DoubleBuffered = true;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Vytvoøení pera pro kreslení obdélníku se zaoblenými rohy
            Pen pen = new Pen(Color.Black, 3);
            int cornerRadius = 20;  // Zaoblení rohù

            // Kreslení obdélníku se zaoblenými rohy
            e.Graphics.DrawArc(pen, 0, 0, cornerRadius, cornerRadius, 180, 90); // Horní levý roh
            e.Graphics.DrawArc(pen, panel1.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90); // Horní pravý roh
            e.Graphics.DrawArc(pen, 0, panel1.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90); // Dolní levý roh
            e.Graphics.DrawArc(pen, panel1.Width - cornerRadius, panel1.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90); // Dolní pravý roh

            // Kreslení èar pro spoje mezi rohy
            e.Graphics.DrawLine(pen, cornerRadius, 0, panel1.Width - cornerRadius, 0); // Horní hrana
            e.Graphics.DrawLine(pen, panel1.Width, cornerRadius, panel1.Width, panel1.Height - cornerRadius); // Pravá hrana
            e.Graphics.DrawLine(pen, panel1.Width - cornerRadius, panel1.Height, cornerRadius, panel1.Height); // Spodní hrana
            e.Graphics.DrawLine(pen, 0, panel1.Height - cornerRadius, 0, cornerRadius); // Levá hrana
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // Vytvoøení pera pro kreslení
            Pen pen = new Pen(Color.FromArgb(0, 122, 204), 2);  // Tmavì modrá barva pro horní panel

            // Kreslení zaobleného obdélníku pro horní menu
            int cornerRadius = 20;  // Radius pro zaoblené rohy

            // Kreslení hran panelu s zaoblenými rohy
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;  // Zajištìní hladkého vykreslování

            // Kreslení horního panelu se zaoblenými rohy
            e.Graphics.DrawArc(pen, 0, 0, cornerRadius, cornerRadius, 180, 90); // Levý horní roh
            e.Graphics.DrawArc(pen, panel2.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90); // Pravý horní roh
            e.Graphics.DrawLine(pen, cornerRadius, 0, panel2.Width - cornerRadius, 0); // Horní okraj
            e.Graphics.DrawLine(pen, panel2.Width, cornerRadius, panel2.Width, panel2.Height); // Pravý okraj

            // Kreslení spodního okraje panelu
            e.Graphics.DrawLine(pen, 0, panel2.Height - 1, panel2.Width, panel2.Height - 1); // Spodní okraj

            // Pøidání pozadí do panelu
            panel2.BackColor = Color.FromArgb(0, 122, 204);  // Tmavì modrá barva pozadí
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            // Vytvoøení pera pro kreslení rámeèku
            Pen pen = new Pen(Color.FromArgb(200, 200, 200), 2);  // Svìtle šedý rámeèek

            // Kreslení zaobleného rámeèku pro detail
            int cornerRadius = 15;  // Radius pro zaoblené rohy detailního panelu

            // Kreslení rámeèku kolem panelu
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;  // Zajištìní hladkého vykreslování
            e.Graphics.DrawArc(pen, 0, 0, cornerRadius, cornerRadius, 180, 90); // Levý horní roh
            e.Graphics.DrawArc(pen, panel3.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90); // Pravý horní roh
            e.Graphics.DrawLine(pen, cornerRadius, 0, panel3.Width - cornerRadius, 0); // Horní okraj
            e.Graphics.DrawLine(pen, panel3.Width, cornerRadius, panel3.Width, panel3.Height - cornerRadius); // Pravý okraj
            e.Graphics.DrawLine(pen, panel3.Width - cornerRadius, panel3.Height, cornerRadius, panel3.Height); // Spodní okraj
            e.Graphics.DrawLine(pen, 0, panel3.Height - cornerRadius, 0, cornerRadius); // Levý okraj

            panel3.BackColor = Color.White;  


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
        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
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
            // Tlaèítko 1 (Login)
            button1.BackColor = Color.WhiteSmoke; // Pozadí
            button1.ForeColor = Color.Black; // Barva textu
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 2;
            button1.FlatAppearance.BorderColor = Color.FromArgb(0, 122, 204); // Modrý rámeèek
            button1.Font = new Font("Segoe UI", 12);
            button1.Padding = new Padding(10);


            // Tlaèítko 2 (Registrace)
            button2.BackColor = Color.WhiteSmoke;
            button2.ForeColor = Color.Black;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 2;
            button2.FlatAppearance.BorderColor = Color.FromArgb(0, 122, 204); // Modrý rámeèek
            button2.Font = new Font("Segoe UI", 12);
            button2.Padding = new Padding(10);


            // Tlaèítko 3
            button3.BackColor = Color.WhiteSmoke;
            button3.ForeColor = Color.Black;
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 2;
            button3.FlatAppearance.BorderColor = Color.FromArgb(0, 122, 204); // Modrý rámeèek
            button3.Font = new Font("Segoe UI", 12);
            button3.Padding = new Padding(10);


            // Tlaèítko 4
            button4.BackColor = Color.WhiteSmoke;
            button4.ForeColor = Color.Black;
            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 2;
            button4.FlatAppearance.BorderColor = Color.FromArgb(0, 122, 204); // Modrý rámeèek
            button4.Font = new Font("Segoe UI", 12);
            button4.Padding = new Padding(10);


            // Tlaèítko 5
            button5.BackColor = Color.WhiteSmoke;
            button5.ForeColor = Color.Black;
            button5.FlatStyle = FlatStyle.Flat;
            button5.FlatAppearance.BorderSize = 2;
            button5.FlatAppearance.BorderColor = Color.FromArgb(0, 122, 204); // Modrý rámeèek
            button5.Font = new Font("Segoe UI", 12);
            button5.Padding = new Padding(10);


            // Tlaèítko 6
            button6.BackColor = Color.WhiteSmoke;
            button6.ForeColor = Color.Black;
            button6.FlatStyle = FlatStyle.Flat;
            button6.FlatAppearance.BorderSize = 2;
            button6.FlatAppearance.BorderColor = Color.FromArgb(0, 122, 204); // Modrý rámeèek
            button6.Font = new Font("Segoe UI", 12);
            button6.Padding = new Padding(10);

        }




        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.BackColor = Color.FromArgb(0, 105, 160); // Tmavší modrá pøi najetí
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.BackColor = Color.WhiteSmoke; // Zùstane transparentní pozadí
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
