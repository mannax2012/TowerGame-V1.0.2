using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classDataManagment;
using System.Data.SQLite;
using System.Data;
using characterData;
using System.Windows;

namespace TowerGame_V1._0._2.classes
{
    internal class classManager
    {
        
        PlayerData? playerData;
        List<classData>? playerClasses;
        public void getClassBonus(string name)
        {
            
                string selectedClassName = name;
                if (selectedClassName != null)
                {
                    MessageBox.Show($"Name:'{selectedClassName}'");
                    classData? selectedClass = playerClasses?.FirstOrDefault(pc => pc.ClassName == selectedClassName);
                    MessageBox.Show($"Name2:'{selectedClass}'");
                    if (selectedClass != null && playerData != null)
                    {
                    playerData.Strength += selectedClass.bonusSTR;
                    playerData.Dexterity += selectedClass.bonusDEX;
                    playerData.Stamina += selectedClass.bonusSTAM;
                    playerData.Intellect += selectedClass.bonusINTEL;
                    playerData.Focus += selectedClass.bonusFocus;
                    playerData.Wisdom += selectedClass.bonusWisdom;
                    MessageBox.Show($"BonusSTR:'{selectedClass.bonusSTR}'");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a class.");
                }
        }
        
    }
}
