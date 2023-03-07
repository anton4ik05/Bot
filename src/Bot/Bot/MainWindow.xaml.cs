using System.Windows;
using System.Windows.Media;
using Microsoft.Extensions.Logging;
using Bot.Providers;

namespace Bot
{
  public partial class MainWindow : Window
  {
    private static bool _isRunning = false;
    private readonly ILogger<MainWindow> _logger;
    private readonly JournalProvider _journalProvider;
    public MainWindow(ILogger<MainWindow> logger, JournalProvider journalProvider)
    {
      InitializeComponent();
      _logger = logger;
      _journalProvider = journalProvider;
      Log.Document.Blocks.Clear();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      if(_isRunning)
      {
        PowerButton.Background = Brushes.GreenYellow;
        _isRunning = !_isRunning;
        _logger.LogDebug("Stop application");
        _journalProvider.ChangeLog("Остановка бота");
      }
      else
      {
        PowerButton.Background = Brushes.Red;
        _isRunning = !_isRunning;
        _logger.LogDebug("Start application");
        _journalProvider.ChangeLog("Запуск Nox и Clash of clans");
      }
    }
  }
}