using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using YiYang.DAL;
using YiYang.Model;

namespace YiYang.BLL
{
  /// <summary>
  /// 血压管理类
  /// </summary>
  public class PressureManager
  {
    /// <summary>
    /// 添加血压信息
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="gaoYa"></param>
    /// <param name="diYa"></param>
    /// <returns></returns>
    public OperResult AddPressure(Guid userId, int gaoYa, int diYa)
    {
      DateTime timeNow = DateTime.Now;
      // 实例化记录
      BloodPressure bloodPressure = new BloodPressure()
      {
        No = Guid.NewGuid(),
        Id = userId,
        RiQi = timeNow.ToString("yyyyMMdd"),
        Shi = timeNow.Hour,
        Fen = timeNow.Minute,
        GaoYa = gaoYa,
        DiYa = diYa,
        AddTime = timeNow
      };
      // 附加到上下文
      YiYangDbContext db = DbManager.CreateDbContext();
      db.Entry(bloodPressure).State = EntityState.Added;
      // 保存到数据库
      try
      {
        int result = db.SaveChanges();
        return result > 0 ? OperResult.Succeed() : OperResult.Fail("数据添加失败！");
      }
      catch (Exception ex)
      {
        return OperResult.Error(ex);
      }
    }

    /// <summary>
    /// 获取血压信息列表
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public List<BloodPressure> ListPressure(Guid userId, int count = 40)
    {
      // 查询
      YiYangDbContext db = DbManager.CreateDbContext();
      List<BloodPressure> pressureList = db.Set<BloodPressure>().Where(m => m.Id == userId).OrderByDescending(m => m.AddTime).Take(count).OrderBy(m => m.AddTime).ToList();
      // 返回结果
      return pressureList;
    }
  }
}