using System.ServiceProcess;
using log4net;


namespace LabelPrintingServiceInstaller
{
    static class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            log.Info("Serivce Main Method Called");
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new LabelPrintingService() 
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
