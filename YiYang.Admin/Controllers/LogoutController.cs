using System.Web.Mvc;
using System.Web.Security;

namespace YiYang.Admin.Controllers
{
  /// <summary>
  /// 注销控制器
  /// </summary>
  public class LogoutController : Controller
  {
    // 登出
    // GET: /Logout
    public ActionResult Index()
    {
      // 注销
      FormsAuthentication.SignOut();
      // 跳转到登录
      return RedirectToAction("Index", "Login");
    }
  }
}