using System.Windows.Documents;

namespace Bot.Providers
{
  /// <summary>
  /// Journal provider class
  /// </summary>
  public class JournalProvider
  {
    private MainWindow _mainWindow;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="window"></param>
    public JournalProvider(MainWindow window)
    {
      _mainWindow= window;
    }
    /// <summary>
    /// Add log in log window
    /// </summary>
    /// <param name="message"></param>
    public void ChangeLog(string message)
    {
      Paragraph p = new Paragraph(new Run(message));
      p.LineHeight = 1;
      _mainWindow.log.Document.Blocks.Add(p);
      _mainWindow.log.ScrollToEnd();
    }
  }
}
