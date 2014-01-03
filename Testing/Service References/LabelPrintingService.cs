﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LabelPrinting
{
    using System.Runtime.Serialization;


    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "PrintResult", Namespace = "http://schemas.datacontract.org/2004/07/LabelPrinting")]
    public partial class PrintResult : object, System.Runtime.Serialization.IExtensibleDataObject
    {

        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        private string MessageField;

        private bool SuccessField;

        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message
        {
            get
            {
                return this.MessageField;
            }
            set
            {
                this.MessageField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Success
        {
            get
            {
                return this.SuccessField;
            }
            set
            {
                this.SuccessField = value;
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "LabelParameters", Namespace = "http://schemas.datacontract.org/2004/07/LabelPrinting")]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(string[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(LabelPrinting.CustomException))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(LabelPrinting.PrintResult))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(LabelPrinting.LabelParameters[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(LabelPrinting.PrintJobParameters[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(LabelPrinting.PrintJobParameters))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(LabelPrinting.AssetParameters[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(LabelPrinting.AssetParameters))]
    public partial class LabelParameters : object, System.Runtime.Serialization.IExtensibleDataObject
    {

        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        private string ParamNameField;

        private object ParamValueField;

        private string ParamValueStrField;

        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ParamName
        {
            get
            {
                return this.ParamNameField;
            }
            set
            {
                this.ParamNameField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public object ParamValue
        {
            get
            {
                return this.ParamValueField;
            }
            set
            {
                this.ParamValueField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ParamValueStr
        {
            get
            {
                return this.ParamValueStrField;
            }
            set
            {
                this.ParamValueStrField = value;
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "CustomException", Namespace = "http://schemas.datacontract.org/2004/07/LabelPrinting")]
    public partial class CustomException : object, System.Runtime.Serialization.IExtensibleDataObject
    {

        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        private string DescriptionField;

        private string MesssageField;

        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description
        {
            get
            {
                return this.DescriptionField;
            }
            set
            {
                this.DescriptionField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Messsage
        {
            get
            {
                return this.MesssageField;
            }
            set
            {
                this.MesssageField = value;
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "PrintJobParameters", Namespace = "http://schemas.datacontract.org/2004/07/LabelPrinting")]
    public partial class PrintJobParameters : object, System.Runtime.Serialization.IExtensibleDataObject
    {

        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        private int AssetTypeIDField;

        private byte[] inputBTWFileField;

        private LabelPrinting.AssetParameters[] lstAssetParametersField;

        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int AssetTypeID
        {
            get
            {
                return this.AssetTypeIDField;
            }
            set
            {
                this.AssetTypeIDField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] inputBTWFile
        {
            get
            {
                return this.inputBTWFileField;
            }
            set
            {
                this.inputBTWFileField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public LabelPrinting.AssetParameters[] lstAssetParameters
        {
            get
            {
                return this.lstAssetParametersField;
            }
            set
            {
                this.lstAssetParametersField = value;
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "AssetParameters", Namespace = "http://schemas.datacontract.org/2004/07/LabelPrinting")]
    public partial class AssetParameters : object, System.Runtime.Serialization.IExtensibleDataObject
    {

        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        private int AssetIDField;

        private LabelPrinting.LabelParameters[] lstLabelParametersField;

        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int AssetID
        {
            get
            {
                return this.AssetIDField;
            }
            set
            {
                this.AssetIDField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public LabelPrinting.LabelParameters[] lstLabelParameters
        {
            get
            {
                return this.lstLabelParametersField;
            }
            set
            {
                this.lstLabelParametersField = value;
            }
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName = "ILabelPrintingService")]
public interface ILabelPrintingService
{

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ILabelPrintingService/GetInstalledPrinters", ReplyAction = "http://tempuri.org/ILabelPrintingService/GetInstalledPrintersResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(LabelPrinting.CustomException), Action = "http://tempuri.org/ILabelPrintingService/GetInstalledPrintersCustomExceptionFault" +
        "", Name = "CustomException", Namespace = "http://schemas.datacontract.org/2004/07/LabelPrinting")]
    string[] GetInstalledPrinters();

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ILabelPrintingService/GetInstalledPrinters", ReplyAction = "http://tempuri.org/ILabelPrintingService/GetInstalledPrintersResponse")]
    System.Threading.Tasks.Task<string[]> GetInstalledPrintersAsync();

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ILabelPrintingService/IsPrinterInstalled", ReplyAction = "http://tempuri.org/ILabelPrintingService/IsPrinterInstalledResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(LabelPrinting.CustomException), Action = "http://tempuri.org/ILabelPrintingService/IsPrinterInstalledCustomExceptionFault", Name = "CustomException", Namespace = "http://schemas.datacontract.org/2004/07/LabelPrinting")]
    bool IsPrinterInstalled(string printerName);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ILabelPrintingService/IsPrinterInstalled", ReplyAction = "http://tempuri.org/ILabelPrintingService/IsPrinterInstalledResponse")]
    System.Threading.Tasks.Task<bool> IsPrinterInstalledAsync(string printerName);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ILabelPrintingService/GenerateLabelPreview", ReplyAction = "http://tempuri.org/ILabelPrintingService/GenerateLabelPreviewResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(LabelPrinting.CustomException), Action = "http://tempuri.org/ILabelPrintingService/GenerateLabelPreviewCustomExceptionFault" +
        "", Name = "CustomException", Namespace = "http://schemas.datacontract.org/2004/07/LabelPrinting")]
    byte[] GenerateLabelPreview(byte[] inputBytes, string printerName);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ILabelPrintingService/GenerateLabelPreview", ReplyAction = "http://tempuri.org/ILabelPrintingService/GenerateLabelPreviewResponse")]
    System.Threading.Tasks.Task<byte[]> GenerateLabelPreviewAsync(byte[] inputBytes, string printerName);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ILabelPrintingService/PrintLabel", ReplyAction = "http://tempuri.org/ILabelPrintingService/PrintLabelResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(LabelPrinting.CustomException), Action = "http://tempuri.org/ILabelPrintingService/PrintLabelCustomExceptionFault", Name = "CustomException", Namespace = "http://schemas.datacontract.org/2004/07/LabelPrinting")]
    LabelPrinting.PrintResult PrintLabel(byte[] inputBytes, string printerName);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ILabelPrintingService/PrintLabel", ReplyAction = "http://tempuri.org/ILabelPrintingService/PrintLabelResponse")]
    System.Threading.Tasks.Task<LabelPrinting.PrintResult> PrintLabelAsync(byte[] inputBytes, string printerName);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ILabelPrintingService/GenerateCustomeLabelPreview", ReplyAction = "http://tempuri.org/ILabelPrintingService/GenerateCustomeLabelPreviewResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(LabelPrinting.CustomException), Action = "http://tempuri.org/ILabelPrintingService/GenerateCustomeLabelPreviewCustomExcepti" +
        "onFault", Name = "CustomException", Namespace = "http://schemas.datacontract.org/2004/07/LabelPrinting")]
    byte[] GenerateCustomeLabelPreview(byte[] inputBytes, LabelPrinting.LabelParameters[] listLabelParameters, string printerName);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ILabelPrintingService/GenerateCustomeLabelPreview", ReplyAction = "http://tempuri.org/ILabelPrintingService/GenerateCustomeLabelPreviewResponse")]
    System.Threading.Tasks.Task<byte[]> GenerateCustomeLabelPreviewAsync(byte[] inputBytes, LabelPrinting.LabelParameters[] listLabelParameters, string printerName);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ILabelPrintingService/PrintCustomeLabel", ReplyAction = "http://tempuri.org/ILabelPrintingService/PrintCustomeLabelResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(LabelPrinting.CustomException), Action = "http://tempuri.org/ILabelPrintingService/PrintCustomeLabelCustomExceptionFault", Name = "CustomException", Namespace = "http://schemas.datacontract.org/2004/07/LabelPrinting")]
    LabelPrinting.PrintResult PrintCustomeLabel(byte[] inputBytes, LabelPrinting.LabelParameters[] listLabelParameters, string printerName);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ILabelPrintingService/PrintCustomeLabel", ReplyAction = "http://tempuri.org/ILabelPrintingService/PrintCustomeLabelResponse")]
    System.Threading.Tasks.Task<LabelPrinting.PrintResult> PrintCustomeLabelAsync(byte[] inputBytes, LabelPrinting.LabelParameters[] listLabelParameters, string printerName);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ILabelPrintingService/GetLabelParameters", ReplyAction = "http://tempuri.org/ILabelPrintingService/GetLabelParametersResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(LabelPrinting.CustomException), Action = "http://tempuri.org/ILabelPrintingService/GetLabelParametersCustomExceptionFault", Name = "CustomException", Namespace = "http://schemas.datacontract.org/2004/07/LabelPrinting")]
    string[] GetLabelParameters(byte[] inputBytes, string printerName);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ILabelPrintingService/GetLabelParameters", ReplyAction = "http://tempuri.org/ILabelPrintingService/GetLabelParametersResponse")]
    System.Threading.Tasks.Task<string[]> GetLabelParametersAsync(byte[] inputBytes, string printerName);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ILabelPrintingService/PrintBatchJob", ReplyAction = "http://tempuri.org/ILabelPrintingService/PrintBatchJobResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(LabelPrinting.CustomException), Action = "http://tempuri.org/ILabelPrintingService/PrintBatchJobCustomExceptionFault", Name = "CustomException", Namespace = "http://schemas.datacontract.org/2004/07/LabelPrinting")]
    LabelPrinting.PrintResult PrintBatchJob(string printJobName, string printerName, LabelPrinting.PrintJobParameters[] lstPrintJobParameters);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ILabelPrintingService/PrintBatchJob", ReplyAction = "http://tempuri.org/ILabelPrintingService/PrintBatchJobResponse")]
    System.Threading.Tasks.Task<LabelPrinting.PrintResult> PrintBatchJobAsync(string printJobName, string printerName, LabelPrinting.PrintJobParameters[] lstPrintJobParameters);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ILabelPrintingService/IsPrinterAvailable", ReplyAction = "http://tempuri.org/ILabelPrintingService/IsPrinterAvailableResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(LabelPrinting.CustomException), Action = "http://tempuri.org/ILabelPrintingService/IsPrinterAvailableCustomExceptionFault", Name = "CustomException", Namespace = "http://schemas.datacontract.org/2004/07/LabelPrinting")]
    bool IsPrinterAvailable(string printerName);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ILabelPrintingService/IsPrinterAvailable", ReplyAction = "http://tempuri.org/ILabelPrintingService/IsPrinterAvailableResponse")]
    System.Threading.Tasks.Task<bool> IsPrinterAvailableAsync(string printerName);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface ILabelPrintingServiceChannel : ILabelPrintingService, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class LabelPrintingServiceClient : System.ServiceModel.ClientBase<ILabelPrintingService>, ILabelPrintingService
{

    public LabelPrintingServiceClient()
    {
    }

    public LabelPrintingServiceClient(string endpointConfigurationName) :
        base(endpointConfigurationName)
    {
    }

    public LabelPrintingServiceClient(string endpointConfigurationName, string remoteAddress) :
        base(endpointConfigurationName, remoteAddress)
    {
    }

    public LabelPrintingServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
        base(endpointConfigurationName, remoteAddress)
    {
    }

    public LabelPrintingServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
        base(binding, remoteAddress)
    {
    }

    public string[] GetInstalledPrinters()
    {
        return base.Channel.GetInstalledPrinters();
    }

    public System.Threading.Tasks.Task<string[]> GetInstalledPrintersAsync()
    {
        return base.Channel.GetInstalledPrintersAsync();
    }

    public bool IsPrinterInstalled(string printerName)
    {
        return base.Channel.IsPrinterInstalled(printerName);
    }

    public System.Threading.Tasks.Task<bool> IsPrinterInstalledAsync(string printerName)
    {
        return base.Channel.IsPrinterInstalledAsync(printerName);
    }

    public byte[] GenerateLabelPreview(byte[] inputBytes, string printerName)
    {
        return base.Channel.GenerateLabelPreview(inputBytes, printerName);
    }

    public System.Threading.Tasks.Task<byte[]> GenerateLabelPreviewAsync(byte[] inputBytes, string printerName)
    {
        return base.Channel.GenerateLabelPreviewAsync(inputBytes, printerName);
    }

    public LabelPrinting.PrintResult PrintLabel(byte[] inputBytes, string printerName)
    {
        return base.Channel.PrintLabel(inputBytes, printerName);
    }

    public System.Threading.Tasks.Task<LabelPrinting.PrintResult> PrintLabelAsync(byte[] inputBytes, string printerName)
    {
        return base.Channel.PrintLabelAsync(inputBytes, printerName);
    }

    public byte[] GenerateCustomeLabelPreview(byte[] inputBytes, LabelPrinting.LabelParameters[] listLabelParameters, string printerName)
    {
        return base.Channel.GenerateCustomeLabelPreview(inputBytes, listLabelParameters, printerName);
    }

    public System.Threading.Tasks.Task<byte[]> GenerateCustomeLabelPreviewAsync(byte[] inputBytes, LabelPrinting.LabelParameters[] listLabelParameters, string printerName)
    {
        return base.Channel.GenerateCustomeLabelPreviewAsync(inputBytes, listLabelParameters, printerName);
    }

    public LabelPrinting.PrintResult PrintCustomeLabel(byte[] inputBytes, LabelPrinting.LabelParameters[] listLabelParameters, string printerName)
    {
        return base.Channel.PrintCustomeLabel(inputBytes, listLabelParameters, printerName);
    }

    public System.Threading.Tasks.Task<LabelPrinting.PrintResult> PrintCustomeLabelAsync(byte[] inputBytes, LabelPrinting.LabelParameters[] listLabelParameters, string printerName)
    {
        return base.Channel.PrintCustomeLabelAsync(inputBytes, listLabelParameters, printerName);
    }

    public string[] GetLabelParameters(byte[] inputBytes, string printerName)
    {
        return base.Channel.GetLabelParameters(inputBytes, printerName);
    }

    public System.Threading.Tasks.Task<string[]> GetLabelParametersAsync(byte[] inputBytes, string printerName)
    {
        return base.Channel.GetLabelParametersAsync(inputBytes, printerName);
    }

    public LabelPrinting.PrintResult PrintBatchJob(string printJobName, string printerName, LabelPrinting.PrintJobParameters[] lstPrintJobParameters)
    {
        return base.Channel.PrintBatchJob(printJobName, printerName, lstPrintJobParameters);
    }

    public System.Threading.Tasks.Task<LabelPrinting.PrintResult> PrintBatchJobAsync(string printJobName, string printerName, LabelPrinting.PrintJobParameters[] lstPrintJobParameters)
    {
        return base.Channel.PrintBatchJobAsync(printJobName, printerName, lstPrintJobParameters);
    }

    public bool IsPrinterAvailable(string printerName)
    {
        return base.Channel.IsPrinterAvailable(printerName);
    }

    public System.Threading.Tasks.Task<bool> IsPrinterAvailableAsync(string printerName)
    {
        return base.Channel.IsPrinterAvailableAsync(printerName);
    }
}
