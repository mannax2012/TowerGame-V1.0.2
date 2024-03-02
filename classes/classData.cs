using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classDataManagment
{
    internal class classData
    { 
            public string ClassName { get; set; }
            public int bonusSTR { get; set; }
            public int bonusDEX { get; set; }
            public int bonusSTAM { get; set; }
            public int bonusINTEL { get; set; }
            public int bonusFocus { get; set; }
            public int bonusWisdom {  get; set; }


            public classData(string name, int str, int dex, int stam, int intel, int focus, int wisdom)
            {
                ClassName = name;
                bonusSTR = str;
                bonusDEX = dex;
                bonusSTAM = stam;
                bonusINTEL = intel;
                bonusFocus = focus;
                bonusWisdom = wisdom;
                
            }
     }
    
}
