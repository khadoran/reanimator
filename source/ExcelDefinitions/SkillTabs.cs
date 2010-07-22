﻿using System;
using System.Runtime.InteropServices;

namespace Reanimator.ExcelDefinitions
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class SkillTabsRow
    {
        ExcelFile.TableHeader header;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string name;

        public Int32 code;
        public Int32 displayString;//stridx
        public Int32 drawOnlyKnown;//bool
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string iconTextureName;
    }
}
