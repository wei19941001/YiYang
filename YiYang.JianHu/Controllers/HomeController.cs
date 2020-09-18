using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YiYang.BLL;
using YiYang.Model;

namespace YiYang.JianHu.Controllers
{
  /// <summary>
  /// 默认控制器
  /// </summary>
  public class HomeController : Controller
  {
    // 主页
    // GET: /
    public ActionResult Index()
    {
      // 获取身份
      UserInfo userInfo = IdentityManager.ReadIdentity();
      // 返回视图
      ViewData["UserInfo"] = userInfo;
      return View();
    }
  }
}