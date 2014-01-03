using log4net;
using Seagull.BarTender.Print;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Printing;
using System.IO;
using System.ServiceModel;
using System.Threading;

namespace LabelPrinting
{
    //[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant, InstanceContextMode = InstanceContextMode.PerCall)]
    public class LabelPrintingService : ILabelPrintingService
    {
        //enum CallingSource
        //{
        //    Error,
        //    Sent
        //}

        private const string ImagePrefix = "img";

        private static readonly ILog log = LogManager.GetLogger(typeof(LabelPrintingService));

        public LabelPrintingService()
        {
            log.Info("LabelPrintingService Constructor Called.");
        }

        public byte[] GenerateLabelPreview(byte[] inputBytes, string printerName)
        {
            try
            {
                log.Info("GenerateLabelPreview Method Called.");
                return Preview(inputBytes, null, printerName);
            }
            catch (Exception outerEx)
            {
                log.Error(outerEx);
                CustomException exceptionDetails = new CustomException();
                exceptionDetails.Messsage = exceptionDetails.Messsage;
                exceptionDetails.Description = exceptionDetails.Description;
                throw new FaultException<CustomException>(exceptionDetails, outerEx.Message);
            }
        }

        public IEnumerable<string> GetLabelParameters(byte[] inputBytes, string printerName)
        {
            try
            {
                log.Info("GetLabelParameters Method Called.");
                string inputFile = WriteBytesToFile(inputBytes, FileType.BTW);
                using (Engine engine = new Engine(true))
                {
                    LabelFormatDocument format = engine.Documents.Open(inputFile);
                    format.PrintSetup.PrinterName = printerName;
                    List<string> parameters = new List<string>();
                    foreach (SubString subString in format.SubStrings)
                    {
                        parameters.Add(subString.Name);
                    }
                    try
                    {
                        File.Delete(inputFile);
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                    }
                    return parameters;
                }
            }
            catch (Exception outerEx)
            {
                log.Error(outerEx);
                CustomException exceptionDetails = new CustomException();
                exceptionDetails.Messsage = exceptionDetails.Messsage;
                exceptionDetails.Description = exceptionDetails.Description;
                throw new FaultException<CustomException>(exceptionDetails, outerEx.Message);
            }
        }

        public IEnumerable<string> GetInstalledPrinters()
        {
            try
            {
                log.Info("GetInstalledPrinters Method Called.");
                List<string> printers = new List<string>();
                foreach (string printer in PrinterSettings.InstalledPrinters)
                {
                    log.Info(string.Format("Printer {0} is install.", printer));
                    printers.Add(printer);
                }
                return printers;
            }
            catch (Exception outerEx)
            {
                log.Error(outerEx);
                CustomException exceptionDetails = new CustomException();
                exceptionDetails.Messsage = exceptionDetails.Messsage;
                exceptionDetails.Description = exceptionDetails.Description;
                throw new FaultException<CustomException>(exceptionDetails, outerEx.Message);
            }
        }

        public bool IsPrinterInstalled(string printerName)
        {
            try
            {
                log.Info("IsPrinterInstalled Method Called.");
                List<string> printers = (List<string>)GetInstalledPrinters();

                if (printers.Exists(p => p.ToLower() == printerName.ToLower()))
                {
                    return true;
                }
                else
                {
                    log.Info(string.Format("Printer '{0}' is not installed in the system.", printerName));
                    return false;
                }
            }
            catch (Exception outerEx)
            {
                log.Error(outerEx);
                CustomException exceptionDetails = new CustomException();
                exceptionDetails.Messsage = exceptionDetails.Messsage;
                exceptionDetails.Description = exceptionDetails.Description;
                throw new FaultException<CustomException>(exceptionDetails, outerEx.Message);
            }
        }

        public PrintResult PrintLabel(byte[] inputBytes, string printerName)
        {
            try
            {
                log.Info("PrintLabel Method Called.");
                return Print(inputBytes, null, printerName);
            }
            catch (Exception outerEx)
            {
                log.Error(outerEx);
                CustomException exceptionDetails = new CustomException();
                exceptionDetails.Messsage = exceptionDetails.Messsage;
                exceptionDetails.Description = exceptionDetails.Description;
                throw new FaultException<CustomException>(exceptionDetails, outerEx.Message);
            }
        }

