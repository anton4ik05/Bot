using System;
using System.Windows.Documents;
using Microsoft.Extensions.DependencyInjection;

namespace Bot.Providers
{
  /// <summary>
  /// Journal provider class
  /// </summary>
  public class JournalProvider
  {
    private readonly IServiceProvider _provider;

    /// <summary>
    /// Constructor
    /// </summary>
    public JournalProvider(IServiceProvider provider)
    {
      _provider = provider;
    }
    /// <summary>
    /// Add Log in Log window
    /// </summary>
    /// <param name="message"></param>
    public void ChangeLog(string message)
    {
      var mainWindow = _provider.GetRequiredService<MainWindow>();
      Paragraph p = new(new Run(message))
      {
        LineHeight = 1
      };
      mainWindow.Log.Document.Blocks.Add(p);
      mainWindow.Log.ScrollToEnd();
    }
  }
}
