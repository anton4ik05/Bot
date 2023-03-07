using Microsoft.Extensions.Logging;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace Bot
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    static bool IsRunning = false;
    private ILogger<MainWindow> _logger;
    public MainWindow(ILogger<MainWindow> logger)
    {
      InitializeComponent();
      _logger = logger;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      _logger.LogDebug("Clock");
      if(IsRunning)
      {
        PowerButton.Background = Brushes.GreenYellow;
        IsRunning = !IsRunning;
      }
      else
      {
        PowerButton.Background = Brushes.Red;
        IsRunning = !IsRunning;
      }
    }
  }
}