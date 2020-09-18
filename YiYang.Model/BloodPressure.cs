using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YiYang.Model
{
  /// <summary>
  /// 血压信息
  /// </summary>
  [Table("BloodPressure")]
  public class BloodPressure
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
    /// 血高压值
    /// </summary>
    [Required]
    public int GaoYa { get; set; }

    /// <summary>
    /// 血低压值
    /// </summary>
    [Required]
    public int DiYa { get; set; }

    /// <summary>
    /// 添加时间
    /// </summary>
    [Required]
    public DateTime AddTime { get; set; }
  }
}