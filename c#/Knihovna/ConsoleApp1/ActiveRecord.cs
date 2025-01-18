using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace ConsoleApp1
{
    public abstract class ActiveRecord
    {
        protected static readonly string ConnectionString = "Data Source=C:\\Users\\Žigy-san\\Desktop\\vis\\dbs\\dbs.db;Version=3;";

        public abstract bool Save();
        public abstract bool Delete();
        public abstract bool Update();

        public static void ExportDatabaseToText()
        {
            string dbFile = "C:\\Users\\Žigy-san\\Desktop\\vis\\dbs\\dbs.db";
            string exportFile = "C:\\Users\\Žigy-san\\Desktop\\vis\\dbs\\database_export.txt";

            using (var connection = new SQLiteConnection($"Data Source={dbFile};"))
            {
                connection.Open();

                // Získání seznamu tabulek
                var command = new SQLiteCommand("SELECT name FROM sqlite_master WHERE type='table';", connection);
                using (var reader = command.ExecuteReader())
                {
                    // Otevření souboru pro zápis
                    using (StreamWriter writer = new StreamWriter(exportFile))
                    {
                        // Procházení všech tabulek v databázi
                        while (reader.Read())
                        {
                            string tableName = reader.GetString(0);
                            writer.WriteLine($"Tabulka: {tableName}");

                            // Získání dat z každé tabulky
                            var dataCommand = new SQLiteCommand($"SELECT * FROM {tableName};", connection);
                            using (var dataReader = dataCommand.ExecuteReader())
                            {
                                // Zapsání názvů sloupců
                                for (int i = 0; i < dataReader.FieldCount; i++)
                                {
                                    writer.Write(dataReader.GetName(i) + "\t");
                                }
                                writer.WriteLine();

                                // Zapsání dat
                                while (dataReader.Read())
                                {
                                    for (int i = 0; i < dataReader.FieldCount; i++)
                                    {
                                        writer.Write(dataReader.GetValue(i) + "\t");
                                    }
                                    writer.WriteLine();
                                }
                            }
                            writer.WriteLine(); // Mezera mezi tabulkami
                        }
                    }
                }
            }
        }

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(ConnectionString);
        }
    }
}
