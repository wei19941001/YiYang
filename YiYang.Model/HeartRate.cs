using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YiYang.Model
{
  /// <summary>
  /// 心率信息
  /// </summary>
  [Table("HeartRate")]
  public class HeartRate
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
    /// 日期（年月日）
    /// </summary>
    [Required, StringLength(8, MinimumLength = 8), Index(IsUnique = false)]
    public string RiQi { get; set; }

    /// <summary>
    /// 时
    /// </summary>
    [Required]
    public int Shi { get; set; }

    /// <summary>
    /// 分
    /// </summary>
    [Required]
    public int Fen { get; set; }

    /// <summary>
    /// 心率值
    /// </summary>
    [Required]
    public int XinLv { get; set; }

    /// <summary>
    /// 添加时间
    /// </summary>
    [Required]
    public DateTime AddTime { get; set; }
  }
}