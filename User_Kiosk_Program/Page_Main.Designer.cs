namespace User_Kiosk_Program
{
    partial class Page_Main
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
            pn_BoardContainer = new Panel();
            btn_Next = new Button();
            lbl_PageInfo = new Label();
            btn_Prev = new Button();
            flp_Categories = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // pn_BoardContainer
            // 
            pn_BoardContainer.Location = new Point(56, 211);
            pn_BoardContainer.Name = "pn_BoardContainer";
            pn_BoardContainer.Size = new Size(600, 649);
            pn_BoardContainer.TabIndex = 0;
            // 
            // btn_Next
            // 
            btn_Next.Location = new Point(439, 872);
            btn_Next.Name = "btn_Next";
            btn_Next.Size = new Size(75, 23);
            btn_Next.TabIndex = 1;
            btn_Next.Text = "button1";
            btn_Next.UseVisualStyleBackColor = true;
            // 
            // lbl_PageInfo
            // 
            lbl_PageInfo.AutoSize = true;
            lbl_PageInfo.Location = new Point(333, 876);
            lbl_PageInfo.Name = "lbl_PageInfo";
            lbl_PageInfo.Size = new Size(39, 15);
            lbl_PageInfo.TabIndex = 3;
            lbl_PageInfo.Text = "label1";
            // 
            // btn_Prev
            // 
            btn_Prev.Location = new Point(194, 872);
            btn_Prev.Name = "btn_Prev";
            btn_Prev.Size = new Size(75, 23);
            btn_Prev.TabIndex = 2;
            btn_Prev.Text = "button2";
            btn_Prev.UseVisualStyleBackColor = true;
            // 
            // flp_Categories
            // 
            flp_Categories.Location = new Point(56, 139);
            flp_Categories.Name = "flp_Categories";
            flp_Categories.Size = new Size(600, 70);
            flp_Categories.TabIndex = 4;
            // 
            // Page_Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btn_Next);
            Controls.Add(flp_Categories);
            Controls.Add(lbl_PageInfo);
            Controls.Add(btn_Prev);
            Controls.Add(pn_BoardContainer);
            Name = "Page_Main";
            Size = new Size(720, 1020);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private Panel pn_BoardContainer;
        private Button btn_Next;
        private Button btn_Prev;
        private Label lbl_PageInfo;
        private FlowLayoutPanel flp_Categories;
    }
}
