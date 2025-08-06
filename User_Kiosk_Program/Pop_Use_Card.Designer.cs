namespace User_Kiosk_Program
{
    partial class Pop_Use_Card
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
            btn_Pay = new Button();
            btn_Cancel = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btn_Pay
            // 
            btn_Pay.AccessibleRole = AccessibleRole.None;
            btn_Pay.Location = new Point(203, 125);
            btn_Pay.Name = "btn_Pay";
            btn_Pay.Size = new Size(122, 52);
            btn_Pay.TabIndex = 0;
            btn_Pay.Text = "예";
            btn_Pay.UseVisualStyleBackColor = true;
            // 
            // btn_Cancel
            // 
            btn_Cancel.Location = new Point(75, 125);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(122, 52);
            btn_Cancel.TabIndex = 0;
            btn_Cancel.Text = "아니오";
            btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(139, 87);
            label1.Name = "label1";
            label1.Size = new Size(109, 15);
            label1.TabIndex = 1;
            label1.Text = "결제하시겠습니까?";
            // 
            // Pop_Use_Card
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(btn_Cancel);
            Controls.Add(btn_Pay);
            Name = "Pop_Use_Card";
            Size = new Size(400, 250);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Pay;
        private Button btn_Cancel;
        private Label label1;
    }
}
