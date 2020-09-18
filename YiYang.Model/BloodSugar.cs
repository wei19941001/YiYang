using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YiYang.Model
{
  /// <summary>
  /// 血糖信息
  /// </summary>
  [Table("BloodSugar")]
  public class BloodSugar
  {
    /// <summary>
    /// 编号
    /// </summary>
    [Key]
    public Guid No { get; set; }

    /// <summary>
    /// 用户Id
    /// </summary>
    [Required, Index(IsUnique = false)]
    public Guid Id { get; set; }

    /// <summary>
    /// 用户信息
    /// </summary>
    [ForeignKey("Id")]
    public virtual UserInfo UserInfo { get; set; }

    /// <summary>
    /// 血糖值
    /// </summary>
    [Required]
    public double XueTang { get; set; }

    /// <summary>
    /// 采集日期（年月日）
    /// </summary>
    [Required, Index(IsUnique = false)]
    public DateTime GatherDate { get; set; }
  }
}