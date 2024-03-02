/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Reflection.PortableExecutable;
using System.Windows.Media;
using System.Xml.Linq;
using System.ComponentModel;
namespace TowerGame_V1._0._2
{
    class characterManagement
    {
        public static string connectionString { get; } = @"Data Source=characters.db;Version=3;";
        public static void playerLevelUpData(PlayerData player)
        {
            Random random = new Random();
            double experienceMultiplier = 9.75;
            double quadraticCoefficient = 1.5;
            int playerEXP = Convert.ToInt32(player.playerExP);
            int pLevel = Convert.ToInt32(player.playerLevel);
            string? playerName = Convert.ToString(player.playerName);
            string? playerClass = Convert.ToString(player.playerClass);

            int pStrength = Convert.ToInt32(player.playerStrength);
            int pDexterity = Convert.ToInt32(player.playerDexterity);
            int pStamina = Convert.ToInt32(player.playerStamina);
           
            int pIntellect = Convert.ToInt32(player.playerIntellect);
            int pFocus = Convert.ToInt32(player.playerFocus);
            int pWisdom = Convert.ToInt32(player.playerWisdom);
            int pHealth = Convert.ToInt32(player.playerHealth);
            int pHealthMax = Convert.ToInt32(player.playerHealthMax);
            int pMagic = Convert.ToInt32(player.playerMagic);
            int pMagicMax = Convert.ToInt32(player.playerMagicMax);
            int pExP = Convert.ToInt32(player.playerExP);
            int pExPMax = Convert.ToInt32(player.playerExPMAX);
            int skillpointTotal = Convert.ToInt32(player.skillPoints);

            int maxEXPnew = pExPMax+ (int)(10 * (experienceMultiplier * Math.Pow(pLevel, 2)) + (quadraticCoefficient * pLevel));
            int maxHPnew = pHealthMax + ((pStamina + pStrength) * 2);
            int maxMPnew = pMagicMax + ((pStamina + pIntellect) * 2);
            int STRnew = random.Next(10);
            int DEXnew = random.Next(10);
            int INTELnew = random.Next(10);
            int STAMnew = random.Next(10);
            int newSkillPoints = 5;


            player.playerLevel = pLevel + 1;
            player.playerExPMAX += maxEXPnew;
            player.playerStrength += STRnew;
            player.playerStamina += STAMnew;
            player.playerDexterity += DEXnew;
            player.playerIntellect += INTELnew;
            player.playerHealthMax = maxHPnew;
            player.playerMagicMax = maxMPnew;
            player.skillPoints += newSkillPoints;
        }
    }
    public class DatabaseManagement
    {
        public static string connectionString { get; } = @"Data Source=characters.db;Version=3;";
        public void InitializeDatabase()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string createTableQuery = "CREATE TABLE IF NOT EXISTS Characters (Name TEXT, ClassName TEXT, Level INTEGER, Health INTEGER, HealthMax INTEGER, Magic INTEGER, MagicMax INTEGER, Strength INTEGER, Dexterity INTEGER, Intellect INTEGER, Stamina INTEGER, CurrentEXP INTEGER, EXPMAX INTEGER, SkillPoints INTEGER, playerCurrency INTEGER, inventorySlotCount INTEGER)";
                SQLiteCommand createTableCommand = new SQLiteCommand(createTableQuery, connection);
                createTableCommand.ExecuteNonQuery();
            }
        }
        public void deleteCharacter(string playerName)
        {

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM Characters WHERE Name = @Name";
                SQLiteCommand deleteCommand = new SQLiteCommand(deleteQuery, connection);
                deleteCommand.Parameters.AddWithValue("@Name", playerName);
                deleteCommand.ExecuteNonQuery();
            }
        }
    }
    public class PlayerData
    {
        public string? playerName { get; set; }
        public int? playerLevel { get; set; }
        public int? playerExP { get; set; }
        public int? playerExPMAX { get; set; }
        public string? playerClass { get; set; }
        public int? playerStrength { get; set; }
        public int? playerDexterity { get; set; }
        public int? playerStamina { get; set; }
        public int? playerIntellect { get; set; }
        public int? playerFocus { get; set; }
        public int? playerWisdom { get; set; }
        public int? damageTaken { get; set; }
        public int? magicUsed { get; set; }
        public int? playerGold { get; set; }
        public int? skillPoints { get; set; }
        public int? playerHealth { get; set; }
        public int? playerHealthMax { get; set; }
        public int? playerMagic { get; set; }
        public int? playerMagicMax { get; set; }


        public PlayerData(string name, int level, int ExP, int ExPMax, string pclass, int str, int dex, int stamina, int intel, int focus, int wisd, int playerDamage, int UseMagic, int goldAmount, int unusedSkillPoints, int pHealth, int pHealthMax, int pMagic, int pMagicMax)
        {
            playerName = name;
            playerLevel = level;
            playerExP = ExP;
            playerExPMAX = ExPMax;
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
            playerHealthMax = pHealthMax;
            playerMagic = pMagic;
            playerMagicMax = pMagicMax;
        }
    }
}
*/