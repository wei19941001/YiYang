using System.Collections.Generic;
using System.Web.Mvc;
using YiYang.BLL;
using YiYang.Common;
using YiYang.JianHu.Models;
using YiYang.Model;

namespace YiYang.JianHu.Controllers
{
  /// <summary>
  /// 病历控制器
  /// </summary>
  public class MedicalController : Controller
  {
    // 查看病历记录
    // GET: /Medical
    public ActionResult Index()
    {
      // 查询
      UserInfo userInfo = IdentityManager.ReadIdentity();
      MedicalManager medicalManager = new MedicalManager();
      List<MedicalInfo> medicalList = medicalManager.ListMedical(userInfo.Id);
      // 返回视图
      return View(medicalList);
    }

    // 添加病历
    // GET: /Medical/Add
    public ActionResult Add()
    {
      UserInfo userInfo = IdentityManager.ReadIdentity();
      ViewData["UserInfo"] = userInfo;
      return View();
    }

    // 添加病历
    // POST: /Medical/Add
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Add(MedicalModel mvModel)
    {
      // 模型验证
      if (!ModelState.IsValid)
      {
        return OperResult.Fail(ModelState.GetErrorMessage()).CreateJsonResult(true);
      }
      // 添加病历
      MedicalManager medicalManager = new MedicalManager();
      OperResult addResult = medicalManager.AddMedical(
        mvModel.Id, 
        mvModel.ZhuSu, 
        mvModel.JianCha, 
        mvModel.ZhenDuan, 
        mvModel.ChuLi, 
        mvModel.DiagnoseDate);
      // 返回结果
      return addResult.CreateJsonResult(true);
    }
  }
}