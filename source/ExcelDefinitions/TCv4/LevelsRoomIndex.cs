﻿using System;
using System.Runtime.InteropServices;
using ExcelOutput = Reanimator.ExcelFile.ExcelOutputAttribute;

namespace Reanimator.ExcelDefinitions
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class LevelsRoomIndexTCv4Row
    {
        ExcelFile.TableHeader header;

        [ExcelOutput(SortId = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string name;
        [ExcelOutput(IsBool = true)]
        public Int32 outDoor;//bool;
        [ExcelOutput(IsBool = true)]
        public Int32 outDoorVisibility;//bool;
        [ExcelOutput(IsBool = true)]
        public Int32 computeAmbientOcclusion;//bool;
        [ExcelOutput(IsBool = true)]
        public Int32 noMonsterSpawn;//bool
        [ExcelOutput(IsBool = true)]
        public Int32 noAdventures;//bool
        [ExcelOutput(IsBool = true)]
        public Int32 noSubLevelEntrance;//bool
        [ExcelOutput(IsBool = true)]
        public Int32 occupiesNodes;//bool
        [ExcelOutput(IsBool = true)]
        public Int32 raisesNodes;//bool
        [ExcelOutput(IsBool = true)]
        public Int32 fullCollision;//bool
        [ExcelOutput(IsBool = true)]
        public Int32 dontObstructSound;//bool
        [ExcelOutput(IsBool = true)]
        public Int32 dontOccludeVisibility;//bool
        [ExcelOutput(IsBool = true)]
        public Int32 thirdPersonCameraIgnore;//bool
        [ExcelOutput(IsBool = true)]
        public Int32 rtsCameraIgnore;//bool
        public Int32 havokSliceType;
        public Int32 roomVersion;
        public float nodeBuffer;
        [ExcelOutput(Exclude = true)]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        Int32[] TCV4_1;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        Int32[] undefined1;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string reverbEnvironment;
        [ExcelOutput(Exclude = true)]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 68)]
        Int32[] TCV4_2;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        Int32[] undefined2;
        public Int32 backGroundSound;//idx
        public Int32 noGore;//idx;
        public Int32 noHumans;//idx
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        Int32[] undefined3;
    }
}