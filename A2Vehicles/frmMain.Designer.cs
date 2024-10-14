namespace A2Vehicles
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbYears = new ComboBox();
            btnShow = new Button();
            cmbMonths = new ComboBox();
            btnUpdateStatistics = new Button();
            groupBox1 = new GroupBox();
            btnClearSide = new Button();
            btnClearGrid = new Button();
            btnShowDesglose = new Button();
            lblIncomeUsed = new Label();
            lblIncomeNew = new Label();
            lblUsed = new Label();
            lblNew = new Label();
            lblMonth = new Label();
            lblYear = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dgvDataOfAYear = new DataGridView();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            lblTitleGrid = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDataOfAYear).BeginInit();
            SuspendLayout();
            // 
            // cmbYears
            // 
            cmbYears.FormattingEnabled = true;
            cmbYears.Items.AddRange(new object[] { "JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC", "ALL" });
            cmbYears.Location = new Point(25, 103);
            cmbYears.Name = "cmbYears";
            cmbYears.Size = new Size(137, 23);
            cmbYears.TabIndex = 0;
            // 
            // btnShow
            // 
            btnShow.Location = new Point(12, 22);
            btnShow.Name = "btnShow";
            btnShow.Size = new Size(236, 99);
            btnShow.TabIndex = 1;
            btnShow.Text = "Show";
            btnShow.UseVisualStyleBackColor = true;
            btnShow.Click += btnShow_Click;
            // 
            // cmbMonths
            // 
            cmbMonths.FormattingEnabled = true;
            cmbMonths.Items.AddRange(new object[] { "JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC", "ALL" });
            cmbMonths.Location = new Point(180, 103);
            cmbMonths.Name = "cmbMonths";
            cmbMonths.Size = new Size(137, 23);
            cmbMonths.TabIndex = 2;
            // 
            // btnUpdateStatistics
            // 
            btnUpdateStatistics.Location = new Point(12, 137);
            btnUpdateStatistics.Name = "btnUpdateStatistics";
            btnUpdateStatistics.Size = new Size(236, 23);
            btnUpdateStatistics.TabIndex = 3;
            btnUpdateStatistics.Text = "Edit";
            btnUpdateStatistics.UseVisualStyleBackColor = true;
            btnUpdateStatistics.Click += btnUpdateStatistics_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnClearSide);
            groupBox1.Controls.Add(btnClearGrid);
            groupBox1.Controls.Add(btnShowDesglose);
            groupBox1.Controls.Add(lblIncomeUsed);
            groupBox1.Controls.Add(lblIncomeNew);
            groupBox1.Controls.Add(lblUsed);
            groupBox1.Controls.Add(lblNew);
            groupBox1.Controls.Add(lblMonth);
            groupBox1.Controls.Add(lblYear);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnUpdateStatistics);
            groupBox1.Controls.Add(btnShow);
            groupBox1.Location = new Point(777, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(259, 560);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Enter += groupBox1_Enter;
            // 
            // btnClearSide
            // 
            btnClearSide.Location = new Point(146, 492);
            btnClearSide.Name = "btnClearSide";
            btnClearSide.Size = new Size(102, 49);
            btnClearSide.TabIndex = 18;
            btnClearSide.Text = "Clear SideBar";
            btnClearSide.UseVisualStyleBackColor = true;
            btnClearSide.Click += btnClearSide_Click;
            // 
            // btnClearGrid
            // 
            btnClearGrid.Location = new Point(12, 492);
            btnClearGrid.Name = "btnClearGrid";
            btnClearGrid.Size = new Size(106, 49);
            btnClearGrid.TabIndex = 17;
            btnClearGrid.Text = "Clear Grid";
            btnClearGrid.UseVisualStyleBackColor = true;
            btnClearGrid.Click += btnClearGrid_Click;
            // 
            // btnShowDesglose
            // 
            btnShowDesglose.Location = new Point(12, 387);
            btnShowDesglose.Name = "btnShowDesglose";
            btnShowDesglose.Size = new Size(236, 99);
            btnShowDesglose.TabIndex = 16;
            btnShowDesglose.Text = "Show detailed year sales";
            btnShowDesglose.UseVisualStyleBackColor = true;
            btnShowDesglose.Click += btnShowDesglose_Click;
            // 
            // lblIncomeUsed
            // 
            lblIncomeUsed.AutoSize = true;
            lblIncomeUsed.Location = new Point(21, 356);
            lblIncomeUsed.Name = "lblIncomeUsed";
            lblIncomeUsed.Size = new Size(0, 15);
            lblIncomeUsed.TabIndex = 15;
            lblIncomeUsed.TextAlign = ContentAlignment.TopRight;
            // 
            // lblIncomeNew
            // 
            lblIncomeNew.AutoSize = true;
            lblIncomeNew.Location = new Point(21, 304);
            lblIncomeNew.Name = "lblIncomeNew";
            lblIncomeNew.Size = new Size(0, 15);
            lblIncomeNew.TabIndex = 14;
            // 
            // lblUsed
            // 
            lblUsed.AutoSize = true;
            lblUsed.Location = new Point(204, 253);
            lblUsed.Name = "lblUsed";
            lblUsed.Size = new Size(0, 15);
            lblUsed.TabIndex = 13;
            lblUsed.TextAlign = ContentAlignment.TopRight;
            // 
            // lblNew
            // 
            lblNew.AutoSize = true;
            lblNew.Location = new Point(21, 253);
            lblNew.Name = "lblNew";
            lblNew.Size = new Size(0, 15);
            lblNew.TabIndex = 12;
            // 
            // lblMonth
            // 
            lblMonth.AutoSize = true;
            lblMonth.Location = new Point(204, 201);
            lblMonth.Name = "lblMonth";
            lblMonth.Size = new Size(0, 15);
            lblMonth.TabIndex = 11;
            lblMonth.TextAlign = ContentAlignment.TopRight;
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Location = new Point(25, 201);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(0, 15);
            lblYear.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(21, 332);
            label6.Name = "label6";
            label6.Size = new Size(83, 15);
            label6.TabIndex = 9;
            label6.Text = "Income: Used";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(21, 280);
            label5.Name = "label5";
            label5.Size = new Size(81, 15);
            label5.TabIndex = 8;
            label5.Text = "Income: New";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(204, 228);
            label4.Name = "label4";
            label4.Size = new Size(35, 15);
            label4.TabIndex = 7;
            label4.Text = "Used";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(21, 228);
            label3.Name = "label3";
            label3.Size = new Size(33, 15);
            label3.TabIndex = 6;
            label3.Text = "New";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(204, 175);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 5;
            label2.Text = "Month";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(21, 175);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 4;
            label1.Text = "Year";
            // 
            // dgvDataOfAYear
            // 
            dgvDataOfAYear.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvDataOfAYear.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDataOfAYear.Location = new Point(62, 172);
            dgvDataOfAYear.Name = "dgvDataOfAYear";
            dgvDataOfAYear.ReadOnly = true;
            dgvDataOfAYear.Size = new Size(648, 326);
            dgvDataOfAYear.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.Location = new Point(25, 85);
            label7.Name = "label7";
            label7.Size = new Size(31, 15);
            label7.TabIndex = 6;
            label7.Text = "Year";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label8.Location = new Point(180, 85);
            label8.Name = "label8";
            label8.Size = new Size(44, 15);
            label8.TabIndex = 7;
            label8.Text = "Month";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label9.Location = new Point(636, 94);
            label9.Name = "label9";
            label9.Size = new Size(31, 15);
            label9.TabIndex = 8;
            label9.Text = "Year";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(25, 9);
            label10.Name = "label10";
            label10.Size = new Size(126, 30);
            label10.TabIndex = 9;
            label10.Text = "Cars sold in";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 28F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label11.Location = new Point(166, 9);
            label11.Name = "label11";
            label11.Size = new Size(194, 51);
            label11.TabIndex = 10;
            label11.Text = "Maryland";
            // 
            // lblTitleGrid
            // 
            lblTitleGrid.AutoSize = true;
            lblTitleGrid.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitleGrid.Location = new Point(673, 103);
            lblTitleGrid.Name = "lblTitleGrid";
            lblTitleGrid.Size = new Size(0, 37);
            lblTitleGrid.TabIndex = 17;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1048, 592);
            Controls.Add(lblTitleGrid);
            Controls.Add(groupBox1);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(dgvDataOfAYear);
            Controls.Add(cmbMonths);
            Controls.Add(cmbYears);
            Name = "Form1";
            Text = "Cars sold in Maryland";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDataOfAYear).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbYears;
        private Button btnShow;
        private ComboBox cmbMonths;
        private Button btnUpdateStatistics;
        private GroupBox groupBox1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label lblIncomeUsed;
        private Label lblIncomeNew;
        private Label lblUsed;
        private Label lblNew;
        private Label lblMonth;
        private Label lblYear;
        private Label label6;
        private DataGridView dgvDataOfAYear;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Button btnShowDesglose;
        private Label lblTitleGrid;
        private Button btnClearSide;
        private Button btnClearGrid;
    }
}