        public byte[] GenerateLabelPreview(byte[] inputBytes, List<LabelParameters> listLabelParameters, string printerName)
        {
            try
            {
                log.Info("GenerateCustomeLabelPreview Method Called.");
                return Preview(inputBytes, listLabelParameters, printerName);
            }
            catch (Exception outerEx)
            {
                log.Error(outerEx);
                CustomException exceptionDetails = new CustomException();
                exceptionDetails.Messsage = exceptionDetails.Messsage;
                exceptionDetails.Description = exceptionDetails.Description;
                throw new FaultException<CustomException>(exceptionDetails, outerEx.Message);
            }
        }

        public PrintResult PrintLabel(byte[] inputBytes, List<LabelParameters> listLabelParameters, string printerName)
        {
            try
            {
                log.Info("PrintCustomeLabel Method Called.");
                return Print(inputBytes, listLabelParameters, printerName);
            }
            catch (Exception outerEx)
            {
                log.Error(outerEx);
                CustomException exceptionDetails = new CustomException();
                exceptionDetails.Messsage = exceptionDetails.Messsage;
                exceptionDetails.Description = exceptionDetails.Description;
                throw new FaultException<CustomException>(exceptionDetails, outerEx.Message);
            }
        }

        public PrintResult PrintBatchJob( string printJobName, string printerName,string printedBy, List<PrintJobParameters> lstPrintJobParameters)
        {
            try
            {
                PrintResult printResult = new PrintResult();
                //if (!IsPrinterInstalled(printerName))
                //{
                //    printResult.Success = false;
                //    printResult.Message = "Selected printer is not installed.";
                //    return printResult;
                //}
                PrintBatchJobRepository repository = new PrintBatchJobRepository();
                repository.UpdatePrintJobStatus(printedBy, printJobName, "Printing");

                List<object> lstThreadParam = new List<object>();
                lstThreadParam.Add(printJobName);
                lstThreadParam.Add(printerName);
                lstThreadParam.Add(lstPrintJobParameters);
                ParameterizedThreadStart threadStart = new ParameterizedThreadStart(StartPrintBatchJob);
                new Thread(threadStart).Start(lstThreadParam);
                //StartPrintBatchJob(printJobID, printerName, lstPrintJobParameters);


                repository.UpdatePrintJobStatus(printedBy,printJobName, "Printed");
                printResult.Message = ServiceMessages.JobSubmitted;
                printResult.Success = true;
                return printResult;
            }
            catch (Exception outerEx)
            {
                log.Error(outerEx);
                CustomException exceptionDetails = new CustomException();
                exceptionDetails.Messsage = exceptionDetails.Messsage;
                exceptionDetails.Description = exceptionDetails.Description;
                throw new FaultException<CustomException>(exceptionDetails, outerEx.Message);
            }
        }


        public bool IsPrinterAvailable(string printerName)
        {
            throw new NotImplementedException("IsPrinterAvailable");
        }

        public void PrintBatchJobCallback(string printJobName, string printerName, List<PrintJobParameters> lstPrintJobParameters)
        {
            throw new NotImplementedException("PrintBatchJobCallback");
        }

        #region "Private Methods"

        private void StartPrintBatchJob(object functionParameters)
        {
            List<object> lstThreadParam = (List<object>)functionParameters;

            string printJobName = (string)lstThreadParam[0];
            string printerName = (string)lstThreadParam[1];
            List<PrintJobParameters> lstPrintJobParameters = (List<PrintJobParameters>)lstThreadParam[2];
            StartPrintBatchJob(printJobName, printerName, lstPrintJobParameters);
        }

        private void StartPrintBatchJob(string printJobName, string printerName, List<PrintJobParameters> lstPrintJobParameters)
        {
            foreach (PrintJobParameters jobParam in lstPrintJobParameters)
            {
                string inputFile = WriteBytesToFile(jobParam.inputBTWFile, FileType.BTW);
                foreach (AssetParameters assetParam in jobParam.lstAssetParameters)
                {
                    PrintJob(jobParam.AssetTypeID, assetParam, printJobName, printerName, inputFile);
                }
                try
                {
                    File.Delete(inputFile);
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                }
            }
        }

