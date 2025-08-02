using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User_Kiosk_Program
{
    public partial class Page_Default : UserControl
    {

        private List<string> adImageUrls;
        private int currentAdIndex = -1;
        private HttpClient httpClient = new HttpClient();

        public Page_Default()
        {
            InitializeComponent();
            this.Load += Page_Default_Load;
        }

        private async void Page_Default_Load(object? sender, EventArgs e)
        {
            await InitializeAds();
        }

        private async Task InitializeAds()
        {
            adImageUrls = DatabaseManager.Instance.GetAdImageUrls();

            if (adImageUrls != null && adImageUrls.Count > 0)
            {
                // 첫 번째 광고를 표시하고 타이머를 시작
                await ShowNextAd();
                adChangeTimer.Start();
            }
            else
            {
                // TODO: DB에 광고가 없을 경우 기본 이미지 표시 또는 메시지 처리
                pb_Show_Ad_1.BackColor = Color.DimGray;
            }
        }

        private async void adChangeTimer_Tick(object sender, EventArgs e)
        {
            await ShowNextAd();
        }

        private async Task ShowNextAd()
        {
            if (adImageUrls == null || adImageUrls.Count == 0) return;

            // 다음 광고 인덱스 계산 (순환 구조)
            currentAdIndex = (currentAdIndex + 1) % adImageUrls.Count;
            string nextImageUrl = adImageUrls[currentAdIndex];

            // 현재 보이지 않는 PictureBox를 찾아 다음 이미지를 로드
            PictureBox inactivePb = pb_Show_Ad_1.Visible ? pb_Show_Ad_2 : pb_Show_Ad_1;
            PictureBox activePb = pb_Show_Ad_1.Visible ? pb_Show_Ad_1 : pb_Show_Ad_2;

            try
            {
                // 비동기로 이미지 로드
                var imageStream = await httpClient.GetStreamAsync(nextImageUrl);
                inactivePb.Image = Image.FromStream(imageStream);

                // 이미지 전환
                activePb.Visible = false;
                inactivePb.Visible = true;
            }
            catch (Exception ex)
            {
                // 이미지 로딩 실패 시 다음 순서로 넘어감
                Console.WriteLine($"Image load failed: {nextImageUrl} - {ex.Message}");
            }
        }
    }
}
