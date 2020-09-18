using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YiYang.Model
{
  /// <summary>
  /// 用户信息
  /// </summary>

  [Table("UserInfo")]
  public class UserInfo
  {
    /// <summary>
    /// 用户Id
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// 姓名
    /// </summary>
    [Required, StringLength(4, MinimumLength = 2)]
    public string Name { get; set; }

    /// <summary>
    /// 身份证号
    /// </summary>
    [Required, StringLength(18, MinimumLength = 18)]
    public string IdCard { get; set; }

    /// <summary>
    /// 手机号
    /// </summary>
    [Required, StringLength(11)]
    public string Mobile { get; set; }

    /// <summary>
    /// 监护人信息（姓名/手机号字典）
    /// </summary>
    public string Guardian { get; set; }

    /// <summary>
    /// 联系地址
    /// </summary>
    [Required, StringLength(36)]
    public string Address { get; set; }

    /// <summary>
    /// 解锁密码（图案解锁）
    /// </summary>
    [Required, StringLength(10, MinimumLength = 5)]
    public string Unlock { get; set; }

    /// <summary>
    /// 添加时间
    /// </summary>
    [Required]
    public DateTime AddTime { get; set; }
  }
}