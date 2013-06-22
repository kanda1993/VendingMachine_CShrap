using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VendingMachine.Model;

namespace VendingMachine {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {

        /// <summary>
        /// 手に持っているお金。
        /// つまんでいるイメージなので、1個だけ。
        /// </summary>
        private MoneyBase _moneyInHand;


        public MainWindow() {
            InitializeComponent();
        }

        /// <summary>
        /// お札投入口のクリックHandler.
        /// 
        /// 手に持っているお金を投入します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSlotInsertCoin_Click(object sender, RoutedEventArgs e) {
            MoneyManager moneyManager = MoneyManager.GetInstance();
            if (_moneyInHand != null) {
                moneyManager.InsertMoney(_moneyInHand);
            }

            InsertedMoneyDisplay.Text = moneyManager.CountInsertedMoney();
        }

        /// <summary>
        /// 硬貨投入口のクリックHandler.
        /// 
        /// 手に持っているお金を投入します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSlotInsertOsatsu_Click(object sender, RoutedEventArgs e) {
            MoneyManager moneyManager = MoneyManager.GetInstance();
            if (_moneyInHand != null) {
                moneyManager.InsertMoney(_moneyInHand);
            }

            InsertedMoneyDisplay.Text = moneyManager.CountInsertedMoney();
        }

        /// <summary>
        /// おつりレバーのクリックHandler.
        /// 
        /// クリックすると、投入したお金の分だけTextで出します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RectRetunMoneyLever_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
            MoneyManager moneyManager = MoneyManager.GetInstance();
            string insertedMoney = moneyManager.ReturnInsertedMoney();
            this.InsertedMoneyDisplay.Text = moneyManager.CountInsertedMoney();

            // 仮。
            if (!string.IsNullOrEmpty(insertedMoney)) {
                insertedMoney = "ちゃりんちゃりんちゃりん\n" + insertedMoney;
            }
            else {
                insertedMoney = "カチャッ...";
            }

            ReturnMoneyOutputter.Text = insertedMoney;
        }


        private void btnYen10000_Click(object sender, RoutedEventArgs e) {
            PickMoneyFromSaifu(MoneyType.yen10000);
        }

        private void btnYen5000_Click(object sender, RoutedEventArgs e) {
            PickMoneyFromSaifu(MoneyType.yen5000);
        }

        private void btnYen2000_Click(object sender, RoutedEventArgs e) {
            PickMoneyFromSaifu(MoneyType.yen2000);
        }

        private void btnYen1000_Click(object sender, RoutedEventArgs e) {
            PickMoneyFromSaifu(MoneyType.yen1000);
        }

        private void btnYen500_Click(object sender, RoutedEventArgs e) {
            PickMoneyFromSaifu(MoneyType.yen500);
        }

        private void btnYen100_Click(object sender, RoutedEventArgs e) {
            PickMoneyFromSaifu(MoneyType.yen100);
        }

        private void btnYen50_Click(object sender, RoutedEventArgs e) {
            PickMoneyFromSaifu(MoneyType.yen50);
        }

        private void btnYen10_Click(object sender, RoutedEventArgs e) {
            PickMoneyFromSaifu(MoneyType.yen10);
        }

        private void btnYen5_Click(object sender, RoutedEventArgs e) {
            PickMoneyFromSaifu(MoneyType.yen5);
        }

        private void btnYen1_Click(object sender, RoutedEventArgs e) {
            PickMoneyFromSaifu(MoneyType.yen1);
        }

        private void btnDoller100_Click(object sender, RoutedEventArgs e) {
            PickMoneyFromSaifu(MoneyType.doller100);
        }

        private void btnCent1_Click(object sender, RoutedEventArgs e) {
            PickMoneyFromSaifu(MoneyType.cent1);
        }


        /// <summary>
        /// お金クラスをインスタンス化して、手に持たせる。
        /// </summary>
        /// <param name="moneyType"></param>
        private void PickMoneyFromSaifu(MoneyType moneyType) {
            MoneyManager manager = MoneyManager.GetInstance();
            _moneyInHand = manager.CreateMoney(moneyType);

            this.moneyInHandDisplay.Text = "手に" + moneyType.ToString() + "を持っています。";
        }
    }
}