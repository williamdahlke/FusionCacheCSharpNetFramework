using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace FusionCacheCSharpNetFramework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            ServiceExample service = App.ServiceProvider.GetRequiredService<ServiceExample>();
            dgCars.ItemsSource = service.Teste();
        }
    }
}
