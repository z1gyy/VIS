namespace WinFormsApp1
{
    partial class Form12
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            textBox5 = new TextBox();
            label5 = new Label();
            button1 = new Button();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox2 = new TextBox();
            label4 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            label3 = new Label();
            label2 = new Label();
            label6 = new Label();
            textBox6 = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(textBox6);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(textBox5);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(166, 70);
            panel1.Name = "panel1";
            panel1.Size = new Size(449, 386);
            panel1.TabIndex = 13;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(180, 200);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(211, 23);
            textBox5.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label5.Location = new Point(49, 245);
            label5.Name = "label5";
            label5.Size = new Size(114, 25);
            label5.TabIndex = 12;
            label5.Text = "Exemplář_id";
            // 
            // button1
            // 
            button1.Location = new Point(216, 285);
            button1.Name = "button1";
            button1.Size = new Size(122, 32);
            button1.TabIndex = 10;
            button1.Text = "Potvrdit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(181, 114);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(211, 23);
            textBox3.TabIndex = 6;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(180, 160);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(211, 23);
            textBox4.TabIndex = 8;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(181, 66);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(211, 23);
            textBox2.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label4.Location = new Point(71, 200);
            label4.Name = "label4";
            label4.Size = new Size(92, 25);
            label4.TabIndex = 7;
            label4.Text = "Čtenář_id";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(181, 24);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(211, 23);
            textBox1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.Location = new Point(97, 19);
            label1.Name = "label1";
            label1.Size = new Size(30, 25);
            label1.TabIndex = 1;
            label1.Text = "ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label3.Location = new Point(40, 64);
            label3.Name = "label3";
            label3.Size = new Size(135, 25);
            label3.TabIndex = 5;
            label3.Text = "Datum Pujčení";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.Location = new Point(40, 109);
            label2.Name = "label2";
            label2.Size = new Size(136, 25);
            label2.TabIndex = 3;
            label2.Text = "Datum Vrácení";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label6.Location = new Point(9, 155);
            label6.Name = "label6";
            label6.Size = new Size(154, 25);
            label6.TabIndex = 14;
            label6.Text = "Skutečné vrácení";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(181, 245);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(211, 23);
            textBox6.TabIndex = 14;
            // 
            // Form12
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "Form12";
            Text = "Form12";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox textBox5;
        private Label label5;
        private Button button1;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox2;
        private Label label4;
        private TextBox textBox1;
        private Label label1;
        private Label label3;
        private Label label2;
        private TextBox textBox6;
        private Label label6;
    }
}