﻿using System;
using System.Runtime.InteropServices;
using ExcelOutput = Hellgate.ExcelFile.OutputAttribute;
using RowHeader = Hellgate.ExcelFile.RowHeader;

namespace Hellgate.Excel
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class AnimationGroups
    {
        RowHeader header;
        [ExcelOutput(SortColumnOrder = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string name;
        [ExcelOutput(IsBool = true)]
        public Int32 playRightLeft;
        [ExcelOutput(IsBool = true)]
        public Int32 playLegs;
        [ExcelOutput(IsBool = true)]
        public Int32 onlyPlaySubGroups;
        [ExcelOutput(IsBool = true)]
        public Int32 showInHammer;
        [ExcelOutput(IsBool = true)]
        public Int32 copyFootSteps;
        public Int32 defaultStance;//idx
        public Int32 defaultStanceInTown;//idx
        [ExcelOutput(IsBool = true)]
        public Int32 canStartSkillWithLeftweapon;
        public float secondsToHoldStanceInTown;
        public Int32 undefined;
        public Int32 fallback;//idx
        public Int32 rightWeapon;//idx
        public Int32 leftWeapon;//idx
        public Int32 rightAnims;//idx
        public Int32 leftAnims;//idx
        public Int32 legAnims;//idx
    }
}
