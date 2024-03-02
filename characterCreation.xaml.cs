using System;
using System.Collections.Generic;
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

namespace TowerGame_V1._0._2
{
    /// <summary>
    /// Interaction logic for characterCreation.xaml
    /// </summary>
    public partial class characterCreation : Window
    {
        public characterCreation()
        {
            InitializeComponent();
            DataContext = new CharacterDataManager();
            addClassList();
        }
        public void addClassList()
        {
            NameTextBox.Focus();
            classListBox.Items.Clear();
            classListBox.Items.Add("Warrior");
            classListBox.Items.Add("Paladin");
            classListBox.Items.Add("Mage");
            classListBox.Items.Add("Priest");
            classListBox.Items.Add("Ranger");
            classListBox.Items.Add("Archer");
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
