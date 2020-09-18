using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YiYang.BLL;
using YiYang.Common;
using YiYang.Model;
using System.Web.Security;

namespace YiYang.JianHu.Controllers
{
  /// <summary>
  /// 手势控制器
  /// </summary>
  public class GestureController : Controller
    {
    // 手势解锁
    // GET: /Gesture
    public ActionResult Index(string cno)
    {
      // 传参
      if (string.IsNullOrWhiteSpace(cno))
      {
        return Content("参数无效！");
      }
      // 有效性验证
      CardManager cardManager = new CardManager();
      OperResult checkRes = cardManager.CheckCard(cno);
      if (checkRes.StatusCode != StatusCode.成功)
      {
        return Content(checkRes.Message);
      }
      // 检查绑定
      bool bindRes = cardManager.CheckBind(cno);
      if (!bindRes)
      {
        return Content("卡片未绑定用户！");
      }
      // 返回视图
      ViewData["CardNo"] = cno;
      return View();
    }

    // 手势解锁
    // POST: /Gesture
    [HttpPost]
    public ActionResult Index(string cno, string ges)
    {
      // 查询用户信息
      CardManager cardManager = new CardManager();
      UserInfo userInfo = cardManager.GetUserInfoByCardNo(cno);
      if (userInfo == null)
      {
        return OperResult.Fail("用户未注册！").CreateJsonResult(true);
      }
      // 密码验证
      if (!userInfo.Unlock.Equals(ges))
      {
        return OperResult.Fail("解锁密码不正确！").CreateJsonResult(true);
      }
      // 登录
      IdentityManager.SaveIdentity(userInfo);
      // 返回结果
      return OperResult.Succeed().CreateJsonResult(true);
    }
  }
}