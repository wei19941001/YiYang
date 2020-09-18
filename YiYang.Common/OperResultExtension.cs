using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Web.Mvc;
using YiYang.Model;

namespace YiYang.Common
{
  /// <summary>
  /// 操作结果扩展类
  /// </summary>
  public static class OperResultExtension
  {
    /// <summary>
    /// 转成字符串
    /// </summary>
    /// <param name="operResult">操作结果</param>
    public static string ToJsonString(this OperResult operResult)
    {
      // 时间转换
      IsoDateTimeConverter isoDateTimeConverter = new IsoDateTimeConverter()
      {
        DateTimeFormat = "yyyy-MM-dd HH:mm:ss"
      };
      // 枚举转文本
      StringEnumConverter stringEnumConverter = new StringEnumConverter();
      // 序列化
      JsonConverter[] jsonConverters = new JsonConverter[]
      {
        isoDateTimeConverter,
        stringEnumConverter
      };
      return JsonConvert.SerializeObject(operResult, jsonConverters);
    }

    /// <summary>
    /// 创建JSON视图结果
    /// </summary>
    /// <param name="operResult">操作结果</param>
    /// <param name="denyGet">拒绝GET请求</param>
    /// <param name="showTime">日期显示时间</param>
    public static JsonResult CreateJsonResult(this OperResult operResult, bool denyGet = false)
    {
      JsonResult jsonResult = new JsonResult();
      jsonResult.JsonRequestBehavior = denyGet ? JsonRequestBehavior.DenyGet : JsonRequestBehavior.AllowGet;
      jsonResult.Data = operResult;
      return jsonResult;
    }
  }
}