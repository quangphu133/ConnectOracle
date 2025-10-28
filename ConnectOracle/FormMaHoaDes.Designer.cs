namespace ConnectOracle
{
    partial class FormMaHoaDES
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.txtColumnName = new System.Windows.Forms.TextBox();
            this.txtEncryptKey = new System.Windows.Forms.TextBox();
            this.btnEncryptColumn = new System.Windows.Forms.Button();
            this.btnEncryptTable = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDecryptTable = new System.Windows.Forms.TextBox();
            this.txtDecryptColumn = new System.Windows.Forms.TextBox();
            this.txtDecryptKey = new System.Windows.Forms.TextBox();
            this.btnDecryptColumn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTableName);
            this.groupBox1.Controls.Add(this.txtColumnName);
            this.groupBox1.Controls.Add(this.txtEncryptKey);
            this.groupBox1.Controls.Add(this.btnEncryptColumn);
            this.groupBox1.Controls.Add(this.btnEncryptTable);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 180);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mã hóa DES cho Tables";
            // 
            // txtTableName
            // 
            this.txtTableName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtTableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTableName.Location = new System.Drawing.Point(120, 30);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(200, 23);
            this.txtTableName.TabIndex = 1;
            this.txtTableName.Text = "SACH";
            // 
            // txtColumnName
            // 
            this.txtColumnName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtColumnName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColumnName.Location = new System.Drawing.Point(120, 65);
            this.txtColumnName.Name = "txtColumnName";
            this.txtColumnName.Size = new System.Drawing.Size(200, 23);
            this.txtColumnName.TabIndex = 2;
            this.txtColumnName.Text = "TENSACH";
            // 
            // txtEncryptKey
            // 
            this.txtEncryptKey.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtEncryptKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEncryptKey.Location = new System.Drawing.Point(120, 100);
            this.txtEncryptKey.Name = "txtEncryptKey";
            this.txtEncryptKey.Size = new System.Drawing.Size(200, 23);
            this.txtEncryptKey.TabIndex = 3;
            this.txtEncryptKey.Text = "PRIVATEKEY";
            // 
            // btnEncryptColumn
            // 
            this.btnEncryptColumn.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnEncryptColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncryptColumn.Location = new System.Drawing.Point(350, 65);
            this.btnEncryptColumn.Name = "btnEncryptColumn";
            this.btnEncryptColumn.Size = new System.Drawing.Size(120, 30);
            this.btnEncryptColumn.TabIndex = 4;
            this.btnEncryptColumn.Text = "Mã hóa cột";
            this.btnEncryptColumn.UseVisualStyleBackColor = true;
            this.btnEncryptColumn.Click += new System.EventHandler(this.btnEncryptColumn_Click);
            // 
            // btnEncryptTable
            // 
            this.btnEncryptTable.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnEncryptTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncryptTable.Location = new System.Drawing.Point(350, 130);
            this.btnEncryptTable.Name = "btnEncryptTable";
            this.btnEncryptTable.Size = new System.Drawing.Size(120, 30);
            this.btnEncryptTable.TabIndex = 5;
            this.btnEncryptTable.Text = "Mã hóa toàn table";
            this.btnEncryptTable.UseVisualStyleBackColor = true;
            this.btnEncryptTable.Click += new System.EventHandler(this.btnEncryptTable_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Table:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên Cột:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Khóa bí mật:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDecryptTable);
            this.groupBox2.Controls.Add(this.txtDecryptColumn);
            this.groupBox2.Controls.Add(this.txtDecryptKey);
            this.groupBox2.Controls.Add(this.btnDecryptColumn);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 210);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(560, 140);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Giải mã DES cho Tables";
            // 
            // txtDecryptTable
            // 
            this.txtDecryptTable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtDecryptTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDecryptTable.Location = new System.Drawing.Point(120, 30);
            this.txtDecryptTable.Name = "txtDecryptTable";
            this.txtDecryptTable.Size = new System.Drawing.Size(200, 23);
            this.txtDecryptTable.TabIndex = 6;
            this.txtDecryptTable.Text = "SACH";
            // 
            // txtDecryptColumn
            // 
            this.txtDecryptColumn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtDecryptColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDecryptColumn.Location = new System.Drawing.Point(120, 65);
            this.txtDecryptColumn.Name = "txtDecryptColumn";
            this.txtDecryptColumn.Size = new System.Drawing.Size(200, 23);
            this.txtDecryptColumn.TabIndex = 7;
            this.txtDecryptColumn.Text = "TENSACH";
            // 
            // txtDecryptKey
            // 
            this.txtDecryptKey.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtDecryptKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDecryptKey.Location = new System.Drawing.Point(120, 100);
            this.txtDecryptKey.Name = "txtDecryptKey";
            this.txtDecryptKey.Size = new System.Drawing.Size(200, 23);
            this.txtDecryptKey.TabIndex = 8;
            this.txtDecryptKey.Text = "PRIVATEKEY";
            // 
            // btnDecryptColumn
            // 
            this.btnDecryptColumn.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnDecryptColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecryptColumn.Location = new System.Drawing.Point(350, 65);
            this.btnDecryptColumn.Name = "btnDecryptColumn";
            this.btnDecryptColumn.Size = new System.Drawing.Size(120, 30);
            this.btnDecryptColumn.TabIndex = 9;
            this.btnDecryptColumn.Text = "Giải mã cột";
            this.btnDecryptColumn.UseVisualStyleBackColor = true;
            this.btnDecryptColumn.Click += new System.EventHandler(this.btnDecryptColumn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tên Table:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tên Cột:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Khóa bí mật:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtResult);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 370);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(560, 100);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Kết quả";
            // 
            // txtResult
            // 
            this.txtResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.Location = new System.Drawing.Point(120, 30);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(420, 50);
            this.txtResult.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Kết quả:";
            // 
            // btnClear
            // 
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(350, 490);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 35);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Xóa hết";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(472, 490);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 35);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormMaHoaDES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 541);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMaHoaDES";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mã hóa và Giải mã DES cho Tables Oracle";
            this.Load += new System.EventHandler(this.FormMaHoaDES_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.TextBox txtColumnName;
        private System.Windows.Forms.TextBox txtEncryptKey;
        private System.Windows.Forms.Button btnEncryptColumn;
        private System.Windows.Forms.Button btnEncryptTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDecryptTable;
        private System.Windows.Forms.TextBox txtDecryptColumn;
        private System.Windows.Forms.TextBox txtDecryptKey;
        private System.Windows.Forms.Button btnDecryptColumn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;


        #endregion
    }
}