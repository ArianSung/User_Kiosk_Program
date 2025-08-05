namespace User_Kiosk_Program
{
    partial class Pop_Point
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
            lb_Point_Save = new Label();
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
            pn_New_Member1 = new Panel();
            pictureBox3 = new PictureBox();
            button2 = new Button();
            lb_New_Member = new Label();
            pn_Existing = new Panel();
            pn_Existing1 = new Panel();
            pictureBox4 = new PictureBox();
            button3 = new Button();
            lb_Existing = new Label();
            btn_Cacel = new Button();
            btn_Confirm = new Button();
            pn_Pop_Point = new Panel();
            pn_Error = new Panel();
            pn_Error1 = new Panel();
            pictureBox5 = new PictureBox();
            button4 = new Button();
            lb_Error = new Label();
            pn_New_Member = new Panel();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            panel2 = new Panel();
            pictureBox2 = new PictureBox();
            button1 = new Button();
            label1 = new Label();
            pn_Number_Pad.SuspendLayout();
            pn_New_Member1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            pn_Existing.SuspendLayout();
            pn_Existing1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            pn_Pop_Point.SuspendLayout();
            pn_Error.SuspendLayout();
            pn_Error1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            pn_New_Member.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // lb_Point_Save
            // 
            lb_Point_Save.AutoSize = true;
            lb_Point_Save.Font = new Font("맑은 고딕", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            lb_Point_Save.Location = new Point(178, 62);
            lb_Point_Save.Name = "lb_Point_Save";
            lb_Point_Save.Size = new Size(245, 74);
            lb_Point_Save.TabIndex = 0;
            lb_Point_Save.Text = "P가 적립됩니다.\r\n적립하시겠습니까?";
            lb_Point_Save.TextAlign = ContentAlignment.TopCenter;
            // 
            // textBox_Phone
            // 
            textBox_Phone.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_Phone.Location = new Point(188, 151);
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
            pn_Number_Pad.TabIndex = 2;
            // 
            // btn_C
            // 
            btn_C.BackColor = SystemColors.ControlLight;
            btn_C.FlatStyle = FlatStyle.Flat;
            btn_C.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_C.Location = new Point(3, 297);
            btn_C.Name = "btn_C";
            btn_C.Size = new Size(114, 92);
            btn_C.TabIndex = 1;
            btn_C.Text = "C";
            btn_C.UseVisualStyleBackColor = false;
            btn_C.Click += btn_C_Click_1;
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
            btn_1.Location = new Point(3, 3);
            btn_1.Name = "btn_1";
            btn_1.Size = new Size(114, 92);
            btn_1.TabIndex = 0;
            btn_1.Text = "1";
            btn_1.UseVisualStyleBackColor = false;
            btn_1.Click += btn_1_Click;
            // 
            // pn_New_Member1
            // 
            pn_New_Member1.BackColor = Color.Snow;
            pn_New_Member1.Controls.Add(pictureBox3);
            pn_New_Member1.Controls.Add(button2);
            pn_New_Member1.Controls.Add(lb_New_Member);
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
            // button2
            // 
            button2.BackColor = Color.RosyBrown;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(97, 269);
            button2.Name = "button2";
            button2.Size = new Size(146, 67);
            button2.TabIndex = 7;
            button2.Text = "확인";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // lb_New_Member
            // 
            lb_New_Member.AutoSize = true;
            lb_New_Member.Font = new Font("맑은 고딕", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            lb_New_Member.Location = new Point(32, 115);
            lb_New_Member.Name = "lb_New_Member";
            lb_New_Member.Size = new Size(71, 37);
            lb_New_Member.TabIndex = 6;
            lb_New_Member.Text = "신규";
            lb_New_Member.TextAlign = ContentAlignment.TopCenter;
            // 
            // pn_Existing
            // 
            pn_Existing.BackColor = Color.Black;
            pn_Existing.Controls.Add(pn_Existing1);
            pn_Existing.Location = new Point(464, 117);
            pn_Existing.Name = "pn_Existing";
            pn_Existing.Size = new Size(360, 390);
            pn_Existing.TabIndex = 11;
            // 
            // pn_Existing1
            // 
            pn_Existing1.BackColor = Color.Snow;
            pn_Existing1.Controls.Add(pictureBox4);
            pn_Existing1.Controls.Add(button3);
            pn_Existing1.Controls.Add(lb_Existing);
            pn_Existing1.Location = new Point(2, 2);
            pn_Existing1.Name = "pn_Existing1";
            pn_Existing1.Size = new Size(356, 386);
            pn_Existing1.TabIndex = 6;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.로고_8;
            pictureBox4.Location = new Point(252, 0);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(104, 80);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 8;
            pictureBox4.TabStop = false;
            // 
            // button3
            // 
            button3.BackColor = Color.RosyBrown;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(97, 272);
            button3.Name = "button3";
            button3.Size = new Size(146, 64);
            button3.TabIndex = 7;
            button3.Text = "확인";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // lb_Existing
            // 
            lb_Existing.AutoSize = true;
            lb_Existing.Font = new Font("맑은 고딕", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            lb_Existing.Location = new Point(57, 115);
            lb_Existing.Name = "lb_Existing";
            lb_Existing.Size = new Size(71, 37);
            lb_Existing.TabIndex = 6;
            lb_Existing.Text = "적립";
            lb_Existing.TextAlign = ContentAlignment.TopCenter;
            // 
            // btn_Cacel
            // 
            btn_Cacel.BackColor = Color.White;
            btn_Cacel.FlatStyle = FlatStyle.Flat;
            btn_Cacel.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Cacel.Location = new Point(93, 700);
            btn_Cacel.Name = "btn_Cacel";
            btn_Cacel.Size = new Size(146, 64);
            btn_Cacel.TabIndex = 3;
            btn_Cacel.Text = "취소";
            btn_Cacel.UseVisualStyleBackColor = false;
            btn_Cacel.Click += btn_Cacel_Click;
            // 
            // btn_Confirm
            // 
            btn_Confirm.BackColor = Color.RosyBrown;
            btn_Confirm.FlatStyle = FlatStyle.Flat;
            btn_Confirm.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Confirm.Location = new Point(364, 700);
            btn_Confirm.Name = "btn_Confirm";
            btn_Confirm.Size = new Size(146, 64);
            btn_Confirm.TabIndex = 3;
            btn_Confirm.Text = "확인";
            btn_Confirm.UseVisualStyleBackColor = false;
            btn_Confirm.Click += btn_Confirm_Click;
            // 
            // pn_Pop_Point
            // 
            pn_Pop_Point.BackColor = Color.Snow;
            pn_Pop_Point.Controls.Add(pn_Error);
            pn_Pop_Point.Controls.Add(pn_New_Member);
            pn_Pop_Point.Controls.Add(pn_Existing);
            pn_Pop_Point.Controls.Add(pictureBox1);
            pn_Pop_Point.Controls.Add(lb_Point_Save);
            pn_Pop_Point.Controls.Add(btn_Confirm);
            pn_Pop_Point.Controls.Add(textBox_Phone);
            pn_Pop_Point.Controls.Add(btn_Cacel);
            pn_Pop_Point.Controls.Add(pn_Number_Pad);
            pn_Pop_Point.Location = new Point(3, 2);
            pn_Pop_Point.Name = "pn_Pop_Point";
            pn_Pop_Point.Size = new Size(594, 845);
            pn_Pop_Point.TabIndex = 4;
            // 
            // pn_Error
            // 
            pn_Error.BackColor = Color.Black;
            pn_Error.Controls.Add(pn_Error1);
            pn_Error.Location = new Point(509, 525);
            pn_Error.Name = "pn_Error";
            pn_Error.Size = new Size(360, 390);
            pn_Error.TabIndex = 12;
            // 
            // pn_Error1
            // 
            pn_Error1.BackColor = Color.Snow;
            pn_Error1.Controls.Add(pictureBox5);
            pn_Error1.Controls.Add(button4);
            pn_Error1.Controls.Add(lb_Error);
            pn_Error1.Location = new Point(2, 2);
            pn_Error1.Name = "pn_Error1";
            pn_Error1.Size = new Size(356, 386);
            pn_Error1.TabIndex = 9;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.로고_8;
            pictureBox5.Location = new Point(258, 0);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(104, 80);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 5;
            pictureBox5.TabStop = false;
            // 
            // button4
            // 
            button4.BackColor = Color.RosyBrown;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button4.Location = new Point(103, 272);
            button4.Name = "button4";
            button4.Size = new Size(146, 64);
            button4.TabIndex = 4;
            button4.Text = "확인";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // lb_Error
            // 
            lb_Error.AutoSize = true;
            lb_Error.Font = new Font("맑은 고딕", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            lb_Error.Location = new Point(83, 115);
            lb_Error.Name = "lb_Error";
            lb_Error.Size = new Size(197, 74);
            lb_Error.TabIndex = 1;
            lb_Error.Text = "휴대폰 번호를 \r\n입력해주세요";
            lb_Error.TextAlign = ContentAlignment.TopCenter;
            // 
            // pn_New_Member
            // 
            pn_New_Member.BackColor = Color.Black;
            pn_New_Member.Controls.Add(pn_New_Member1);
            pn_New_Member.Location = new Point(18, 31);
            pn_New_Member.Name = "pn_New_Member";
            pn_New_Member.Size = new Size(360, 390);
            pn_New_Member.TabIndex = 12;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.로고_8;
            pictureBox1.Location = new Point(464, -2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(134, 98);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(600, 850);
            panel1.TabIndex = 5;
            // 
            // panel2
            // 
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(603, 280);
            panel2.Name = "panel2";
            panel2.Size = new Size(356, 392);
            panel2.TabIndex = 9;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.로고_8;
            pictureBox2.Location = new Point(252, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(104, 80);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // button1
            // 
            button1.BackColor = Color.RosyBrown;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(97, 272);
            button1.Name = "button1";
            button1.Size = new Size(146, 64);
            button1.TabIndex = 7;
            button1.Text = "확인";
            button1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(77, 115);
            label1.Name = "label1";
            label1.Size = new Size(197, 74);
            label1.TabIndex = 6;
            label1.Text = "휴대폰 번호를 \r\n입력해주세요";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // Pop_Point
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pn_Pop_Point);
            Controls.Add(panel1);
            Name = "Pop_Point";
            Size = new Size(600, 850);
            pn_Number_Pad.ResumeLayout(false);
            pn_New_Member1.ResumeLayout(false);
            pn_New_Member1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            pn_Existing.ResumeLayout(false);
            pn_Existing1.ResumeLayout(false);
            pn_Existing1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            pn_Pop_Point.ResumeLayout(false);
            pn_Pop_Point.PerformLayout();
            pn_Error.ResumeLayout(false);
            pn_Error1.ResumeLayout(false);
            pn_Error1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            pn_New_Member.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lb_Point_Save;
        private TextBox textBox_Phone;
        private Panel pn_Number_Pad;
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
        private Button btn_Cacel;
        private Button btn_Confirm;
        private Panel pn_Pop_Point;
        private Panel panel1;
        private Button btn_C;
        private PictureBox pictureBox1;
        private Panel pn_New_Member1;
        private PictureBox pictureBox3;
        private Button button2;
        private Label lb_New_Member;
        private Panel pn_Error1;
        private Panel pn_Existing1;
        private Panel panel2;
        private PictureBox pictureBox2;
        private Button button1;
        private Label label1;
        private PictureBox pictureBox4;
        private Button button3;
        private Label lb_Existing;
        private PictureBox pictureBox5;
        private Button button4;
        private Label lb_Error;
        private Panel pn_Error;
        private Panel pn_New_Member;
        private Panel pn_Existing;
    }
}
