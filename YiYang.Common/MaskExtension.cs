namespace YiYang.Common
{
  /// <summary>
  /// 掩码扩展类
  /// </summary>
  public static class MaskExtension
  {
    /// <summary>
    /// 姓名掩码
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static string MaskName(this string name)
    {
      if (string.IsNullOrWhiteSpace(name))
      {
        return string.Empty;
      }
      if (name.Length == 2)
      {
        return name.Substring(0, 1) + "*";
      }
      else
      {
        return name.Substring(0, 1) + "*" + name.Substring(name.Length - 1, 1);
      }
    }

    /// <summary>
    /// 手机号掩码
    /// </summary>
    /// <returns></returns>
    public static string MaskMobileNo(this string mobileNo)
    {
      if (string.IsNullOrWhiteSpace(mobileNo))
        return string.Empty;
      return mobileNo.Substring(0, 3) + "****" + mobileNo.Substring(7, 4);
    }

    /// <summary>
    /// 电话号掩码
    /// </summary>
    /// <param name="phoneNo"></param>
    /// <returns></returns>
    public static string MaskPhoneNo(this string phoneNo)
    {
      if (string.IsNullOrWhiteSpace(phoneNo))
        return string.Empty;
      switch (phoneNo.Length)
      {
        case 7:
          return phoneNo.Substring(0, 2) + "**" + phoneNo.Substring(4, 3);
        case 8:
          return phoneNo.Substring(0, 2) + "***" + phoneNo.Substring(5, 3);
        case 11:
          return phoneNo.Substring(0, 3) + "****" + phoneNo.Substring(7, 4);
        case 12:
          return phoneNo.Substring(0, 5) + "***" + phoneNo.Substring(8, 4);
        case 13:
          return phoneNo.Substring(0, 6) + "***" + phoneNo.Substring(9, 4);
        default:
          return phoneNo.Substring(0, 3) + "***" + phoneNo.Substring(6);
      }
    }

    /// <summary>
    /// 企业名称掩码
    /// </summary>
    /// <param name="enterpriseName"></param>
    /// <returns></returns>
    public static string MaskEnterpriseName(this string enterpriseName)
    {
      if (string.IsNullOrWhiteSpace(enterpriseName))
      {
        return string.Empty;
      }
      return enterpriseName.Substring(0, 4) + "****" + enterpriseName.Substring(enterpriseName.Length - 4, 4);
    }

    /// <summary>
    /// 微信开放Id掩码
    /// </summary>
    /// <param name="wechatOpenId"></param>
    /// <returns></returns>
    public static string MaskWechatOpenId(this string wechatOpenId)
    {
      if (string.IsNullOrWhiteSpace(wechatOpenId))
      {
        return string.Empty;
      }
      if (wechatOpenId.Length < 28)
      {
        return wechatOpenId;
      }
      return wechatOpenId.Substring(0, 4) + "********" + wechatOpenId.Substring(12, 4) + "********" + wechatOpenId.Substring(25);
    }
  }
}