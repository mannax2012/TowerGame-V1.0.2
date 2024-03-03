using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classDataManagment
{
    internal class classData
    { 
            public string ClassName { get; }
            public int bonusSTR { get; }
            public int bonusDEX { get; }
            public int bonusSTAM { get; }
            public int bonusINTEL { get; }
            public int bonusFocus { get; }
            public int bonusWisdom {  get; }


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
