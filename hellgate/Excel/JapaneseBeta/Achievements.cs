﻿using System;
using System.Runtime.InteropServices;

namespace Hellgate.Excel.JapaneseBeta
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class AchievementsBeta
    {
        ExcelFile.RowHeader header;
        Int32 undefined;
        [ExcelFile.OutputAttribute(SortColumnOrder = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public String name;
        [ExcelFile.OutputAttribute(SortColumnOrder = 2)]
        public Int32 code;
        [ExcelFile.OutputAttribute(IsStringIndex = true)]
        public Int32 nameString;
        [ExcelFile.OutputAttribute(IsStringIndex = true)]
        public Int32 descripFormatString;
        [ExcelFile.OutputAttribute(IsStringIndex = true)]
        public Int32 detailsString;
        [ExcelFile.OutputAttribute(IsStringIndex = true)]
        public Int32 rewardTypeString;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public String icon;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "ACHIEVEMENTS")]
        public Int32 linkedAchievement;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "ACHIEVEMENTS")]
        public Int32 progressionAchievement;
        public Int32 revealCondition;
        public Int32 revealValue;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "ACHIEVEMENTS")]
        public Int32 revealParentAchievement;
        public Int32 hideCondition;
        public Int32 hideValue;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "ACHIEVEMENTS")]
        public Int32 hideParentAchievement;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "UNITTYPES")]
        public Int32 playerClass0;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "UNITTYPES")]
        public Int32 playerClass1;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "UNITTYPES")]
        public Int32 playerClass2;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "UNITTYPES")]
        public Int32 playerClass3;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "UNITTYPES")]
        public Int32 playerClass4;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "UNITTYPES")]
        public Int32 playerClass5;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "UNITTYPES")]
        public Int32 playerClass6;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "UNITTYPES")]
        public Int32 playerClass7;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "UNITTYPES")]
        public Int32 playerClass8;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "UNITTYPES")]
        public Int32 playerClass9;
        public Int32 type;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "ACHIEVEMENTS")]
        public Int32 notActiveTillParentComplete;
        public Int32 completeNumber;
        public Int32 param1;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "UNITTYPES")]
        public Int32 monsterUnitType0;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "UNITTYPES")]
        public Int32 monsterUnitType1;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "UNITTYPES")]
        public Int32 monsterUnitType2;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "UNITTYPES")]
        public Int32 monsterUnitType3;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "UNITTYPES")]
        public Int32 monsterUnitType4;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "UNITTYPES")]
        public Int32 monsterUnitType5;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "UNITTYPES")]
        public Int32 monsterUnitType6;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "UNITTYPES")]
        public Int32 monsterUnitType7;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "UNITTYPES")]
        public Int32 monsterUnitType8;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "UNITTYPES")]
        public Int32 monsterUnitType9;		
        //[ExcelOutput(IsTableIndex = true, TableStringId = "")]//table C9
        public Int32 pvpGameType0;
        //[ExcelOutput(IsTableIndex = true, TableStringId = "")]
        public Int32 pvpGameType1;
        //[ExcelOutput(IsTableIndex = true, TableStringId = "")]
        public Int32 pvpGameType2;
        //[ExcelOutput(IsTableIndex = true, TableStringId = "")]
        public Int32 pvpGameType3;
        //[ExcelOutput(IsTableIndex = true, TableStringId = "")]
        public Int32 pvpGameType4;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "QUEST")]
        public Int32 questTaskComplete;
        public Int32 randomQuests;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "MONSTERS")]
        public Int32 monster;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "OBJECTS")]
        public Int32 Object;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "UNITTYPES")]
        public Int32 itemUnitType0;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "UNITTYPES")]
        public Int32 itemUnitType1;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "UNITTYPES")]
        public Int32 itemUnitType2;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "UNITTYPES")]
        public Int32 itemUnitType3;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "UNITTYPES")]
        public Int32 itemUnitType4;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "UNITTYPES")]
        public Int32 itemUnitType5;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "UNITTYPES")]
        public Int32 itemUnitType6;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "UNITTYPES")]
        public Int32 itemUnitType7;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "UNITTYPES")]
        public Int32 itemUnitType8;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "UNITTYPES")]
        public Int32 itemUnitType9;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "ITEM_QUALITY")]
        public Int32 quality;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "ITEMS")]
        public Int32 item;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "SKILLS")]
        public Int32 skill;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "LEVEL")]
        public Int32 level;
        //[ExcelOutput(IsTableIndex = true, TableStringId = "")]//table C8
        public Int32 fieldLevel;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "STATS")]
        public Int32 stat;
        public Int32 rewardAchievementPoints;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "TREASURE")]
        public Int32 rewardTreasureClass;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "EMOTES")]
        public Int32 rewardEmote;
        public Int32 rewardXP;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "SKILLS")]
        public Int32 rewardSkill;
        [ExcelFile.OutputAttribute(IsStringIndex = true)]
        public Int32 rewardTitle;
        [ExcelFile.OutputAttribute(IsScript = true)]
        public Int32 rewardScript;
		public bool cheatComplete;
        [ExcelFile.OutputAttribute(IsTableIndex = true, TableStringId = "QUEST")]
        public Int32 quest;
		
    }
}