using System.IO;

using System.ServiceModel;
using System.Runtime.Serialization;

namespace LabelPrinting
{
    [ServiceContract]
    public interface ILabelPrintingService
    {
        [OperationContract]
        [FaultContract(typeof(CustomException))]
        byte[] GenerateLabelPreview(byte[] inputBytes,string printerName);
    }


    [DataContract]
    public class CustomException
    {
        [DataMember]
        public string Messsage { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}
