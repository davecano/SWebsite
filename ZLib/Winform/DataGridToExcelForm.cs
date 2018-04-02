using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Z
{
    public partial class DataGridToExcelForm : System.Windows.Forms.Form
    {
        private DataTable _DataTable = new DataTable();
        private DataGridView _DataGridView;
        public string excelFileName = "";
        //private bool _saveExportLog = false;

        public DataGridToExcelForm(DataGridView dataGrid,string fileName)
        {
            this.InitializeComponent();
            _DataGridView = dataGrid;
            excelFileName = fileName;
            for (int i = 0; i < _DataGridView.Columns.Count; i++)
            {
                if (dataGrid.Columns[i].Width > 0
                    && (dataGrid.Columns[i].CellType.Name == "DataGridViewTextBoxCell"
                        || dataGrid.Columns[i].CellType.Name == "DataGridViewLinkCell")
                    && dataGrid.Columns[i].Visible)
                {
                    this.checkedListBox1.Items.Add(dataGrid.Columns[i].HeaderText);
                }
            }
        }

        DataGridView _dataGrid = new DataGridView();
        DataGridViewRow _dataRow = new DataGridViewRow();

        public DataGridView dataGrid
        {
            get { return this._dataGrid; }
            set { this._dataGrid = value; }
        }


        public DataGridViewRow dataRow
        {
            get { return this._dataRow; }
            set { this._dataRow = value; }
        }

        public DataGridToExcelForm(System.Data.DataTable dataTable, DataGridView dataGrid)
        {
            this.InitializeComponent();
            _DataTable = dataTable;
            _DataGridView = dataGrid;
            for (int i = 0; i < _DataGridView.Columns.Count; i++)
            {
                if (dataGrid.Columns[i].Width > 0
                    && (dataGrid.Columns[i].CellType.Name == "DataGridViewTextBoxCell"
                        || dataGrid.Columns[i].CellType.Name == "DataGridViewLinkCell")
                    && dataGrid.Columns[i].Visible)
                {
                    this.checkedListBox1.Items.Add(_DataGridView.Columns[i].HeaderText);
                }
            }
        }


        /// <summary>
        /// 全选按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
            {
                this.checkedListBox1.SetItemChecked(i, true);
            }
        }

        /// <summary>
        /// 根据Item的Id号判断Item的选中状态并进行更改
        /// </summary>
        /// <param name="checkIndex"></param>
        private void checkedListBox1_SelectedIndexChanged(int checkIndex)
        {
            if (this.checkedListBox1.GetItemCheckState(checkIndex) == CheckState.Checked)
                this.checkedListBox1.SetItemChecked(checkIndex, false);
            else
                this.checkedListBox1.SetItemChecked(checkIndex, true);
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.checkedListBox1_SelectedIndexChanged(this.checkedListBox1.SelectedIndex);
        }

        /// <summary>
        /// 反选按钮时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
            {
                this.checkedListBox1_SelectedIndexChanged(i);
            }
        }

        private void btnToExcel_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
                                 
            //列index
            System.Collections.ArrayList CheckedIDList = new System.Collections.ArrayList();

            //列name
            System.Collections.ArrayList CheckedNameList = new System.Collections.ArrayList();

            //列dataSourceFieldName
            System.Collections.ArrayList CheckedFieldName = new System.Collections.ArrayList();

            int checknum = this.checkedListBox1.CheckedItems.Count;

            if (checknum > 0)
            {
                for (int i = 0, j = 0; i < _DataGridView.ColumnCount && j < checknum; i++)
                {
                    if (_DataGridView.Columns[i].Visible
                        && _DataGridView.Columns[i].Width > 0
                        && _DataGridView.Columns[i].HeaderText ==
                            this.checkedListBox1.CheckedItems[j].ToString())
                    {
                        CheckedIDList.Add(i);
                        CheckedNameList.Add(this.checkedListBox1.CheckedItems[j].ToString());
                        CheckedFieldName.Add(_DataGridView.Columns[i].DataPropertyName);
                        j++;
                    }
                }

                bool Export;
                if (_DataTable.Rows.Count > 0)
                {
                    //导出全部
                    FileExcel.OpenerForm = this;
                    Export = FileExcel.ExportDataTableToExcel(CheckedIDList, CheckedFieldName,
                                                         CheckedNameList, _DataTable,
                                                         _DataGridView,excelFileName);
                }
                else
                {
                    //导出当前页
                    FileExcel.OpenerForm = this;
                    Export = FileExcel.ExportDataTableToExcel(_DataGridView, CheckedIDList,
                                                          CheckedNameList,excelFileName);
                }

                if (Export)
                {
                    MessageBox.Show("导出成功！", "系统消息",
                                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("导出不成功！", "系统消息",
                                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.Abort;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("请至少选择一项！", "系统消息",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Cursor = Cursors.Default;
        }

        private void DataGridToExcelForm_Resize(object sender, EventArgs e)
        {
            this.Width = 367;
            this.Height = 320;
        }
    }
}
