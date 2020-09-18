using YiYang.DAL;

namespace YiYang.BLL
{
  /// <summary>
  /// 数据库管理类
  /// </summary>
  public class DbManager
  {
    /// <summary>
    /// 创建数据上下文
    /// </summary>
    /// <returns></returns>
    public static YiYangDbContext CreateDbContext()
    {
      return new YiYangDbContext();
    }
  }
}