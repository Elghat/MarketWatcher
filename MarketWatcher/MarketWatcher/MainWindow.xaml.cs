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

namespace MarketWatcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Pour la version finale il faudrait que je sauvegarde la position et la taille de la fenêtre quelque part pour la réassigner plus tard
            this.Left = SystemParameters.PrimaryScreenWidth - this.Width + 7;
            this.Top = SystemParameters.PrimaryScreenHeight - this.Height - 41;
            


        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            button1.Content = this.Top;
        }
        
    }
}
