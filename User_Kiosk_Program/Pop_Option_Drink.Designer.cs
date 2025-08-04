namespace User_Kiosk_Program
{
    partial class Pop_Option_Drink
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.pb_Select_Image = new System.Windows.Forms.PictureBox();
            this.pn_Option = new System.Windows.Forms.Panel();
            this.btn_Confirm = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.lbl_ProductName = new System.Windows.Forms.Label();
            this.lbl_ProductPrice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Select_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_Select_Image
            // 
            this.pb_Select_Image.Location = new System.Drawing.Point(24, 24);
            this.pb_Select_Image.Name = "pb_Select_Image";
            this.pb_Select_Image.Size = new System.Drawing.Size(180, 180);
            this.pb_Select_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Select_Image.TabIndex = 0;
            this.pb_Select_Image.TabStop = false;
            // 
            // pn_Option
            // 
            this.pn_Option.AutoScroll = true;
            this.pn_Option.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pn_Option.Location = new System.Drawing.Point(24, 220);
            this.pn_Option.Name = "pn_Option";
            this.pn_Option.Size = new System.Drawing.Size(552, 420);
            this.pn_Option.TabIndex = 1;
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Confirm.Location = new System.Drawing.Point(320, 655);
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(120, 50);
            this.btn_Confirm.TabIndex = 2;
            this.btn_Confirm.Text = "담기";
            this.btn_Confirm.UseVisualStyleBackColor = true;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_Cancel.Location = new System.Drawing.Point(160, 655);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(120, 50);
            this.btn_Cancel.TabIndex = 3;
            this.btn_Cancel.Text = "취소";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // lbl_ProductName
            // 
            this.lbl_ProductName.AutoSize = true;
            this.lbl_ProductName.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_ProductName.Location = new System.Drawing.Point(220, 40);
            this.lbl_ProductName.Name = "lbl_ProductName";
            this.lbl_ProductName.Size = new System.Drawing.Size(111, 32);
            this.lbl_ProductName.TabIndex = 4;
            this.lbl_ProductName.Text = "상품이름";
            // 
            // lbl_ProductPrice
            // 
            this.lbl_ProductPrice.AutoSize = true;
            this.lbl_ProductPrice.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_ProductPrice.Location = new System.Drawing.Point(220, 90);
            this.lbl_ProductPrice.Name = "lbl_ProductPrice";
            this.lbl_ProductPrice.Size = new System.Drawing.Size(84, 25);
            this.lbl_ProductPrice.TabIndex = 5;
            this.lbl_ProductPrice.Text = "상품가격";
            // 
            // Pop_Option_Drink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lbl_ProductPrice);
            this.Controls.Add(this.lbl_ProductName);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Confirm);
            this.Controls.Add(this.pn_Option);
            this.Controls.Add(this.pb_Select_Image);
            this.Name = "Pop_Option_Drink";
            this.Size = new System.Drawing.Size(600, 720);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Select_Image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pb_Select_Image;
        private System.Windows.Forms.Panel pn_Option;
        private System.Windows.Forms.Button btn_Confirm;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label lbl_ProductName;
        private System.Windows.Forms.Label lbl_ProductPrice;
    }
}