﻿using System;
using System.Runtime.InteropServices;
using ExcelOutput = Hellgate.ExcelFile.OutputAttribute;
using TableHeader = Hellgate.ExcelFile.TableHeader;

namespace Hellgate.Excel
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class UnitTypes
    {
        TableHeader header;
        [ExcelOutput(SortAscendingID = 1, RequiresDefault = true)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public String type;
        [ExcelOutput(SortAscendingID = 2)]
        public Int32 code;
        [ExcelOutput(IsTableIndex = true, TableStringID = "UNITTYPES")]
        public Int32 isA0;
        [ExcelOutput(IsTableIndex = true, TableStringID = "UNITTYPES")]
        public Int32 isA1;
        [ExcelOutput(IsTableIndex = true, TableStringID = "UNITTYPES")]
        public Int32 isA2;
        [ExcelOutput(IsTableIndex = true, TableStringID = "UNITTYPES")]
        public Int32 isA3;
        [ExcelOutput(IsTableIndex = true, TableStringID = "UNITTYPES")]
        public Int32 isA4;
        [ExcelOutput(IsTableIndex = true, TableStringID = "UNITTYPES")]
        public Int32 isA5;
        [ExcelOutput(IsTableIndex = true, TableStringID = "UNITTYPES")]
        public Int32 isA6;
        [ExcelOutput(IsTableIndex = true, TableStringID = "UNITTYPES")]
        public Int32 isA7;
        [ExcelOutput(IsTableIndex = true, TableStringID = "UNITTYPES")]
        public Int32 isA8;
        [ExcelOutput(IsTableIndex = true, TableStringID = "UNITTYPES")]
        public Int32 isA9;
        [ExcelOutput(IsTableIndex = true, TableStringID = "UNITTYPES")]
        public Int32 isA10;
        [ExcelOutput(IsTableIndex = true, TableStringID = "UNITTYPES")]
        public Int32 isA11;
        [ExcelOutput(IsTableIndex = true, TableStringID = "UNITTYPES")]
        public Int32 isA12;
        [ExcelOutput(IsTableIndex = true, TableStringID = "UNITTYPES")]
        public Int32 isA13;
        [ExcelOutput(IsTableIndex = true, TableStringID = "UNITTYPES")]
        public Int32 isA14;
        [ExcelOutput(IsTableIndex = true, TableStringID = "UNITTYPES")]
        public Int32 isA15;
        public Int32 String;//stridx
    }
}