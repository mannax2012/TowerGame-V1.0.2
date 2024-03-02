using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classDataManagment;
using System.Data.SQLite;
using System.Data;

namespace TowerGame_V1._0._2.classes
{
    internal class classManager
    {
        public string connectionString = @"Data Source=Classes.db;Version=3;";
        
        public void InitializeClassDatabase()
        {
            ClearDatabase();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Check if the table exists
                if (!TableExists("Classes", connectionString))
                {
                    // If the table does not exist, create it
                    string createTableQuery = "CREATE TABLE Classes (Name TEXT, str INTEGER, dex INTEGER, stam INTEGER, intel INTEGER, focus INTEGER, wisdom INTEGER)";
                    SQLiteCommand createTableCommand = new SQLiteCommand(createTableQuery, connection);
                    createTableCommand.ExecuteNonQuery();
                }

                if (!EntryExists("Warrior", connection))
                {
                    // If default entry does not exist, insert it
                    string insertQuery = "INSERT INTO Classes (Name, str, dex, stam, intel, focus, wisdom) VALUES ('Warrior', 8, 4, 3, 0, 0, 0)";
                    SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection);
                    insertCommand.ExecuteNonQuery();
                }
                if (!EntryExists("Priest", connection))
                {
                    // If default entry does not exist, insert it
                    string insertQuery = "INSERT INTO Classes (Name, str, dex, stam, intel, focus, wisdom) VALUES ('Priest', 0, 0, 0, 10, 2, 3)";
                    SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection);
                    insertCommand.ExecuteNonQuery();
                }
                if (!EntryExists("Rogue", connection))
                {
                    // If default entry does not exist, insert it
                    string insertQuery = "INSERT INTO Classes (Name, str, dex, stam, intel, focus, wisdom) VALUES ('Rogue', 3, 7, 5, 0, 0, 0)";
                    SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection);
                    insertCommand.ExecuteNonQuery();
                }
                if (!EntryExists("Mage", connection))
                {
                    // If default entry does not exist, insert it
                    string insertQuery = "INSERT INTO Classes (Name, str, dex, stam, intel, focus, wisdom) VALUES ('Mage', 0, 0, 0, 8, 3, 4)";
                    SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection);
                    insertCommand.ExecuteNonQuery();
                }
                if (!EntryExists("Paladin", connection))
                {
                    // If default entry does not exist, insert it
                    string insertQuery = "INSERT INTO Classes (Name, str, dex, stam, intel, focus, wisdom) VALUES ('Paladin', 5, 2, 3, 3, 0, 2)";
                    SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection);
                    insertCommand.ExecuteNonQuery();
                }
                if (!EntryExists("Archer", connection))
                {
                    // If default entry does not exist, insert it
                    string insertQuery = "INSERT INTO Classes (Name, str, dex, stam, intel, focus, wisdom) VALUES ('Archer', 4, 8, 3, 0, 0, 0)";
                    SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection);
                    insertCommand.ExecuteNonQuery();
                }
            }
        }
        private void ClearDatabase()
        {
            // Ensure the table exists before attempting to delete its contents
            if (TableExists("Classes", connectionString))
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string deleteQuery = "DELETE FROM Classes";
                    SQLiteCommand deleteCommand = new SQLiteCommand(deleteQuery, connection);
                    deleteCommand.ExecuteNonQuery();
                }
            }
            else
            {
                // Handle the case where the "Classes" table does not exist
                // You can choose to log an error message, create the table, or take other appropriate action
                Console.WriteLine("Error: The 'Classes' table does not exist.");
            }
        }

        private bool TableExists(string tableName, string connectionString)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand($"SELECT name FROM sqlite_master WHERE type='table' AND name='{tableName}'", connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        return reader.Read(); // Returns true if the table exists, false otherwise
                    }
                }
            }
        }


        private bool EntryExists(string name, SQLiteConnection connection)
        {
            string query = $"SELECT COUNT(*) FROM Classes WHERE Name = @Name";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@Name", name);
            int count = Convert.ToInt32(command.ExecuteScalar());
            return count > 0;
        }
    }
}
