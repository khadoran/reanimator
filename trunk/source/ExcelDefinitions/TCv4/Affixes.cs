﻿using System;
using System.Runtime.InteropServices;
using ExcelOutput = Reanimator.ExcelFile.ExcelOutputAttribute;

namespace Reanimator.ExcelDefinitions
{
    // TODO: what are SortId 2 & 4?
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class AffixesTCv4Row
    {
        ExcelFile.TableHeader header;

        [ExcelOutput(IsStringOffset = true, SortId = 1)]
        public Int32 affix;
        Int32 unknown02;
        [ExcelOutput(IsBool = true)]
        public Int32 alwaysApply;
        [ExcelOutput(IsStringId = true, TableStringId = "Strings_Affix")]
        Int32 qualityNameString;
        [ExcelOutput(IsStringId = true, TableStringId = "Strings_Affix")]
        public Int32 setNameString;
        [ExcelOutput(IsStringId = true, TableStringId = "Strings_Affix")]
        public Int32 magicNameString;
        [ExcelOutput(IsStringId = true, TableStringId = "Strings_Affix")]
        Int32 replaceNameString;
        [ExcelOutput(IsStringId = true, TableStringId = "Strings_Affix")]
        Int32 flavorText;
        public Int32 unknown03;
        Int32 nameColor;
        Int32 gridColor;
        public Int32 dom;
        [ExcelOutput(SortId = 3)]
        public Int32 code;
        [ExcelOutput(IsTableIndex = true, TableStringId = "AFFIXTYPES")]
        public Int32 affixType1;
        [ExcelOutput(IsTableIndex = true, TableStringId = "AFFIXTYPES")]
        public Int32 affixType2;
        [ExcelOutput(IsTableIndex = true, TableStringId = "AFFIXTYPES")]
        public Int32 affixType3;
        [ExcelOutput(IsTableIndex = true, TableStringId = "AFFIXTYPES")]
        public Int32 affixType4;
        [ExcelOutput(IsTableIndex = true, TableStringId = "AFFIXTYPES")]
        public Int32 affixType5;
        [ExcelOutput(IsTableIndex = true, TableStringId = "AFFIXTYPES")]
        public Int32 affixType6;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        //Int32[] affixtype_TCV4;
        public Int32 affixType7;
        public Int32 affixType8;
        public Int32 affixType9;
        public Int32 affixType10;
        public Int32 affixType11;
        public Int32 affixType12;
        public Int32 affixType13;
        public Int32 affixType14;
        public Int32 affixType15;
        public Int32 suffix;
        [ExcelOutput(IsStringOffset = true)]
        public Int32 group;
        public Int32 style;
        [ExcelOutput(IsBool = true)]
        public Int32 useWhenAugmenting;
        [ExcelOutput(IsBool = true)]
        public Int32 spawn;
        public Int32 minLevel;
        public Int32 maxLevel;
        [ExcelOutput(IsTableIndex = true, TableStringId = "UNITTYPES")]
        public Int32 allowTypes1;
        [ExcelOutput(IsTableIndex = true, TableStringId = "UNITTYPES")]
        public Int32 allowTypes2;
        [ExcelOutput(IsTableIndex = true, TableStringId = "UNITTYPES")]
        public Int32 allowTypes3;
        [ExcelOutput(IsTableIndex = true, TableStringId = "UNITTYPES")]
        public Int32 allowTypes4;
        [ExcelOutput(IsTableIndex = true, TableStringId = "UNITTYPES")]
        public Int32 allowTypes5;
        [ExcelOutput(IsTableIndex = true, TableStringId = "UNITTYPES")]
        public Int32 allowTypes6;
        [ExcelOutput(IsIntOffset = true)]
        public Int32 weight;
        Int32 luckWeight;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        Int32[] unknown04;
        public Int32 colorSet;
        public Int32 colorSetPriority;
        public Int32 state;
        Int32 saveState;
        [ExcelOutput(IsIntOffset = true)]
        public Int32 buyPriceMulti;
        [ExcelOutput(IsIntOffset = true)]
        public Int32 buyPriceAdd;
        [ExcelOutput(IsIntOffset = true)]
        public Int32 sellPriceMulti;
        [ExcelOutput(IsIntOffset = true)]
        public Int32 sellPriceAdd;
        [ExcelOutput(IsIntOffset = true)]
        public Int32 cond;
        public Int32 itemLevel;
        public Int32 prop1Cond;
        public Int32 prop2Cond;
        public Int32 prop3Cond;
        public Int32 prop4Cond;
        public Int32 prop5Cond;
        public Int32 prop6Cond;
        [ExcelOutput(IsIntOffset = true)]
        public Int32 property1;
        [ExcelOutput(IsIntOffset = true)]
        public Int32 property2;
        [ExcelOutput(IsIntOffset = true)]
        public Int32 property3;
        [ExcelOutput(IsIntOffset = true)]
        public Int32 property4;
        [ExcelOutput(IsIntOffset = true)]
        public Int32 property5;
        [ExcelOutput(IsIntOffset = true)]
        public Int32 property6;
        [ExcelOutput(IsIntOffset = true)]
        public Int32 statsFeed_TCv4;
        [ExcelOutput(IsTableIndex = true, TableStringId = "UNITTYPES")]
        public Int32 onlyOnItemsRequiringUnitType;
        public Int32 undefined_TCv4;
    }
}
