using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HardwareGatewayWebApi.controller
{
public class TestController : ApiController
{
    [HttpGet]
    public String Get()
    {
        return "HelloWorld";
    }

    [HttpGet]
    public string Get(int id)
    {
        return $"收到数据{id}";
    }

    public string Post([FromBody] string data)
    {
        return data;
    }

    public string Delete(int id)
    {
        return $"delete数据{id}"; ;
    }
}
}
