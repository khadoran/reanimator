﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Reanimator.Excel
{
    public class SoundVcaSets : ExcelTable
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        class SoundVcaSetsTable
        {
            TableHeader header;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string name;

            public Int32 vca1;//idx
            public Int32 vca2;//idx
            public Int32 vca3;//idx
            public Int32 vca4;//idx
            public Int32 vca5;//idx
            public Int32 vca6;//idx
            public Int32 vca7;//idx
            public Int32 vca8;//idx
        }

        public SoundVcaSets(byte[] data) : base(data) { }

        protected override void ParseTables(byte[] data)
        {
            ReadTables<SoundVcaSetsTable>(data, ref offset, Count);
        }
    }
}
