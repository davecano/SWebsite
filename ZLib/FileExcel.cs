using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;
using System.Data;
using Microsoft.Office.Interop.Excel;

namespace Z
{
    class FileExcel
    {
        #region ToExcel


        private static Form _openerForm;
        /// <summary>
        /// 所属窗体
        /// </summary>
        public static Form OpenerForm
        {
            set { _openerForm = value; }
            get { return _openerForm; }
        }


        /// <summary>
        /// 将DataGridView中的内容转换成excel文件
        /// </summary>
        /// <param name="dataGridview">DataGridView的实例</param>
        /// <returns>true 成功   false ：失败</returns>
        public static bool ExportDataGridViewToExcel(DataGridView dataGridview)//打印方法
        {
            string str = "", tempStr = "";

            //写标题 
            for (int i = 0; i < dataGridview.ColumnCount; i++)
            {
                if (i == 0) dataGridview.Columns[i].HeaderText = "序号";
                if (i > 0)
                {
                    str += "\t";
                }
                str += dataGridview.Columns[i].HeaderText;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Execl files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = false;
            saveFileDialog.Title = "导出到Excel文件";

            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return false;
            }
            Stream myStream = saveFileDialog.OpenFile();
            StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding("gb2312"));
            sw.WriteLine(str);

            try
            {

                //写内容
                for (int j = 0; j < dataGridview.Rows.Count; j++)
                {
                    tempStr = "";
                    if (dataGridview.Rows[j].Height == 3)
                    {
                        continue;
                    }
                    for (int k = 0; k < dataGridview.Columns.Count; k++)
                    {


                        if (k == 0 && j < (dataGridview.Rows.Count - 2))
                            dataGridview.Rows[j].Cells[k].Value = j + 1;

                        if (k > 0)
                        {
                            tempStr += "\t";
                        }
                        tempStr += dataGridview.Rows[j].Cells[k].Value.ToString();

                    }

                    sw.WriteLine(tempStr);
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
            finally
            {
                sw.Close();
                myStream.Close();
            }
        }



        /// <summary>
        /// 导出当前页
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="CheckedIdList"></param>
        /// <param name="CheckedNameList"></param>
        /// <returns></returns>
        public static bool ExportDataTableToExcel
        (
            DataGridView dataGridView,
            System.Collections.ArrayList CheckedIdList,
            System.Collections.ArrayList CheckedNameList,
            string formName
        )
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = formName;
            saveFileDialog.Filter = "Execl files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = false;
            saveFileDialog.Title = "导出Excel文件到";

            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return false;
            }

            ProgressBar tempPgb = (ProgressBar)OpenerForm.Controls.Find("pgb", true)[0];
            //Microsoft.Office.Interop.Excel.Application 
            Microsoft.Office.Interop.Excel.Application oXL;
            Microsoft.Office.Interop.Excel._Workbook oWB;
            Microsoft.Office.Interop.Excel._Worksheet oSheet;
            oXL = new Microsoft.Office.Interop.Excel.Application();
            oXL.Visible = false;
            oXL.DisplayAlerts = false;

