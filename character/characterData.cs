using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace characterData
{
    public class PlayerData : INotifyPropertyChanged
    {
        private int _health;
        private int _strength;
        private int _intellect;
        private int _dexterity;
        private int _stamina;
        private int _skillpoints;

        public event PropertyChangedEventHandler? PropertyChanged;

        public int Health
        {
            get => _health;
            set
            {
                _health = value;
                OnPropertyChanged(nameof(Health));
            }
        }

        public int Strength
        {
            get => _strength;
            set
            {
                _strength = value;
                OnPropertyChanged(nameof(Strength));
            }
        }

        public int Intelligence
        {
            get => _intellect;
            set
            {
                _intellect = value;
                OnPropertyChanged(nameof(Intelligence));
            }
        }

        public int Dexterity
        {
            get => _dexterity;
            set
            {
                _dexterity = value;
                OnPropertyChanged(nameof(Dexterity));
            }
        }

        public int Stamina
        {
            get => _stamina;
            set
            {
                _stamina = value;
                OnPropertyChanged(nameof(Stamina));
            }
        }

        public int skillPoints
        {
            get => _skillpoints;
            set
            {
                _skillpoints = value;
                OnPropertyChanged(nameof(skillPoints));
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public PlayerData(int health, int strength, int intelligence, int dexterity, int stamina, int skillpoints)
        {
            Health = health;
            Strength = strength;
            Intelligence = intelligence;
            Dexterity = dexterity;
            Stamina = stamina;
            skillPoints = skillpoints;
        }
    }
}
