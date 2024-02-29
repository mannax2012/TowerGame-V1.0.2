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

namespace TowerGame_V1._0._2
{
    /// <summary>
    /// Interaction logic for characterCreation.xaml
    /// </summary>
    public partial class characterCreation : Window
    {
        public PlayerData? playerData;
        public int totalSP = 5;
        public int totalAdjustedSTR;
        public int totalAdjustedDEX;
        public int totalAdjustedINTEL;
        public int totalAdjustedSTAM;
        public int currentSP = 0;
        public int currentAdjustedHP = 0;
        public int currentAdjustedMP = 0;
        public int totalAdjustedHP = 0;
        public int totalAdjustedMP = 0;

        public int totalSTR;
        public int totalDEX;
        public int totalINTEL;
        public int totalSTAM;
        public characterCreation()
        {
            InitializeComponent();
            addClassList();
            setNewCharacterData();


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

        public void createCharButton_Click(object sender, RoutedEventArgs e)
        {

            getPlayerData();
            if (playerData != null && playerData.playerName != "")
            {
                MessageBox.Show("Welcome to the game" + playerData.playerName + "Level:" + playerData.playerLevel + "Class:" + playerData.playerClass + "Strength:" + playerData.playerStrength + "Dexterity:" + playerData.playerDexterity + "Stamina:" + playerData.playerStamina + "Intellect:" + playerData.playerIntellect + "Focus:" + playerData.playerFocus + "Wisdom:" + playerData.playerWisdom);
            }
            else
            {
                MessageBox.Show("playerData Failed");
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
        public void setNewCharacterData()
        {
            Random random = new Random();
            double experienceMultiplier = 9.75;
            double quadraticCoefficient = 1.5;
            int playerLevel = Convert.ToInt32(levelLabel.Content.ToString());
            int playerStrength = 10;
            int playerDexterity = 10;
            int playerStamina = 10;
            int playerIntellect = 10;
            int playerFocus = 10;
            int playerWisdom = 10;
            int damagetaken = 32;
            int magicUsed = 0;
            int playerGold = 100;
            int skillPoints = 10;
            int playerHealth = 100 + (playerStamina * random.Next(10));
            int playerMagic = 100 + (playerWisdom * random.Next(10));
            int maxExP = 1000;

            levelLabel.Content = 1;
            strengthLabel.Content = playerStrength;
            dexterityLabel.Content = 10;
            staminaLabel.Content = 10;
            intellectLabel.Content = 10;
            focusLabel.Content = 10;
            wisdomLabel.Content = 10;
            classListBox.SelectedIndex = 0;
            HealthBar.Value = playerHealth - damagetaken;
            HealthBar.Maximum = playerHealth;
            MagicBar.Value = playerMagic - magicUsed;
            MagicBar.Maximum = playerMagic;
            ExPBar.Value = 0;
            ExPBar.Maximum = maxExP;
        }
        public void getPlayerData()
        {
            string playerName = NameTextBox.Text;
            string? pClass = classLabel.Content.ToString();
            int playerLevel = Convert.ToInt32(levelLabel.Content.ToString());
            int playerStrength = Convert.ToInt32(strengthLabel.Content.ToString());
            int playerDexterity = Convert.ToInt32(dexterityLabel.Content.ToString());
            int playerStamina = Convert.ToInt32(staminaLabel.Content.ToString());
            int playerIntellect = Convert.ToInt32(intellectLabel.Content.ToString());
            int playerFocus = Convert.ToInt32(focusLabel.Content.ToString());
            int playerWisdom = Convert.ToInt32(wisdomLabel.Content.ToString());
            int damagetaken = 0;
            int magicUsed = 0;
            int playerGold = 0;
            int skillPoints = 0;
            int playerHealth = 0;
            int playerMagic = 0;
            playerData = new PlayerData(playerName, playerLevel, pClass, playerStrength, playerDexterity, playerStamina, playerIntellect, playerFocus, playerWisdom, damagetaken, magicUsed, playerGold, skillPoints, playerHealth, playerMagic);


        }
        public void getSheetUpdate()
        {
            int pCurrentHealth = HealthBar.Value;
            int pCurrentMagic = MagicBar.Value;
            int pHealthStep = pCurrentHealth - currentAdjustedHP;
            int pMagicStep = pCurrentMagic - currentAdjustedMP;

            int pHealth = pHealthStep + totalAdjustedHP;
            HealthBar.Value = pHealth;
            //totalAdjustedHPshow.Text = totalAdjustedHP.ToString();

            int pMagic = pMagicStep + totalAdjustedMP;
            MagicBar.Value = pMagic;
            //totalAdjustedHPshow.Text = totalAdjustedMP.ToString();
        }
        private void addStrengthButton_Click(object sender, RoutedEventArgs e)
        {
            if (totalSP > 0)
            {
                totalSP = totalSP - 1;
                totalAdjustedSTR = totalAdjustedSTR + 1;

                int currentSTR = int.Parse(strengthLabel.Content);

                //int pMagic = 100 + ((pStamina + pIntellect) * 10);
                int addedSTR = currentSTR + 1;
                strengthLabel.Content = addedSTR.ToString();
                characterTotalSP.Content = totalSP.ToString();
                getSheetUpdate();
            }
            else
            {
                MessageBox.Show($"Not enough skill points: {totalSP}");
            }
        }
    }
    public class PlayerData
    {
        public string? playerName { get; set; }
        public int? playerLevel { get; set; }
        public string? playerClass{ get; set; }
        public int? playerStrength { get; set; }
        public int? playerDexterity { get; set; }
        public int? playerStamina { get; set; }
        public int? playerIntellect { get; set; }
        public int? playerFocus { get; set; }
        public int? playerWisdom { get; set; }
        public int? damageTaken { get; set; }
        public int? magicUsed { get; set; }
        public int? playerGold { get; set; }
        public int? skillPoints {  get; set; }
        public int? playerHealth { get; set; }
        public int? playerMagic { get; set; }



        public PlayerData(string name, int level, string pclass, int str, int dex, int stamina, int intel, int focus, int wisd, int playerDamage, int UseMagic, int goldAmount, int unusedSkillPoints, int pHealth, int pMagic)
        {
            playerName = name;
            playerLevel = level;
            playerClass = pclass;
            playerStrength = str;
            playerDexterity = dex;
            playerStamina = stamina;
            playerIntellect = intel;
            playerFocus = focus;
            playerWisdom = wisd;
            damageTaken = playerDamage;
            magicUsed = UseMagic;
            playerGold = goldAmount;
            skillPoints = unusedSkillPoints;
            playerHealth = pHealth;
            playerMagic = pMagic;
        }
    }
}
