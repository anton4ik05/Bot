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

    public MainWindow()
    {
      InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      if(IsRunning)
      {
        ChangeStateButton.Background = Brushes.GreenYellow;
        IsRunning = !IsRunning;
      }
      else
      {
        ChangeStateButton.Background = Brushes.Red;
        IsRunning = !IsRunning;
      }
    }
  }
}