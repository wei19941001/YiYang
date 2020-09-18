using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using YiYang.DAL;
using YiYang.Model;

namespace YiYang.BLL
{
  /// <summary>
  /// 识别卡管理类
  /// </summary>
  public class CardManager
  {
    /// <summary>
    /// 添加卡号
    /// </summary>
    /// <param name="cardNo"></param>
    /// <returns></returns>
    public OperResult AddCard(string cardNo)
    {
      // 是否已添加
      YiYangDbContext db = DbManager.CreateDbContext();
      if (db.Set<CardInfo>().Any(m => m.No == cardNo))
      {
        return OperResult.Fail("卡号已存在，不能重复添加！");
      }
      // 实例化
      CardInfo card = new CardInfo()
      {
        No = cardNo,
        ZhuangTai = ZhuangTaiEnumer.待绑定,
        AddTime = DateTime.Now
      };
      // 附加到上下文
      db.Entry(card).State = EntityState.Added;
      // 保存到数据库
      try
      {
        int res = db.SaveChanges();
        return res > 0 ? OperResult.Succeed() : OperResult.Fail("添加失败！");
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
    /// 检索卡号
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public IQueryable<CardInfo> SearchCard(string text)
    {
      // 检索
      YiYangDbContext db = DbManager.CreateDbContext();
      return db.Set<CardInfo>().Where(m => m.No.Contains(text)).OrderBy(m => m.No).Take(15);
    }

    /// <summary>
    /// 检查卡片
    /// </summary>
    /// <param name="cardNo"></param>
    /// <returns></returns>
    public OperResult CheckCard(string cardNo)
    {
      // 是否有效卡号
      YiYangDbContext db = new YiYangDbContext();
      CardInfo cardInfo = db.Set<CardInfo>().SingleOrDefault(m => m.No == cardNo);
      if (cardInfo == null)
      {
        return OperResult.Fail("卡号无效！");
      }
      // 卡片状态
      if (cardInfo.ZhuangTai == ZhuangTaiEnumer.已弃用)
      {
        return OperResult.Fail("卡片已弃用！");
      }
      // 返回结果
      return OperResult.Succeed();
    }

    /// <summary>
    /// 检查绑定
    /// </summary>
    /// <param name="cardNo"></param>
    /// <returns></returns>
    public bool CheckBind(string cardNo)
    {
      // 查询
      YiYangDbContext db = new YiYangDbContext();
      return db.Set<CardUser>().Any(m => m.No == cardNo);
    }

    /// <summary>
    /// 通过卡号获取用户信息
    /// </summary>
    /// <param name="cardNo"></param>
    /// <returns></returns>
    public UserInfo GetUserInfoByCardNo(string cardNo)
    {
      // 查询
      YiYangDbContext db = new YiYangDbContext();
      CardUser cardUser = db.Set<CardUser>().FirstOrDefault(m => m.No == cardNo);
      return cardUser.UserInfo;
    }
  }
}