using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using System.IO;
using System.Security.Cryptography;
using Newtonsoft.Json;
using TowerGame_V1._0._2.classes;

namespace TowerGame_V1._0._2
{
    /// <summary>
    /// Interaction logic for titleScreen.xaml
    /// </summary>
    public partial class titleScreen : Window
    {
        //public PlayerData playerData;
        public titleScreen()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            //classManager classes = new classManager();
            //classes.InitializeClassDatabase();
        }

        private void exitGameButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void startGameButton_Click(object sender, RoutedEventArgs e)
        {
            double prevWindowLeft = this.Left;
            double prevWindowTop = this.Top;
            double prevWindowWidth = this.Width;
            double prevWindowHeight = this.Height;

            double centerX = prevWindowLeft + prevWindowWidth / 2;
            double centerY = prevWindowTop + prevWindowHeight / 2;

            characterCreation createCharacter = new characterCreation();
            createCharacter.WindowStartupLocation = WindowStartupLocation.Manual;
            double newWindowLeft = centerX - createCharacter.Width / 2;
            double newWindowTop = centerY - createCharacter.Height / 2;
            createCharacter.Left = newWindowLeft;
            createCharacter.Top = newWindowTop;
            createCharacter.Show();
            this.Close();
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Start window dragging
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void loadGameButton_Click(object sender, RoutedEventArgs e)
        {
            loadCharacter loadCharacterData = new loadCharacter();
            loadCharacterData.Show();
            this.Close();
        }
    }
        /*
        private void Button_Click(object sender, RoutedEventArgs e)
        {
        string subfolderName = "savedgames";
        string Name = "Mannax";
        int Level = 1;
        string fullPath = System.IO.Path.Combine(subfolderName, Name);
        string serializedData = File.ReadAllText(fullPath);
        string storedHashValue = File.ReadAllText(fullPath + ".hash");

        PlayerData playerData = new PlayerData(Name, Level);
        MessageBox.Show("Hello!" + playerData.Name);
        progressBarHealth.Background = Brushes.Green;
        DataManager dataManager = new DataManager();
        dataManager.SavePlayerData(playerData, Name);
        dataManager.LoadPlayerData(serializedData, storedHashValue);
}
}
        */
        /*
        public class DataManager
        {
            public void SavePlayerData(PlayerData playerData, string filePath)
            {
                // Define the subfolder name
                string subfolderName = "savedgames";

                // Combine the subfolder name with the file name
                string fullPath = System.IO.Path.Combine(subfolderName, filePath);
                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(fullPath));
                // Serialize player data to JSON
                string serializedData = JsonConvert.SerializeObject(playerData);

                // Compute SHA-256 hash of the serialized data
                byte[] serializedBytes = System.Text.Encoding.UTF8.GetBytes(serializedData);
                byte[] hashBytes;
                using (SHA256 sha256 = SHA256.Create())
                {
                    hashBytes = sha256.ComputeHash(serializedBytes);
                }
                string hashValue = BitConverter.ToString(hashBytes).Replace("-", "");

                // Save serialized data and hash value to file
                File.WriteAllText(fullPath, serializedData);
                File.WriteAllText(fullPath + ".hash", hashValue);
            }

            public bool VerifyPlayerDataIntegrity(string filePath, string hashValue)
            {
                string subfolderName = "savedgames";
                string fullPath = System.IO.Path.Combine(subfolderName, filePath);
                // Read serialized data and hash value from file
                string serializedData = File.ReadAllText(filePath);
                string storedHashValue = File.ReadAllText(fullPath + ".hash");

                // Compute SHA-256 hash of the serialized data
                byte[] serializedBytes = System.Text.Encoding.UTF8.GetBytes(serializedData);
                byte[] hashBytes;
                using (SHA256 sha256 = SHA256.Create())
                {
                    hashBytes = sha256.ComputeHash(serializedBytes);
                }
                string computedHashValue = BitConverter.ToString(hashBytes).Replace("-", "");

                // Compare computed hash with stored hash
                return storedHashValue.Equals(computedHashValue);
            }
            public void LoadPlayerData(string serializedData, string storedHashValue)
            {
                // Verify the integrity of the loaded data
                bool isDataIntegrityValid = VerifyPlayerDataIntegrity(serializedData, storedHashValue);
                if (isDataIntegrityValid)
                {
                    // Deserialize the player data from JSON
                    PlayerData player = JsonConvert.DeserializeObject<PlayerData>(serializedData);

                    // Now you can use the 'player' object in your application
                    Console.WriteLine($"Player Name: {player.Name}, Level: {player.Level}");
                }
                else
                {
                    Console.WriteLine("Warning: Data integrity validation failed. Player data may have been tampered with.");
                }
            }
        }
    */
    }