        private void PrintJob(int assetTypeID, AssetParameters assetParam, string printJobName, string printerName, string inputFile)
        {
            using (Engine engine = new Engine(true))
            {
                string fileName = assetParam.AssetID + "," + assetTypeID + "," + printJobName;
                LabelFormatDocument format = engine.Documents.Open(inputFile);
                format.PrintSetup.PrinterName = printerName;

                //format.JobCancelled += format_JobErrorOccurred;
                //format.JobErrorOccurred += format_JobErrorOccurred;
                // format.JobSent += format_JobSent;

                PrintBatchJobRepository repository = new PrintBatchJobRepository();

                if (assetParam.lstLabelParameters != null)
                {
                    SetLabelParameters(assetParam.lstLabelParameters, format);
                }

                Messages messages = new Messages();
                Result result = format.Print(Path.GetFileName(inputFile), out messages);
                string messageString = "\n\nMessages:";
                PrintResult printResult = new PrintResult();

                foreach (Seagull.BarTender.Print.Message message in messages)
                {
                    messageString += "\n\n" + message.Text;
                }

                if (messageString.ToString().ToLower().Contains("job status"))
                {
                    messageString = messageString.Substring(messageString.ToLower().IndexOf("job status"));
                    if (messageString.ToLower().LastIndexOf("status") > 0)
                    {
                        messageString = Environment.NewLine + messageString.Substring(messageString.ToLower().LastIndexOf("status"));
                    }
                    else
                    {
                        messageString = string.Empty;
                    }
                }

                if (result == Result.Failure)
                {
                    repository.UpdatePrintJobDetailStatus(printJobName, assetTypeID, assetParam.AssetID, false, ServiceMessages.PrintFailed + messageString);
                }
                else if (result == Result.Timeout)
                {
                    repository.UpdatePrintJobDetailStatus(printJobName, assetTypeID, assetParam.AssetID, false, ServiceMessages.PrintTimeout + messageString);
                }
                else
                {
                    repository.UpdatePrintJobDetailStatus(printJobName, assetTypeID, assetParam.AssetID, true, ServiceMessages.PrintSpooled);
                }
            }
        }

        //void format_JobSent(object sender, JobSentEventArgs e)
        //{
        //    UpdateJobStatus(e, e.JobPrintingVerified, CallingSource.Sent);
        //}

        //void format_JobErrorOccurred(object sender, PrintJobEventArgs e)
        //{
        //    UpdateJobStatus(e, false, CallingSource.Error);
        //}

        //private void UpdateJobStatus(PrintJobEventArgs e, bool JobPrintingVerified, CallingSource source)
        //{
        //    string[] fileName = e.Name.Split(',');
        //    int assetID = Convert.ToInt32(fileName[0]);
        //    int assetTypeID = Convert.ToInt32(fileName[1]);
        //    string printJobName = fileName[2];
        //    PrintBatchJobRepository repository = new PrintBatchJobRepository();
        //    bool isPrinted = JobPrintingVerified;
        //    if (JobPrintingVerified)
        //    {
        //        repository.UpdatePrintJobDetailStatus(printJobName, assetTypeID, assetID, isPrinted, e.PrinterInfo.Message);
        //    }
        //    else
        //    {
        //        if (e.PrinterInfo.StatusSeverity == PrinterStatusSeverity.Normal && source == CallingSource.Sent)
        //        {
        //            isPrinted = true;
        //        }
        //        if (source == CallingSource.Error)
        //        {
        //            isPrinted = false;
        //        }
        //        if (e.PrinterInfo.StatusSeverity == PrinterStatusSeverity.Error)
        //        {
        //            isPrinted = false;
        //        }
        //        if (e.PrinterInfo.Message.ToLower().Contains("error") || e.PrinterInfo.Message.ToLower().Contains("user cancelled"))
        //        {
        //            isPrinted = false;
        //        }
        //        repository.UpdatePrintJobDetailStatus(printJobName, assetTypeID, assetID, isPrinted, e.PrinterInfo.Message);
        //    }
        //}

        private bool IsSubStringExists(string subStringKey, SubStrings subStrings)
        {
            foreach (SubString subString in subStrings)
            {
                if (subString.Name.Equals(subStringKey))
                    return true;
            }

            return false;
        }

