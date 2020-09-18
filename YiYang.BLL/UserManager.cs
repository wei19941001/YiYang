using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using YiYang.DAL;
using YiYang.Model;

namespace YiYang.BLL
{
  /// <summary>
  /// 用户管理类
  /// </summary>
  public class UserManager
  {
    /// <summary>
    /// 添加用户
    /// </summary>
    /// <param name="cardNo"></param>
    /// <param name="name"></param>
    /// <param name="idCard"></param>
    /// <param name="mobile"></param>
    /// <param name="address"></param>
    /// <param name="unlock"></param>
    /// <returns></returns>
    public OperResult AddUser(string cardNo, string name, string idCard, string mobile, string address, string unlock)
    {
      // 卡片状态更新
      YiYangDbContext db = DbManager.CreateDbContext();
      CardInfo cardInfo = db.Set<CardInfo>().SingleOrDefault(m => m.No == cardNo);
      if (cardInfo == null)
      {
        return OperResult.Fail("卡号无效！");
      }
      if (cardInfo.ZhuangTai == ZhuangTaiEnumer.已弃用)
      {
        return OperResult.Fail("卡号已弃用！");
      }
      if (cardInfo.ZhuangTai == ZhuangTaiEnumer.已绑定)
      {
        return OperResult.Fail("卡号已绑定其他用户！");
      }
      cardInfo.ZhuangTai = ZhuangTaiEnumer.已绑定;
      db.Entry(cardInfo).State = EntityState.Modified;
      // 添加用户信息
      Guid userId = Guid.NewGuid();
      UserInfo userInfo = new UserInfo()
      {
        Id = userId,
        Name = name,
        IdCard = idCard,
        Mobile = mobile,
        Address = address,
        Unlock = unlock,
        AddTime = DateTime.Now
      };
      db.Entry(userInfo).State = EntityState.Added;
      // 卡片用户
      CardUser cardUser = new CardUser()
      {
        No = cardNo,
        Id = userId
      };
      db.Entry(cardUser).State = EntityState.Added;
      // 保存到数据库
      try
      {
        int res = db.SaveChanges();
        return res > 0 ? OperResult.Succeed() : OperResult.Fail("数据保存失败！");
      }
      catch(DbEntityValidationException dbEx)
      {
        return OperResult.Error(dbEx);
      }
      catch(Exception ex)
      {
        return OperResult.Error(ex);
      }
    }
    
    /// <summary>
    /// 通过用户Id获取用户信息
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public UserInfo GetUserInfoByUserId(Guid userId)
    {
      YiYangDbContext db = DbManager.CreateDbContext();
      return db.Set<UserInfo>().SingleOrDefault(m => m.Id == userId);
    }
  }
}