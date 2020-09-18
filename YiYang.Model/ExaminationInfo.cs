using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YiYang.Model
{
  /// <summary>
  /// 体检信息
  /// </summary>
  [Table("ExaminationInfo")]
  public class ExaminationInfo
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
    /// 更新日期
    /// </summary>
    [Required]
    public DateTime Updated { get; set; }

    #region 一般状况

    /// <summary>
    /// 脉率
    /// </summary>
    public int? MaiLv { get; set; }

    /// <summary>
    /// 低血压
    /// </summary>
    public int? DiYa { get; set; }

    /// <summary>
    /// 高血压
    /// </summary>
    public int? GaoYa { get; set; }

    /// <summary>
    /// 身高
    /// </summary>
    public int? ShenGao { get; set; }

    /// <summary>
    /// 体重
    /// </summary>
    public int? TiZhong { get; set; }

    /// <summary>
    /// 听力
    /// </summary>
    public TingLiEnumer TingLi { get; set; }

    #endregion

    #region 症状

    /// <summary>
    /// 症状
    /// </summary>
    public string ZhengZhuang { get; set; }

    /// <summary>
    /// 认知障碍
    /// </summary>
    public bool RenZhi { get; set; }

    /// <summary>
    /// 抑郁
    /// </summary>
    public bool YiYu { get; set; }

    /// <summary>
    /// 下肢水肿
    /// </summary>
    public XiaZhiEnumer XiaZhi { get; set; }

    /// <summary>
    /// 肺罗音
    /// </summary>
    public LuoYinEnumer LuoYin { get; set; }

    #endregion

    #region 生活方式

    /// <summary>
    /// 锻炼
    /// </summary>
    public DuanLianEnumer DuanLian { get; set; }

    /// <summary>
    /// 生活自理
    /// </summary>
    public ZiLiEnumer ZiLi { get; set; }

    /// <summary>
    /// 吸烟
    /// </summary>
    public bool XiYan { get; set; }

    /// <summary>
    /// 饮酒
    /// </summary>
    public bool YinJiu { get; set; }

    #endregion
  }
}