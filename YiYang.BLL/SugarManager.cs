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
  /// 血糖管理类
  /// </summary>
  public class SugarManager
  {
    /// <summary>
    /// 采集血糖
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="xueTang"></param>
    /// <param name="gatherDate"></param>
    /// <returns></returns>
    public OperResult AddSugar(Guid userId, double xueTang, DateTime gatherDate)
    {
      // 实例化血糖信息
      BloodSugar bloodSugar = new BloodSugar()
      {
        No = Guid.NewGuid(),
        Id = userId,
        XueTang = xueTang,
        GatherDate = gatherDate
      };
      // 附加到上下文
      YiYangDbContext db = new YiYangDbContext();
      db.Entry(bloodSugar).State = EntityState.Added;
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
    /// 获取血糖信息列表
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public List<BloodSugar> ListSugar(Guid userId, int count = 10)
    {
      // 查询
      YiYangDbContext db = DbManager.CreateDbContext();
      List<BloodSugar> sugarList = db.Set<BloodSugar>().Where(m => m.Id == userId).OrderByDescending(m => m.GatherDate).Take(count).OrderBy(m => m.GatherDate).ToList();
      // 返回结果
      return sugarList;
    }
  }
}