            oWB = (Microsoft.Office.Interop.Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
            oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

            try
            {

                int _RowCount = dataGridView.RowCount;
                int _ColumnCount = dataGridView.ColumnCount;

                //显示进度条

                tempPgb.Maximum = _RowCount;
                tempPgb.Visible = true;

                for (int i = 0; i < CheckedNameList.Count; i++)
                {
                    oSheet.Cells[1, i + 1] = "'" + CheckedNameList[i].ToString();
                }

                for (int j = 0; j < _RowCount; j++)
                {
                    for (int k = 0; k < CheckedIdList.Count; k++)
                    {
                        if
                        (
                            (dataGridView.Columns[(int)CheckedIdList[k]].ValueType != null)
                            && dataGridView.Columns[(int)CheckedIdList[k]].ValueType.Name.Equals("Double")
                        )
                        {
                            oSheet.Cells[j + 2, k + 1] = (dataGridView.Rows[j].Cells[(int)CheckedIdList[k]].Value != null && dataGridView.Rows[j].Cells[(int)CheckedIdList[k]].Value.ToString().Trim() != "") ? Math.Round(double.Parse(dataGridView.Rows[j].Cells[(int)CheckedIdList[k]].Value.ToString()), 4) : 0;
                        }
                        else if
                        (
                            (dataGridView.Columns[(int)CheckedIdList[k]].ValueType != null)
                            && dataGridView.Columns[(int)CheckedIdList[k]].ValueType.Name.Equals("Int32")
                        )
                        {
                            oSheet.Cells[j + 2, k + 1] = (dataGridView.Rows[j].Cells[(int)CheckedIdList[k]].Value != null && dataGridView.Rows[j].Cells[(int)CheckedIdList[k]].Value.ToString().Trim() != "") ? Int32.Parse(dataGridView.Rows[j].Cells[(int)CheckedIdList[k]].Value.ToString()) : 0;
                        }
                        else
                        {
                            oSheet.Cells[j + 2, k + 1] = (dataGridView.Rows[j].Cells[(int)CheckedIdList[k]].Value != null) ? ("'" + dataGridView.Rows[j].Cells[(int)CheckedIdList[k]].Value.ToString()) : "";
                        }
                    }

                    if (tempPgb.Value < tempPgb.Maximum) { tempPgb.Value++; }
                }

                string ExcelHeader = GetExcelHeader(CheckedIdList.Count);

                oSheet.get_Range("A1", ExcelHeader + "1").Font.Bold = true;
                oSheet.get_Range("A1", ExcelHeader + (_RowCount + 1).ToString()).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                oSheet.get_Range("A1", ExcelHeader + (_RowCount + 1).ToString()).EntireColumn.AutoFit();

                oWB.SaveAs
                    (
                        saveFileDialog.FileName,
                        Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel8,
                        Type.Missing,
                        Type.Missing,
                        Type.Missing,
                        Type.Missing,
                        Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
                        Type.Missing,
                        Type.Missing,
                        Type.Missing,
                        Type.Missing
                    );

                tempPgb.Visible = false;
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                tempPgb.Visible = false;
                return false;
            }
            finally
            {
                oWB.Close(null, null, null);
                oXL.Workbooks.Close();
                oXL.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oXL);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oWB);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oSheet);
                oSheet = null;
                oWB = null;
                oXL = null;
                GC.Collect();
            }
        }


        /// <summary>
        /// 导出全部数据
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="CheckedIdList"></param>
        /// <param name="CheckedNameList"></param>
        /// <param name="datatable"></param>
        /// <returns></returns>
        public static bool ExportDataTableToExcel(ArrayList CheckedIdList, ArrayList CheckedFieldName,
                                                  ArrayList CheckedNameList, System.Data.DataTable datatable,
                                                  DataGridView dataGridView, string formName)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = formName;
            saveFileDialog.Filter = "Execl files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = false;
            saveFileDialog.Title = "导出Excel文件到";

            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return false;
            }

            //设置鼠标为等待
            OpenerForm.Cursor = Cursors.WaitCursor;
            ProgressBar tempPgb = (ProgressBar)OpenerForm.Controls.Find("pgb", true)[0];

            Microsoft.Office.Interop.Excel.Application oXL;
            Microsoft.Office.Interop.Excel._Workbook oWB;
            Microsoft.Office.Interop.Excel._Worksheet oSheet;
            oXL = new Microsoft.Office.Interop.Excel.Application();
            oXL.Visible = false;
            oXL.DisplayAlerts = false;

            oWB = (Microsoft.Office.Interop.Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
            oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

            try
            {
                int _RowCount = datatable.Rows.Count;

                //显示进度条

                tempPgb.Maximum = _RowCount;
                tempPgb.Visible = true;


                for (int i = 0; i < CheckedNameList.Count; i++)
                {
                    oSheet.Cells[1, i + 1] = "'" + CheckedNameList[i].ToString();
                }

                for (int j = 0; j < _RowCount; j++)
                {
                    for (int k = 0; k < CheckedFieldName.Count; k++)
                    {

                        //处理无数据源的datagridview列
                        if (CheckedFieldName[k] == null || CheckedFieldName[k].ToString() == "")
                        {
                            if (j < dataGridView.Rows.Count)
                            {
                                oSheet.Cells[j + 2, k + 1] = (dataGridView.Rows[j].Cells[(int)CheckedIdList[k]].Value != null) ? ("'" + dataGridView.Rows[j].Cells[(int)CheckedIdList[k]].Value.ToString()) : "";
                            }
                            else
                            {
                                oSheet.Cells[j + 2, k + 1] = "";
                            }
                        }
                        else if ((datatable.Columns[(string)CheckedFieldName[k]] != null) && datatable.Columns[(string)CheckedFieldName[k]].DataType.Name.Equals("Double"))
                        {
                            oSheet.Cells[j + 2, k + 1] = (datatable.Rows[j][(string)CheckedFieldName[k]] != null && datatable.Rows[j][(string)CheckedFieldName[k]].ToString() != "") ? Math.Round(double.Parse(datatable.Rows[j][(string)CheckedFieldName[k]].ToString()), 4) : 0;
                        }
                        else if ((datatable.Columns[(string)CheckedFieldName[k]] != null) && datatable.Columns[(string)CheckedFieldName[k]].DataType.Name.Equals("Int32"))
                        {
                            oSheet.Cells[j + 2, k + 1] = (datatable.Rows[j][(string)CheckedFieldName[k]] != null && datatable.Rows[j][(string)CheckedFieldName[k]].ToString() != "") ? Int32.Parse(datatable.Rows[j][(string)CheckedFieldName[k]].ToString()) : 0;
                        }
                        else
                        {
                            oSheet.Cells[j + 2, k + 1] = (datatable.Rows[j][(string)CheckedFieldName[k]] != null && datatable.Rows[j][(string)CheckedFieldName[k]].ToString() != "") ? ("'" + datatable.Rows[j][(string)CheckedFieldName[k]].ToString()) : "";
                        }
                    }

                    if (tempPgb.Value < tempPgb.Maximum) { tempPgb.Value++; }
                }

                string ExcelHeader = GetExcelHeader(CheckedFieldName.Count);

                oSheet.get_Range("A1", ExcelHeader + "1").Font.Bold = true;
                oSheet.get_Range("A1", ExcelHeader + (_RowCount + 1).ToString()).Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                oSheet.get_Range("A1", ExcelHeader + (_RowCount + 1).ToString()).EntireColumn.AutoFit();

                oWB.SaveAs
                    (
                        saveFileDialog.FileName,
                        Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel8,
                        Type.Missing,
                        Type.Missing,
                        Type.Missing,
                        Type.Missing,
                        Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
                        Type.Missing,
                        Type.Missing,
                        Type.Missing,
                        Type.Missing
                    );

                tempPgb.Visible = false;

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                tempPgb.Visible = false;
                return false;
            }
            finally
            {
                oWB.Close(null, null, null);
                oXL.Workbooks.Close();
                oXL.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oXL);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oWB);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oSheet);
                oSheet = null;
                oWB = null;
                oXL = null;
                GC.Collect();
            }
        }



        public static bool ExportDataTableToExcel(System.Data.DataTable dataTable)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Execl files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = false;
            saveFileDialog.Title = "导出Excel文件到";

            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return false;
            }

            Microsoft.Office.Interop.Excel.Application oXL;
            Microsoft.Office.Interop.Excel._Workbook oWB;
            Microsoft.Office.Interop.Excel._Worksheet oSheet;
            Microsoft.Office.Interop.Excel.Range oRng;

            try
            {
                oXL = new Microsoft.Office.Interop.Excel.Application();
                oXL.Visible = false;

                oWB = (Microsoft.Office.Interop.Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
                oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

                int _RowCount = dataTable.Rows.Count;
                int _ColumnCount = dataTable.Columns.Count;

                for (int i = 0; i < _ColumnCount; i++)
                {
                    oSheet.Cells[1, i + 1] = dataTable.Columns[i].Caption;
                }

                for (int j = 0; j < _RowCount; j++)
                {
                    for (int k = 0; k < _ColumnCount; k++)
                    {
                        oSheet.Cells[j + 2, k + 1] = dataTable.Rows[j].ItemArray[k].ToString();
                    }
                }

                string ExcelHeader = GetExcelHeader(_ColumnCount);

                oWB.SaveAs
                (
                    saveFileDialog.FileName,
                    Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel8,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing,
                    Type.Missing
                );

                oWB.Close(null, null, null);
                oXL.Workbooks.Close();
                oXL.Quit();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
            finally
            {
            }
        }

        #endregion ToExcel
        private static string GetExcelHeader(int number)
        {
            string[] Header =
                new string[] 
                { 
                    " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", 
                    "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "W", 
                    "Z" 
                };
            if (number <= 26)
            {
                return Header[number];
            }
            else
            {
                return GetExcelHeader(number / 26) + Header[number % 26];
            }
        }

    }
}
