using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace YiYang.JianHu.Models
{
  /// <summary>
  /// 病历信息模型
  /// </summary>
  public class MedicalModel
  {
    /// <summary>
    /// 用户Id
    /// </summary>
    [Required]
    public Guid Id { get; set; }

    /// <summary>
    /// 主诉
    /// </summary>
    [DisplayName("主诉"), Required(ErrorMessage = "{0}不能为空"), StringLength(24, ErrorMessage = "{0}最多包含{2}个字符")]
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
    [DisplayName("诊断日期"), Required(ErrorMessage = "请选择{0}")]
    public DateTime DiagnoseDate { get; set; }
  }
}