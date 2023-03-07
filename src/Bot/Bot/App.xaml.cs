using Bot.Providers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Windows;

namespace Bot
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    private readonly ServiceProvider _serviceProvider;
    public App()
    {
      ServiceCollection services = new ServiceCollection();
      ConfigureServices(services);
      _serviceProvider = services.BuildServiceProvider();
    }
    private void ConfigureServices(ServiceCollection services)
    {
      services.AddLogging(builder =>
      {
        Log.Logger = new LoggerConfiguration()
        .WriteTo.File(@"../../../logs/Log.txt", rollingInterval: RollingInterval.Day)
        .MinimumLevel.Verbose()
        .CreateLogger();

        builder.AddSerilog();
      });
      services.AddSingleton<MainWindow>();
      services.AddSingleton<JournalProvider>();
    }
    private void OnStartup(object sender, StartupEventArgs e)
    {
      var mainWindow = _serviceProvider.GetService<MainWindow>();
      mainWindow!.Show();
    }
  }
}