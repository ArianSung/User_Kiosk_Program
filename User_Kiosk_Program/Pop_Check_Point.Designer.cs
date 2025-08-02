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
            textBox1 = new TextBox();
            pn_Number_Pad = new Panel();
            button = new Button();
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
            pn_Number_Pad.SuspendLayout();
            SuspendLayout();
            // 
            // lb_Point_Use
            // 
            lb_Point_Use.AutoSize = true;
            lb_Point_Use.Font = new Font("맑은 고딕", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lb_Point_Use.Location = new Point(221, 113);
            lb_Point_Use.Name = "lb_Point_Use";
            lb_Point_Use.Size = new Size(142, 32);
            lb_Point_Use.TabIndex = 0;
            lb_Point_Use.Text = "포인트 조회";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(177, 159);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(224, 23);
            textBox1.TabIndex = 1;
            // 
            // pn_Number_Pad
            // 
            pn_Number_Pad.Controls.Add(button);
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
            pn_Number_Pad.Location = new Point(121, 228);
            pn_Number_Pad.Name = "pn_Number_Pad";
            pn_Number_Pad.Size = new Size(359, 395);
            pn_Number_Pad.TabIndex = 3;
            // 
            // button
            // 
            button.Location = new Point(3, 297);
            button.Name = "button";
            button.Size = new Size(114, 92);
            button.TabIndex = 5;
            button.UseVisualStyleBackColor = true;
            // 
            // btn_Backspace
            // 
            btn_Backspace.Location = new Point(243, 297);
            btn_Backspace.Name = "btn_Backspace";
            btn_Backspace.Size = new Size(114, 92);
            btn_Backspace.TabIndex = 0;
            btn_Backspace.Text = "Backspace";
            btn_Backspace.UseVisualStyleBackColor = true;
            // 
            // btn_0
            // 
            btn_0.Location = new Point(123, 297);
            btn_0.Name = "btn_0";
            btn_0.Size = new Size(114, 92);
            btn_0.TabIndex = 0;
            btn_0.Text = "0";
            btn_0.UseVisualStyleBackColor = true;
            // 
            // btn_9
            // 
            btn_9.Location = new Point(243, 199);
            btn_9.Name = "btn_9";
            btn_9.Size = new Size(114, 92);
            btn_9.TabIndex = 0;
            btn_9.Text = "9";
            btn_9.UseVisualStyleBackColor = true;
            // 
            // btn_8
            // 
            btn_8.Location = new Point(123, 199);
            btn_8.Name = "btn_8";
            btn_8.Size = new Size(114, 92);
            btn_8.TabIndex = 0;
            btn_8.Text = "8";
            btn_8.UseVisualStyleBackColor = true;
            // 
            // btn_6
            // 
            btn_6.Location = new Point(243, 101);
            btn_6.Name = "btn_6";
            btn_6.Size = new Size(114, 92);
            btn_6.TabIndex = 0;
            btn_6.Text = "6";
            btn_6.UseVisualStyleBackColor = true;
            // 
            // btn_5
            // 
            btn_5.Location = new Point(123, 101);
            btn_5.Name = "btn_5";
            btn_5.Size = new Size(114, 92);
            btn_5.TabIndex = 0;
            btn_5.Text = "5";
            btn_5.UseVisualStyleBackColor = true;
            // 
            // btn_7
            // 
            btn_7.Location = new Point(3, 199);
            btn_7.Name = "btn_7";
            btn_7.Size = new Size(114, 92);
            btn_7.TabIndex = 0;
            btn_7.Text = "7";
            btn_7.UseVisualStyleBackColor = true;
            // 
            // btn_3
            // 
            btn_3.Location = new Point(243, 3);
            btn_3.Name = "btn_3";
            btn_3.Size = new Size(114, 92);
            btn_3.TabIndex = 0;
            btn_3.Text = "3";
            btn_3.UseVisualStyleBackColor = true;
            // 
            // btn_4
            // 
            btn_4.Location = new Point(3, 101);
            btn_4.Name = "btn_4";
            btn_4.Size = new Size(114, 92);
            btn_4.TabIndex = 0;
            btn_4.Text = "4";
            btn_4.UseVisualStyleBackColor = true;
            // 
            // btn_2
            // 
            btn_2.Location = new Point(123, 3);
            btn_2.Name = "btn_2";
            btn_2.Size = new Size(114, 92);
            btn_2.TabIndex = 0;
            btn_2.Text = "2";
            btn_2.UseVisualStyleBackColor = true;
            // 
            // btn_1
            // 
            btn_1.Location = new Point(3, 3);
            btn_1.Name = "btn_1";
            btn_1.Size = new Size(114, 92);
            btn_1.TabIndex = 0;
            btn_1.Text = "1";
            btn_1.UseVisualStyleBackColor = true;
            // 
            // btn_Check_Point
            // 
            btn_Check_Point.Location = new Point(232, 705);
            btn_Check_Point.Name = "btn_Check_Point";
            btn_Check_Point.Size = new Size(146, 64);
            btn_Check_Point.TabIndex = 6;
            btn_Check_Point.Text = "적립";
            btn_Check_Point.UseVisualStyleBackColor = true;
            // 
            // Pop_Check_Point
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btn_Check_Point);
            Controls.Add(pn_Number_Pad);
            Controls.Add(textBox1);
            Controls.Add(lb_Point_Use);
            Name = "Pop_Check_Point";
            Size = new Size(600, 850);
            pn_Number_Pad.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lb_Point_Use;
        private TextBox textBox1;
        private Panel pn_Number_Pad;
        private Button button;
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
    }
}
