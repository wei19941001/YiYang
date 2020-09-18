using System.Configuration;
using System.Web.Mvc;
using System.Web.Security;
using YiYang.Admin.Models;

namespace YiYang.Admin.Controllers
{
  /// <summary>
  /// 登录控制器
  /// </summary>
  public class LoginController : Controller
  {
    // 登录
    // GET: /Login
    public ActionResult Index()
    {
      return View();
    }

    // 登录
    // POST: /Login
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Index(LoginModel lnModel)
    {
      // 模型验证
      if (!ModelState.IsValid)
      {
        return View(lnModel);
      }
      // 判断用户名和密码
      string adminUserName = ConfigurationManager.AppSettings["Admin:UserName"];
      string adminPassword = ConfigurationManager.AppSettings["Admin:Password"];
      if (!lnModel.UserName.Equals(adminUserName) || !lnModel.Password.Equals(adminPassword))
      {
        ModelState.AddModelError("", "用户名或密码错误！");
        return View(lnModel);
      }
      // 登录成功
      FormsAuthentication.SetAuthCookie(adminUserName, true);
      // 跳转到主页
      return RedirectToAction("Index", "Home");
    }
  }
}