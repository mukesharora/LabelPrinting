
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

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

        [OperationContract]
        [FaultContract(typeof(CustomException))]
        PrintResult PrintBatchJob(string printJobName, string printerName,string printedBy, List<PrintJobParameters> lstPrintJobParameters);
              
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
        [DataMember]
        public string ParamValueStr { get; set; }
    }

    internal enum FileType
    {
        JPEG,
        BTW
    }

    [DataContract]
    public class PrintJobParameters
    {
        [DataMember]
        public int AssetTypeID { get; set; }
        [DataMember]
        public byte[] inputBTWFile { get; set; }
        [DataMember]
        public List<AssetParameters> lstAssetParameters { get; set; }
    }

    [DataContract]
    public class AssetParameters
    {
        [DataMember]
        public int AssetID { get; set; }
        [DataMember]
        public List<LabelParameters> lstLabelParameters { get; set; }
    }
}
