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
            SuspendLayout();
            // 
            // btn_Pay
            // 
            btn_Pay.AccessibleRole = AccessibleRole.None;
            btn_Pay.Location = new Point(223, 172);
            btn_Pay.Name = "btn_Pay";
            btn_Pay.Size = new Size(75, 23);
            btn_Pay.TabIndex = 0;
            btn_Pay.Text = "button1";
            btn_Pay.UseVisualStyleBackColor = true;
            // 
            // btn_Cancel
            // 
            btn_Cancel.Location = new Point(100, 172);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(75, 23);
            btn_Cancel.TabIndex = 0;
            btn_Cancel.Text = "button1";
            btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // Pop_Use_Card
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btn_Cancel);
            Controls.Add(btn_Pay);
            Name = "Pop_Use_Card";
            Size = new Size(400, 250);
            ResumeLayout(false);
        }

        #endregion

        private Button btn_Pay;
        private Button btn_Cancel;
    }
}
