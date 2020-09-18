using System.Web.Mvc;

namespace YiYang.Admin.Controllers
{
  /// <summary>
  /// 默认控制器
  /// </summary>
  [Authorize]
  public class HomeController : Controller
  {
    // 主页
    // GET: /
    public ActionResult Index()
    {
      return View();
    }
  }
}