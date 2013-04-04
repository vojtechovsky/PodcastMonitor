using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace PodcastMonitor.Services.Feed.Application
{
    [RunInstaller(true)]
    public class CommunicationServiceInstaller : Installer
    {
        private readonly ServiceInstaller _installer;
        private readonly ServiceProcessInstaller _processInstaller;

        public CommunicationServiceInstaller()
        {
            _installer = new ServiceInstaller
                             {
                                 Description = "Processor for listing podcasts",
                                 DisplayName = "My podcast service",
                                 ServiceName = "PodcastMonitorFeedService",
                                 StartType = ServiceStartMode.Automatic
                             };

            _processInstaller = new ServiceProcessInstaller
                                    {
                                        Account = ServiceAccount.LocalSystem
                                    };

            Installers.AddRange(new Installer[] { _installer, _processInstaller });
        }
    }
}