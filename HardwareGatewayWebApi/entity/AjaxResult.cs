using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HardwareGatewayWebApi.entity
{
[DataContract]
public class AjaxResult
{
    /**
    * 正常返回
    */
    public const int OK = 0;
    /// <summary>
    /// 警告
    /// </summary>
    public const int WARN = 301;
    /**
        * 异常
        */
    public const int ERROR = 500;

    /// <summary>
    /// 状态码
    /// </summary>
    [DataMember]
    public int code { get; set; }
    /// <summary>
    /// 返回内容
    /// </summary>
    [DataMember]
    public String msg { get; set; }
    /// <summary>
    /// 数据对象
    /// </summary>
    [DataMember]
    public Object data { get; set; }
    /**
        * 无惨构造
        */
    public AjaxResult() { }

    /**
        *填充正确结果
        * @param data
        * @return
        */
    public static AjaxResult success(string strData)
    {
        return success(strData, "成功");
    }

    public static AjaxResult success(Object objData)
    {
        return success(JsonConvert.SerializeObject(objData), "成功");//JsonConvert.SerializeObject()
    }

    /**
        * 填充错误结果
        * @param data 数据
        * @param message 开发者信息
        * @return 错误结果描述
        */
    public static AjaxResult error(String strData, string message)
    {
        return new AjaxResult(strData, ERROR, string.IsNullOrEmpty(message) ? "失败" : message);
    }

    /**
    * 填充错误结果
    * @param data 数据
    * @param message 开发者信息
    * @return 错误结果描述
    */
    public static AjaxResult error(Object strData, string message)
    {
        return new AjaxResult(strData, ERROR, string.IsNullOrEmpty(message) ? "失败" : message);
    }

    /**
        * 填充正确结果
        * @param data 数据
        * @param message 信息
        * @return 正确结果描述
        */
    public static AjaxResult success(Object objData, String message)
    {
        return new AjaxResult(objData, OK, string.IsNullOrEmpty(message) ? "成功" : message);
    }

    /**
        * 带参数的构造
        * @param data
        * @param code
        * @param message
        */
    AjaxResult(Object objData, int code, String message)
    {
        this.data = objData;
        this.code = code;
        this.msg = message;
    }

}
}
