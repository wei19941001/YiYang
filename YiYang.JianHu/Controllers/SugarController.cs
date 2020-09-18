using System.Web.Mvc;
using YiYang.BLL;
using YiYang.Common;
using YiYang.JianHu.Models;
using YiYang.Model;

namespace YiYang.JianHu.Controllers
{
  /// <summary>
  /// 血糖控制器
  /// </summary>
  public class SugarController : Controller
  {
    // 采集血糖信息
    // GET: /Sugar
    public ActionResult Index()
    {
      // 查询体检信息
      UserInfo userInfo = IdentityManager.ReadIdentity();
      // 返回视图
      ViewData["UserInfo"] = userInfo;
      return View();
    }

    // 采集血糖信息
    // POST: /Sugar
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Index(SugarModel svModel)
    {
      // 模型验证
      if (!ModelState.IsValid)
      {
        return OperResult.Fail(ModelState.GetErrorMessage()).CreateJsonResult(true);
      }
      // 采集血糖
      SugarManager sugarManager = new SugarManager();
      OperResult addResult = sugarManager.AddSugar(
        svModel.Id, 
        svModel.XueTang, 
        svModel.GatherDate);
      // 返回结果
      return addResult.CreateJsonResult(true);
    }
  }
}