﻿using System;
using System.Runtime.InteropServices;
using ExcelOutput = Hellgate.ExcelFile.OutputAttribute;
using TableHeader = Hellgate.ExcelFile.TableHeader;

namespace Hellgate.Excel.Tc
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class Stats
    {
        TableHeader header;
        [ExcelOutput(SortAscendingID = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string stat;
        [ExcelOutput(SortAscendingID = 2)]
        public Int32 code;
        public Int32 type;
        public Int32 assocStat1;
        public Int32 assocStat2;
        public Int32 regenIntervalInMS;
        public Int32 regenDivisor;
        public Int32 regenDelayOnDec;
        public Int32 regenDelayOnZero;
        public Int32 regenDelayMonster;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        byte[] undefined1;
        public Int32 offset;
        public Int32 shift;
        public Int32 minSet;
        public Int32 maxSet;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte[] undefined3;
        public Int32 minAssert;
        public Int32 maxAssert;
        public Int32 undefined4;
        public Int32 accrueToTypes1;
        public Int32 accrueToTypes2;
        public Int32 unitType;
        [ExcelOutput(IsBitmask = true, DefaultBitmask = 0)]
        public BitMask01 bitmask01;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte[] undefined5;
        [ExcelOutput(IsBool = true)]
        public Int32 player;
        [ExcelOutput(IsBool = true)]
        public Int32 monster;
        [ExcelOutput(IsBool = true)]
        public Int32 missile;
        [ExcelOutput(IsBool = true)]
        public Int32 item;
        [ExcelOutput(IsBool = true)]
        public Int32 Object;
        public Int32 valbits;
        public Int32 valWindow;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte[] undefined6;
        public Int32 valShift;
        public Int32 valOffs;
        public Int32 valTable;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        byte[] undefined7;
        public Int32 param1Bits;
        public Int32 param2Bits;
        public Int32 param3Bits;
        public Int32 param4Bits;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        byte[] undefined8;
        public Int32 param1Shift;
        public Int32 param2Shift;
        public Int32 param3Shift;
        public Int32 param4Shift;
        public Int32 param1Offs;
        public Int32 param2Offs;
        public Int32 param3Offs;
        public Int32 param4Offs;
        public Int32 param1Table;
        public Int32 param2Table;
        public Int32 param3Table;
        public Int32 param4Table;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        byte[] undefined9;
        public Int32 minTicksBetweenDbCommand;
        public Int32 databaseUnitField;
        public Int32 databaseOperationContext_tcv4;
        public Int32 specFunc;
        public Int32 sfStat1;
        public Int32 sfStat2;
        public Int32 sfStat3;
        public Int32 sfStat4;
        public Int32 sfStat5_tcv4;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 28)]
        byte[] undefined10;
        public Int32 checkAgainstTypes1;
        public Int32 checkAgainstTypes2;
        public Int32 reqFailString;//stridx
        public Int32 reqFailStringHellgate;
        public Int32 reqFailStringMythos;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        byte[] undefined11;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string versionFunction;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        byte[] undefined12;
        public Int32 sendToOthersStat_tcv4;
        public Int32 undefined4_tcv4;

        [FlagsAttribute]
        public enum BitMask01 : uint
        {
            _undefined1_tcv4 = (1 << 0),
            cur = (1 << 1),
            modList = (1 << 2),
            vector = (1 << 3),
            Float = (1 << 4),
            _undefined2_tcv4 = (1 << 5),
            accrue = (1 << 6),
            accrueOnceOnly = (1 << 7),
            combat = (1 << 8),
            directDmg = (1 << 9),
            send = (1 << 10),
            sendAll = (1 << 11),
            _undefined3_tcv4 = (1 << 12),
            save = (1 << 13),
            _undefined4_tcv4 = (1 << 14),
            noMaxCurWhenDead = (1 << 15),
            stateMonitorsC = (1 << 16),
            stateMonitorsS = (1 << 17),
            transfer = (1 << 18),
            transferToMissile = (1 << 19),
            calcRider = (1 << 20),
            calc = (1 << 21),
            updateDatabase = (1 << 22),
            dontTranferToNonWeaponMissile = (1 << 23),
            _undefined5_tcv4 = (1 << 24),
            clearOnItemRestore_tcv4 = (1 << 25),
            exposeInDataService_tcv4 = (1 << 26)
        }
    }
}