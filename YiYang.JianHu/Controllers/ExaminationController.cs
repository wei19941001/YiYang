using System.Web.Mvc;
using YiYang.BLL;
using YiYang.Common;
using YiYang.JianHu.Models;
using YiYang.Model;

namespace YiYang.JianHu.Controllers
{
  /// <summary>
  /// 体检控制器
  /// </summary>
  public class ExaminationController : Controller
  {
    // 更新体检信息
    // GET: /Examination
    public ActionResult Index()
    {
      // 查询体检信息
      UserInfo userInfo = IdentityManager.ReadIdentity();
      ExaminationManager examinationManager = new ExaminationManager();
      ExaminationInfo examinationInfo = examinationManager.GetExaminationInfoByUserId(userInfo.Id);
      // 返回视图
      ViewData["UserInfo"] = userInfo;
      ViewData["ExaminationInfo"] = examinationInfo;
      return View();
    }

    // 更新体检信息
    // POST: /Examination
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Index(ExaminationModel evModel)
    {
      // 模型验证
      if (!ModelState.IsValid)
      {
        return OperResult.Fail(ModelState.GetErrorMessage()).CreateJsonResult(true);
      }
      // 保存体检信息
      string zhengZhuang = string.Join(",", evModel.ZhengZhuang);
      UserInfo userInfo = IdentityManager.ReadIdentity();
      ExaminationManager examinationManager = new ExaminationManager();
      OperResult addResult = examinationManager.AddExamination(userInfo.Id, evModel.MaiLv, evModel.DiYa, evModel.GaoYa, evModel.ShenGao, evModel.TiZhong,
        evModel.TingLi.HasValue ? evModel.TingLi.Value : TingLiEnumer.未知,
        zhengZhuang,
        evModel.RenZhi.HasValue ? evModel.RenZhi.Value : false,
        evModel.YiYu.HasValue ? evModel.YiYu.Value : false,
        evModel.XiaZhi.HasValue ? evModel.XiaZhi.Value : XiaZhiEnumer.未知,
        evModel.LuoYin.HasValue ? evModel.LuoYin.Value : LuoYinEnumer.未知,
        evModel.DuanLian.HasValue ? evModel.DuanLian.Value : DuanLianEnumer.未知,
        evModel.ZiLi.HasValue ? evModel.ZiLi.Value : ZiLiEnumer.未知,
        evModel.XiYan.HasValue ? evModel.XiYan.Value : false,
        evModel.YinJiu.HasValue ? evModel.YinJiu.Value : false);
      // 返回结果
      return addResult.CreateJsonResult(true);
    }
  }
}