using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace YiYang.Model
{
  /// <summary>
  /// 操作结果
  /// </summary>
  public class OperResult
  {
    /// <summary>
    /// 返回结果
    /// </summary>
    public object Result { get; private set; }

    /// <summary>
    /// 消息
    /// </summary>
    public string Message { get; private set; }

    /// <summary>
    /// 状态码
    /// </summary>
    public StatusCode StatusCode { get; set; }

    /// <summary>
    /// 异常
    /// </summary>
    public Exception Exception { get; private set; }

    /// <summary>
    /// 操作成功
    /// </summary>
    public static OperResult Succeed()
    {
      return new OperResult()
      {
        StatusCode = StatusCode.成功
      };
    }

    /// <summary>
    /// 操作成功
    /// </summary>
    /// <param name="result">结果</param>
    public static OperResult Succeed(object result)
    {
      return new OperResult()
      {
        Result = result,
        StatusCode = StatusCode.成功
      };
    }

    /// <summary>
    /// 操作成功
    /// </summary>
    /// <param name="statusCode">状态码</param>
    /// <param name="result">结果</param>
    /// <returns></returns>
    public static OperResult Succeed(StatusCode statusCode, object result = null)
    {
      return new OperResult()
      {
        Result = result,
        StatusCode = statusCode
      };
    }

    /// <summary>
    /// 获取结果
    /// </summary>
    /// <typeparam name="T">结果类型</typeparam>
    public T GetResult<T>()
    {
      if (Result == null)
        return default(T);
      if (!(Result is T))
        return default(T);
      return (T)Result;
    }

    /// <summary>
    /// 操作失败
    /// </summary>
    /// <param name="message">消息</param>
    /// <param name="statusCode">状态码</param>
    public static OperResult Fail(string message, StatusCode statusCode = StatusCode.失败)
    {
      return new OperResult()
      {
        Message = message,
        StatusCode = statusCode
      };
    }

    /// <summary>
    /// 操作失败
    /// </summary>
    /// <param name="exception">异常信息</param>
    /// <param name="statusCode">状态码</param>
    /// <returns></returns>
    public static OperResult Error(DbEntityValidationException exception, StatusCode statusCode = StatusCode.数据异常)
    {
      // 处理异常
      StringBuilder builder = new StringBuilder();
      if (exception.EntityValidationErrors == null || !(exception.EntityValidationErrors.Count() > 0))
        builder.Append("数据格式错误。");
      else
      {
        foreach (DbEntityValidationResult result in exception.EntityValidationErrors)
        {
          foreach (DbValidationError error in result.ValidationErrors)
          {
            builder.Append(string.Format("{0}错误：{1}", error.PropertyName, error.ErrorMessage));
          }
        }
      }
      string message = builder.ToString();
      // 返回结果
      return new OperResult()
      {
        Message = message,
        StatusCode = statusCode,
        Exception = exception
      };
    }

    /// <summary>
    /// 操作失败
    /// </summary>
    /// <param name="exception">异常信息</param>
    /// <param name="statusCode">状态码</param>
    /// <returns></returns>
    public static OperResult Error(Exception exception, StatusCode statusCode = StatusCode.程序异常)
    {
      string message = exception.Message;
      // 返回结果
      return new OperResult()
      {
        Message = message,
        StatusCode = statusCode,
        Exception = exception
      };
    }
  }
}