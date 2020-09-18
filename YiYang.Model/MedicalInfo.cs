using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YiYang.Model
{
  /// <summary>
  /// 病历信息
  /// </summary>
  [Table("MedicalInfo")]
  public class MedicalInfo
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
    /// 主诉
    /// </summary>
    [Required, StringLength(24)]
    public string ZhuSu { get; set; }

    /// <summary>
    /// 检查
    /// </summary>
    [StringLength(36)]
    public string JianCha { get; set; }

    /// <summary>
    /// 诊断
    /// </summary>
    [StringLength(36)]
    public string ZhenDuan { get; set; }

    /// <summary>
    /// 处理
    /// </summary>
    [StringLength(52)]
    public string ChuLi { get; set; }

    /// <summary>
    /// 诊断日期
    /// </summary>
    [Required]
    public DateTime DiagnoseDate { get; set; }
  }
}