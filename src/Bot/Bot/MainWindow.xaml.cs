using System.Windows;
using System.Windows.Media;
using Microsoft.Extensions.Logging;
using Bot.Providers;

namespace Bot
{
  public partial class MainWindow : Window
  {
    static bool IsRunning = false;
    private ILogger<MainWindow> _logger;
    private readonly JournalProvider _journalProvider;
    public MainWindow(ILogger<MainWindow> logger, JournalProvider journalProvider)
    {
      InitializeComponent();
      _logger = logger;
      _journalProvider = journalProvider;
      log.Document.Blocks.Clear();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      if(IsRunning)
      {
        PowerButton.Background = Brushes.GreenYellow;
        IsRunning = !IsRunning;
        _logger.LogDebug("Stop application");
        _journalProvider.ChangeLog("asd");
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