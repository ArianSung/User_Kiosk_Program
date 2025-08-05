namespace User_Kiosk_Program
{
    partial class Form_Printf_Recipt_No
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pn_Print_Reicpt_No = new Panel();
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            lb_Order_Num = new Label();
            lb_Confirm = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            pn_Print_Reicpt_No.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pn_Print_Reicpt_No
            // 
            pn_Print_Reicpt_No.Controls.Add(panel1);
            pn_Print_Reicpt_No.Controls.Add(lb_Order_Num);
            pn_Print_Reicpt_No.Controls.Add(lb_Confirm);
            pn_Print_Reicpt_No.Dock = DockStyle.Fill;
            pn_Print_Reicpt_No.Location = new Point(0, 0);
            pn_Print_Reicpt_No.Name = "pn_Print_Reicpt_No";
            pn_Print_Reicpt_No.Size = new Size(310, 181);
            pn_Print_Reicpt_No.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(104, 121);
            panel1.Name = "panel1";
            panel1.Size = new Size(102, 65);
            panel1.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe Script", 18F, FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(15, 0);
            label1.Name = "label1";
            label1.Size = new Size(70, 38);
            label1.TabIndex = 7;
            label1.Text = "Ssep";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(8, 40);
            label2.Name = "label2";
            label2.Size = new Size(84, 14);
            label2.TabIndex = 8;
            label2.Text = "BRUNCH CAFE";
            // 
            // lb_Order_Num
            // 
            lb_Order_Num.AutoSize = true;
            lb_Order_Num.Font = new Font("맑은 고딕", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            lb_Order_Num.Location = new Point(57, 25);
            lb_Order_Num.Name = "lb_Order_Num";
            lb_Order_Num.Size = new Size(134, 37);
            lb_Order_Num.TabIndex = 6;
            lb_Order_Num.Text = "주문 번호";
            // 
            // lb_Confirm
            // 
            lb_Confirm.AutoSize = true;
            lb_Confirm.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lb_Confirm.Location = new Point(46, 89);
            lb_Confirm.Name = "lb_Confirm";
            lb_Confirm.Size = new Size(191, 21);
            lb_Confirm.TabIndex = 8;
            lb_Confirm.Text = "lb_Confirm (그냥 확인용)";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Form_Printf_Recipt_No
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(310, 181);
            Controls.Add(pn_Print_Reicpt_No);
            Name = "Form_Printf_Recipt_No";
            Text = "Form_Printf_Recipt_No";
            pn_Print_Reicpt_No.ResumeLayout(false);
            pn_Print_Reicpt_No.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pn_Print_Reicpt_No;
        private Label lb_Order_Num;
        private Label lb_Confirm;
        private System.Windows.Forms.Timer timer1;
        private Panel panel1;
        private Label label1;
        private Label label2;
    }
}