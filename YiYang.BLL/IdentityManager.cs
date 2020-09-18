using System;
using System.Web;
using System.Web.Security;
using YiYang.Model;

namespace YiYang.BLL
{
  /// <summary>
  /// 身份管理类
  /// </summary>
  public class IdentityManager
  {
    /// <summary>
    /// 保存身份
    /// </summary>
    /// <param name="userInfo"></param>
    public static void SaveIdentity(UserInfo userInfo)
    {
      HttpContext.Current.Session["UserInfo"] = userInfo;
      HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName);
      cookie.Value = userInfo.Id.ToString();
      cookie.HttpOnly = true;
      cookie.Expires = DateTime.MaxValue;
      HttpContext.Current.Response.Cookies.Set(cookie);
    }

    /// <summary>
    /// 读取身份
    /// </summary>
    /// <returns></returns>
    public static UserInfo ReadIdentity()
    {
      UserInfo user = HttpContext.Current.Session["UserInfo"] as UserInfo;
      if (!(user == null))
      {
        return user;
      }
      HttpCookie cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
      if (cookie == null)
      {
        return default(UserInfo);
      }
      Guid userId = Guid.Parse(cookie.Value);
      UserManager userManager = new UserManager();
      user = userManager.GetUserInfoByUserId(userId);
      if (!(user == null))
      {
        HttpContext.Current.Session["UserInfo"] = user;
      }
      return user;
    }
  }
}