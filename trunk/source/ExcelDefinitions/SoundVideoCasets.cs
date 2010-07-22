﻿using System;
using System.Runtime.InteropServices;

namespace Reanimator.ExcelDefinitions
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class SoundVideoCasetsRow
    {
        ExcelFile.TableHeader header;

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
}