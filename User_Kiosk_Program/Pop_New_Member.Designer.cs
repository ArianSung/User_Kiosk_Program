namespace User_Kiosk_Program
{
    partial class Pop_New_Member
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
            btn_Confirm = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btn_Confirm
            // 
            btn_Confirm.Location = new Point(156, 164);
            btn_Confirm.Name = "btn_Confirm";
            btn_Confirm.Size = new Size(75, 23);
            btn_Confirm.TabIndex = 0;
            btn_Confirm.Text = "확인";
            btn_Confirm.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(145, 89);
            label1.Name = "label1";
            label1.Size = new Size(103, 15);
            label1.TabIndex = 1;
            label1.Text = "신규사용자입니다";
            // 
            // Pop_New_Member
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(btn_Confirm);
            Name = "Pop_New_Member";
            Size = new Size(400, 250);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Confirm;
        private Label label1;
    }
}
