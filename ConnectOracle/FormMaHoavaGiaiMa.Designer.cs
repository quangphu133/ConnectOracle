namespace ConnectOracle
{
    partial class FormMaHoavaGiaiMa
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblInput = new System.Windows.Forms.Label();
            this.lblKey = new System.Windows.Forms.Label();
            this.lblEncodedAdd = new System.Windows.Forms.Label();
            this.lblDecodedAdd = new System.Windows.Forms.Label();
            this.lblEncodedMul = new System.Windows.Forms.Label();
            this.lblDecodedMul = new System.Windows.Forms.Label();

            this.txtInput = new System.Windows.Forms.TextBox();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.btnEncodeAdd = new System.Windows.Forms.Button();
            this.btnDecodeAdd = new System.Windows.Forms.Button();
            this.btnEncodeMul = new System.Windows.Forms.Button();
            this.btnDecodeMul = new System.Windows.Forms.Button();
            this.txtEncodedAdd = new System.Windows.Forms.TextBox();
            this.txtDecodedAdd = new System.Windows.Forms.TextBox();
            this.txtEncodedMul = new System.Windows.Forms.TextBox();
            this.txtDecodedMul = new System.Windows.Forms.TextBox();
            this.SuspendLayout();

            this.lblInput.Location = new System.Drawing.Point(30, 10);
            this.lblInput.Size = new System.Drawing.Size(100, 20);
            this.lblInput.Text = "Chuỗi cần mã hóa";

            this.lblKey.Location = new System.Drawing.Point(350, 10);
            this.lblKey.Size = new System.Drawing.Size(50, 20);
            this.lblKey.Text = "Key";


            this.txtInput.Location = new System.Drawing.Point(30, 30);
            this.txtInput.Size = new System.Drawing.Size(300, 20);


            this.txtKey.Location = new System.Drawing.Point(350, 30);
            this.txtKey.Size = new System.Drawing.Size(50, 20);

            this.btnEncodeAdd.Location = new System.Drawing.Point(30, 70);
            this.btnEncodeAdd.Size = new System.Drawing.Size(120, 23);
            this.btnEncodeAdd.Text = "Mã hóa (Cộng)";
            this.btnEncodeAdd.Click += new System.EventHandler(this.btnEncodeAdd_Click);


            this.btnDecodeAdd.Location = new System.Drawing.Point(160, 70);
            this.btnDecodeAdd.Size = new System.Drawing.Size(120, 23);
            this.btnDecodeAdd.Text = "Giải mã (Cộng)";
            this.btnDecodeAdd.Click += new System.EventHandler(this.btnDecodeAdd_Click);

            this.lblEncodedAdd.Location = new System.Drawing.Point(30, 95);
            this.lblEncodedAdd.Size = new System.Drawing.Size(150, 20);
            this.lblEncodedAdd.Text = "Kết quả mã hóa (Cộng)";


            this.txtEncodedAdd.Location = new System.Drawing.Point(30, 115);
            this.txtEncodedAdd.Size = new System.Drawing.Size(300, 20);


            this.lblDecodedAdd.Location = new System.Drawing.Point(30, 135);
            this.lblDecodedAdd.Size = new System.Drawing.Size(150, 20);
            this.lblDecodedAdd.Text = "Kết quả giải mã (Cộng)";

            this.txtDecodedAdd.Location = new System.Drawing.Point(30, 155);
            this.txtDecodedAdd.Size = new System.Drawing.Size(300, 20);


            this.btnEncodeMul.Location = new System.Drawing.Point(30, 190);
            this.btnEncodeMul.Size = new System.Drawing.Size(120, 23);
            this.btnEncodeMul.Text = "Mã hóa (Nhân)";
            this.btnEncodeMul.Click += new System.EventHandler(this.btnEncodeMul_Click);


            this.btnDecodeMul.Location = new System.Drawing.Point(160, 190);
            this.btnDecodeMul.Size = new System.Drawing.Size(120, 23);
            this.btnDecodeMul.Text = "Giải mã (Nhân)";
            this.btnDecodeMul.Click += new System.EventHandler(this.btnDecodeMul_Click);


            this.lblEncodedMul.Location = new System.Drawing.Point(30, 215);
            this.lblEncodedMul.Size = new System.Drawing.Size(150, 20);
            this.lblEncodedMul.Text = "Kết quả mã hóa (Nhân)";


            this.txtEncodedMul.Location = new System.Drawing.Point(30, 235);
            this.txtEncodedMul.Size = new System.Drawing.Size(300, 20);


            this.lblDecodedMul.Location = new System.Drawing.Point(30, 255);
            this.lblDecodedMul.Size = new System.Drawing.Size(150, 20);
            this.lblDecodedMul.Text = "Kết quả giải mã (Nhân)";


            this.txtDecodedMul.Location = new System.Drawing.Point(30, 275);
            this.txtDecodedMul.Size = new System.Drawing.Size(300, 20);


            this.ClientSize = new System.Drawing.Size(420, 320);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.lblEncodedAdd);
            this.Controls.Add(this.lblDecodedAdd);
            this.Controls.Add(this.lblEncodedMul);
            this.Controls.Add(this.lblDecodedMul);

            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.btnEncodeAdd);
            this.Controls.Add(this.btnDecodeAdd);
            this.Controls.Add(this.btnEncodeMul);
            this.Controls.Add(this.btnDecodeMul);
            this.Controls.Add(this.txtEncodedAdd);
            this.Controls.Add(this.txtDecodedAdd);
            this.Controls.Add(this.txtEncodedMul);
            this.Controls.Add(this.txtDecodedMul);

            this.Name = "MainForm";
            this.Text = "Oracle Encode/Decode";
            this.ResumeLayout(false);
            this.PerformLayout();
        }


        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.Label lblEncodedAdd;
        private System.Windows.Forms.Label lblDecodedAdd;
        private System.Windows.Forms.Label lblEncodedMul;
        private System.Windows.Forms.Label lblDecodedMul;

        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Button btnEncodeAdd;
        private System.Windows.Forms.Button btnDecodeAdd;
        private System.Windows.Forms.Button btnEncodeMul;
        private System.Windows.Forms.Button btnDecodeMul;
        private System.Windows.Forms.TextBox txtEncodedAdd;
        private System.Windows.Forms.TextBox txtDecodedAdd;
        private System.Windows.Forms.TextBox txtEncodedMul;
        private System.Windows.Forms.TextBox txtDecodedMul;
    }
}

