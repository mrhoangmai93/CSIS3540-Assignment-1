namespace AS1ProjectTeam01
{
    partial class CarListingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataAllCars = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCountAll = new System.Windows.Forms.Label();
            this.lblAveragePriceAll = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.resetButton = new System.Windows.Forms.Button();
            this.listMakes = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listYears = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.listColors = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.listDealers = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtMinPrice = new System.Windows.Forms.TextBox();
            this.txtMaxPrice = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMaxEngineSize = new System.Windows.Forms.TextBox();
            this.txtMinEngineSize = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.searchPrice = new System.Windows.Forms.CheckBox();
            this.searchEngineSize = new System.Windows.Forms.CheckBox();
            this.labelAverage = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.dataSelectedCars = new System.Windows.Forms.DataGridView();
            this.label19 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataAllCars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSelectedCars)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "All Cars";
            // 
            // dataAllCars
            // 
            this.dataAllCars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataAllCars.Location = new System.Drawing.Point(36, 90);
            this.dataAllCars.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.dataAllCars.Name = "dataAllCars";
            this.dataAllCars.RowTemplate.Height = 24;
            this.dataAllCars.Size = new System.Drawing.Size(1805, 382);
            this.dataAllCars.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 509);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 37);
            this.label2.TabIndex = 2;
            this.label2.Text = "Count =";
            // 
            // lblCountAll
            // 
            this.lblCountAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCountAll.Location = new System.Drawing.Point(354, 509);
            this.lblCountAll.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblCountAll.Name = "lblCountAll";
            this.lblCountAll.Size = new System.Drawing.Size(230, 39);
            this.lblCountAll.TabIndex = 3;
            // 
            // lblAveragePriceAll
            // 
            this.lblAveragePriceAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAveragePriceAll.Location = new System.Drawing.Point(1389, 509);
            this.lblAveragePriceAll.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblAveragePriceAll.Name = "lblAveragePriceAll";
            this.lblAveragePriceAll.Size = new System.Drawing.Size(240, 39);
            this.lblAveragePriceAll.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1121, 509);
            this.label4.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(253, 37);
            this.label4.TabIndex = 4;
            this.label4.Text = "Average Price = ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 583);
            this.label3.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 38);
            this.label3.TabIndex = 6;
            this.label3.Text = "Filters";
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(734, 571);
            this.resetButton.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(318, 53);
            this.resetButton.TabIndex = 7;
            this.resetButton.Text = "Reset Filters";
            this.resetButton.UseVisualStyleBackColor = true;
            // 
            // listMakes
            // 
            this.listMakes.FormattingEnabled = true;
            this.listMakes.ItemHeight = 37;
            this.listMakes.Location = new System.Drawing.Point(36, 701);
            this.listMakes.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.listMakes.Name = "listMakes";
            this.listMakes.Size = new System.Drawing.Size(353, 300);
            this.listMakes.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 657);
            this.label5.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 37);
            this.label5.TabIndex = 9;
            this.label5.Text = "Makes";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(558, 657);
            this.label6.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 37);
            this.label6.TabIndex = 11;
            this.label6.Text = "Years";
            // 
            // listYears
            // 
            this.listYears.FormattingEnabled = true;
            this.listYears.ItemHeight = 37;
            this.listYears.Location = new System.Drawing.Point(556, 701);
            this.listYears.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.listYears.Name = "listYears";
            this.listYears.Size = new System.Drawing.Size(175, 300);
            this.listYears.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(924, 657);
            this.label7.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 37);
            this.label7.TabIndex = 13;
            this.label7.Text = "Colors";
            // 
            // listColors
            // 
            this.listColors.FormattingEnabled = true;
            this.listColors.ItemHeight = 37;
            this.listColors.Location = new System.Drawing.Point(922, 701);
            this.listColors.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.listColors.Name = "listColors";
            this.listColors.Size = new System.Drawing.Size(263, 300);
            this.listColors.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1444, 657);
            this.label8.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 37);
            this.label8.TabIndex = 15;
            this.label8.Text = "Dealers";
            // 
            // listDealers
            // 
            this.listDealers.FormattingEnabled = true;
            this.listDealers.ItemHeight = 37;
            this.listDealers.Location = new System.Drawing.Point(1451, 701);
            this.listDealers.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.listDealers.Name = "listDealers";
            this.listDealers.Size = new System.Drawing.Size(384, 300);
            this.listDealers.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Location = new System.Drawing.Point(28, 1064);
            this.label9.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 39);
            this.label9.TabIndex = 16;
            this.label9.Text = "Price";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(178, 1064);
            this.label10.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 37);
            this.label10.TabIndex = 17;
            this.label10.Text = "Min";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(178, 1135);
            this.label11.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 37);
            this.label11.TabIndex = 18;
            this.label11.Text = "Max";
            // 
            // txtMinPrice
            // 
            this.txtMinPrice.Location = new System.Drawing.Point(261, 1057);
            this.txtMinPrice.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.txtMinPrice.Name = "txtMinPrice";
            this.txtMinPrice.Size = new System.Drawing.Size(232, 44);
            this.txtMinPrice.TabIndex = 19;
            // 
            // txtMaxPrice
            // 
            this.txtMaxPrice.Location = new System.Drawing.Point(261, 1128);
            this.txtMaxPrice.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.txtMaxPrice.Name = "txtMaxPrice";
            this.txtMaxPrice.Size = new System.Drawing.Size(232, 44);
            this.txtMaxPrice.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Location = new System.Drawing.Point(955, 1064);
            this.label12.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(188, 39);
            this.label12.TabIndex = 21;
            this.label12.Text = "Engine Size";
            // 
            // txtMaxEngineSize
            // 
            this.txtMaxEngineSize.Location = new System.Drawing.Point(1316, 1126);
            this.txtMaxEngineSize.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.txtMaxEngineSize.Name = "txtMaxEngineSize";
            this.txtMaxEngineSize.Size = new System.Drawing.Size(232, 44);
            this.txtMaxEngineSize.TabIndex = 25;
            // 
            // txtMinEngineSize
            // 
            this.txtMinEngineSize.Location = new System.Drawing.Point(1316, 1054);
            this.txtMinEngineSize.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.txtMinEngineSize.Name = "txtMinEngineSize";
            this.txtMinEngineSize.Size = new System.Drawing.Size(232, 44);
            this.txtMinEngineSize.TabIndex = 24;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1233, 1133);
            this.label13.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 37);
            this.label13.TabIndex = 23;
            this.label13.Text = "Max";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(1233, 1061);
            this.label14.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 37);
            this.label14.TabIndex = 22;
            this.label14.Text = "Min";
            // 
            // searchPrice
            // 
            this.searchPrice.AutoSize = true;
            this.searchPrice.Location = new System.Drawing.Point(261, 1193);
            this.searchPrice.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.searchPrice.Name = "searchPrice";
            this.searchPrice.Size = new System.Drawing.Size(290, 41);
            this.searchPrice.TabIndex = 26;
            this.searchPrice.Text = "Search on Price";
            this.searchPrice.UseVisualStyleBackColor = true;
            // 
            // searchEngineSize
            // 
            this.searchEngineSize.AutoSize = true;
            this.searchEngineSize.Location = new System.Drawing.Point(1240, 1191);
            this.searchEngineSize.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.searchEngineSize.Name = "searchEngineSize";
            this.searchEngineSize.Size = new System.Drawing.Size(387, 41);
            this.searchEngineSize.TabIndex = 27;
            this.searchEngineSize.Text = "Search on Engine Size";
            this.searchEngineSize.UseVisualStyleBackColor = true;
            // 
            // lblAverageSelected
            // 
            this.labelAverage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelAverage.Location = new System.Drawing.Point(1399, 1744);
            this.labelAverage.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelAverage.Name = "lblAverageSelected";
            this.labelAverage.Size = new System.Drawing.Size(240, 39);
            this.labelAverage.TabIndex = 33;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(1130, 1744);
            this.label16.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(253, 37);
            this.label16.TabIndex = 32;
            this.label16.Text = "Average Price = ";
            // 
            // lblCountSelected
            // 
            this.labelCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelCount.Location = new System.Drawing.Point(363, 1744);
            this.labelCount.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelCount.Name = "lblCountSelected";
            this.labelCount.Size = new System.Drawing.Size(230, 39);
            this.labelCount.TabIndex = 31;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(226, 1744);
            this.label18.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(131, 37);
            this.label18.TabIndex = 30;
            this.label18.Text = "Count =";
            // 
            // dataSelectedCars
            // 
            this.dataSelectedCars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataSelectedCars.Location = new System.Drawing.Point(45, 1325);
            this.dataSelectedCars.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.dataSelectedCars.Name = "dataSelectedCars";
            this.dataSelectedCars.RowTemplate.Height = 24;
            this.dataSelectedCars.Size = new System.Drawing.Size(1805, 382);
            this.dataSelectedCars.TabIndex = 29;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(38, 1256);
            this.label19.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(215, 38);
            this.label19.TabIndex = 28;
            this.label19.Text = "Selected Cars";
            // 
            // CarListingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1900, 1866);
            this.Controls.Add(this.labelAverage);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.dataSelectedCars);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.searchEngineSize);
            this.Controls.Add(this.searchPrice);
            this.Controls.Add(this.txtMaxEngineSize);
            this.Controls.Add(this.txtMinEngineSize);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtMaxPrice);
            this.Controls.Add(this.txtMinPrice);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.listDealers);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.listColors);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listYears);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listMakes);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblAveragePriceAll);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblCountAll);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataAllCars);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.Name = "CarListingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Assignment 1 - Car Listings - ProjectTeam 01 ";
            ((System.ComponentModel.ISupportInitialize)(this.dataAllCars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSelectedCars)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataAllCars;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCountAll;
        private System.Windows.Forms.Label lblAveragePriceAll;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.ListBox listMakes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listYears;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox listColors;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox listDealers;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtMinPrice;
        private System.Windows.Forms.TextBox txtMaxPrice;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtMaxEngineSize;
        private System.Windows.Forms.TextBox txtMinEngineSize;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox searchPrice;
        private System.Windows.Forms.CheckBox searchEngineSize;
        private System.Windows.Forms.Label labelAverage;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataGridView dataSelectedCars;
        private System.Windows.Forms.Label label19;
    }
}

