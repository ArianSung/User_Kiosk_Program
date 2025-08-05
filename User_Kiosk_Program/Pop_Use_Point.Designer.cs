namespace User_Kiosk_Program
{
    partial class Pop_Use_Point
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
            lb_Total_Point = new Label();
            lb_Point_Info = new Label();
            lb_Balance_Point = new Label();
            lb_Warn = new Label();
            lb_Quest_Point = new Label();
            pn_Number_Pad = new Panel();
            btn_Backspace = new Button();
            btn_C = new Button();
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
            btn_Use_AllPoint = new Button();
            btn_Confirm = new Button();
            btn_Cacel = new Button();
            textBox_Use_Point = new TextBox();
            pn_Pop_Use_Point = new Panel();
            pn_Warning = new Panel();
            pn_New_Member1 = new Panel();
            pictureBox3 = new PictureBox();
            btnWarningOK = new Button();
            lblWarningMessage = new Label();
            pictureBox1 = new PictureBox();
            pn_Number_Pad.SuspendLayout();
            pn_Pop_Use_Point.SuspendLayout();
            pn_Warning.SuspendLayout();
            pn_New_Member1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lb_Total_Point
            // 
            lb_Total_Point.AutoSize = true;
            lb_Total_Point.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lb_Total_Point.Location = new Point(221, 132);
            lb_Total_Point.Name = "lb_Total_Point";
            lb_Total_Point.Size = new Size(158, 21);
            lb_Total_Point.TabIndex = 0;
            lb_Total_Point.Text = "보유 포인트 : 0000P";
            lb_Total_Point.TextAlign = ContentAlignment.TopCenter;
            // 
            // lb_Point_Info
            // 
            lb_Point_Info.AutoSize = true;
            lb_Point_Info.BackColor = Color.Snow;
            lb_Point_Info.ForeColor = Color.Red;
            lb_Point_Info.Location = new Point(207, 208);
            lb_Point_Info.Name = "lb_Point_Info";
            lb_Point_Info.Size = new Size(186, 15);
            lb_Point_Info.TabIndex = 1;
            lb_Point_Info.Text = "최소 사용 포인트는 500P 입니다.";
            // 
            // lb_Balance_Point
            // 
            lb_Balance_Point.AutoSize = true;
            lb_Balance_Point.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lb_Balance_Point.Location = new Point(191, 185);
            lb_Balance_Point.Name = "lb_Balance_Point";
            lb_Balance_Point.Size = new Size(218, 21);
            lb_Balance_Point.TabIndex = 2;
            lb_Balance_Point.Text = "사용 후 남은 포인트 : 0000P";
            lb_Balance_Point.TextAlign = ContentAlignment.TopCenter;
            // 
            // lb_Warn
            // 
            lb_Warn.AutoSize = true;
            lb_Warn.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lb_Warn.ForeColor = Color.Red;
            lb_Warn.Location = new Point(203, 70);
            lb_Warn.Name = "lb_Warn";
            lb_Warn.Size = new Size(0, 15);
            lb_Warn.TabIndex = 2;
            // 
            // lb_Quest_Point
            // 
            lb_Quest_Point.AutoSize = true;
            lb_Quest_Point.Font = new Font("맑은 고딕", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            lb_Quest_Point.Location = new Point(119, 85);
            lb_Quest_Point.Name = "lb_Quest_Point";
            lb_Quest_Point.Size = new Size(362, 37);
            lb_Quest_Point.TabIndex = 0;
            lb_Quest_Point.Text = "포인트를 사용하시겠습니까?";
            // 
            // pn_Number_Pad
            // 
            pn_Number_Pad.Controls.Add(btn_Backspace);
            pn_Number_Pad.Controls.Add(btn_C);
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
            pn_Number_Pad.TabIndex = 4;
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
            // btn_C
            // 
            btn_C.BackColor = SystemColors.ControlLight;
            btn_C.FlatStyle = FlatStyle.Flat;
            btn_C.Location = new Point(3, 297);
            btn_C.Name = "btn_C";
            btn_C.Size = new Size(114, 92);
            btn_C.TabIndex = 0;
            btn_C.Text = "C";
            btn_C.UseVisualStyleBackColor = false;
            btn_C.Click += btn_C_Click;
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
            btn_1.Location = new Point(3, 3);
            btn_1.Name = "btn_1";
            btn_1.Size = new Size(114, 92);
            btn_1.TabIndex = 0;
            btn_1.Text = "1";
            btn_1.UseVisualStyleBackColor = false;
            btn_1.Click += btn_1_Click;
            // 
            // btn_Use_AllPoint
            // 
            btn_Use_AllPoint.BackColor = SystemColors.ControlLight;
            btn_Use_AllPoint.Location = new Point(375, 157);
            btn_Use_AllPoint.Name = "btn_Use_AllPoint";
            btn_Use_AllPoint.Size = new Size(72, 29);
            btn_Use_AllPoint.TabIndex = 5;
            btn_Use_AllPoint.Text = "전액 사용";
            btn_Use_AllPoint.UseVisualStyleBackColor = false;
            btn_Use_AllPoint.Click += btn_Use_AllPoint_Click;
            // 
            // btn_Confirm
            // 
            btn_Confirm.BackColor = Color.RosyBrown;
            btn_Confirm.FlatStyle = FlatStyle.Flat;
            btn_Confirm.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Confirm.Location = new Point(364, 700);
            btn_Confirm.Name = "btn_Confirm";
            btn_Confirm.Size = new Size(146, 64);
            btn_Confirm.TabIndex = 5;
            btn_Confirm.Text = "확인";
            btn_Confirm.UseVisualStyleBackColor = false;
            btn_Confirm.Click += btn_Confirm_Click;
            // 
            // btn_Cacel
            // 
            btn_Cacel.BackColor = Color.White;
            btn_Cacel.FlatStyle = FlatStyle.Flat;
            btn_Cacel.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Cacel.ForeColor = Color.Black;
            btn_Cacel.Location = new Point(92, 700);
            btn_Cacel.Name = "btn_Cacel";
            btn_Cacel.Size = new Size(146, 64);
            btn_Cacel.TabIndex = 6;
            btn_Cacel.Text = "취소";
            btn_Cacel.UseVisualStyleBackColor = false;
            btn_Cacel.Click += btn_Cacel_Click;
            // 
            // textBox_Use_Point
            // 
            textBox_Use_Point.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_Use_Point.Location = new Point(160, 157);
            textBox_Use_Point.Name = "textBox_Use_Point";
            textBox_Use_Point.Size = new Size(224, 29);
            textBox_Use_Point.TabIndex = 7;
            textBox_Use_Point.TextChanged += textBox_Use_Point_TextChanged;
            // 
            // pn_Pop_Use_Point
            // 
            pn_Pop_Use_Point.BackColor = Color.Snow;
            pn_Pop_Use_Point.Controls.Add(pn_Warning);
            pn_Pop_Use_Point.Controls.Add(lb_Quest_Point);
            pn_Pop_Use_Point.Controls.Add(pictureBox1);
            pn_Pop_Use_Point.Controls.Add(btn_Use_AllPoint);
            pn_Pop_Use_Point.Controls.Add(lb_Warn);
            pn_Pop_Use_Point.Controls.Add(textBox_Use_Point);
            pn_Pop_Use_Point.Controls.Add(lb_Total_Point);
            pn_Pop_Use_Point.Controls.Add(btn_Confirm);
            pn_Pop_Use_Point.Controls.Add(lb_Point_Info);
            pn_Pop_Use_Point.Controls.Add(btn_Cacel);
            pn_Pop_Use_Point.Controls.Add(lb_Balance_Point);
            pn_Pop_Use_Point.Controls.Add(pn_Number_Pad);
            pn_Pop_Use_Point.Dock = DockStyle.Fill;
            pn_Pop_Use_Point.Location = new Point(0, 0);
            pn_Pop_Use_Point.Name = "pn_Pop_Use_Point";
            pn_Pop_Use_Point.Size = new Size(600, 850);
            pn_Pop_Use_Point.TabIndex = 8;
            // 
            // pn_Warning
            // 
            pn_Warning.BackColor = Color.Black;
            pn_Warning.Controls.Add(pn_New_Member1);
            pn_Warning.Location = new Point(49, 185);
            pn_Warning.Name = "pn_Warning";
            pn_Warning.Size = new Size(360, 390);
            pn_Warning.TabIndex = 13;
            // 
            // pn_New_Member1
            // 
            pn_New_Member1.BackColor = Color.Snow;
            pn_New_Member1.Controls.Add(pictureBox3);
            pn_New_Member1.Controls.Add(btnWarningOK);
            pn_New_Member1.Controls.Add(lblWarningMessage);
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
            // btnWarningOK
            // 
            btnWarningOK.BackColor = Color.RosyBrown;
            btnWarningOK.FlatStyle = FlatStyle.Flat;
            btnWarningOK.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnWarningOK.Location = new Point(97, 269);
            btnWarningOK.Name = "btnWarningOK";
            btnWarningOK.Size = new Size(146, 67);
            btnWarningOK.TabIndex = 7;
            btnWarningOK.Text = "확인";
            btnWarningOK.UseVisualStyleBackColor = false;
            btnWarningOK.Click += btnWarningOK_Click;
            // 
            // lblWarningMessage
            // 
            lblWarningMessage.AutoSize = true;
            lblWarningMessage.Font = new Font("맑은 고딕", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblWarningMessage.Location = new Point(32, 115);
            lblWarningMessage.Name = "lblWarningMessage";
            lblWarningMessage.Size = new Size(71, 37);
            lblWarningMessage.TabIndex = 6;
            lblWarningMessage.Text = "신규";
            lblWarningMessage.TextAlign = ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.로고_8;
            pictureBox1.Location = new Point(466, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(134, 98);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // Pop_Use_Point
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(pn_Pop_Use_Point);
            Name = "Pop_Use_Point";
            Size = new Size(600, 850);
            Load += Pop_Use_Point_Load;
            pn_Number_Pad.ResumeLayout(false);
            pn_Pop_Use_Point.ResumeLayout(false);
            pn_Pop_Use_Point.PerformLayout();
            pn_Warning.ResumeLayout(false);
            pn_New_Member1.ResumeLayout(false);
            pn_New_Member1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lb_Total_Point;
        private Label lb_Point_Info;
        private Label lb_Balance_Point;
        private Label lb_Warn;
        private Label lb_Quest_Point;
        private Panel pn_Number_Pad;
        private Button btn_Use_AllPoint;
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
        private Button btn_Confirm;
        private Button btn_Cacel;
        private TextBox textBox_Use_Point;
        private Panel pn_Pop_Use_Point;
        private Button btn_C;
        private PictureBox pictureBox1;
        private Panel pn_Warning;
        private Panel pn_New_Member1;
        private PictureBox pictureBox3;
        private Button btnWarningOK;
        private Label lblWarningMessage;
    }
}
