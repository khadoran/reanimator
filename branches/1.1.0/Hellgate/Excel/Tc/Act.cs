﻿using System;
using System.Runtime.InteropServices;
using ExcelOutput = Reanimator.ExcelFile.ExcelOutputAttribute;

namespace Reanimator.ExcelDefinitions
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class ActTCv4Row
    {
        ExcelFile.TableHeader header;

        [ExcelOutput(SortId = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string name;
        [ExcelOutput(SortId = 2)]
        public Int32 code;
        [ExcelOutput(IsBitmask = true, DefaultBitmask = 0)]
        public Act.BitMask01 bitmask01;
        public Int32 minimumExperienceLevelToEnter_tcv4;

        public abstract class Act
        {
            [FlagsAttribute]
            public enum BitMask01 : uint
            {
                betaAccountCanPlay = 1,
                nonSubScriberAccountCanPlay = 2,
                trialAccountCanPlay = 4
            }
        }
    }
}