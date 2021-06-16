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
using System.Windows.Shapes;

namespace FirstProject
{
    /// <summary>
    /// Window1.xaml etkileşim mantığı
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void CategoriesClicked(object sender, RoutedEventArgs e)
        {
            Categories win = new Categories();
            win.Show();
            this.Close();
        }
        private void ShippersClicked(object sender, RoutedEventArgs e)
        {
            Shippers win = new Shippers();
            win.Show();
            this.Close();
        }
        private void TerritoriesClicked(object sender, RoutedEventArgs e)
        {
            Territories win = new Territories();
            win.Show();
            this.Close();
        }
    }
}
