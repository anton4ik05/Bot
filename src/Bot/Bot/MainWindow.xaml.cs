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
    private readonly ILogger _logger;
    public MainWindow(ILogger loger)
    {
      _logger = loger;
      InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      _logger.LogDebug("Button click");
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