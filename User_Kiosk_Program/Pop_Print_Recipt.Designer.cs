namespace User_Kiosk_Program
{
    partial class Pop_Print_Recipt
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
            lb_Order_Num = new Label();
            lb_Recipt_text = new Label();
            lb_Confirm = new Label();
            SuspendLayout();
            // 
            // lb_Order_Num
            // 
            lb_Order_Num.AutoSize = true;
            lb_Order_Num.Font = new Font("맑은 고딕", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lb_Order_Num.Location = new Point(235, 119);
            lb_Order_Num.Name = "lb_Order_Num";
            lb_Order_Num.Size = new Size(118, 32);
            lb_Order_Num.TabIndex = 0;
            lb_Order_Num.Text = "주문 번호";
            // 
            // lb_Recipt_text
            // 
            lb_Recipt_text.AutoSize = true;
            lb_Recipt_text.Location = new Point(145, 210);
            lb_Recipt_text.Name = "lb_Recipt_text";
            lb_Recipt_text.Size = new Size(80, 15);
            lb_Recipt_text.TabIndex = 1;
            lb_Recipt_text.Text = "lb_Recipt_text";
            // 
            // lb_Confirm
            // 
            lb_Confirm.AutoSize = true;
            lb_Confirm.Location = new Point(146, 310);
            lb_Confirm.Name = "lb_Confirm";
            lb_Confirm.Size = new Size(142, 15);
            lb_Confirm.TabIndex = 2;
            lb_Confirm.Text = "lb_Confirm (그냥 확인용)";
            // 
            // Pop_Print_Recipt
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lb_Confirm);
            Controls.Add(lb_Recipt_text);
            Controls.Add(lb_Order_Num);
            Name = "Pop_Print_Recipt";
            Size = new Size(600, 850);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lb_Order_Num;
        private Label lb_Recipt_text;
        private Label lb_Confirm;
    }
}
