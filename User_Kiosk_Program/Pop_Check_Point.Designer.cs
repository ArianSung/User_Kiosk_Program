namespace User_Kiosk_Program
{
    partial class Pop_Check_Point
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
            lb_Point_Use = new Label();
            textBox_Phone = new TextBox();
            pn_Number_Pad = new Panel();
            btn_C = new Button();
            btn_Backspace = new Button();
            btn_0 = new Button();
            btn_9 = new Button();
            btn_8 = new Button();
            btn_6 = new Button();
            btn_5 = new Button();
            btn_7 = new Button();
            btn_3 = new Button();
            btn_4 = new Button();
            btn_2 = new Button();
            btn_1 = new Button();
            btn_Check_Point = new Button();
            pn_Pop_Check_Point = new Panel();
            pictureBox1 = new PictureBox();
            btn_Cacel = new Button();
            lb_Check_Point = new Label();
            pn_PointWarning = new Panel();
            pn_New_Member1 = new Panel();
            pictureBox3 = new PictureBox();
            btnPointWarningOK = new Button();
            lblPointWarningMessage = new Label();
            pn_Number_Pad.SuspendLayout();
            pn_Pop_Check_Point.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pn_PointWarning.SuspendLayout();
            pn_New_Member1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // lb_Point_Use
            // 
            lb_Point_Use.AutoSize = true;
            lb_Point_Use.Font = new Font("맑은 고딕", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            lb_Point_Use.Location = new Point(220, 85);
            lb_Point_Use.Name = "lb_Point_Use";
            lb_Point_Use.Size = new Size(161, 37);
            lb_Point_Use.TabIndex = 0;
            lb_Point_Use.Text = "포인트 조회";
            // 
            // textBox_Phone
            // 
            textBox_Phone.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_Phone.Location = new Point(188, 154);
            textBox_Phone.Name = "textBox_Phone";
            textBox_Phone.Size = new Size(224, 29);
            textBox_Phone.TabIndex = 1;
            // 
            // pn_Number_Pad
            // 
            pn_Number_Pad.Controls.Add(btn_C);
            pn_Number_Pad.Controls.Add(btn_Backspace);
            pn_Number_Pad.Controls.Add(btn_0);
            pn_Number_Pad.Controls.Add(btn_9);
            pn_Number_Pad.Controls.Add(btn_8);
            pn_Number_Pad.Controls.Add(btn_6);
            pn_Number_Pad.Controls.Add(btn_5);
            pn_Number_Pad.Controls.Add(btn_7);
            pn_Number_Pad.Controls.Add(btn_3);
            pn_Number_Pad.Controls.Add(btn_4);
            pn_Number_Pad.Controls.Add(btn_2);
            pn_Number_Pad.Controls.Add(btn_1);
            pn_Number_Pad.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            pn_Number_Pad.Location = new Point(121, 228);
            pn_Number_Pad.Name = "pn_Number_Pad";
            pn_Number_Pad.Size = new Size(359, 395);
            pn_Number_Pad.TabIndex = 3;
            // 
            // btn_C
            // 
            btn_C.BackColor = SystemColors.ControlLight;
            btn_C.FlatStyle = FlatStyle.Flat;
            btn_C.Location = new Point(3, 297);
            btn_C.Name = "btn_C";
            btn_C.Size = new Size(114, 92);
            btn_C.TabIndex = 5;
            btn_C.Text = "C";
            btn_C.UseVisualStyleBackColor = false;
            btn_C.Click += btn_C_Click;
            // 
            // btn_Backspace
            // 
            btn_Backspace.BackColor = SystemColors.ControlLight;
            btn_Backspace.FlatStyle = FlatStyle.Flat;
            btn_Backspace.Location = new Point(243, 297);
            btn_Backspace.Name = "btn_Backspace";
            btn_Backspace.Size = new Size(114, 92);
            btn_Backspace.TabIndex = 0;
            btn_Backspace.Text = "Backspace";
            btn_Backspace.UseVisualStyleBackColor = false;
            btn_Backspace.Click += btn_Backspace_Click;
            // 
            // btn_0
            // 
            btn_0.BackColor = Color.White;
            btn_0.FlatStyle = FlatStyle.Flat;
            btn_0.Location = new Point(123, 297);
            btn_0.Name = "btn_0";
            btn_0.Size = new Size(114, 92);
            btn_0.TabIndex = 0;
            btn_0.Text = "0";
            btn_0.UseVisualStyleBackColor = false;
            btn_0.Click += btn_0_Click;
            // 
            // btn_9
            // 
            btn_9.BackColor = Color.White;
            btn_9.FlatStyle = FlatStyle.Flat;
            btn_9.Location = new Point(243, 199);
            btn_9.Name = "btn_9";
            btn_9.Size = new Size(114, 92);
            btn_9.TabIndex = 0;
            btn_9.Text = "9";
            btn_9.UseVisualStyleBackColor = false;
            btn_9.Click += btn_9_Click;
            // 
            // btn_8
            // 
            btn_8.BackColor = Color.White;
            btn_8.FlatStyle = FlatStyle.Flat;
            btn_8.Location = new Point(123, 199);
            btn_8.Name = "btn_8";
            btn_8.Size = new Size(114, 92);
            btn_8.TabIndex = 0;
            btn_8.Text = "8";
            btn_8.UseVisualStyleBackColor = false;
            btn_8.Click += btn_8_Click;
            // 
            // btn_6
            // 
            btn_6.BackColor = Color.White;
            btn_6.FlatStyle = FlatStyle.Flat;
            btn_6.Location = new Point(243, 101);
            btn_6.Name = "btn_6";
            btn_6.Size = new Size(114, 92);
            btn_6.TabIndex = 0;
            btn_6.Text = "6";
            btn_6.UseVisualStyleBackColor = false;
            btn_6.Click += btn_6_Click;
            // 
            // btn_5
            // 
            btn_5.BackColor = Color.White;
            btn_5.FlatStyle = FlatStyle.Flat;
            btn_5.Location = new Point(123, 101);
            btn_5.Name = "btn_5";
            btn_5.Size = new Size(114, 92);
            btn_5.TabIndex = 0;
            btn_5.Text = "5";
            btn_5.UseVisualStyleBackColor = false;
            btn_5.Click += btn_5_Click;
            // 
            // btn_7
            // 
            btn_7.BackColor = Color.White;
            btn_7.FlatStyle = FlatStyle.Flat;
            btn_7.Location = new Point(3, 199);
            btn_7.Name = "btn_7";
            btn_7.Size = new Size(114, 92);
            btn_7.TabIndex = 0;
            btn_7.Text = "7";
            btn_7.UseVisualStyleBackColor = false;
            btn_7.Click += btn_7_Click;
            // 
            // btn_3
            // 
            btn_3.BackColor = Color.White;
            btn_3.FlatStyle = FlatStyle.Flat;
            btn_3.Location = new Point(243, 3);
            btn_3.Name = "btn_3";
            btn_3.Size = new Size(114, 92);
            btn_3.TabIndex = 0;
            btn_3.Text = "3";
            btn_3.UseVisualStyleBackColor = false;
            btn_3.Click += btn_3_Click;
            // 
            // btn_4
            // 
            btn_4.BackColor = Color.White;
            btn_4.FlatStyle = FlatStyle.Flat;
            btn_4.Location = new Point(3, 101);
            btn_4.Name = "btn_4";
            btn_4.Size = new Size(114, 92);
            btn_4.TabIndex = 0;
            btn_4.Text = "4";
            btn_4.UseVisualStyleBackColor = false;
            btn_4.Click += btn_4_Click;
            // 
            // btn_2
            // 
            btn_2.BackColor = Color.White;
            btn_2.FlatStyle = FlatStyle.Flat;
            btn_2.Location = new Point(123, 3);
            btn_2.Name = "btn_2";
            btn_2.Size = new Size(114, 92);
            btn_2.TabIndex = 0;
            btn_2.Text = "2";
            btn_2.UseVisualStyleBackColor = false;
            btn_2.Click += btn_2_Click;
            // 
            // btn_1
            // 
            btn_1.BackColor = Color.White;
            btn_1.FlatStyle = FlatStyle.Flat;
            btn_1.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_1.Location = new Point(3, 3);
            btn_1.Name = "btn_1";
            btn_1.Size = new Size(114, 92);
            btn_1.TabIndex = 0;
            btn_1.Text = "1";
            btn_1.UseVisualStyleBackColor = false;
            btn_1.Click += btn_1_Click;
            // 
            // btn_Check_Point
            // 
            btn_Check_Point.BackColor = Color.RosyBrown;
            btn_Check_Point.FlatStyle = FlatStyle.Flat;
            btn_Check_Point.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Check_Point.Location = new Point(364, 700);
            btn_Check_Point.Name = "btn_Check_Point";
            btn_Check_Point.Size = new Size(146, 64);
            btn_Check_Point.TabIndex = 6;
            btn_Check_Point.Text = "조회";
            btn_Check_Point.UseVisualStyleBackColor = false;
            btn_Check_Point.Click += btn_Check_Point_Click;
            // 
            // pn_Pop_Check_Point
            // 
            pn_Pop_Check_Point.BackColor = Color.Snow;
            pn_Pop_Check_Point.Controls.Add(pn_PointWarning);
            pn_Pop_Check_Point.Controls.Add(pictureBox1);
            pn_Pop_Check_Point.Controls.Add(btn_Cacel);
            pn_Pop_Check_Point.Controls.Add(lb_Check_Point);
            pn_Pop_Check_Point.Controls.Add(lb_Point_Use);
            pn_Pop_Check_Point.Controls.Add(btn_Check_Point);
            pn_Pop_Check_Point.Controls.Add(textBox_Phone);
            pn_Pop_Check_Point.Controls.Add(pn_Number_Pad);
            pn_Pop_Check_Point.Dock = DockStyle.Fill;
            pn_Pop_Check_Point.Location = new Point(0, 0);
            pn_Pop_Check_Point.Name = "pn_Pop_Check_Point";
            pn_Pop_Check_Point.Size = new Size(600, 850);
            pn_Pop_Check_Point.TabIndex = 7;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.로고_8;
            pictureBox1.Location = new Point(466, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(134, 98);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // btn_Cacel
            // 
            btn_Cacel.BackColor = Color.White;
            btn_Cacel.FlatStyle = FlatStyle.Flat;
            btn_Cacel.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Cacel.Location = new Point(92, 700);
            btn_Cacel.Name = "btn_Cacel";
            btn_Cacel.Size = new Size(146, 64);
            btn_Cacel.TabIndex = 7;
            btn_Cacel.Text = "취소";
            btn_Cacel.UseVisualStyleBackColor = false;
            btn_Cacel.Click += btn_Cacel_Click;
            // 
            // lb_Check_Point
            // 
            lb_Check_Point.AutoSize = true;
            lb_Check_Point.Font = new Font("맑은 고딕", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lb_Check_Point.Location = new Point(187, 189);
            lb_Check_Point.Name = "lb_Check_Point";
            lb_Check_Point.Size = new Size(133, 32);
            lb_Check_Point.TabIndex = 0;
            lb_Check_Point.Text = "             P";
            lb_Check_Point.TextAlign = ContentAlignment.TopCenter;
            // 
            // pn_PointWarning
            // 
            pn_PointWarning.BackColor = Color.Black;
            pn_PointWarning.Controls.Add(pn_New_Member1);
            pn_PointWarning.Location = new Point(36, 114);
            pn_PointWarning.Name = "pn_PointWarning";
            pn_PointWarning.Size = new Size(360, 390);
            pn_PointWarning.TabIndex = 13;
            // 
            // pn_New_Member1
            // 
            pn_New_Member1.BackColor = Color.Snow;
            pn_New_Member1.Controls.Add(pictureBox3);
            pn_New_Member1.Controls.Add(btnPointWarningOK);
            pn_New_Member1.Controls.Add(lblPointWarningMessage);
            pn_New_Member1.Location = new Point(2, 2);
            pn_New_Member1.Name = "pn_New_Member1";
            pn_New_Member1.Size = new Size(356, 386);
            pn_New_Member1.TabIndex = 10;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.로고_8;
            pictureBox3.Location = new Point(252, 0);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(104, 80);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 8;
            pictureBox3.TabStop = false;
            // 
            // btnPointWarningOK
            // 
            btnPointWarningOK.BackColor = Color.RosyBrown;
            btnPointWarningOK.FlatStyle = FlatStyle.Flat;
            btnPointWarningOK.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnPointWarningOK.Location = new Point(97, 269);
            btnPointWarningOK.Name = "btnPointWarningOK";
            btnPointWarningOK.Size = new Size(146, 67);
            btnPointWarningOK.TabIndex = 7;
            btnPointWarningOK.Text = "확인";
            btnPointWarningOK.UseVisualStyleBackColor = false;
            btnPointWarningOK.Click += btnPointWarningOK_Click;
            // 
            // lblPointWarningMessage
            // 
            lblPointWarningMessage.AutoSize = true;
            lblPointWarningMessage.Font = new Font("맑은 고딕", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblPointWarningMessage.Location = new Point(32, 115);
            lblPointWarningMessage.Name = "lblPointWarningMessage";
            lblPointWarningMessage.Size = new Size(71, 37);
            lblPointWarningMessage.TabIndex = 6;
            lblPointWarningMessage.Text = "신규";
            lblPointWarningMessage.TextAlign = ContentAlignment.TopCenter;
            // 
            // Pop_Check_Point
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pn_Pop_Check_Point);
            Name = "Pop_Check_Point";
            Size = new Size(600, 850);
            pn_Number_Pad.ResumeLayout(false);
            pn_Pop_Check_Point.ResumeLayout(false);
            pn_Pop_Check_Point.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pn_PointWarning.ResumeLayout(false);
            pn_New_Member1.ResumeLayout(false);
            pn_New_Member1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lb_Point_Use;
        private TextBox textBox_Phone;
        private Panel pn_Number_Pad;
        private Button btn_C;
        private Button btn_Backspace;
        private Button btn_0;
        private Button btn_9;
        private Button btn_8;
        private Button btn_6;
        private Button btn_5;
        private Button btn_7;
        private Button btn_3;
        private Button btn_4;
        private Button btn_2;
        private Button btn_1;
        private Button btn_Check_Point;
        private Panel pn_Pop_Check_Point;
        private Label lb_Check_Point;
        private Button btn_Cacel;
        private PictureBox pictureBox1;
        private Panel pn_PointWarning;
        private Panel pn_New_Member1;
        private PictureBox pictureBox3;
        private Button btnPointWarningOK;
        private Label lblPointWarningMessage;
    }
}
