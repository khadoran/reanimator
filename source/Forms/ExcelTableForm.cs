﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Reanimator.Excel;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;

namespace Reanimator.Forms
{
    public partial class ExcelTableForm : Form, IMdiChildBase
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        class TableIndexDataSource
        {
            public int Unknowns1 { get; set; }
            public int Unknowns2 { get; set; }
            public int Unknowns3 { get; set; }
            public int Unknowns4 { get; set; }
        };

        readonly ExcelTable _excelTable;
        readonly StringsFile _stringsFile;
        readonly TableDataSet _tableDataSet;
        DataView _dataView;

        public ExcelTableForm(Object table, TableDataSet tableDataSet)
        {
            _excelTable = table as ExcelTable;
            _stringsFile = table as StringsFile;
            _tableDataSet = tableDataSet;

            Init();

            ProgressForm progress = new ProgressForm(LoadTable, table);
            progress.ShowDialog(this);

            //UseDataView();
        }

        private void UseDataView()
        {
            String temp = this.dataGridView.DataMember;
            DataTable dataTable = _tableDataSet.XlsDataSet.Tables[temp];
            _dataView = dataTable.DefaultView;
            this.dataGridView.DataMember = null;
            this.dataGridView.DataSource = _dataView;
        }

        private void Init()
        {
            InitializeComponent();

            dataGridView.DoubleBuffered(true);
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView.DataSource = _tableDataSet.XlsDataSet;
            dataGridView.DataMember = null;
           // dataGridView.DataSource = _dataView;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                _dataView.Sort = tstb_sortCriteria.Text;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadTable(ProgressForm progress, Object var)
        {
            // this merely checks the table is already in the dataset
            // if not - then it will load it in
            _tableDataSet.LoadTable(progress, var);

            if (_stringsFile != null)
            {
                dataGridView.DataMember = _stringsFile.Name;
                return;
            }

            if (_excelTable != null)
            {
                dataGridView.DataMember = _excelTable.StringId;
                listBox1.DataSource = _excelTable.SecondaryStrings;
            }
            else
            {
                return;
            }

            // generate the table index data source
            // TODO is there a better way?
            // TODO remove me once unknowns no longer unknowns
            List<TableIndexDataSource> tdsList = new List<TableIndexDataSource>();
            int[][] intArrays = { _excelTable.TableIndicies, _excelTable.Unknowns1, _excelTable.Unknowns2, _excelTable.Unknowns3, _excelTable.Unknowns4 };
            for (int i = 0; i < intArrays.Length; i++)
            {
                if (intArrays[i] == null)
                {
                    continue;
                }

                for (int j = 0; j < intArrays[i].Length; j++)
                {
                    TableIndexDataSource tds;

                    if (tdsList.Count <= j)
                    {
                        tdsList.Add(new TableIndexDataSource());
                    }

                    tds = tdsList[j];
                    switch (i)
                    {
                        case 0:
                            // should we still use the "official" one?
                            // or leave as autogenerated - has anyone ever seen it NOT be ascending from 0?
                            // TODO
                            //dataGridView[i, j].Value = intArrays[i][j];
                            break;
                        case 1:
                            tds.Unknowns1 = intArrays[i][j];
                            break;
                        case 2:
                            tds.Unknowns2 = intArrays[i][j];
                            break;
                        case 3:
                            tds.Unknowns3 = intArrays[i][j];
                            break;
                        case 4:
                            tds.Unknowns4 = intArrays[i][j];
                            break;
                    }
                }
            }

            dataGridView2.DataSource = tdsList.ToArray();

            if (intArrays[4] == null)
            {
                dataGridView2.Columns.RemoveAt(3);
            }
            if (intArrays[3] == null)
            {
                dataGridView2.Columns.RemoveAt(2);
            }
            if (intArrays[2] == null)
            {
                dataGridView2.Columns.RemoveAt(1);
            }
            if (intArrays[1] == null)
            {
                dataGridView2.Columns.RemoveAt(0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*DataTable affixTable = xlsDataSet.Tables["AFFIXES"];
            EnumerableRowCollection<DataRow> query = from affix in affixTable.AsEnumerable()
                                                     where affix.Field<string>("affix").CompareTo("-1") != 0
                                                     orderby affix.Field<string>("affix_string")
                                                     select affix;

            DataView view = query.AsDataView();
            */

            /*   EnumerableRowCollection<DataRow> query2 = from affix in view.GetEnumerator()
                                                        where affix.Field<string>("affix_string").StartsWith("Pet")
                                                        orderby affix.Field<string>("affix_string")
                                                        select affix;

               view = query2.AsDataView();
            dataGridView.DataSource = view;
            dataGridView.DataMember = null;*/


            //DataTable dataTable = xlsDataSet.Tables[0];
            //   DataRow[] dataRows = dataTable.Select("name = 'goggles'");
        }

        public void SaveButton()
        {
            DataTable table = ((DataSet) this.dataGridView.DataSource).Tables[this.dataGridView.DataMember];
            if (table == null) return;

            // TODO have excel file saving use same method as string file saving
            if (_stringsFile == null)
            {
                byte[] excelFileData = _excelTable.GenerateExcelFile((DataSet)this.dataGridView.DataSource);

                using (FileStream fs = new FileStream("test.txt.cooked", FileMode.Create, FileAccess.ReadWrite))
                {
                    fs.Write(excelFileData, 0, excelFileData.Length);
                }
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    AddExtension = false,
                    DefaultExt = StringsFile.FileExtention,
                    FileName = _stringsFile.Name.ToLower(),
                    Filter = String.Format("Strings Files (*.{0})|*.{0}", StringsFile.FileExtention),
                    InitialDirectory = _stringsFile.FilePath.Substring(0, _stringsFile.FilePath.LastIndexOf(@"\"))
                };
                if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
                {
                    saveFileDialog.Dispose();
                    return;
                }
                String filePath = saveFileDialog.FileName;
                saveFileDialog.Dispose();

                // since AddExtension = false doesn't seem to do shit
                const string replaceExtension = "." + StringsFile.FileExtention;
                while (filePath.Contains(replaceExtension))
                {
                    filePath = filePath.Replace(replaceExtension, "");
                }
                filePath += replaceExtension;

                if (!filePath.Contains(StringsFile.FileExtention))
                {
                    filePath += StringsFile.FileExtention;
                }

                byte[] stringsFileData = _stringsFile.GenerateStringsFile(table);
                if (stringsFileData == null || stringsFileData.Length == 0)
                {
                    MessageBox.Show("Failed to generate string byte data!", "Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    return;
                }

                try
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite))
                    {
                        fs.Write(stringsFileData, 0, stringsFileData.Length);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Failed to write to file!\n\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("1 File Saved!", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void regenTable_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Todo");
            //if (_tableDataSet.XlsDataSet.Tables.Remove(_excelTable.StringId))
        }
    }

    public static class ExtensionMethods
    {
        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }
    }
}