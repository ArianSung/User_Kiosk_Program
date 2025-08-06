namespace User_Kiosk_Program
{
    partial class Page_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Page_Main));
            pn_BoardContainer = new Panel();
            flp_Categories = new FlowLayoutPanel();
            flp_Cart = new FlowLayoutPanel();
            btn_Next = new Button();
            btn_Prev = new Button();
            lbl_PageInfo = new Label();
            btn_GotoPay = new Button();
            lbl_CartTotal = new Label();
            pb_Logo = new PictureBox();
            btn_Home = new Button();
            ((System.ComponentModel.ISupportInitialize)pb_Logo).BeginInit();
            SuspendLayout();
            // 
            // pn_BoardContainer
            // 
            pn_BoardContainer.BackColor = Color.White;
            pn_BoardContainer.BorderStyle = BorderStyle.Fixed3D;
            pn_BoardContainer.Location = new Point(56, 130);
            pn_BoardContainer.Name = "pn_BoardContainer";
            pn_BoardContainer.Size = new Size(600, 589);
            pn_BoardContainer.TabIndex = 0;
            // 
            // flp_Categories
            // 
            flp_Categories.Location = new Point(56, 74);
            flp_Categories.Name = "flp_Categories";
            flp_Categories.Size = new Size(600, 57);
            flp_Categories.TabIndex = 4;
            // 
            // flp_Cart
            // 
            flp_Cart.AutoScroll = true;
            flp_Cart.BackColor = Color.White;
            flp_Cart.Location = new Point(56, 753);
            flp_Cart.Name = "flp_Cart";
            flp_Cart.Size = new Size(600, 180);
            flp_Cart.TabIndex = 5;
            flp_Cart.WrapContents = false;
            // 
            // btn_Next
            // 
            btn_Next.Location = new Point(447, 724);
            btn_Next.Name = "btn_Next";
            btn_Next.Size = new Size(75, 23);
            btn_Next.TabIndex = 6;
            btn_Next.Text = "다음";
            btn_Next.UseVisualStyleBackColor = true;
            // 
            // btn_Prev
            // 
            btn_Prev.Location = new Point(202, 724);
            btn_Prev.Name = "btn_Prev";
            btn_Prev.Size = new Size(75, 23);
            btn_Prev.TabIndex = 7;
            btn_Prev.Text = "이전";
            btn_Prev.UseVisualStyleBackColor = true;
            // 
            // lbl_PageInfo
            // 
            lbl_PageInfo.AutoSize = true;
            lbl_PageInfo.Location = new Point(341, 728);
            lbl_PageInfo.Name = "lbl_PageInfo";
            lbl_PageInfo.Size = new Size(39, 15);
            lbl_PageInfo.TabIndex = 8;
            lbl_PageInfo.Text = "label1";
            // 
            // btn_GotoPay
            // 
            btn_GotoPay.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_GotoPay.Location = new Point(546, 940);
            btn_GotoPay.Name = "btn_GotoPay";
            btn_GotoPay.Size = new Size(110, 60);
            btn_GotoPay.TabIndex = 9;
            btn_GotoPay.Text = "결제하기";
            btn_GotoPay.UseVisualStyleBackColor = true;
            // 
            // lbl_CartTotal
            // 
            lbl_CartTotal.Font = new Font("맑은 고딕", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_CartTotal.Location = new Point(56, 940);
            lbl_CartTotal.Name = "lbl_CartTotal";
            lbl_CartTotal.Size = new Size(480, 60);
            lbl_CartTotal.TabIndex = 10;
            lbl_CartTotal.Text = "총 금액: ₩ 0";
            lbl_CartTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pb_Logo
            // 
            pb_Logo.Location = new Point(647, 3);
            pb_Logo.Name = "pb_Logo";
            pb_Logo.Size = new Size(70, 70);
            pb_Logo.TabIndex = 11;
            pb_Logo.TabStop = false;
            // 
            // btn_Home
            // 
            btn_Home.BackColor = Color.Transparent;
            btn_Home.BackgroundImage = (Image)resources.GetObject("btn_Home.BackgroundImage");
            btn_Home.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Home.FlatAppearance.BorderSize = 0;
            btn_Home.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn_Home.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_Home.FlatStyle = FlatStyle.Flat;
            btn_Home.ForeColor = Color.White;
            btn_Home.Location = new Point(3, 3);
            btn_Home.Name = "btn_Home";
            btn_Home.Size = new Size(70, 65);
            btn_Home.TabIndex = 12;
            btn_Home.UseVisualStyleBackColor = false;
            // 
            // Page_Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btn_Home);
            Controls.Add(btn_Next);
            Controls.Add(btn_Prev);
            Controls.Add(lbl_PageInfo);
            Controls.Add(pn_BoardContainer);
            Controls.Add(flp_Cart);
            Controls.Add(flp_Categories);
            Controls.Add(btn_GotoPay);
            Controls.Add(lbl_CartTotal);
            Controls.Add(pb_Logo);
            Name = "Page_Main";
            Size = new Size(720, 1020);
            ((System.ComponentModel.ISupportInitialize)pb_Logo).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private Panel pn_BoardContainer;
        private FlowLayoutPanel flp_Categories;
        private FlowLayoutPanel flp_Cart;
        private Button btn_Next;
        private Button btn_Prev;
        private Label lbl_PageInfo;
        private Button btn_GotoPay;
        private Label lbl_CartTotal; // 이 줄을 추가하세요.
        private PictureBox pb_Logo;
        private Button btn_Home;
    }
}
