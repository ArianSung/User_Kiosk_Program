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
            btn_Back = new Button();
            panel_PaymentDetails = new Panel();
            lbl_FinalAmount = new Label();
            lbl_PointsUsed = new Label();
            lbl_OrderAmount = new Label();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            btn_Pay = new Button();
            pb_Logo = new PictureBox();
            panel_PaymentDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_Logo).BeginInit();
            SuspendLayout();
            // 
            // flp_Payment_Cart
            // 
            flp_Payment_Cart.AutoScroll = true;
            flp_Payment_Cart.BackColor = Color.White;
            flp_Payment_Cart.BorderStyle = BorderStyle.FixedSingle;
            flp_Payment_Cart.FlowDirection = FlowDirection.TopDown;
            flp_Payment_Cart.Location = new Point(60, 100);
            flp_Payment_Cart.Name = "flp_Payment_Cart";
            flp_Payment_Cart.Size = new Size(600, 650);
            flp_Payment_Cart.TabIndex = 0;
            flp_Payment_Cart.WrapContents = false;
            // 
            // btn_Back
            // 
            btn_Back.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Back.Location = new Point(60, 30);
            btn_Back.Name = "btn_Back";
            btn_Back.Size = new Size(120, 50);
            btn_Back.TabIndex = 2;
            btn_Back.Text = "이전으로";
            btn_Back.UseVisualStyleBackColor = true;
            // 
            // panel_PaymentDetails
            // 
            panel_PaymentDetails.BackColor = Color.FromArgb(240, 240, 240);
            panel_PaymentDetails.Controls.Add(lbl_FinalAmount);
            panel_PaymentDetails.Controls.Add(lbl_PointsUsed);
            panel_PaymentDetails.Controls.Add(lbl_OrderAmount);
            panel_PaymentDetails.Controls.Add(label4);
            panel_PaymentDetails.Controls.Add(label3);
            panel_PaymentDetails.Controls.Add(label1);
            panel_PaymentDetails.Location = new Point(60, 753);
            panel_PaymentDetails.Name = "panel_PaymentDetails";
            panel_PaymentDetails.Size = new Size(600, 77);
            panel_PaymentDetails.TabIndex = 3;
            // 
            // lbl_FinalAmount
            // 
            lbl_FinalAmount.Font = new Font("맑은 고딕", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_FinalAmount.ForeColor = Color.Red;
            lbl_FinalAmount.Location = new Point(430, 39);
            lbl_FinalAmount.Name = "lbl_FinalAmount";
            lbl_FinalAmount.Size = new Size(150, 30);
            lbl_FinalAmount.TabIndex = 6;
            lbl_FinalAmount.Text = "₩ 0";
            lbl_FinalAmount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbl_PointsUsed
            // 
            lbl_PointsUsed.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_PointsUsed.Location = new Point(149, 47);
            lbl_PointsUsed.Name = "lbl_PointsUsed";
            lbl_PointsUsed.Size = new Size(130, 21);
            lbl_PointsUsed.TabIndex = 5;
            lbl_PointsUsed.Text = "₩ 0";
            lbl_PointsUsed.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_OrderAmount
            // 
            lbl_OrderAmount.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_OrderAmount.Location = new Point(13, 47);
            lbl_OrderAmount.Name = "lbl_OrderAmount";
            lbl_OrderAmount.Size = new Size(130, 21);
            lbl_OrderAmount.TabIndex = 4;
            lbl_OrderAmount.Text = "₩ 0";
            lbl_OrderAmount.TextAlign = ContentAlignment.MiddleLeft;
            lbl_OrderAmount.Click += lbl_OrderAmount_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(447, 13);
            label4.Name = "label4";
            label4.Size = new Size(133, 25);
            label4.TabIndex = 3;
            label4.Text = "최종 결제금액";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(149, 16);
            label3.Name = "label3";
            label3.Size = new Size(96, 21);
            label3.TabIndex = 2;
            label3.Text = "사용 포인트";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(13, 13);
            label1.Name = "label1";
            label1.Size = new Size(74, 21);
            label1.TabIndex = 0;
            label1.Text = "주문금액";
            label1.Click += label1_Click;
            // 
            // btn_Pay
            // 
            btn_Pay.Font = new Font("맑은 고딕", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Pay.Location = new Point(60, 930);
            btn_Pay.Name = "btn_Pay";
            btn_Pay.Size = new Size(600, 70);
            btn_Pay.TabIndex = 4;
            btn_Pay.Text = "결제하기";
            btn_Pay.UseVisualStyleBackColor = true;
            // 
            // pb_Logo
            // 
            pb_Logo.Location = new Point(647, 3);
            pb_Logo.Name = "pb_Logo";
            pb_Logo.Size = new Size(70, 70);
            pb_Logo.TabIndex = 12;
            pb_Logo.TabStop = false;
            // 
            // Page_Payment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pb_Logo);
            Controls.Add(btn_Pay);
            Controls.Add(panel_PaymentDetails);
            Controls.Add(btn_Back);
            Controls.Add(flp_Payment_Cart);
            Name = "Page_Payment";
            Size = new Size(720, 1020);
            panel_PaymentDetails.ResumeLayout(false);
            panel_PaymentDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pb_Logo).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel flp_Payment_Cart;
        private Button btn_Back;
        private Panel panel_PaymentDetails;
        private Label lbl_FinalAmount;
        private Label lbl_PointsUsed;
        private Label lbl_OrderAmount;
        private Label label4;
        private Label label3;
        private Label label1;
        private Button btn_Pay;
        private PictureBox pb_Logo;
    }
}
