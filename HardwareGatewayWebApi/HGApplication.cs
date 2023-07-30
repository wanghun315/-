using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareGatewayWebApi
{
public class HGApplication
{
    protected IDisposable WebApplication;

    public void Start()
    {
        AppDomain.CurrentDomain.Load(typeof(Microsoft.Owin.Host.HttpListener.OwinHttpListener).Assembly.GetName());
        WebApplication = WebApp.Start<Startup>("http://*:9555/");
    }

    public void Close()
    {
        WebApplication.Dispose();
    }
}
}
