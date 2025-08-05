using System;
using System.Drawing;
using System.Windows.Forms;

namespace User_Kiosk_Program
{
    public partial class Pop_Use_Point : UserControl
    {
        public event EventHandler<PointUsageEventArgs> ApplyClicked;
        public event EventHandler CancelClicked;

        private Member currentMember;
        private decimal totalOrderAmount;
        private bool isPhoneNumberMode = true; // 현재 입력 모드를 추적하는 상태 변수

        public Pop_Use_Point()
        {
            InitializeComponent();

            btn_Confirm.Click += Btn_Confirm_Click;
            btn_Cancel.Click += (s, e) => CancelClicked?.Invoke(this, EventArgs.Empty);
            btn_Search.Click += Btn_Search_Click;
            btn_UseAll.Click += Btn_UseAll_Click;

            // 모든 키패드 버튼은 txt_Input에 텍스트를 추가하도록 합니다.
            btn_Num1.Click += Keypad_Click;
            btn_Num2.Click += Keypad_Click;
            btn_Num3.Click += Keypad_Click;
            btn_Num4.Click += Keypad_Click;
            btn_Num5.Click += Keypad_Click;
            btn_Num6.Click += Keypad_Click;
            btn_Num7.Click += Keypad_Click;
            btn_Num8.Click += Keypad_Click;
            btn_Num9.Click += Keypad_Click;
            btn_Num0.Click += Keypad_Click;
            btn_Clear.Click += (s, e) => { txt_Input.Text = ""; };
            btn_Backspace.Click += (s, e) => {
                if (txt_Input.Text.Length > 0)
                    txt_Input.Text = txt_Input.Text.Substring(0, txt_Input.Text.Length - 1);
            };

            txt_Input.TextChanged += Txt_Input_TextChanged;
        }

        // 팝업이 열릴 때 호출되어 모든 상태를 초기화합니다.
        public void Initialize(decimal orderAmount)
        {
            totalOrderAmount = orderAmount;
            currentMember = null;

            isPhoneNumberMode = true; // 모드를 '전화번호 입력'으로 초기화
            lbl_InputGuide.Text = "전화번호를 입력 후, 조회 버튼을 눌러주세요.";
            txt_Input.Text = "";

            lbl_OwnedPoints.Text = "보유 포인트 : 0P";
            lbl_RemainingPoints.Text = "사용 후 남은 포인트 : 0P";

            txt_Input.Focus();
        }

        private void Keypad_Click(object sender, EventArgs e)
        {
            txt_Input.Text += (sender as Button).Text;
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            if (!isPhoneNumberMode) return; // 이미 조회했다면 다시 실행하지 않음

            string phone = txt_Input.Text;
            currentMember = DatabaseManager.Instance.GetMemberByPhoneNumber(phone);

            if (currentMember != null)
            {
                lbl_OwnedPoints.Text = $"보유 포인트: {currentMember.Point:N0}P";
                txt_Input.Text = ""; // 텍스트박스를 비워 재활용 준비
                isPhoneNumberMode = false; // 모드를 '포인트 입력'으로 전환
                lbl_InputGuide.Text = "사용할 포인트를 입력하세요.";
            }
            else
            {
                MessageBox.Show("존재하지 않는 회원입니다.", "조회 실패");
                lbl_OwnedPoints.Text = "보유 포인트 : 0P";
                txt_Input.Text = "";
            }
        }

        private void Btn_UseAll_Click(object sender, EventArgs e)
        {
            if (isPhoneNumberMode || currentMember == null) return; // 회원 조회가 안됐으면 실행 안함

            decimal pointsToUse = Math.Min(totalOrderAmount, currentMember.Point);
            txt_Input.Text = pointsToUse.ToString("F0");
        }

        private void Txt_Input_TextChanged(object sender, EventArgs e)
        {
            // '포인트 입력' 모드일 때만 남은 포인트를 계산
            if (isPhoneNumberMode || currentMember == null)
            {
                lbl_RemainingPoints.Text = "사용 후 남은 포인트 : -";
                return;
            }

            if (decimal.TryParse(txt_Input.Text, out decimal pointsToUse))
            {
                decimal remaining = currentMember.Point - pointsToUse;
                lbl_RemainingPoints.Text = $"사용 후 남은 포인트 : {remaining:N0}P";
            }
        }

        private void Btn_Confirm_Click(object sender, EventArgs e)
        {
            if (isPhoneNumberMode || currentMember == null)
            {
                MessageBox.Show("회원 조회를 먼저 해주세요.", "알림");
                return;
            }

            if (!decimal.TryParse(txt_Input.Text, out decimal pointsToUse) || string.IsNullOrEmpty(txt_Input.Text))
            {
                pointsToUse = 0; // 아무것도 입력 안하면 0으로 간주
            }

            if (pointsToUse > 0 && pointsToUse < 500)
            {
                MessageBox.Show("최소 사용 포인트는 500P 입니다.", "알림");
                return;
            }

            if (pointsToUse > currentMember.Point)
            {
                MessageBox.Show("보유 포인트를 초과하여 사용할 수 없습니다.", "알림");
                return;
            }

            if (pointsToUse > totalOrderAmount)
            {
                MessageBox.Show("주문 금액을 초과하여 포인트를 사용할 수 없습니다.", "알림");
                return;
            }

            ApplyClicked?.Invoke(this, new PointUsageEventArgs(pointsToUse));
        }
    }
}