using HardwareGatewayWebApi.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HardwareGatewayWebApi.controller
{

public class HardwareGatewayController : ApiController
{
    [HttpGet]
    [Route("HardwareGateway/HelloWorld")]
    public AjaxResult HelloWorld()
    {
        return AjaxResult.success($"HelloWorld") ;
    }
}
}
