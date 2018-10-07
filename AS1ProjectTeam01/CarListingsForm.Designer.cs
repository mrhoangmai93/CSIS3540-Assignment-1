﻿namespace AS1ProjectTeam01
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
            this.button1 = new System.Windows.Forms.Button();
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
            this.lblAverageSelected = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblCountSelected = new System.Windows.Forms.Label();
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
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "All Cars";
            // 
            // dataAllCars
            // 
            this.dataAllCars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataAllCars.Location = new System.Drawing.Point(15, 39);
            this.dataAllCars.Name = "dataAllCars";
            this.dataAllCars.RowTemplate.Height = 24;
            this.dataAllCars.Size = new System.Drawing.Size(760, 165);
            this.dataAllCars.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Count =";
            // 
            // lblCountAll
            // 
            this.lblCountAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCountAll.Location = new System.Drawing.Point(149, 220);
            this.lblCountAll.Name = "lblCountAll";
            this.lblCountAll.Size = new System.Drawing.Size(98, 18);
            this.lblCountAll.TabIndex = 3;
            // 
            // lblAveragePriceAll
            // 
            this.lblAveragePriceAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAveragePriceAll.Location = new System.Drawing.Point(585, 220);
            this.lblAveragePriceAll.Name = "lblAveragePriceAll";
            this.lblAveragePriceAll.Size = new System.Drawing.Size(102, 18);
            this.lblAveragePriceAll.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(472, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Average Price = ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Filters";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(309, 247);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Reset Filters";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // listMakes
            // 
            this.listMakes.FormattingEnabled = true;
            this.listMakes.ItemHeight = 16;
            this.listMakes.Location = new System.Drawing.Point(15, 303);
            this.listMakes.Name = "listMakes";
            this.listMakes.Size = new System.Drawing.Size(151, 132);
            this.listMakes.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 284);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Makes";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(235, 284);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Years";
            // 
            // listYears
            // 
            this.listYears.FormattingEnabled = true;
            this.listYears.ItemHeight = 16;
            this.listYears.Location = new System.Drawing.Point(234, 303);
            this.listYears.Name = "listYears";
            this.listYears.Size = new System.Drawing.Size(76, 132);
            this.listYears.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(389, 284);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Colors";
            // 
            // listColors
            // 
            this.listColors.FormattingEnabled = true;
            this.listColors.ItemHeight = 16;
            this.listColors.Location = new System.Drawing.Point(388, 303);
            this.listColors.Name = "listColors";
            this.listColors.Size = new System.Drawing.Size(113, 132);
            this.listColors.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(608, 284);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "Dealers";
            // 
            // listDealers
            // 
            this.listDealers.FormattingEnabled = true;
            this.listDealers.ItemHeight = 16;
            this.listDealers.Location = new System.Drawing.Point(611, 303);
            this.listDealers.Name = "listDealers";
            this.listDealers.Size = new System.Drawing.Size(164, 132);
            this.listDealers.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Location = new System.Drawing.Point(12, 460);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 18);
            this.label9.TabIndex = 16;
            this.label9.Text = "Price";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(75, 460);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 16);
            this.label10.TabIndex = 17;
            this.label10.Text = "Min";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(75, 491);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 16);
            this.label11.TabIndex = 18;
            this.label11.Text = "Max";
            // 
            // txtMinPrice
            // 
            this.txtMinPrice.Location = new System.Drawing.Point(110, 457);
            this.txtMinPrice.Name = "txtMinPrice";
            this.txtMinPrice.Size = new System.Drawing.Size(100, 22);
            this.txtMinPrice.TabIndex = 19;
            // 
            // txtMaxPrice
            // 
            this.txtMaxPrice.Location = new System.Drawing.Point(110, 488);
            this.txtMaxPrice.Name = "txtMaxPrice";
            this.txtMaxPrice.Size = new System.Drawing.Size(100, 22);
            this.txtMaxPrice.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Location = new System.Drawing.Point(402, 460);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 18);
            this.label12.TabIndex = 21;
            this.label12.Text = "Engine Size";
            // 
            // txtMaxEngineSize
            // 
            this.txtMaxEngineSize.Location = new System.Drawing.Point(554, 487);
            this.txtMaxEngineSize.Name = "txtMaxEngineSize";
            this.txtMaxEngineSize.Size = new System.Drawing.Size(100, 22);
            this.txtMaxEngineSize.TabIndex = 25;
            // 
            // txtMinEngineSize
            // 
            this.txtMinEngineSize.Location = new System.Drawing.Point(554, 456);
            this.txtMinEngineSize.Name = "txtMinEngineSize";
            this.txtMinEngineSize.Size = new System.Drawing.Size(100, 22);
            this.txtMinEngineSize.TabIndex = 24;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(519, 490);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(33, 16);
            this.label13.TabIndex = 23;
            this.label13.Text = "Max";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(519, 459);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 16);
            this.label14.TabIndex = 22;
            this.label14.Text = "Min";
            // 
            // searchPrice
            // 
            this.searchPrice.AutoSize = true;
            this.searchPrice.Location = new System.Drawing.Point(110, 516);
            this.searchPrice.Name = "searchPrice";
            this.searchPrice.Size = new System.Drawing.Size(125, 20);
            this.searchPrice.TabIndex = 26;
            this.searchPrice.Text = "Search on Price";
            this.searchPrice.UseVisualStyleBackColor = true;
            // 
            // searchEngineSize
            // 
            this.searchEngineSize.AutoSize = true;
            this.searchEngineSize.Location = new System.Drawing.Point(522, 515);
            this.searchEngineSize.Name = "searchEngineSize";
            this.searchEngineSize.Size = new System.Drawing.Size(165, 20);
            this.searchEngineSize.TabIndex = 27;
            this.searchEngineSize.Text = "Search on Engine Size";
            this.searchEngineSize.UseVisualStyleBackColor = true;
            // 
            // lblAverageSelected
            // 
            this.lblAverageSelected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAverageSelected.Location = new System.Drawing.Point(589, 754);
            this.lblAverageSelected.Name = "lblAverageSelected";
            this.lblAverageSelected.Size = new System.Drawing.Size(102, 18);
            this.lblAverageSelected.TabIndex = 33;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(476, 754);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(107, 16);
            this.label16.TabIndex = 32;
            this.label16.Text = "Average Price = ";
            // 
            // lblCountSelected
            // 
            this.lblCountSelected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCountSelected.Location = new System.Drawing.Point(153, 754);
            this.lblCountSelected.Name = "lblCountSelected";
            this.lblCountSelected.Size = new System.Drawing.Size(98, 18);
            this.lblCountSelected.TabIndex = 31;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(95, 754);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(52, 16);
            this.label18.TabIndex = 30;
            this.label18.Text = "Count =";
            // 
            // dataSelectedCars
            // 
            this.dataSelectedCars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataSelectedCars.Location = new System.Drawing.Point(19, 573);
            this.dataSelectedCars.Name = "dataSelectedCars";
            this.dataSelectedCars.RowTemplate.Height = 24;
            this.dataSelectedCars.Size = new System.Drawing.Size(760, 165);
            this.dataSelectedCars.TabIndex = 29;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.488F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(16, 543);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(108, 18);
            this.label19.TabIndex = 28;
            this.label19.Text = "Selected Cars";
            // 
            // CarListingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 807);
            this.Controls.Add(this.lblAverageSelected);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lblCountSelected);
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
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblAveragePriceAll);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblCountAll);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataAllCars);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Button button1;
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
        private System.Windows.Forms.Label lblAverageSelected;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblCountSelected;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataGridView dataSelectedCars;
        private System.Windows.Forms.Label label19;
    }
}
