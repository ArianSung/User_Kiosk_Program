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
            pb_Select_Image = new PictureBox();
            pn_Option = new Panel();
            btn_Confirm = new Button();
            btn_Cancel = new Button();
            lbl_ProductName = new Label();
            lbl_ProductPrice = new Label();
            lb_Select_Info = new Label();
            ((System.ComponentModel.ISupportInitialize)pb_Select_Image).BeginInit();
            SuspendLayout();
            // 
            // pb_Select_Image
            // 
            pb_Select_Image.Location = new Point(24, 24);
            pb_Select_Image.Name = "pb_Select_Image";
            pb_Select_Image.Size = new Size(180, 180);
            pb_Select_Image.SizeMode = PictureBoxSizeMode.Zoom;
            pb_Select_Image.TabIndex = 0;
            pb_Select_Image.TabStop = false;
            // 
            // pn_Option
            // 
            pn_Option.AutoScroll = true;
            pn_Option.BorderStyle = BorderStyle.FixedSingle;
            pn_Option.Location = new Point(24, 220);
            pn_Option.Name = "pn_Option";
            pn_Option.Size = new Size(552, 420);
            pn_Option.TabIndex = 1;
            // 
            // btn_Confirm
            // 
            btn_Confirm.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Confirm.Location = new Point(320, 655);
            btn_Confirm.Name = "btn_Confirm";
            btn_Confirm.Size = new Size(120, 50);
            btn_Confirm.TabIndex = 2;
            btn_Confirm.Text = "담기";
            btn_Confirm.UseVisualStyleBackColor = true;
            // 
            // btn_Cancel
            // 
            btn_Cancel.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Cancel.Location = new Point(160, 655);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(120, 50);
            btn_Cancel.TabIndex = 3;
            btn_Cancel.Text = "취소";
            btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // lbl_ProductName
            // 
            lbl_ProductName.AutoSize = true;
            lbl_ProductName.Font = new Font("맑은 고딕", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_ProductName.Location = new Point(220, 40);
            lbl_ProductName.Name = "lbl_ProductName";
            lbl_ProductName.Size = new Size(110, 32);
            lbl_ProductName.TabIndex = 4;
            lbl_ProductName.Text = "상품이름";
            // 
            // lbl_ProductPrice
            // 
            lbl_ProductPrice.AutoSize = true;
            lbl_ProductPrice.Font = new Font("맑은 고딕", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ProductPrice.Location = new Point(220, 90);
            lbl_ProductPrice.Name = "lbl_ProductPrice";
            lbl_ProductPrice.Size = new Size(88, 25);
            lbl_ProductPrice.TabIndex = 5;
            lbl_ProductPrice.Text = "상품가격";
            // 
            // lb_Select_Info
            // 
            lb_Select_Info.Font = new Font("맑은 고딕", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lb_Select_Info.Location = new Point(220, 130);
            lb_Select_Info.Name = "lb_Select_Info";
            lb_Select_Info.Size = new Size(350, 74);
            lb_Select_Info.TabIndex = 6;
            lb_Select_Info.Text = "상품 설명이 여기에 표시됩니다.";
            // 
            // Pop_Option_Drink
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lb_Select_Info);
            Controls.Add(lbl_ProductPrice);
            Controls.Add(lbl_ProductName);
            Controls.Add(btn_Cancel);
            Controls.Add(btn_Confirm);
            Controls.Add(pn_Option);
            Controls.Add(pb_Select_Image);
            Name = "Pop_Option_Drink";
            Size = new Size(600, 720);
            ((System.ComponentModel.ISupportInitialize)pb_Select_Image).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pb_Select_Image;
        private System.Windows.Forms.Panel pn_Option;
        private System.Windows.Forms.Button btn_Confirm;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label lbl_ProductName;
        private System.Windows.Forms.Label lbl_ProductPrice;
        private Label lb_Select_Info;
    }
}