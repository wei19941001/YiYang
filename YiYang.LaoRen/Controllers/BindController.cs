using System.Web.Mvc;
using YiYang.BLL;
using YiYang.Common;
using YiYang.LaoRen.Models;
using YiYang.Model;

namespace YiYang.LaoRen.Controllers
{
  /// <summary>
  /// 绑定控制器
  /// </summary>
  public class BindController : Controller
  {
    // 身份识别卡绑定
    // GET: /Bind
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
      if (bindRes)
      {
        return Content("卡片已绑定，请登录");
      }
      // 返回视图
      ViewData["CardNo"] = cno;
      return View();
    }

    // 身份识别卡绑定
    // POST: /Bind
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Index(BindModel bvModel)
    {
      // 模型验证
      if (!ModelState.IsValid)
      {
        return OperResult.Fail(ModelState.GetErrorMessage()).CreateJsonResult(true);
      }
      // 添加用户绑定
      UserManager userManager = new UserManager();
      OperResult addResult = userManager.AddUser(
        bvModel.No,
        bvModel.Name,
        bvModel.IdCard,
        bvModel.Mobile,
        bvModel.Address,
        bvModel.Unlock);
      // 返回结果
      return addResult.CreateJsonResult(true);
    }
  }
}