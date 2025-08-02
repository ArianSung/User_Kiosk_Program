namespace User_Kiosk_Program
{
    partial class Page_Default
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
            components = new System.ComponentModel.Container();
            adChangeTimer = new System.Windows.Forms.Timer(components);
            pn_Show_Ad = new Panel();
            pb_Ad = new PictureBox();
            fade_Timer = new System.Windows.Forms.Timer(components);
            pn_Show_Ad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_Ad).BeginInit();
            SuspendLayout();
            // 
            // adChangeTimer
            // 
            adChangeTimer.Interval = 5000;
            adChangeTimer.Tick += adChangeTimer_Tick;
            // 
            // pn_Show_Ad
            // 
            pn_Show_Ad.Controls.Add(pb_Ad);
            pn_Show_Ad.Dock = DockStyle.Fill;
            pn_Show_Ad.Location = new Point(0, 0);
            pn_Show_Ad.Name = "pn_Show_Ad";
            pn_Show_Ad.Size = new Size(720, 1020);
            pn_Show_Ad.TabIndex = 0;
            // 
            // pb_Ad
            // 
            pb_Ad.Dock = DockStyle.Fill;
            pb_Ad.Location = new Point(0, 0);
            pb_Ad.Name = "pb_Ad";
            pb_Ad.Size = new Size(720, 1020);
            pb_Ad.SizeMode = PictureBoxSizeMode.Zoom;
            pb_Ad.TabIndex = 0;
            pb_Ad.TabStop = false;

            // 
            // Page_Default
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pn_Show_Ad);
            Name = "Page_Default";
            Size = new Size(720, 1020);
            pn_Show_Ad.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pb_Ad).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer adChangeTimer;
        private Panel pn_Show_Ad;
        private PictureBox pb_Show_Ad_3;
        private PictureBox pb_Show_Ad_2;
        private PictureBox pb_Ad;
        private System.Windows.Forms.Timer fade_Timer;
    }
}
