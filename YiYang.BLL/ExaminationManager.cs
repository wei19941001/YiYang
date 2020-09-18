using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using YiYang.DAL;
using YiYang.Model;

namespace YiYang.BLL
{
  /// <summary>
  /// 病例管理类
  /// </summary>
  public class ExaminationManager
  {
    /// <summary>
    /// 添加症状
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="maiLv"></param>
    /// <param name="diYa"></param>
    /// <param name="gaoYa"></param>
    /// <param name="shenGao"></param>
    /// <param name="tiZhong"></param>
    /// <param name="tingLi"></param>
    /// <param name="zhengZhuang"></param>
    /// <param name="renZhi"></param>
    /// <param name="yiYu"></param>
    /// <param name="xiaZhi"></param>
    /// <param name="luoYin"></param>
    /// <param name="duanLian"></param>
    /// <param name="ziLi"></param>
    /// <param name="xiYan"></param>
    /// <param name="yinJiu"></param>
    /// <returns></returns>
    public OperResult AddExamination(Guid userId, int? maiLv, int? diYa, int? gaoYa, int? shenGao, int? tiZhong, TingLiEnumer tingLi, 
      string zhengZhuang, bool renZhi, bool yiYu, XiaZhiEnumer xiaZhi, LuoYinEnumer luoYin, DuanLianEnumer duanLian, ZiLiEnumer ziLi, 
      bool xiYan, bool yinJiu)
    {
      // 实例化体检信息
      ExaminationInfo examinationInfo = new ExaminationInfo()
      {
        No = Guid.NewGuid(),
        Id=  userId,
        Updated = DateTime.Now,
        MaiLv = maiLv,
        DiYa = diYa,
        GaoYa = gaoYa,
        ShenGao = shenGao,
        TiZhong = tiZhong,
        TingLi = tingLi,
        ZhengZhuang = zhengZhuang,
        RenZhi = renZhi,
        YiYu = yiYu,
        XiaZhi = xiaZhi,
        LuoYin = luoYin,
        DuanLian = duanLian,
        ZiLi = ziLi,
        XiYan = xiYan,
        YinJiu = yinJiu
      };
      // 附加到上下文
      YiYangDbContext db = new YiYangDbContext();
      db.Entry(examinationInfo).State = EntityState.Added;
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
    /// 通过用户Id查询病例
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public ExaminationInfo GetExaminationInfoByUserId(Guid userId)
    {
      // 查询
      YiYangDbContext db = new YiYangDbContext();
      ExaminationInfo examinationInfo = db.Set<ExaminationInfo>().OrderByDescending(m => m.Updated).FirstOrDefault(m => m.Id == userId);
      return examinationInfo;
    }
  }
}