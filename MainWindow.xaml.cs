using System.Diagnostics;
using System.Linq;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Media;
using GenshinImpactProfileQuery.Core;
using GenshinImpactProfileQuery.Entity;
using GenshinImpactProfileQuery.Utils;
using GenshinImpactProfileQuery.Views;

namespace GenshinImpactProfileQuery
{
    /// <summary>
    ///     MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        //private readonly ObservableCollection<ProfileAvatarEntity> _profileAvatarEntities;
        //private ProfileStatsEntity _profileStatsEntity;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var uid = TextBoxUid.Text;

            if (uid.IsEmptyOrNull())
                return;
            if (!uid.IsNumber())
                return;

            ListViewRoles.Items.Clear();

            //开始加载
            var loading = new LoadingWindow
            {
                Owner = this
            };
            loading.Show();

            OpacityMask = new SolidColorBrush
            {
                Opacity = 0.4,
                Color = Colors.Black
            };

            IsEnabled = false;

            //查询函数
            var stats = await QueryCore.QueryStats(uid);
            var avatars = (await QueryCore.QueryAvatars(uid)).ToList();

            //赋值查询的状态
            ActiveDays.Status = stats.ActiveDays;
            AchievementCount.Status = stats.AchievementCount;
            WinRate.Status = stats.WinRate;
            AnemoculusCount.Status = stats.AnemoculusCount;
            GeoculusCount.Status = stats.GeoculusCount;
            AvatarCount.Status = stats.AvatarCount;
            WayPointCount.Status = stats.WayPointCount;
            DomainCount.Status = stats.DomainCount;
            SpiralAbyss.Status = stats.SpiralAbyss;
            PreciousChests.Status = stats.PreciousChests;
            LuxuriousChests.Status = stats.LuxuriousChests;
            ExquisiteChests.Status = stats.ExquisiteChests;
            CommonChests.Status = stats.CommonChests;

            //赋值人物信息
            //var roles = new ObservableCollection<RolesEntity>();

            var count = 1;
            foreach (var a in avatars)
                ListViewRoles.Items.Add(new RolesEntity
                {
                    Avatar = a.Image,
                    Element = a.Element.ToElement(),
                    Fetter = a.Fetter + "级",
                    Index = count++.ToString(),
                    Level = a.Level + "级",
                    Name = a.Name,
                    Rarity = a.Rarity + "星"
                });

            //结束加载
            OpacityMask = null;
            IsEnabled = true;

            loading.Close();
        }

        private void EventSetter_OnHandler(object sender, RoutedEventArgs e)
        {
            Process.Start((sender as HyperLink)?.NavigateUrl ?? "https://www.google.com");
        }
    }
}