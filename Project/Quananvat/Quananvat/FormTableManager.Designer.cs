
namespace Quananvat
{
    partial class FormTableManager
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lsvbill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.txttongtien = new System.Windows.Forms.TextBox();
            this.lbtongtien = new System.Windows.Forms.Label();
            this.nmgiamgia = new System.Windows.Forms.NumericUpDown();
            this.btngiamgia = new System.Windows.Forms.Button();
            this.btnthanhtoan = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.nmfoodcount = new System.Windows.Forms.NumericUpDown();
            this.btnaddfood = new System.Windows.Forms.Button();
            this.cbfood = new System.Windows.Forms.ComboBox();
            this.cbcategory = new System.Windows.Forms.ComboBox();
            this.flptable = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmgiamgia)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmfoodcount)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.thôngTinTàiKhoảnToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1021, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // thôngTinTàiKhoảnToolStripMenuItem
            // 
            this.thôngTinTàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCáNhânToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.thôngTinTàiKhoảnToolStripMenuItem.Name = "thôngTinTàiKhoảnToolStripMenuItem";
            this.thôngTinTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(161, 24);
            this.thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông Tin Tài Khoản ";
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            this.thôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.thôngTinCáNhânToolStripMenuItem.Text = "Thông tin cá nhân";
            this.thôngTinCáNhânToolStripMenuItem.Click += new System.EventHandler(this.thôngTinCáNhânToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lsvbill);
            this.panel2.Location = new System.Drawing.Point(607, 103);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(403, 489);
            this.panel2.TabIndex = 2;
            // 
            // lsvbill
            // 
            this.lsvbill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvbill.HideSelection = false;
            this.lsvbill.Location = new System.Drawing.Point(1, 2);
            this.lsvbill.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lsvbill.Name = "lsvbill";
            this.lsvbill.Size = new System.Drawing.Size(397, 483);
            this.lsvbill.TabIndex = 0;
            this.lsvbill.UseCompatibleStateImageBehavior = false;
            this.lsvbill.View = System.Windows.Forms.View.Details;
            this.lsvbill.SelectedIndexChanged += new System.EventHandler(this.lsvbill_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên Món";
            this.columnHeader1.Width = 105;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số Lượng";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đơn Giá";
            this.columnHeader3.Width = 58;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành Tiền";
            this.columnHeader4.Width = 72;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txttongtien);
            this.panel3.Controls.Add(this.lbtongtien);
            this.panel3.Controls.Add(this.nmgiamgia);
            this.panel3.Controls.Add(this.btngiamgia);
            this.panel3.Controls.Add(this.btnthanhtoan);
            this.panel3.Location = new System.Drawing.Point(607, 598);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(403, 58);
            this.panel3.TabIndex = 3;
            // 
            // txttongtien
            // 
            this.txttongtien.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttongtien.Location = new System.Drawing.Point(107, 30);
            this.txttongtien.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txttongtien.Name = "txttongtien";
            this.txttongtien.ReadOnly = true;
            this.txttongtien.Size = new System.Drawing.Size(202, 25);
            this.txttongtien.TabIndex = 11;
            this.txttongtien.Text = "0";
            this.txttongtien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txttongtien.TextChanged += new System.EventHandler(this.txttongtien_TextChanged);
            // 
            // lbtongtien
            // 
            this.lbtongtien.AutoSize = true;
            this.lbtongtien.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtongtien.Location = new System.Drawing.Point(162, 6);
            this.lbtongtien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbtongtien.Name = "lbtongtien";
            this.lbtongtien.Size = new System.Drawing.Size(83, 19);
            this.lbtongtien.TabIndex = 12;
            this.lbtongtien.Text = "Tổng tiền";
            // 
            // nmgiamgia
            // 
            this.nmgiamgia.Location = new System.Drawing.Point(4, 34);
            this.nmgiamgia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nmgiamgia.Name = "nmgiamgia";
            this.nmgiamgia.Size = new System.Drawing.Size(96, 22);
            this.nmgiamgia.TabIndex = 9;
            this.nmgiamgia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btngiamgia
            // 
            this.btngiamgia.Location = new System.Drawing.Point(4, 6);
            this.btngiamgia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btngiamgia.Name = "btngiamgia";
            this.btngiamgia.Size = new System.Drawing.Size(96, 28);
            this.btngiamgia.TabIndex = 8;
            this.btngiamgia.Text = "Giảm Giá";
            this.btngiamgia.UseVisualStyleBackColor = true;
            // 
            // btnthanhtoan
            // 
            this.btnthanhtoan.Location = new System.Drawing.Point(317, 0);
            this.btnthanhtoan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnthanhtoan.Name = "btnthanhtoan";
            this.btnthanhtoan.Size = new System.Drawing.Size(83, 58);
            this.btnthanhtoan.TabIndex = 3;
            this.btnthanhtoan.Text = "Thanh Toán";
            this.btnthanhtoan.UseVisualStyleBackColor = true;
            this.btnthanhtoan.Click += new System.EventHandler(this.btnthanhtoan_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.nmfoodcount);
            this.panel4.Controls.Add(this.btnaddfood);
            this.panel4.Controls.Add(this.cbfood);
            this.panel4.Controls.Add(this.cbcategory);
            this.panel4.Location = new System.Drawing.Point(607, 32);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(403, 65);
            this.panel4.TabIndex = 4;
            // 
            // nmfoodcount
            // 
            this.nmfoodcount.Location = new System.Drawing.Point(361, 21);
            this.nmfoodcount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nmfoodcount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nmfoodcount.Name = "nmfoodcount";
            this.nmfoodcount.Size = new System.Drawing.Size(39, 22);
            this.nmfoodcount.TabIndex = 3;
            this.nmfoodcount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnaddfood
            // 
            this.btnaddfood.Location = new System.Drawing.Point(271, 2);
            this.btnaddfood.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnaddfood.Name = "btnaddfood";
            this.btnaddfood.Size = new System.Drawing.Size(83, 58);
            this.btnaddfood.TabIndex = 2;
            this.btnaddfood.Text = "Thêm Món";
            this.btnaddfood.UseVisualStyleBackColor = true;
            this.btnaddfood.Click += new System.EventHandler(this.btnaddfood_Click);
            // 
            // cbfood
            // 
            this.cbfood.FormattingEnabled = true;
            this.cbfood.Location = new System.Drawing.Point(4, 34);
            this.cbfood.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbfood.Name = "cbfood";
            this.cbfood.Size = new System.Drawing.Size(261, 24);
            this.cbfood.TabIndex = 1;
            // 
            // cbcategory
            // 
            this.cbcategory.FormattingEnabled = true;
            this.cbcategory.Location = new System.Drawing.Point(4, 2);
            this.cbcategory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbcategory.Name = "cbcategory";
            this.cbcategory.Size = new System.Drawing.Size(261, 24);
            this.cbcategory.TabIndex = 0;
            this.cbcategory.SelectedIndexChanged += new System.EventHandler(this.cbcategory_SelectedIndexChanged);
            // 
            // flptable
            // 
            this.flptable.AutoScroll = true;
            this.flptable.Location = new System.Drawing.Point(13, 32);
            this.flptable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flptable.Name = "flptable";
            this.flptable.Size = new System.Drawing.Size(588, 624);
            this.flptable.TabIndex = 5;
            this.flptable.Paint += new System.Windows.Forms.PaintEventHandler(this.flptable_Paint);
            // 
            // FormTableManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 663);
            this.Controls.Add(this.flptable);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormTableManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần Mềm Quản Lý Quán Đồ Ăn Vặt";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmgiamgia)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmfoodcount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinTàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lsvbill;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.NumericUpDown nmfoodcount;
        private System.Windows.Forms.Button btnaddfood;
        private System.Windows.Forms.ComboBox cbfood;
        private System.Windows.Forms.ComboBox cbcategory;
        private System.Windows.Forms.FlowLayoutPanel flptable;
        private System.Windows.Forms.Button btnthanhtoan;
        private System.Windows.Forms.NumericUpDown nmgiamgia;
        private System.Windows.Forms.Button btngiamgia;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label lbtongtien;
        private System.Windows.Forms.TextBox txttongtien;
    }
}