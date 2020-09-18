using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using YiYang.DAL;
using YiYang.Model;

namespace YiYang.BLL
{
  /// <summary>
  /// 病历控制器
  /// </summary>
  public class MedicalManager
  {
    /// <summary>
    /// 添加病历
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="zhuSu"></param>
    /// <param name="jianCha"></param>
    /// <param name="zhenDuan"></param>
    /// <param name="chuLi"></param>
    /// <returns></returns>
    public OperResult AddMedical(Guid userId, string zhuSu, string jianCha, string zhenDuan, string chuLi, DateTime diagnoseDate)
    {
      // 实例化体检信息
      MedicalInfo medicalInfo = new MedicalInfo()
      {
        No = Guid.NewGuid(),
        Id = userId,
        ZhuSu = zhuSu,
        JianCha = jianCha,
        ZhenDuan = zhenDuan,
        ChuLi = chuLi,
        DiagnoseDate = diagnoseDate
      };
      // 附加到上下文
      YiYangDbContext db = new YiYangDbContext();
      db.Entry(medicalInfo).State = EntityState.Added;
      // 保存到数据库
      try
      {
        int res = db.SaveChanges();
        return res > 0 ? OperResult.Succeed() : OperResult.Fail("数据保存失败！");
      }
      catch (DbEntityValidationException dbEx)
      {
        return OperResult.Error(dbEx);
      }
      catch (Exception ex)
      {
        return OperResult.Error(ex);
      }
    }

    /// <summary>
    /// 查询病历列表
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public List<MedicalInfo> ListMedical(Guid userId)
    {
      // 查询
      YiYangDbContext db = new YiYangDbContext();
      List<MedicalInfo> medicalList = db.Set<MedicalInfo>().Where(m => m.Id == userId).OrderByDescending(m => m.DiagnoseDate).ToList();
      // 返回结果
      return medicalList;
    }
  }
}