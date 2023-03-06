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
    private ServiceProvider serviceProvider;
    public App()
    {
      ServiceCollection services = new ServiceCollection();
      ConfigureServices(services);
      serviceProvider = services.BuildServiceProvider();
    }
    private void ConfigureServices(ServiceCollection services)
    {
      services.AddLogging(builder =>
      {
        LoggerConfiguration loggerConfiguration = new LoggerConfiguration()
        .WriteTo.File("test.txt", rollingInterval: RollingInterval.Day);

        builder.AddSerilog(loggerConfiguration.CreateLogger());
      });
      services.AddSingleton<MainWindow>();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
      var mainWindow = serviceProvider.GetService<MainWindow>();
      mainWindow!.Show();
      base.OnStartup(e);
    }
  }
}