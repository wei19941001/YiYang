using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YiYang.Model;

namespace YiYang.YiSheng.Controllers
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
      UserInfo userInfo = Session["UserInfo"] as UserInfo;

      // 返回视图
      ViewData["UserInfo"] = userInfo;
      return View();
    }
  }
}