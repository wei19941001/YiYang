using System.Data.Entity;
using System.Data.Entity.Migrations;
using YiYang.Model;

namespace YiYang.DAL
{
  /// <summary>
  /// 医养伴侣数据上下文
  /// </summary>
  public class YiYangDbContext : DbContext
  {
    /// <summary>
    /// 构造函数
    /// </summary>
    public YiYangDbContext() : base("DbConn") { }

    /// <summary>
    /// 静态构造函数
    /// </summary>
    static YiYangDbContext()
    {
      Database.SetInitializer(new MigrateDatabaseToLatestVersion<YiYangDbContext, YiYangDbMigrations>());
    }

    /// <summary>
    /// 识别卡信息表
    /// </summary>
    public DbSet<CardInfo> CardInfos { get; set; }

    /// <summary>
    /// 用户信息表
    /// </summary>
    public DbSet<UserInfo> UserInfos { get; set; }

     /// <summary>
     /// 识别卡用户表
     /// </summary>
    public DbSet<CardUser> CardUsers { get; set; }

    /// <summary>
    /// 体检信息表
    /// </summary>
    public DbSet<ExaminationInfo> ExaminationInfos { get; set; }

    /// <summary>
    /// 病历信息表
    /// </summary>
    public DbSet<MedicalInfo> MedicalInfos { get; set; }

    /// <summary>
    /// 心率信息表
    /// </summary>
    public DbSet<HeartRate> HeartRates { get; set; }

    /// <summary>
    /// 血压信息表
    /// </summary>
    public DbSet<BloodPressure> BloodPressures { get; set; }

    /// <summary>
    /// 血糖信息表
    /// </summary>
    public DbSet<BloodSugar> BloodSugars { get; set; }
  }

  /// <summary>
  /// 数据库自动迁移
  /// </summary>
  internal class YiYangDbMigrations : DbMigrationsConfiguration<YiYangDbContext>
  {
    /// <summary>
    /// 构造函数
    /// </summary>
    public YiYangDbMigrations()
    {
      AutomaticMigrationsEnabled = true;          // 启用自动迁移
      AutomaticMigrationDataLossAllowed = true;   // 自动迁移中允许丢失数据
    }
  }
}