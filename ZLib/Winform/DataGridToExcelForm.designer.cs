namespace Z
{
    partial class DataGridToExcelForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pgb = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.btnToExcel = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // pgb
            // 
            this.pgb.Location = new System.Drawing.Point(0, 279);
            this.pgb.Name = "pgb";
            this.pgb.Size = new System.Drawing.Size(359, 14);
            this.pgb.TabIndex = 9;
            this.pgb.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(133, 250);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "反选";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnToExcel
            // 
            this.btnToExcel.Location = new System.Drawing.Point(214, 250);
            this.btnToExcel.Name = "btnToExcel";
            this.btnToExcel.Size = new System.Drawing.Size(75, 23);
            this.btnToExcel.TabIndex = 7;
            this.btnToExcel.Text = "导出";
            this.btnToExcel.UseVisualStyleBackColor = true;
            this.btnToExcel.Click += new System.EventHandler(this.btnToExcel_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(52, 250);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 6;
            this.btnSelect.Text = "全选";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(0, 0);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(359, 244);
            this.checkedListBox1.TabIndex = 5;
            this.checkedListBox1.ThreeDCheckBoxes = true;
            // 
            // DataGridToExcelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 293);
            this.Controls.Add(this.pgb);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnToExcel);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.checkedListBox1);
            this.Name = "DataGridToExcelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择导出的字段";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pgb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnToExcel;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}