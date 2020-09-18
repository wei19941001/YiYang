using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace YiYang.LaoRen.Models
{
  /// <summary>
  /// 身份识别卡绑定视图模型
  /// </summary>
  public class BindModel
  {
    [DisplayName("卡号"), Required(ErrorMessage = "{0}不能为空"), StringLength(15, MinimumLength = 15, ErrorMessage = "{0}无效")]
    public string No { get; set; }

    /// <summary>
    /// 姓名
    /// </summary>
    [DisplayName("真实姓名"), Required(ErrorMessage = "{0}不能为空"), StringLength(4, MinimumLength = 2, ErrorMessage = "{0}为{1}到{2}个字符")]
    public string Name { get; set; }

    /// <summary>
    /// 身份证号
    /// </summary>
    [DisplayName("身份证号"), Required(ErrorMessage = "{0}不能为空"), StringLength(18, MinimumLength = 18, ErrorMessage = "{0}为{2}个字符")]
    public string IdCard { get; set; }

    /// <summary>
    /// 手机号
    /// </summary>
    [DisplayName("手机号"), Required(ErrorMessage = "{0}不能为空"), StringLength(11, MinimumLength = 11, ErrorMessage = "{0}为{2}个字符")]
    public string Mobile { get; set; }

    /// <summary>
    /// 联系地址
    /// </summary>
    [DisplayName("手机号"), Required(ErrorMessage = "{0}不能为空"), StringLength(36, ErrorMessage = "{0}最多{2}个字符")]
    public string Address { get; set; }

    /// <summary>
    /// 解锁密码（图案解锁）
    /// </summary>
    [DisplayName("解锁密码"), Required(ErrorMessage = "请绘制{0}"), StringLength(10, MinimumLength = 5, ErrorMessage = "{0}为{1}至{2}个节点")]
    public string Unlock { get; set; }
  }
}