﻿using System;
using System.Runtime.InteropServices;
using ExcelOutput = Hellgate.ExcelFile.OutputAttribute;
using RowHeader = Hellgate.ExcelFile.RowHeader;

namespace Hellgate.Excel.TCv4
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class AffixesTCv4
    {
        RowHeader header;

        [ExcelOutput(IsStringOffset = true, SortColumnOrder = 1)]
        public Int32 affix;
        public Int32 unknown02;
        [ExcelOutput(IsBool = true)]
        public Int32 alwaysApply;
        [ExcelOutput(IsStringIndex = true)]
        public Int32 qualityNameString;
        [ExcelOutput(IsStringIndex = true)]
        public Int32 setNameString;
        [ExcelOutput(IsStringIndex = true)]
        public Int32 magicNameString;
        [ExcelOutput(IsStringIndex = true)]
        public Int32 replaceNameString;
        [ExcelOutput(IsStringIndex = true)]
        public Int32 flavorText;
        public Int32 unknown03;
        public Int32 nameColor;
        public Int32 gridColor;
        public Int32 dom;
        [ExcelOutput(SortColumnOrder = 3)]
        public Int32 code;
        [ExcelOutput(IsTableIndex = true, TableStringId = "AFFIXTYPES", SortColumnOrder = 2, SecondarySortColumn = "code")]
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
        [ExcelOutput(SortColumnOrder = 4, IsTableIndex = true, TableStringId = "_TCv4_AFFIX_GROUP")] // not secondary string like SP version
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
        [ExcelOutput(IsScript = true)]
        public Int32 weight;
        public Int32 luckWeight;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        Int32[] unknown04;
        public Int32 colorSet;
        public Int32 colorSetPriority;
        public Int32 state;
        public Int32 saveState;
        [ExcelOutput(IsScript = true)]
        public Int32 buyPriceMulti;
        [ExcelOutput(IsScript = true)]
        public Int32 buyPriceAdd;
        [ExcelOutput(IsScript = true)]
        public Int32 sellPriceMulti;
        [ExcelOutput(IsScript = true)]
        public Int32 sellPriceAdd;
        [ExcelOutput(IsScript = true)]
        public Int32 cond;
        public Int32 itemLevel;
        public Int32 prop1Cond;
        public Int32 prop2Cond;
        public Int32 prop3Cond;
        public Int32 prop4Cond;
        public Int32 prop5Cond;
        public Int32 prop6Cond;
        [ExcelOutput(IsScript = true)]
        public Int32 property1;
        [ExcelOutput(IsScript = true)]
        public Int32 property2;
        [ExcelOutput(IsScript = true)]
        public Int32 property3;
        [ExcelOutput(IsScript = true)]
        public Int32 property4;
        [ExcelOutput(IsScript = true)]
        public Int32 property5;
        [ExcelOutput(IsScript = true)]
        public Int32 property6;
        [ExcelOutput(IsScript = true)]
        public Int32 statsFeed_tcv4;
        [ExcelOutput(IsTableIndex = true, TableStringId = "UNITTYPES")]
        public Int32 onlyOnItemsRequiringUnitType;
        public Int32 undefined_tcv4;
    }
}