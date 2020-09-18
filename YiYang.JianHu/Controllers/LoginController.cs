using System.Web.Mvc;
using YiYang.BLL;
using YiYang.Common;
using YiYang.Model;

namespace YiYang.JianHu.Controllers
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

    // 验证识别卡
    // POST: /Login/Check
    [HttpPost]
    public ActionResult Check(string cno)
    {
      // 传参验证
      if (string.IsNullOrWhiteSpace(cno))
      {
        return OperResult.Fail("参数无效").CreateJsonResult(true);
      }
      // 验证
      CardManager cardManager = new CardManager();
      OperResult checkRes = cardManager.CheckCard(cno);
      // 返回结果
      return checkRes.CreateJsonResult(true);
    }

    // 检查识别卡绑定
    // POST: /Login/Bind
    [HttpPost]
    public ActionResult Bind(string cno)
    {
      // 传参验证
      if (string.IsNullOrWhiteSpace(cno))
      {
        return OperResult.Fail("参数无效").CreateJsonResult(true);
      }
      // 检查
      CardManager cardManager = new CardManager();
      bool bind = cardManager.CheckBind(cno);
      // 返回结果
      return OperResult.Succeed(bind).CreateJsonResult(true);
    }
  }
}