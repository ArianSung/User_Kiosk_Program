namespace User_Kiosk_Program
{
    partial class Pop_Use_Point_OK
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
            pn_Use_Point_OK = new Panel();
            lb_Use_Point_OK = new Label();
            brn_OK = new Button();
            pn_Use_Point_OK.SuspendLayout();
            SuspendLayout();
            // 
            // pn_Use_Point_OK
            // 
            pn_Use_Point_OK.BackColor = Color.Snow;
            pn_Use_Point_OK.Controls.Add(lb_Use_Point_OK);
            pn_Use_Point_OK.Controls.Add(brn_OK);
            pn_Use_Point_OK.Dock = DockStyle.Fill;
            pn_Use_Point_OK.Location = new Point(0, 0);
            pn_Use_Point_OK.Name = "pn_Use_Point_OK";
            pn_Use_Point_OK.Size = new Size(600, 850);
            pn_Use_Point_OK.TabIndex = 9;
            // 
            // lb_Use_Point_OK
            // 
            lb_Use_Point_OK.AutoSize = true;
            lb_Use_Point_OK.Font = new Font("맑은 고딕", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            lb_Use_Point_OK.Location = new Point(135, 331);
            lb_Use_Point_OK.Name = "lb_Use_Point_OK";
            lb_Use_Point_OK.Size = new Size(330, 37);
            lb_Use_Point_OK.TabIndex = 6;
            lb_Use_Point_OK.Text = "포인트가 사용되었습니다.";
            // 
            // brn_OK
            // 
            brn_OK.BackColor = Color.RosyBrown;
            brn_OK.FlatStyle = FlatStyle.Flat;
            brn_OK.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            brn_OK.Location = new Point(227, 700);
            brn_OK.Name = "brn_OK";
            brn_OK.Size = new Size(146, 64);
            brn_OK.TabIndex = 5;
            brn_OK.Text = "확인";
            brn_OK.UseVisualStyleBackColor = false;
            brn_OK.Click += brn_OK_Click;
            // 
            // Pop_Use_Point_OK
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            Controls.Add(pn_Use_Point_OK);
            Name = "Pop_Use_Point_OK";
            Size = new Size(600, 850);
            pn_Use_Point_OK.ResumeLayout(false);
            pn_Use_Point_OK.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pn_Use_Point_OK;
        private Label lb_Use_Point_OK;
        private Button brn_OK;
    }
}
