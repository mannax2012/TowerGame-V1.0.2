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
using System.Numerics;
using classDataManagment;

namespace TowerGame_V1._0._2
{
    /// <summary>
    /// Interaction logic for characterCreation.xaml
    /// </summary>
    public partial class characterCreation : Window
    {

        List<classData> playerClasses = new List<classData>();
        classManager classList = new classManager();

        public characterCreation()
        {
            InitializeComponent();
            DataContext = new CharacterDataManager();
            classListBox.Items.Clear();
            InitializeClassDatabase();
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
        public void InitializeClassDatabase()
        {
            playerClasses = new List<classData>
            {
                new classData("Warrior", 7, 3, 5, 0, 0, 0),
                new classData("Mage", 0, 0, 1, 7, 3, 4),
            };

            if (playerClasses != null && playerClasses.Count > 0)
            {
                foreach (var player in playerClasses)
                {
                    classListBox.Items.Add(player.ClassName);
                }
            }
            else
            {
                classListBox.Items.Add("Failure");
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
       
        public void classListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (classListBox.SelectedItem != null)
                {
                    classLabel.Content = classListBox.SelectedItem.ToString();
                    string? playerClass = classLabel.Content.ToString();
                    classList.getClassBonus(playerClass);
                    
                }
                else
                {
                    classLabel.Content = "string_null";
                }
        }

    }
}

