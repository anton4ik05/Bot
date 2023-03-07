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
      if(IsRunning)
      {
        PowerButton.Background = Brushes.GreenYellow;
        IsRunning = !IsRunning;
        _logger.LogDebug("Stop application");
      }
      else
      {
        PowerButton.Background = Brushes.Red;
        IsRunning = !IsRunning;
        _logger.LogDebug("Start application");
      }
    }
  }
}