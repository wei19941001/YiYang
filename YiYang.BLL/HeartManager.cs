using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using YiYang.DAL;
using YiYang.Model;

namespace YiYang.BLL
{
  /// <summary>
  /// 脉搏管理类
  /// </summary>
  public class HeartManager
  {
    /// <summary>
    /// 添加脉搏信息
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="xinLv"></param>
    /// <returns></returns>
    public OperResult AddHeart(Guid userId, int xinLv)
    {
      DateTime timeNow = DateTime.Now;
      // 实例化记录
      HeartRate heartRate = new HeartRate()
      {
        No = Guid.NewGuid(),
        Id = userId,
        RiQi = timeNow.ToString("yyyyMMdd"),
        Shi = timeNow.Hour,
        Fen = timeNow.Minute,
        XinLv = xinLv,
        AddTime = timeNow
      };
      // 附加到上下文
      YiYangDbContext db = DbManager.CreateDbContext();
      db.Entry(heartRate).State = EntityState.Added;
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
    /// 获取脉搏信息列表
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public List<HeartRate> ListHeart(Guid userId, int count = 40)
    {
      // 查询
      YiYangDbContext db = DbManager.CreateDbContext();
      List<HeartRate> heartList = db.Set<HeartRate>().Where(m => m.Id == userId).OrderByDescending(m => m.AddTime).Take(count).OrderBy(m => m.AddTime).ToList();
      // 返回结果
      return heartList;
    }
  }
}