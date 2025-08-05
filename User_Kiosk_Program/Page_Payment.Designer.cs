namespace User_Kiosk_Program
{
    partial class Page_Payment
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            flp_Payment_Cart = new FlowLayoutPanel();
            lbl_TotalPrice = new Label();
            btn_Back = new Button();
            SuspendLayout();
            // 
            // flp_Payment_Cart
            // 
            flp_Payment_Cart.AutoScroll = true;
            flp_Payment_Cart.Location = new Point(49, 207);
            flp_Payment_Cart.Name = "flp_Payment_Cart";
            flp_Payment_Cart.Size = new Size(620, 480);
            flp_Payment_Cart.TabIndex = 0;
            // 
            // lbl_TotalPrice
            // 
            lbl_TotalPrice.AutoSize = true;
            lbl_TotalPrice.Location = new Point(321, 719);
            lbl_TotalPrice.Name = "lbl_TotalPrice";
            lbl_TotalPrice.Size = new Size(39, 15);
            lbl_TotalPrice.TabIndex = 1;
            lbl_TotalPrice.Text = "label1";
            // 
            // btn_Back
            // 
            btn_Back.Location = new Point(588, 105);
            btn_Back.Name = "btn_Back";
            btn_Back.Size = new Size(75, 23);
            btn_Back.TabIndex = 2;
            btn_Back.Text = "button1";
            btn_Back.UseVisualStyleBackColor = true;
            // 
            // Page_Payment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btn_Back);
            Controls.Add(lbl_TotalPrice);
            Controls.Add(flp_Payment_Cart);
            Name = "Page_Payment";
            Size = new Size(720, 1020);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flp_Payment_Cart;
        private Label lbl_TotalPrice;
        private Button btn_Back;
    }
}
