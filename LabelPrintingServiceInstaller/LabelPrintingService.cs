using System.ServiceModel;
using System.ServiceProcess;
using log4net;
using System;

namespace LabelPrintingServiceInstaller
{
    partial class LabelPrintingService : ServiceBase
    {
        private ServiceHost _serviceHost = null;
        private static readonly ILog log = LogManager.GetLogger(typeof(LabelPrintingService));

        public LabelPrintingService()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledExceptionHandler);
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                log.Info("LabelPrintingService OnStart() Method Called.");
                if (_serviceHost != null && _serviceHost.State == CommunicationState.Opened)
                {
                    _serviceHost.Close();
                }

                _serviceHost = new ServiceHost(typeof(LabelPrinting.LabelPrintingService));
                _serviceHost.Open();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw ex;
            }
        }

        protected override void OnStop()
        {
            if (_serviceHost != null)
            {
                _serviceHost.Close();
                _serviceHost = null;
            }
            log.Info("LabelPrintingService OnStop() Method Called.");
        }



        void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            log.Error(e.ExceptionObject);
        }

    }
}
