using Microsoft.Owin;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

[assembly: OwinStartup(typeof(HardwareGatewayWebApi.Startup))]

namespace HardwareGatewayWebApi
{
public class Startup
{
    public void Configuration(IAppBuilder app)
    {
        // 有关如何配置应用程序的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkID=316888
        HttpConfiguration config = new HttpConfiguration();
        config.Formatters.Clear();
        config.Formatters.Add(new JsonMediaTypeFormatter());
        config.Formatters.JsonFormatter.SerializerSettings =
        new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };
        ////干掉xml序列号器
        //config.Formatters.Remove(config.Formatters.XmlFormatter);
        ////解决json序列号时的循环问题
        //config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        ////对json数据使用混合大小写 驼峰式
        //config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        ////跟属性名同样大小输出
        //config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new DefaultContractResolver();
        config.MapHttpAttributeRoutes();
        config.Routes.MapHttpRoute(
            name: "default",
            routeTemplate: "api/{controller}/{action}/{id}",
            defaults: new { id = RouteParameter.Optional }
            );
        app.UseWebApi(config);
    }
}
}
