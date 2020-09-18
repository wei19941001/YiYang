using System.Web.Mvc;
using YiYang.BLL;
using YiYang.Model;

namespace YiYang.YiSheng.Controllers
{
  /// <summary>
  /// 体检控制器
  /// </summary>
  public class ExaminationController : Controller
  {
    // 查看体检信息
    // GET: /Examination
    public ActionResult Index()
    {
      UserInfo userInfo = IdentityManager.ReadIdentity();
      ExaminationManager examinationManager = new ExaminationManager();
      ExaminationInfo examinationInfo = examinationManager.GetExaminationInfoByUserId(userInfo.Id);
      // 返回视图
      return View(examinationInfo);
    }
  }
}