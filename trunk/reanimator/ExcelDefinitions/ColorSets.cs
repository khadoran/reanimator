﻿using System;
using System.Runtime.InteropServices;
using ExcelOutput = Reanimator.ExcelFile.ExcelOutputAttribute;

namespace Reanimator.ExcelDefinitions
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class ColorSetsRow
    {
        ExcelFile.TableHeader header;

        [ExcelOutput(SortAscendingID = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string color;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        Int32[] undefined;
        [ExcelOutput(SortAscendingID = 2)]
        public Int32 code;
        [ExcelOutput(IsBool = true)]
        public Int32 canBeRandomPick;
    }
}