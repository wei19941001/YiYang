using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace YiYang.JianHu.Models
{
  /// <summary>
  /// 血糖视图模型
  /// </summary>
  public class SugarModel
  {
    /// <summary>
    /// 用户Id
    /// </summary>
    [Required]
    public Guid Id { get; set; }

    /// <summary>
    /// 血糖值
    /// </summary>
    [DisplayName("血糖值"), Required(ErrorMessage = "请填写{0}")]
    public double XueTang { get; set; }

    /// <summary>
    /// 日期（年月日）
    /// </summary>
    [DisplayName("采集日期"), Required(ErrorMessage = "请选择{0}")]
    public DateTime GatherDate { get; set; }
  }
}