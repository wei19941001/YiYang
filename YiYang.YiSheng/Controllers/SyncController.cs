using System.Web.Mvc;
using YiYang.BLL;
using YiYang.Model;

namespace YiYang.YiSheng.Controllers
{
  /// <summary>
  /// 同步控制器
  /// </summary>
  public class SyncController : Controller
  {
    // 同步用户
    // GET: /Sync
    public ActionResult Index(string cno)
    {
      // 查询用户信息
      CardManager cardManager = new CardManager();
      UserInfo userInfo = cardManager.GetUserInfoByCardNo(cno);
      if (userInfo == null)
      {
        return Content("用户未注册！");
      }
      // 登录
      IdentityManager.SaveIdentity(userInfo);
      // 返回结果
      return RedirectToAction("Index","Home");
    }
  }
}