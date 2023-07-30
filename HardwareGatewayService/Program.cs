using HardwareGatewayWebApi;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace HardwareGatewayService
{
    internal class Program
    {
        /// <summary>
        /// 描述信息
        /// </summary>
        private static string Description
        {
            get
            {
                return ConfigurationManager.AppSettings["Description"];
            }
        }
        /// <summary>
        /// 显示名称
        /// </summary>
        private static string DisplayName
        {
            get
            {
                return ConfigurationManager.AppSettings["DisplayName"];
            }
        }

        /// <summary>
        /// 服务名称
        /// </summary>
        private static string ServerName
        {
            get
            {
                return ConfigurationManager.AppSettings["ServerName"];
            }
        }
      
        static void Main(string[] args)
        {
            HostFactory.Run(host =>
            {
                host.Service<Application>(service =>
                {
                    //连接变为restfulApi
                    service.ConstructUsing(() => new Application());
                    //当服务开始的时候，运行
                    service.WhenStarted(tc => tc.Start());
                    service.WhenStopped(tc => tc.Stop());
                });
                //本地作为系统服务启动，且设置为自启动
                host.RunAsLocalSystem().StartAutomatically();
                host.SetDescription(Description);
                host.SetDisplayName(DisplayName);
                host.SetServiceName(ServerName);
            });
        }

internal class Application {
    HGApplication _host = null;
    internal void Start() {
        System.Console.WriteLine($"Start");
        try
        {
            _host = new HGApplication();
            _host.Start();
        }
        catch (Exception ex)
        {
            throw new NotImplementedException();
        }
    }
    internal void Stop() {
        System.Console.WriteLine($"Stop");
        if (_host != null)
        {
            _host.Close();
        }
    }
}
    }
}
