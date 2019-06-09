using System.Windows;
using Sparrow.Logging;

namespace DotNetUfa1
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            LoggingSource loggingSource = LoggingSource.Instance;
            loggingSource.EnableConsoleLogging();
            

            Logger logger = loggingSource.GetLogger<App>("APP");
            logger.Info("APPLICATION STARTED");
        }
    }
}