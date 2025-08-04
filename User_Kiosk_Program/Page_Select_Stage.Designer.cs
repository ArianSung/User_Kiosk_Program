namespace User_Kiosk_Program
{
    partial class Page_Select_Stage
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
            pb_WebBanner = new PictureBox();
            pn_Bottom = new Panel();
            btn_Pickup = new Button();
            btn_Store = new Button();
            ((System.ComponentModel.ISupportInitialize)pb_WebBanner).BeginInit();
            pn_Bottom.SuspendLayout();
            SuspendLayout();
            // 
            // pb_WebBanner
            // 
            pb_WebBanner.Location = new Point(0, 0);
            pb_WebBanner.Name = "pb_WebBanner";
            pb_WebBanner.Size = new Size(720, 800);
            pb_WebBanner.TabIndex = 0;
            pb_WebBanner.TabStop = false;
            // 
            // pn_Bottom
            // 
            pn_Bottom.Controls.Add(btn_Pickup);
            pn_Bottom.Controls.Add(btn_Store);
            pn_Bottom.Location = new Point(0, 800);
            pn_Bottom.Name = "pn_Bottom";
            pn_Bottom.Size = new Size(720, 220);
            pn_Bottom.TabIndex = 1;
            // 
            // btn_Pickup
            // 
            btn_Pickup.Font = new Font("맑은 고딕", 36F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Pickup.Location = new Point(415, 45);
            btn_Pickup.Name = "btn_Pickup";
            btn_Pickup.Size = new Size(250, 130);
            btn_Pickup.TabIndex = 0;
            btn_Pickup.Text = "픽업";
            btn_Pickup.UseVisualStyleBackColor = true;
            btn_Pickup.Click += btn_Pickup_Click;
            // 
            // btn_Store
            // 
            btn_Store.Font = new Font("맑은 고딕", 36F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Store.Location = new Point(55, 45);
            btn_Store.Name = "btn_Store";
            btn_Store.Size = new Size(250, 130);
            btn_Store.TabIndex = 0;
            btn_Store.Text = "매장";
            btn_Store.UseVisualStyleBackColor = true;
            btn_Store.Click += btn_Store_Click;
            // 
            // Page_Select_Stage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pn_Bottom);
            Controls.Add(pb_WebBanner);
            Name = "Page_Select_Stage";
            Size = new Size(720, 1020);
            ((System.ComponentModel.ISupportInitialize)pb_WebBanner).EndInit();
            pn_Bottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pb_WebBanner;
        private Panel pn_Bottom;
        private Button btn_Pickup;
        private Button btn_Store;
    }
}
