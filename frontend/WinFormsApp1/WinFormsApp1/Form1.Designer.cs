namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            panel3 = new Panel();
            textBox7 = new TextBox();
            label8 = new Label();
            textBox6 = new TextBox();
            label7 = new Label();
            textBox5 = new TextBox();
            label6 = new Label();
            textBox4 = new TextBox();
            label5 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            Podrobnosti = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            panel2 = new Panel();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button1 = new Button();
            button3 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(85, 202);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(980, 175);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(58, 45);
            panel1.Name = "panel1";
            panel1.Size = new Size(1146, 658);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // panel3
            // 
            panel3.Controls.Add(textBox7);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(textBox6);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(textBox5);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(textBox4);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(textBox3);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(textBox2);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(Podrobnosti);
            panel3.Controls.Add(textBox1);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(85, 435);
            panel3.Name = "panel3";
            panel3.Size = new Size(980, 189);
            panel3.TabIndex = 2;
            panel3.Paint += panel3_Paint;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(824, 88);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(135, 23);
            textBox7.TabIndex = 16;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(851, 64);
            label8.Name = "label8";
            label8.Size = new Size(81, 21);
            label8.TabIndex = 15;
            label8.Text = "Poznámka";
            label8.Click += label8_Click;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(615, 112);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(144, 23);
            textBox6.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(502, 112);
            label7.Name = "label7";
            label7.Size = new Size(76, 21);
            label7.TabIndex = 13;
            label7.Text = "Bestseller";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(615, 66);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(144, 23);
            textBox5.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(502, 68);
            label6.Name = "label6";
            label6.Size = new Size(107, 21);
            label6.TabIndex = 11;
            label6.Text = "Datum vydání";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(332, 114);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(144, 23);
            textBox4.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(240, 116);
            label5.Name = "label5";
            label5.Size = new Size(84, 21);
            label5.TabIndex = 9;
            label5.Text = "Nakladatel";
            label5.Click += label5_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(332, 70);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(144, 23);
            textBox3.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(240, 72);
            label4.Name = "label4";
            label4.Size = new Size(86, 21);
            label4.TabIndex = 7;
            label4.Text = "Počet stran";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(74, 114);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(144, 23);
            textBox2.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(15, 116);
            label3.Name = "label3";
            label3.Size = new Size(53, 21);
            label3.TabIndex = 5;
            label3.Text = "Název";
            // 
            // Podrobnosti
            // 
            Podrobnosti.AutoSize = true;
            Podrobnosti.Font = new Font("Segoe UI", 14F);
            Podrobnosti.Location = new Point(17, 9);
            Podrobnosti.Name = "Podrobnosti";
            Podrobnosti.Size = new Size(114, 25);
            Podrobnosti.TabIndex = 4;
            Podrobnosti.Text = "Podrobnosti";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(74, 70);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(144, 23);
            textBox1.TabIndex = 4;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(16, 68);
            label1.Name = "label1";
            label1.Size = new Size(44, 21);
            label1.TabIndex = 3;
            label1.Text = "ISBN";
            label1.Click += label1_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(button6);
            panel2.Controls.Add(button5);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button2);
            panel2.Location = new Point(21, 27);
            panel2.Name = "panel2";
            panel2.Size = new Size(1101, 68);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // button6
            // 
            button6.Location = new Point(500, 5);
            button6.Name = "button6";
            button6.Size = new Size(154, 58);
            button6.TabIndex = 4;
            button6.Text = "Nové knihy";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.Location = new Point(180, 4);
            button5.Name = "button5";
            button5.Size = new Size(154, 60);
            button5.TabIndex = 3;
            button5.Text = "Stránky";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.Location = new Point(340, 4);
            button4.Name = "button4";
            button4.Size = new Size(154, 59);
            button4.TabIndex = 3;
            button4.Text = "Autor";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button1
            // 
            button1.Location = new Point(756, 6);
            button1.Name = "button1";
            button1.Size = new Size(162, 56);
            button1.TabIndex = 0;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.Location = new Point(20, 3);
            button3.Name = "button3";
            button3.Size = new Size(154, 61);
            button3.TabIndex = 2;
            button3.Text = "Menu";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(924, 7);
            button2.Name = "button2";
            button2.Size = new Size(162, 55);
            button2.TabIndex = 1;
            button2.Text = "Registrace";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1274, 743);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Panel panel1;
        private Panel panel3;
        private Panel panel2;
        private Button button2;
        private Button button1;
        private TextBox textBox1;
        private Label label1;
        private Label Podrobnosti;
        private TextBox textBox7;
        private Label label8;
        private TextBox textBox6;
        private Label label7;
        private TextBox textBox5;
        private Label label6;
        private TextBox textBox4;
        private Label label5;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox2;
        private Label label3;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
    }
}
