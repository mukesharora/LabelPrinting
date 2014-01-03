using System;
using System.ServiceModel;

namespace HostingApp
{
    class Program
    {
        private static void Main(string[] args)
        {
            Type serviceType = typeof(LabelPrinting.LabelPrintingService);
            
            ServiceHost host = new ServiceHost(serviceType);


            host.Open();

            Console.WriteLine("Press ENTER to exit.");
            Console.ReadLine();

            host.Close();
        }

    }

    //class Program
    //{
    //    private static void Main(string[] args)
    //    {
    //        Type serviceType = typeof(LabelPrinting.LabelPrintingService);

    //        IEndpointInfo endpointInfo = new BasicHttpEndpointInfo();

    //        ServiceHost host = new ServiceHost(serviceType, endpointInfo.BaseAddress);
    //         host.Description.Behaviors.Add(new ConsoleMessageTracing());

    //        host.AddServiceEndpoint(typeof(LabelPrinting.ILabelPrintingService), endpointInfo.GetBinding(), endpointInfo.BaseAddress);

    //        host.Open();

    //        Console.WriteLine("Press ENTER to exit.");
    //        Console.ReadLine();

    //        host.Close();
    //    }

    //    interface IEndpointInfo
    //    {
    //        Uri BaseAddress { get; }
    //        Binding GetBinding();
    //    }


    //    class BasicHttpEndpointInfo : IEndpointInfo
    //    {
    //        #region IEndpointInfo Members

    //        public Uri BaseAddress
    //        {
    //            get { return new Uri("http://localhost:9733/Design_Time_Addresses/LabelPrinting/LabelPrintingService/"); }
    //        }

    //        public Binding GetBinding()
    //        {
    //            BasicHttpBinding binding = new BasicHttpBinding();
    //            binding.AllowCookies = false;
    //            binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
    //            binding.MessageEncoding = WSMessageEncoding.Text;

    //            return binding;
    //        }

    //        #endregion
    //    }

    //}



    //public class ConsoleMessageTracing : IServiceBehavior
    //{
    //    #region IServiceBehavior Members

    //    public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
    //    {
    //        return;
    //    }

    //    public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
    //    {
    //        return;
    //    }

    //    public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
    //    {
    //        foreach (ChannelDispatcher cDispatcher in serviceHostBase.ChannelDispatchers)
    //            foreach (EndpointDispatcher eDispatcher in cDispatcher.Endpoints)
    //                eDispatcher.DispatchRuntime.MessageInspectors.Add(new ConsoleMessageTracer());
    //    }

    //    #endregion
    //}


    //public class ConsoleMessageTracer : IDispatchMessageInspector, IClientMessageInspector
    //{
    //    private Message TraceMessage(MessageBuffer buffer)
    //    {
    //        Message msg = buffer.CreateMessage();
    //        Console.WriteLine("\n{0}\n", msg);
    //        return buffer.CreateMessage();
    //    }

    //    public object AfterReceiveRequest(ref Message request,
    //        IClientChannel channel,
    //        InstanceContext instanceContext)
    //    {
    //        request = TraceMessage(request.CreateBufferedCopy(int.MaxValue));
    //        return null;
    //    }

    //    public void BeforeSendReply(ref Message reply, object
    //        correlationState)
    //    {
    //        reply = TraceMessage(reply.CreateBufferedCopy(int.MaxValue));
    //    }

    //    public void AfterReceiveReply(ref Message reply, object
    //        correlationState)
    //    {
    //        reply = TraceMessage(reply.CreateBufferedCopy(int.MaxValue));
    //    }

    //    public object BeforeSendRequest(ref Message request,
    //        IClientChannel channel)
    //    {
    //        request = TraceMessage(request.CreateBufferedCopy(int.MaxValue));
    //        return null;
    //    }
    //}
}