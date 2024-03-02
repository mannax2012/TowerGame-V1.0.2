using characterData;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TowerGame_V1._0._2.characterManager;
using TowerGame_V1._0._2.classes;

namespace TowerGame_V1._0._2
{
    /// <summary>
    /// Interaction logic for characterCreation.xaml
    /// </summary>
    public partial class characterCreation : Window
    {
        PlayerData playerData;
        DataTable dtClasses;
        public string connectionString = @"Data Source=Classes.db;Version=3;";
        public characterCreation()
        {
            InitializeComponent();
            DataContext = new CharacterDataManager();
            addClassList();
            NameTextBox.Focus();
        }
        public void addClassList()
        {
            classListBox.Items.Clear();
            LoadClassesIntoComboBox();
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void createCancelButton_Click(object sender, RoutedEventArgs e)
        {
            double prevWindowLeft = this.Left;
            double prevWindowTop = this.Top;
            double prevWindowWidth = this.Width;
            double prevWindowHeight = this.Height;

            double centerX = prevWindowLeft + prevWindowWidth / 2;
            double centerY = prevWindowTop + prevWindowHeight / 2;

            titleScreen titleScreen = new titleScreen();
            titleScreen.WindowStartupLocation = WindowStartupLocation.Manual;
            double newWindowLeft = centerX - titleScreen.Width / 2;
            double newWindowTop = centerY - titleScreen.Height / 2;

            titleScreen.Left = newWindowLeft;

            titleScreen.Top = newWindowTop;

            titleScreen.Show();
            this.Close();
        }
        private void LoadClassesIntoComboBox()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT Name FROM Classes";
                SQLiteCommand selectCommand = new SQLiteCommand(selectQuery, connection);
                SQLiteDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    classListBox.Items.Add(reader["Name"].ToString());
                }
            }
        }
        public void classListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (classListBox.SelectedItem != null)
            {
                // Update the label with the selected item's content
                classLabel.Content = classListBox.SelectedItem.ToString();
    
            }
            else
            {
                    // Clear the label if no item is selected
                    classLabel.Content = "string_null";
            }
            

        }

    }
}

