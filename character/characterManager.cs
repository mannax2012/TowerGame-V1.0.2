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

        public CharacterDataManager()
        {
            Player = new PlayerData(10, 10, 10, 10, 10, 15); // Initialize with default values
            LevelUpCommand = new RelayCommand(LevelUp);
            addStrengthCommand = new RelayCommand(LevelUpSTR);
        }

        private void LevelUpSTR() {

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

        private void LevelUp()
        {
            Player.Health += 2;
            Player.Strength += 2;
            Player.Intelligence += 2;
            Player.Dexterity += 2;
            Player.Stamina += 2;
        }

        public event PropertyChangedEventHandler PropertyChanged;

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

        public event EventHandler CanExecuteChanged
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
