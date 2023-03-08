using System.Windows;
using System.Windows.Media;
using Microsoft.Extensions.Logging;
using Bot.Providers;
using Bot.Services;

namespace Bot
{
  public partial class MainWindow : Window
  {
    private static bool _isRunning = false;
    private readonly ILogger<MainWindow> _logger;
    private readonly JournalProvider _journalProvider;
    private readonly BotService _botService;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="logger">Logger</param>
    /// <param name="journalProvider">Journal provider</param>
    /// <param name="botService">Bot service</param>
    public MainWindow(ILogger<MainWindow> logger, JournalProvider journalProvider, BotService botService)
    {
      InitializeComponent();
      _logger = logger;
      _journalProvider = journalProvider;
      _botService = botService;
      Log.Document.Blocks.Clear();
    }

    /// <summary>
    /// Click power button
    /// </summary>
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
        
        _botService.Start();
      }
    }
  }
}