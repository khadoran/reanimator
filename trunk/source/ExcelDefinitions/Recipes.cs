﻿using System;
using System.Runtime.InteropServices;

namespace Reanimator.ExcelDefinitions
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class RecipesRow
    {
        ExcelFile.TableHeader header;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string recipe;

        public Int32 String;
        public Int32 code;
        public Int32 cubeRecipe;
        public Int32 alwaysKnown;
        public Int32 dontRequireExactIngredients;
        public Int32 allowInRandomSingleUse;
        public Int32 removeOnLoad;
        public Int32 weight;
        public Int32 experienceEarned;
        public Int32 goldReward;
        public Int32 resultQualityModifiesIngredientQuantity;
        public Int32 ingredient1ItemClass;
        public Int32 ingredient1UnitType;
        public Int32 ingredient1ItemQuality;
        public Int32 ingredient1MinQuantity;
        public Int32 ingredient1MaxQuantity;
        public Int32 ingredient2ItemClass;
        public Int32 ingredient2UnitType;
        public Int32 ingredient2ItemQuality;
        public Int32 ingredient2MinQuantity;
        public Int32 ingredient2MaxQuantity;
        public Int32 ingredient3ItemClass;
        public Int32 ingredient3UnitType;
        public Int32 ingredient3ItemQuality;
        public Int32 ingredient3MinQuantity;
        public Int32 ingredient3MaxQuantity;
        public Int32 ingredient4ItemClass;
        public Int32 ingredient4UnitType;
        public Int32 ingredient4ItemQuality;
        public Int32 ingredient4MinQuantity;
        public Int32 ingredient4MaxQuantity;
        public Int32 ingredient5ItemClass;
        public Int32 ingredient5UnitType;
        public Int32 ingredient5ItemQuality;
        public Int32 ingredient5MinQuantity;
        public Int32 ingredient5MaxQuantity;
        public Int32 ingredient6ItemClass;
        public Int32 ingredient6UnitType;
        public Int32 ingredient6ItemQuality;
        public Int32 ingredient6MinQuantity;
        public Int32 ingredient6MaxQuantity;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public Int32[] craftResult;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public Int32[] treasureResult;
        public Int32 mustPlaceInInvSlot;
        public Int32 canBeLearned;//can be learned bit 0, can spawn bit 1
        public Int32 spawnLevelMin;
        public Int32 spawnLevelMax;
    }
}