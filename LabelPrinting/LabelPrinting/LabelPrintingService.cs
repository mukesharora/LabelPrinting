using System;
using System.Drawing;
using System.IO;
using log4net;
using Seagull.BarTender.Print;
using System.Drawing.Printing;
using System.ServiceModel;

namespace LabelPrinting
{
    public class LabelPrintingService : ILabelPrintingService
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(LabelPrintingService));

        public LabelPrintingService()
        {
            log.Info("LabelPrintingService Constructor Called");
        }

        public byte[] GenerateLabelPreview(byte[] inputBytes, string printerName)
        {
            try
            {
                log.Info("GenerateLabelPreview Method Called");
                using (Engine engine = new Engine(true))
                {
                    string outputFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Output_" + Guid.NewGuid().ToString() + ".jpg";
                    string inputFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Input_" + Guid.NewGuid().ToString() + ".btw";
                    log.Info("BTW file paht - " + inputFile);
                    log.Info("Preview fiel path - " + outputFile);

                    using (FileStream file = File.Create(inputFile))
                    {
                        file.Write(inputBytes, 0, inputBytes.Length);
                        file.Close();

                        LabelFormatDocument format = engine.Documents.Open(inputFile);
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
    }
}
