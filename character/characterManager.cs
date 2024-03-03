using characterData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TowerGame_V1._0._2.characterManager
{
    public class CharacterDataManager : INotifyPropertyChanged
    {
        private PlayerData player;
        private int totalAdjustedSTR;
        private int totalAdjustedDEX;
        private int totalAdjustedSTAM;
        private int totalAdjustedINTEL;
        private int totalAdjustedFOCUS;
        private int totalAdjustedWISDOM;
        
        public PlayerData Player
        {
            get => player;
            set
            {
                player = value;
                OnPropertyChanged(nameof(Player));
            }
        }

        public ICommand LevelUpCommand { get; }
        public ICommand addStrengthCommand { get; }
        public ICommand addDexterityCommand { get; }
        public ICommand addStaminaCommand { get; }
        public ICommand addIntellectCommand { get; }
        public ICommand addFocusCommand { get; }
        public ICommand addWisdomCommand { get; }

        public CharacterDataManager()
        {
            Player = new PlayerData("", "Choose a Class", 1, 100, 100, 100, 100, 10, 10, 10, 10, 10, 10, 0, 1000, 5, 15); // Initialize with default values
            LevelUpCommand = new RelayCommand(LevelUp);
            addStrengthCommand = new RelayCommand(addStrength);
            addDexterityCommand = new RelayCommand(addDexterity);
            addStaminaCommand = new RelayCommand(addStamina);
            addIntellectCommand = new RelayCommand(addIntellect);
            addFocusCommand = new RelayCommand(addFocus);
            addWisdomCommand = new RelayCommand(addWisdom);
        }

        private void addStrength() {

            if (Player.skillPoints > 0)
            {
                Player.skillPoints = Player.skillPoints - 1;
                totalAdjustedSTR = totalAdjustedSTR + 1;

                int currentSTR = Player.Strength;
                int addedSTR = currentSTR + 1;
                Player.Strength = addedSTR;
            }
            else
            {
                MessageBox.Show($"Not enough skill points: {Player.skillPoints}");
            }
        }
        private void addDexterity()
        {

            if (Player.skillPoints > 0)
            {
                Player.skillPoints = Player.skillPoints - 1;
                totalAdjustedDEX = totalAdjustedDEX + 1;

                int currentDEX = Player.Dexterity;
                int addedDEX = currentDEX + 1;
                Player.Dexterity = addedDEX;
            }
            else
            {
                MessageBox.Show($"Not enough skill points: {Player.skillPoints}");
            }
        }
        private void addStamina()
        {

            if (Player.skillPoints > 0)
            {
                Player.skillPoints = Player.skillPoints - 1;
                totalAdjustedSTAM = totalAdjustedSTAM + 1;

                int currentSTAM = Player.Stamina;
                int addedSTAM = currentSTAM + 1;
                Player.Stamina = addedSTAM;
            }
            else
            {
                MessageBox.Show($"Not enough skill points: {Player.skillPoints}");
            }
        }
        private void addIntellect()
        {

            if (Player.skillPoints > 0)
            {
                Player.skillPoints = Player.skillPoints - 1;
                totalAdjustedINTEL = totalAdjustedINTEL + 1;

                int currentINTEL = Player.Intellect;
                int addedINTEL = currentINTEL + 1;
                Player.Intellect = addedINTEL;
            }
            else
            {
                MessageBox.Show($"Not enough skill points: {Player.skillPoints}");
            }
        }
        private void addFocus()
        {

            if (Player.skillPoints > 0)
            {
                Player.skillPoints = Player.skillPoints - 1;
                totalAdjustedFOCUS = totalAdjustedFOCUS + 1;

                int currentFOCUS = Player.Focus;
                int addedFOCUS = currentFOCUS + 1;
                Player.Focus = addedFOCUS;
            }
            else
            {
                MessageBox.Show($"Not enough skill points: {Player.skillPoints}");
            }
        }
        private void addWisdom()
        {

            if (Player.skillPoints > 0)
            {
                Player.skillPoints = Player.skillPoints - 1;
                totalAdjustedWISDOM = totalAdjustedWISDOM + 1;

                int currentWISDOM = Player.Wisdom;
                int addedWISDOM = currentWISDOM + 1;
                Player.Wisdom = addedWISDOM;
            }
            else
            {
                MessageBox.Show($"Not enough skill points: {Player.skillPoints}");
            }
        }
        private void LevelUp()
        {
            Player.Health += 2;
            Player.Strength += 2;
            Player.Intellect += 2;
            Player.Dexterity += 2;
            Player.Stamina += 2;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

    public class RelayCommand : ICommand
    {
        private Action execute;

        public RelayCommand(Action execute)
        {
            this.execute = execute;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { }
            remove { }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            execute();
        }
    }
}
