﻿using System;
using System.Runtime.InteropServices;
using ExcelOutput = Reanimator.ExcelFile.ExcelOutputAttribute;

namespace Reanimator.ExcelDefinitions
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class LevelsDrlgChoiceRow
    {
        ExcelFile.TableHeader header;
        [ExcelFile.ExcelOutput(IsStringOffset = true, SortId = 1)]
        public Int32 name; //pchar
        public Int32 undefined1;
        public float namedMonsterChance;
        public Int32 undefined2;
        public Int32 levelName;//idx
        public Int32 difficulty;//idx
        public Int32 drlg;//idx
        public Int32 spawnClass;//idx
        public Int32 namedMonsterClass;//idx
        public Int32 weight;
        public Int32 music;//idx
        public Int32 environmentOverRide;//idx
        public float environmentSpawnClassRoomDensity;
        public Int32 environmentSpawnClass;//idx
        [ExcelOutput(SortId = 2)]
        public Int32 code;
        public Int32 undefined3;
    }
}