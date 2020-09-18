using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YiYang.Model
{
  /// <summary>
  /// 识别卡用户
  /// </summary>
  [Table("CardUser")]
  public class CardUser
  {
    /// <summary>
    /// 卡号
    /// </summary>
    [Key, StringLength(15, MinimumLength = 15)]
    public string No { get; set; }

    /// <summary>
    /// 卡号信息
    /// </summary>
    [ForeignKey("No")]
    public virtual CardInfo CardInfo { get; set; }

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
  }
}