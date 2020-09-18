using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace YiYang.Admin.Models
{
  /// <summary>
  /// 登录视图模型
  /// </summary>
  public class LoginModel
  {
    /// <summary>
    /// 用户名
    /// </summary>
    [DisplayName("用户名"), Display(Name = "用户名"), Required(ErrorMessage = "请填写{0}"), StringLength(12, MinimumLength = 5, ErrorMessage = "{0}长度为{1}至{2}个字符")]
    public string UserName { get; set; }

    /// <summary>
    /// 密码
    /// </summary>
    [DisplayName("密码"), Display(Name = "密码"), Required(ErrorMessage = "请填写{0}"), StringLength(24, MinimumLength = 8, ErrorMessage = "{0}长度为{1}至{2}个字符")]
    public string Password { get; set; }
  }
}