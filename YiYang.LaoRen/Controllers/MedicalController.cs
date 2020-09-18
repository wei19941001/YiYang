using System.Collections.Generic;
using System.Web.Mvc;
using YiYang.BLL;
using YiYang.Model;

namespace YiYang.LaoRen.Controllers
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
  }
}