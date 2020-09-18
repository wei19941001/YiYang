using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YiYang.Model
{
  /// <summary>
  /// 识别卡信息表
  /// </summary>
  [Table("CardInfo")]
  public class CardInfo
  {
    /// <summary>
    /// 卡号
    /// </summary>
    [Key, StringLength(15, MinimumLength = 15)]
    public string No { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    [Required]
    public ZhuangTaiEnumer ZhuangTai { get; set; }

    /// <summary>
    /// 添加时间
    /// </summary>
    [Required]
    public DateTime AddTime { get; set; }
  }
}