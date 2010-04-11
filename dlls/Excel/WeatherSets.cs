﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Reanimator.Excel
{
    public class WeatherSets : ExcelTable
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        class WeatherSetsTable
        {
            TableHeader header;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string name;

            public Int32 weather1;//idx
            public Int32 weight1;
            public Int32 weather2;//idx
            public Int32 weight2;
            public Int32 weather3;//idx
            public Int32 weight3;
            public Int32 weather4;//idx
            public Int32 weight4;
            public Int32 weather5;//idx
            public Int32 weight5;
            public Int32 weather6;//idx
            public Int32 weight6;
            public Int32 weather7;//idx
            public Int32 weight7;
            public Int32 weather8;//idx
            public Int32 weight8;
        }

        public WeatherSets(byte[] data) : base(data) { }

        protected override void ParseTables(byte[] data)
        {
            ReadTables<WeatherSetsTable>(data, ref offset, Count);
        }
    }
}