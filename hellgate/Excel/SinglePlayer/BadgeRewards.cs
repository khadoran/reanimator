﻿using System;
using System.Runtime.InteropServices;
using ExcelOutput = Hellgate.ExcelFile.OutputAttribute;
using RowHeader = Hellgate.ExcelFile.RowHeader;

namespace Hellgate.Excel
{
    [Serializable, StructLayout(LayoutKind.Sequential, Pack = 1)]
    class BadgeRewards
    {
        RowHeader header;
        [ExcelOutput(SortColumnOrder = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string badgeRewardName;
        [ExcelOutput(SortColumnOrder = 2)]
        public Int32 code;
        public Int32 badgeName;
        [ExcelOutput(IsTableIndex = true, TableStringId = "ITEMS")]
        public Int32 item;//idx
        public Int32 dontApplyIfPlayerHasRewardItemFor;
        [ExcelOutput(IsTableIndex = true, TableStringId = "STATES")]
        public Int32 state;//idx
    }
}
