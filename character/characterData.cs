using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace characterData
{
    public class PlayerData : INotifyPropertyChanged
    {
        private string _name;
        private string _class;
        private int _level;
        private int _health;
        private int _healthMax;
        private int _magic;
        private int _magicMax;
        private int _strength;
        private int _dexterity;
        private int _stamina;
        private int _intellect;
        private int _focus;
        private int _wisdom;
        private int _experience;
        private int _experienceMax;
        private int _currency;
        private int _skillpoints;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Class
        {
            get => _class;
            set
            {
                _class = value;
                OnPropertyChanged(nameof(Class));
            }
        }

        public int Level
        {
            get => _level;
            set
            {
                _level = value;
                OnPropertyChanged(nameof(Level));
            }
        }
        public int Health
        {
            get => _health;
            set
            {
                _health = value;
                OnPropertyChanged(nameof(Health));
            }
        }

        public int HealthMax
        {
            get => _healthMax;
            set
            {
                _healthMax = value;
                OnPropertyChanged(nameof(HealthMax));
            }
        }

        public int Magic
        {
            get => _magic;
            set
            {
                _magic = value;
                OnPropertyChanged(nameof(Magic));
            }
        }

        public int MagicMax
        {
            get => _magicMax;
            set
            {
                _magicMax = value;
                OnPropertyChanged(nameof(MagicMax));
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

        public int Intellect
        {
            get => _intellect;
            set
            {
                _intellect = value;
                OnPropertyChanged(nameof(Intellect));
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
        public int Focus
        {
            get => _focus;
            set
            {
                _focus = value;
                OnPropertyChanged(nameof(Focus));
            }
        }
        public int Wisdom
        {
            get => _wisdom;
            set
            {
                _wisdom = value;
                OnPropertyChanged(nameof(Wisdom));
            }
        }
        public int ExP
        {
            get => _experience;
            set
            {
                _experience = value;
                OnPropertyChanged(nameof(ExP));
            }
        }
        public int ExPMax
        {
            get => _experienceMax;
            set
            {
                _experienceMax = value;
                OnPropertyChanged(nameof(ExPMax));
            }
        }
        public int Currency
        {
            get => _currency;
            set
            {
                _currency = value;
                OnPropertyChanged(nameof(Currency));
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

        public PlayerData(string name, string pclass, int level, int health, int healthMax, int magic, int magicMax, int strength, int dexterity, int stamina, int intellect, int focus, int wisdom, int pExP, int pExPMax, int currency, int skillpoints)
        {
            Name = name;
            Class = pclass;
            Level = level;
            Health = health;
            HealthMax = healthMax;
            Magic = magic;
            MagicMax = magicMax;
            Strength = strength;
            Dexterity = dexterity;
            Stamina = stamina;
            Intellect = intellect;
            Focus = focus;
            Wisdom = wisdom;
            ExP = pExP;
            ExPMax = pExPMax;
            Currency = currency;
            skillPoints = skillpoints;
        }
    }
}