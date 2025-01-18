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
                string id_knihaText = textBox1.Text; // ID tabulky k dropnutí

                if (!string.IsNullOrWhiteSpace(id_knihaText) && int.TryParse(id_knihaText, out int id_kniha))
                {
                    try
                    {
                        Kniha kniha = new Kniha { Isbn = id_kniha };

                        if (kniha.Delete())
                        {
                            MessageBox.Show("Kniha byla úspěšně odstraněna.");
                        }
                        else
                        {
                            MessageBox.Show("Kniha se nepodařilo odstranit.");
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
                string id_vypujckaText = textBox1.Text; // ID tabulky k dropnutí

                if (!string.IsNullOrWhiteSpace(id_vypujckaText) && int.TryParse(id_vypujckaText, out int id_vypujcka))
                {
                    try
                    {
                        Vypujcka vypujcka = new Vypujcka { Id_vypujcka = id_vypujcka };

                        if (vypujcka.Delete())
                        {
                            MessageBox.Show("Vypujcka byla úspěšně odstraněna.");
                        }
                        else
                        {
                            MessageBox.Show("Vypujcku se nepodařilo odstranit.");
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
                string id_ctenarText = textBox1.Text; // ID tabulky k dropnutí

                if (!string.IsNullOrWhiteSpace(id_ctenarText) && int.TryParse(id_ctenarText, out int id_ctenar))
                {
                    try
                    {
                        Ctenar ctenar = new Ctenar { Id_ctenar = id_ctenar };

                        if (ctenar.Delete())
                        {
                            MessageBox.Show("Ctenar byl úspěšně odstraněna");
                        }
                        else
                        {
                            MessageBox.Show("Ctenare se nepodařilo odstranit.");
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
