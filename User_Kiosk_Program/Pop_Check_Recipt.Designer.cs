namespace User_Kiosk_Program
{
    partial class Pop_Check_Recipt
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
            lb_Quest_Recipt = new Label();
            btn_Yes = new Button();
            btn_No = new Button();
            pn_Pop_Check_Recipt = new Panel();
            pictureBox1 = new PictureBox();
            pn_Pop_Check_Recipt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lb_Quest_Recipt
            // 
            lb_Quest_Recipt.AutoSize = true;
            lb_Quest_Recipt.Font = new Font("맑은 고딕", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            lb_Quest_Recipt.Location = new Point(119, 117);
            lb_Quest_Recipt.Name = "lb_Quest_Recipt";
            lb_Quest_Recipt.Size = new Size(362, 37);
            lb_Quest_Recipt.TabIndex = 0;
            lb_Quest_Recipt.Text = "영수증을 출력하시겠습니까?";
            // 
            // btn_Yes
            // 
            btn_Yes.BackColor = Color.RosyBrown;
            btn_Yes.FlatStyle = FlatStyle.Flat;
            btn_Yes.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Yes.Location = new Point(364, 700);
            btn_Yes.Name = "btn_Yes";
            btn_Yes.Size = new Size(146, 64);
            btn_Yes.TabIndex = 4;
            btn_Yes.Text = "출력";
            btn_Yes.UseVisualStyleBackColor = false;
            btn_Yes.Click += btn_Yes_Click;
            // 
            // btn_No
            // 
            btn_No.BackColor = Color.White;
            btn_No.FlatStyle = FlatStyle.Flat;
            btn_No.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_No.Location = new Point(92, 700);
            btn_No.Name = "btn_No";
            btn_No.Size = new Size(146, 64);
            btn_No.TabIndex = 6;
            btn_No.Text = "미출력";
            btn_No.UseVisualStyleBackColor = false;
            btn_No.Click += btn_No_Click;
            // 
            // pn_Pop_Check_Recipt
            // 
            pn_Pop_Check_Recipt.BackColor = Color.Snow;
            pn_Pop_Check_Recipt.Controls.Add(pictureBox1);
            pn_Pop_Check_Recipt.Controls.Add(lb_Quest_Recipt);
            pn_Pop_Check_Recipt.Controls.Add(btn_No);
            pn_Pop_Check_Recipt.Controls.Add(btn_Yes);
            pn_Pop_Check_Recipt.Dock = DockStyle.Fill;
            pn_Pop_Check_Recipt.Location = new Point(0, 0);
            pn_Pop_Check_Recipt.Name = "pn_Pop_Check_Recipt";
            pn_Pop_Check_Recipt.Size = new Size(600, 850);
            pn_Pop_Check_Recipt.TabIndex = 7;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.로고_8;
            pictureBox1.Location = new Point(466, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(134, 98);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // Pop_Check_Recipt
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pn_Pop_Check_Recipt);
            Name = "Pop_Check_Recipt";
            Size = new Size(600, 850);
            pn_Pop_Check_Recipt.ResumeLayout(false);
            pn_Pop_Check_Recipt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lb_Quest_Recipt;
        private Button btn_Yes;
        private Button btn_No;
        private Panel pn_Pop_Check_Recipt;
        private PictureBox pictureBox1;
    }
}
