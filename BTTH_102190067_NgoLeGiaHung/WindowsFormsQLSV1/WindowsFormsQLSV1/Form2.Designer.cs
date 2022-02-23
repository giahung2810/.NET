
namespace WindowsFormsQLSV1
{
    partial class Form2
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.butShow = new System.Windows.Forms.Button();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.butSort = new System.Windows.Forms.Button();
            this.butDel = new System.Windows.Forms.Button();
            this.butUp = new System.Windows.Forms.Button();
            this.butAdd = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.butSearch = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.comboBoxClass1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.butShow);
            this.groupBox3.Controls.Add(this.comboBox);
            this.groupBox3.Controls.Add(this.butSort);
            this.groupBox3.Controls.Add(this.butDel);
            this.groupBox3.Controls.Add(this.butUp);
            this.groupBox3.Controls.Add(this.butAdd);
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Controls.Add(this.butSearch);
            this.groupBox3.Controls.Add(this.tbSearch);
            this.groupBox3.Controls.Add(this.comboBoxClass1);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(13, 26);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(775, 382);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "List";
            // 
            // butShow
            // 
            this.butShow.Location = new System.Drawing.Point(304, 28);
            this.butShow.Name = "butShow";
            this.butShow.Size = new System.Drawing.Size(75, 23);
            this.butShow.TabIndex = 10;
            this.butShow.Text = "Show";
            this.butShow.UseVisualStyleBackColor = true;
            this.butShow.Click += new System.EventHandler(this.butShow_Click);
            // 
            // comboBox
            // 
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(559, 335);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(169, 24);
            this.comboBox.TabIndex = 9;
            // 
            // butSort
            // 
            this.butSort.Location = new System.Drawing.Point(431, 336);
            this.butSort.Name = "butSort";
            this.butSort.Size = new System.Drawing.Size(75, 23);
            this.butSort.TabIndex = 8;
            this.butSort.Text = "Sort";
            this.butSort.UseVisualStyleBackColor = true;
            this.butSort.Click += new System.EventHandler(this.butSort_Click);
            // 
            // butDel
            // 
            this.butDel.Location = new System.Drawing.Point(304, 336);
            this.butDel.Name = "butDel";
            this.butDel.Size = new System.Drawing.Size(75, 23);
            this.butDel.TabIndex = 7;
            this.butDel.Text = "Delete";
            this.butDel.UseVisualStyleBackColor = true;
            this.butDel.Click += new System.EventHandler(this.butDel_Click);
            // 
            // butUp
            // 
            this.butUp.Location = new System.Drawing.Point(179, 336);
            this.butUp.Name = "butUp";
            this.butUp.Size = new System.Drawing.Size(75, 23);
            this.butUp.TabIndex = 6;
            this.butUp.Text = "Update";
            this.butUp.UseVisualStyleBackColor = true;
            this.butUp.Click += new System.EventHandler(this.butUp_Click);
            // 
            // butAdd
            // 
            this.butAdd.Location = new System.Drawing.Point(39, 336);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(75, 23);
            this.butAdd.TabIndex = 5;
            this.butAdd.Text = "Add";
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 83);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(749, 224);
            this.dataGridView1.TabIndex = 4;
            // 
            // butSearch
            // 
            this.butSearch.Location = new System.Drawing.Point(645, 29);
            this.butSearch.Name = "butSearch";
            this.butSearch.Size = new System.Drawing.Size(110, 23);
            this.butSearch.TabIndex = 3;
            this.butSearch.Text = "Search";
            this.butSearch.UseVisualStyleBackColor = true;
            this.butSearch.Click += new System.EventHandler(this.butSearch_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(453, 28);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(141, 22);
            this.tbSearch.TabIndex = 2;
            // 
            // comboBoxClass1
            // 
            this.comboBoxClass1.FormattingEnabled = true;
            this.comboBoxClass1.Location = new System.Drawing.Point(98, 28);
            this.comboBoxClass1.Name = "comboBoxClass1";
            this.comboBoxClass1.Size = new System.Drawing.Size(156, 24);
            this.comboBoxClass1.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Class";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox3);
            this.Name = "Form2";
            this.Text = "Form2";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button butShow;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Button butSort;
        private System.Windows.Forms.Button butDel;
        private System.Windows.Forms.Button butUp;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button butSearch;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.ComboBox comboBoxClass1;
        private System.Windows.Forms.Label label7;
    }
}