﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using Reanimator.Forms;
using System.Windows.Forms;

namespace Reanimator.Excel
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct ExcelTables_Table
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public Int32[] unknown;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string szStringId;
        public Int16 id; 
    }

    public class ExcelTables : ExcelTable
    {
        List<ExcelTables_Table> tables;
        Stats stats;
        public Stats Stats
        {
            get
            {
                return this.stats;
            }
        }
        States states;

        public ExcelTables(byte[] data) : base(data) {}

        protected override void ParseTables(byte[] data)
        {
            tables = ReadTables<ExcelTables_Table>(data, ref offset, Count);
        }

        public string GetTableStringId(int index)
        {
            return tables[index].szStringId;
        }

        public bool LoadTables(string szFolder, Progress progress)
        {
            for (int i = 0; i < Count; i++)
            {
                string szStringId = GetTableStringId(i);
                string szFileName = szFolder + "\\" + szStringId + ".txt.cooked";
                FileStream cookedFile;

                string currentItem = szStringId.ToLower() + ".txt.cooked";
                progress.SetCurrentItemText(currentItem);
                progress.Refresh();

                try
                {
                    cookedFile = new FileStream(szFileName, FileMode.Open);
                }
                catch (Exception)
                {
                    try
                    {
                        szFileName = szFileName.Replace("_common", "");
                        cookedFile = new FileStream(szFileName, FileMode.Open);
                    }
                    catch (Exception)
                    {
                        progress.StepProgress();
                        continue;
                    }
                }

                byte[] buffer = FileTools.StreamToByteArray(cookedFile);
                try
                {
                    if (szStringId.Equals("STATS", StringComparison.OrdinalIgnoreCase))
                    {
                        stats = new Stats(buffer);
                    }
                    else if (szStringId.Equals("STATES", StringComparison.OrdinalIgnoreCase))
                    {
                        states = new States(buffer);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Failed to parse cooked file " + currentItem + "\n\n" + e.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                if (cookedFile != null)
                {
                    cookedFile.Dispose();
                }
                progress.StepProgress();
            }

            return true;
        }
    }
}
