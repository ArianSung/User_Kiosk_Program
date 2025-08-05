namespace User_Kiosk_Program
{
    partial class Form_Print_Recipt_Yes
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
            pn_Printf_Recipt_Yes = new Panel();
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            lb_Order_Num = new Label();
            lb_Confirm = new Label();
            lb_Recipt_text = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            label3 = new Label();
            pn_Printf_Recipt_Yes.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pn_Printf_Recipt_Yes
            // 
            pn_Printf_Recipt_Yes.BackColor = Color.WhiteSmoke;
            pn_Printf_Recipt_Yes.Controls.Add(label3);
            pn_Printf_Recipt_Yes.Controls.Add(panel1);
            pn_Printf_Recipt_Yes.Controls.Add(lb_Order_Num);
            pn_Printf_Recipt_Yes.Controls.Add(lb_Confirm);
            pn_Printf_Recipt_Yes.Controls.Add(lb_Recipt_text);
            pn_Printf_Recipt_Yes.Dock = DockStyle.Fill;
            pn_Printf_Recipt_Yes.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            pn_Printf_Recipt_Yes.Location = new Point(0, 0);
            pn_Printf_Recipt_Yes.Name = "pn_Printf_Recipt_Yes";
            pn_Printf_Recipt_Yes.Size = new Size(310, 442);
            pn_Printf_Recipt_Yes.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(104, 382);
            panel1.Name = "panel1";
            panel1.Size = new Size(102, 65);
            panel1.TabIndex = 9;
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
            lb_Order_Num.BackColor = Color.WhiteSmoke;
            lb_Order_Num.Font = new Font("맑은 고딕", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            lb_Order_Num.Location = new Point(57, 25);
            lb_Order_Num.Name = "lb_Order_Num";
            lb_Order_Num.Size = new Size(134, 37);
            lb_Order_Num.TabIndex = 3;
            lb_Order_Num.Text = "주문 번호";
            // 
            // lb_Confirm
            // 
            lb_Confirm.AutoSize = true;
            lb_Confirm.Location = new Point(119, 561);
            lb_Confirm.Name = "lb_Confirm";
            lb_Confirm.Size = new Size(191, 21);
            lb_Confirm.TabIndex = 5;
            lb_Confirm.Text = "lb_Confirm (그냥 확인용)";
            // 
            // lb_Recipt_text
            // 
            lb_Recipt_text.AutoSize = true;
            lb_Recipt_text.BackColor = Color.Transparent;
            lb_Recipt_text.FlatStyle = FlatStyle.Flat;
            lb_Recipt_text.Location = new Point(45, 84);
            lb_Recipt_text.Name = "lb_Recipt_text";
            lb_Recipt_text.Size = new Size(113, 21);
            lb_Recipt_text.TabIndex = 4;
            lb_Recipt_text.Text = "lb_Recipt_text";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(45, 358);
            label3.Name = "label3";
            label3.Size = new Size(191, 21);
            label3.TabIndex = 10;
            label3.Text = "lb_Confirm (그냥 확인용)";
            // 
            // Form_Print_Recipt_Yes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(310, 442);
            Controls.Add(pn_Printf_Recipt_Yes);
            Name = "Form_Print_Recipt_Yes";
            Text = "Form_Print_Recipt";
            pn_Printf_Recipt_Yes.ResumeLayout(false);
            pn_Printf_Recipt_Yes.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pn_Printf_Recipt_Yes;
        private Label lb_Order_Num;
        private System.Windows.Forms.Timer timer1;
        private Label lb_Confirm;
        private Label lb_Recipt_text;
        private Panel panel1;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}