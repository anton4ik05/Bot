using AdvancedSharpAdbClient;
using Bot.Providers;
using System;

namespace Bot.Services
{
  public class BotService
  {
    private readonly JournalProvider _journalProvider;
    private readonly AdvancedAdbClient _client;
    private readonly DeviceData _device;
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="journalProvider">Journal provider</param>
    public BotService(JournalProvider journalProvider)
    {
      _journalProvider = journalProvider;

      _client = new();
    }

    /// <summary>
    /// Start method
    /// </summary>
    public void Start()
    {
      if (!AdbServer.Instance.GetStatus().IsRunning)
      {
        AdbServer server = new();
        StartServerResult result = server.StartServer(@"..\..\..\Assets\adb\adb.exe", false);
        if (result != StartServerResult.Started)
        {
        }
      }
    }
  }
}
