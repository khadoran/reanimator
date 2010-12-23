﻿using System;
using System.Runtime.InteropServices;
using ExcelOutput = Hellgate.ExcelFile.OutputAttribute;
using RowHeader = Hellgate.ExcelFile.RowHeader;

namespace Hellgate.Excel
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class Npc
    {
        RowHeader header;
        [ExcelOutput(SortColumnOrder = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string name;
        public Int32 greetingGeneric;//idx
        public Int32 greetingTemplar;//idx
        public Int32 greetingCabalist;//idx
        public Int32 greetingHunter;//idx
        public Int32 greetingMale;//idx
        public Int32 greetingFemale;//idx
        public Int32 greetingFactionBad;//idx
        public Int32 greetingFactionNeutral;//idx
        public Int32 greetingFactionGood;//idx
        public Int32 goodByeGeneric;//idx
        public Int32 goodByeTemplar;//idx
        public Int32 goodByeCabalist;//idx
        public Int32 goodByeHunter;//idx
        public Int32 goodByeMale;//idx
        public Int32 goodByeFemale;//idx
        public Int32 goodByeFactionBad;//idx
        public Int32 goodByeFactionNeutral;//idx
        public Int32 goodByeFactionGood;//idx
    }
}
