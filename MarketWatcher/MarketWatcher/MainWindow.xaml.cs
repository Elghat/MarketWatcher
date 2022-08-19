using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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
using FtxApi;
using FtxApi.Enums;

namespace MarketWatcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string test;
        public MainWindow()
        {
            InitializeComponent();
            
            //var client = new Client("SqJHbkedDgAysIzZvo28p9Fz5RsWsmBQcwak0Ez7", "b6WQLKnCeArpM9tdwrnsK_bxVUWrvqHNaY7CZNfk");
            //var api = new FtxRestApi(client);
            //var truc = api.GetAccountInfoAsync().Result;
            //MessageBox.Show(truc);
            

            //Pour la version finale il faudrait que je sauvegarde la position et la taille de la fenêtre quelque part pour la réassigner plus tard
            this.Left = SystemParameters.PrimaryScreenWidth - this.Width + 7;
            this.Top = SystemParameters.PrimaryScreenHeight - this.Height - 41;
            var priceBloc = (TextBlock)FindName("PriceBox");
            //priceBloc.Text = api.GetAccountInfoAsync().Result;
            

        }


        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            var client = new Client("SqJHbkedDgAysIzZvo28p9Fz5RsWsmBQcwak0Ez7", "b6WQLKnCeArpM9tdwrnsK_bxVUWrvqHNaY7CZNfk");
            var api = new FtxRestApi(client);
            string requestResult = await TestWallah(api);
            button1.Content = requestResult;
            var priceBloc = (TextBlock)FindName("PriceBox");
            priceBloc.Text = requestResult;
            // Folder, where a file is created.  
            // Make sure to change this folder to your own folder  
            string filePath = @"C:\Users\grego\Desktop\AccountInfoFTX.txt";
            test = requestResult;
            JsonDocument bidule = JsonDocument.Parse(requestResult);

            // An array of strings  
            // Write array of strings to a file using WriteAllLines.  
            // If the file does not exists, it will create a new file.  
            // This method automatically opens the file, writes to it, and closes file  
            //File.WriteAllText(filePath, requestResult);
            WriteTextToFile(filePath, bidule);
            Console.WriteLine(bidule);
        }

        private void WriteTextToFile(string filePath, JsonDocument content)
        {
            File.WriteAllText(filePath, content.ToString());

        }

        private static async Task<dynamic> TestWallah(FtxRestApi api)
        {
            var t11 = (await api.GetAccountInfoAsync());
            return t11;
        }

        private static async Task RestTests(FtxRestApi api)
        {
            var ins = "BTC-1227";

            var t11 = (await api.GetAccountInfoAsync()).Result;
            Console.WriteLine(JsonSerializer.Serialize(t11));

            var dateStart = DateTime.UtcNow.AddMinutes(-100);
            var dateEnd = DateTime.UtcNow.AddMinutes(-10);

            var r1 = api.GetCoinsAsync().Result;
            var r2 = api.GetAllFuturesAsync().Result;
            var r3 = api.GetFutureAsync(ins).Result;
            var r4 = api.GetFutureStatsAsync(ins).Result;
            var r5 = api.GetFundingRatesAsync(dateStart, dateEnd).Result;
            var r6 = api.GetHistoricalPricesAsync(ins, 300, 30, dateStart, dateEnd).Result;
            var r7 = api.GetMarketsAsync().Result;
            var r8 = api.GetSingleMarketsAsync(ins).Result;
            var r9 = api.GetMarketOrderBookAsync(ins, 20).Result;
            var r10 = api.GetMarketTradesAsync(ins, 20, dateStart, dateEnd).Result;
            var r11 = api.GetAccountInfoAsync().Result;
            var r12 = api.GetPositionsAsync().Result;
            var r13 = api.ChangeAccountLeverageAsync(20).Result;
            var r14 = api.GetCoinAsync().Result;
            var r15 = api.GetBalancesAsync().Result;
            var r16 = api.GetDepositAddressAsync("BTC").Result;
            var r17 = api.GetDepositHistoryAsync().Result;
            var r18 = api.GetWithdrawalHistoryAsync().Result;
            var r19 = api.RequestWithdrawalAsync("USDTBEAR", 20.2m, "0x83a127952d266A6eA306c40Ac62A4a70668FE3BE", "", "", "").Result;
            var r21 = api.GetOpenOrdersAsync(ins).Result;
            var r20 = api.PlaceOrderAsync(ins, SideType.buy, 1000, OrderType.limit, 0.001m, false).Result;
            var r20_1 = api.PlaceStopOrderAsync(ins, SideType.buy, 1000, 0.001m, false).Result;
            var r20_2 = api.PlaceTrailingStopOrderAsync(ins, SideType.buy, 0.05m, 0.001m, false).Result;
            var r20_3 = api.PlaceTakeProfitOrderAsync(ins, SideType.buy, 1000, 0.001m, false).Result;
            var r23 = api.GetOrderStatusAsync("12345").Result;
            var r24 = api.GetOrderStatusByClientIdAsync("12345").Result;
            var r25 = api.CancelOrderAsync("1234").Result;
            var r26 = api.CancelOrderByClientIdAsync("12345").Result;
            var r27 = api.CancelAllOrdersAsync(ins).Result;
            var r28 = api.GetFillsAsync(ins, 20, dateStart, dateEnd).Result;
            var r29 = api.GetFundingPaymentAsync(dateStart, dateEnd).Result;
            var r30 = api.GetLeveragedTokensListAsync().Result;
            var r31 = api.GetTokenInfoAsync("HEDGE").Result;
            var r32 = api.GetLeveragedTokenBalancesAsync().Result;
            var r33 = api.GetLeveragedTokenCreationListAsync().Result;
            var r34 = api.RequestLeveragedTokenCreationAsync("HEDGE", 100).Result;
            var r35 = api.GetLeveragedTokenRedemptionListAsync().Result;
            var r36 = api.RequestLeveragedTokenRedemptionAsync("HEDGE", 100).Result;

        }
    }
}
