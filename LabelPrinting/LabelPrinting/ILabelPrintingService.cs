using System.IO;

using System.ServiceModel;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace LabelPrinting
{
    [ServiceContract]
    public interface ILabelPrintingService
    {
        [OperationContract]
        [FaultContract(typeof(CustomException))]
        IEnumerable<string> GetInstalledPrinters();

        [OperationContract]
        [FaultContract(typeof(CustomException))]
        bool IsPrinterInstalled(string printerName);

        [OperationContract]
        [FaultContract(typeof(CustomException))]
        byte[] GenerateLabelPreview(byte[] inputBytes, string printerName);

        [OperationContract]
        [FaultContract(typeof(CustomException))]
        PrintResult PrintLabel(byte[] inputBytes, string printerName);

        [OperationContract(Name = "GenerateCustomeLabelPreview")]
        [FaultContract(typeof(CustomException))]
        byte[] GenerateLabelPreview(byte[] inputBytes, List<LabelParameters> listLabelParameters, string printerName);

        [OperationContract(Name = "PrintCustomeLabel")]
        [FaultContract(typeof(CustomException))]
        PrintResult PrintLabel(byte[] inputBytes, List<LabelParameters> listLabelParameters, string printerName);

        [OperationContract]
        [FaultContract(typeof(CustomException))]
        IEnumerable<string> GetLabelParameters(byte[] inputBytes, string printerName);

    }


    [DataContract]
    public class CustomException
    {
        [DataMember]
        public string Messsage { get; set; }
        [DataMember]
        public string Description { get; set; }
    }

    [DataContract]
    public class PrintResult
    {
        [DataMember]
        public bool Success { get; set; }

        [DataMember]
        public string Message { get; set; }
    }

    [DataContract]
    public class LabelParameters
    {
        [DataMember]
        public string ParamName { get; set; }
        [DataMember]
        public object ParamValue { get; set; }
    }

   internal enum FileType
    {
        JPEG,
        BTW
    }
}