        private void SetLabelParameters(List<LabelParameters> listLabelParameters, LabelFormatDocument format)
        {
            foreach (LabelParameters param in listLabelParameters)
            {
                if (IsSubStringExists(param.ParamName, format.SubStrings))
                {
                    if (param.ParamName.IndexOf(ImagePrefix, StringComparison.CurrentCultureIgnoreCase) >= 0 && param.ParamValue != null && param.ParamValue.GetType() == typeof(byte[]))
                    {
                        format.SubStrings[param.ParamName].Value = Path.GetFileName(WriteBytesToFile((byte[])param.ParamValue, FileType.JPEG));
                    }
                    else if (param.ParamValue != null && param.ParamValue.GetType() == typeof(string))
                    {
                        format.SubStrings[param.ParamName].Value = param.ParamValue.ToString();
                    }
                }
                else
                {
                    log.Info(param.ParamName + " does not exists in the Label.");
                }
            }
        }

        private string WriteBytesToFile(byte[] inputBytes, FileType fileType)
        {
            string filePath = CreateNewFile(fileType);
            using (FileStream file = File.Create(filePath))
            {
                file.Write(inputBytes, 0, inputBytes.Length);
                file.Close();
            }
            return filePath;
        }

        private string CreateNewFile(FileType fileType)
        {
            string dir = ConfigurationSettings.AppSettings["BTFilePath"];
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            string filePath = Path.Combine(dir, Guid.NewGuid().ToString() + "." + fileType.ToString());
            return filePath;
        }

        private PrintResult Print(byte[] inputBytes, List<LabelParameters> listLabelParameters, string printerName)
        {
            PrintResult printResult = new PrintResult();
            //if (!IsPrinterInstalled(printerName))
            //{
            //    printResult.Success = false;
            //    printResult.Message = "Selected printer is not installed.";
            //    return printResult;
            //}
            string inputFile = WriteBytesToFile(inputBytes, FileType.BTW);

            using (Engine engine = new Engine(true))
            {
                LabelFormatDocument format = engine.Documents.Open(inputFile);
                format.PrintSetup.PrinterName = printerName;
                if (listLabelParameters != null)
                {
                    SetLabelParameters(listLabelParameters, format);
                }
                Messages messages = new Messages();
                Result result = format.Print(Path.GetFileName(inputFile), out messages);
                string messageString = "\n\nMessages:";

                foreach (Seagull.BarTender.Print.Message message in messages)
                {
                    messageString += "\n\n" + message.Text;
                }

                if (messageString.ToString().ToLower().Contains("job status"))
                {
                    messageString = messageString.Substring(messageString.ToLower().IndexOf("job status"));
                    if (messageString.ToLower().LastIndexOf("status") > 0)
                    {
                        messageString = Environment.NewLine + messageString.Substring(messageString.ToLower().LastIndexOf("status"));
                    }
                    else
                    {
                        messageString = string.Empty;
                    }
                }

                if (result == Result.Failure)
                {
                    printResult.Success = false;
                    printResult.Message = "Print Fail " + messageString;
                }
                else if (result == Result.Timeout)
                {
                    printResult.Success = false;
                    printResult.Message = "Print Fail (Timeout) " + messageString;
                }
                else
                {
                    printResult.Success = true;
                    printResult.Message = ServiceMessages.LabelSpooled + messageString;
                }
                try
                {
                    File.Delete(inputFile);
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                }
            }
            return printResult;
        }

        private byte[] Preview(byte[] inputBytes, List<LabelParameters> listLabelParameters, string printerName)
        {
            using (Engine engine = new Engine(true))
            {
                string outputFile = CreateNewFile(FileType.JPEG);
                string inputFile = WriteBytesToFile(inputBytes, FileType.BTW);
                LabelFormatDocument format = engine.Documents.Open(inputFile);
                if (listLabelParameters != null)
                {
                    SetLabelParameters(listLabelParameters, format);
                }
                format.PrintSetup.PrinterName = printerName;
                format.ExportImageToFile(outputFile, ImageType.JPEG, Seagull.BarTender.Print.ColorDepth.ColorDepth256,
                    new Resolution(ImageResolution.Printer), OverwriteOptions.Overwrite);
                format.Close(SaveOptions.DoNotSaveChanges);
                if (engine != null && engine.IsAlive)
                {
                    engine.Stop(SaveOptions.DoNotSaveChanges);
                }
                byte[] fileData = File.ReadAllBytes(outputFile);
                try
                {
                    File.Delete(inputFile);
                    File.Delete(outputFile);
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                }
                return fileData;
            }
        }

        #endregion "Private Methods"
    }
}
