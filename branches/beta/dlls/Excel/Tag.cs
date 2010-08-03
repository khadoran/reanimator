﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Reanimator.Excel
{
    public class Tag : ExcelTable
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        class TagTable
        {
            TableHeader header;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string name;

            public Int32 code;
            public Int32 isValueTime;//bool
            public Int32 isHotKey;//bool
        }

        public Tag(byte[] data) : base(data) { }

        protected override void ParseTables(byte[] data)
        {
            ReadTables<TagTable>(data, ref offset, Count);
        }
    }
}