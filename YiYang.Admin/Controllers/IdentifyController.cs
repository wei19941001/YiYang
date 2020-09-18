using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YiYang.BLL;
using YiYang.Common;
using YiYang.Model;

namespace YiYang.Admin.Controllers
{
  /// <summary>
  /// 身份控制器
  /// </summary>
  [Authorize]
  public class IdentifyController : Controller
  {
    // GET: /Identify
    public ActionResult Index()
    {
      return View();
    }

    // 添加卡片
    // POST: /Identify/AddCard
    [HttpPost]
    public ActionResult AddCard(string no)
    {
      // 传参
      if (string.IsNullOrWhiteSpace(no) || no.Length != 15)
      {
        return OperResult.Fail("参数无效！").CreateJsonResult(true);
      }
      // 添加
      CardManager cardManager = new CardManager();
      OperResult operResult = cardManager.AddCard(no);
      // 返回结果
      return operResult.CreateJsonResult(true);
    }

    // 搜索卡片
    // GET: /Identify/SearchCard
    public ActionResult SearchCard(string t)
    {
      List<CardInfo> cardList = new List<CardInfo>();
      // 传参
      if(string.IsNullOrWhiteSpace(t))
      {
        return OperResult.Succeed(cardList).CreateJsonResult();
      }
      // 查询
      CardManager cardManager = new CardManager();
      cardList = cardManager.SearchCard(t).ToList();
      // 返回结果
      return OperResult.Succeed(cardList).CreateJsonResult();
    }

    // 生成一维码
    // GET: /Identify/BarCode
    public ActionResult BarCode(string text)
    {
      text = HttpUtility.UrlDecode(text);
      byte[] data = new byte[0];
      DiscernManager discernManager = new DiscernManager();
      using (Bitmap bitmap = discernManager.CreateBarCode(text, 300, 80))
      {
        string path = Request.MapPath("~/App_Data/yiyang-zheng.jpg");
        using (Bitmap card = (Bitmap)Image.FromFile(path))
        {
          using (Graphics g = Graphics.FromImage(card))
          {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.InterpolationMode = InterpolationMode.Default;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            g.DrawImage(bitmap, 30, 200);
          }
          using (MemoryStream stream = new MemoryStream())
          {
            card.Save(stream, ImageFormat.Jpeg);
            data = new byte[stream.Length];
            stream.Seek(0, SeekOrigin.Begin);
            stream.Read(data, 0, (int)stream.Length);
          }
        }
      }
      return File(data, "image/jpeg");
    }


    // 
    //public ActionResult QrCode(string text)
    //{
    //  text = HttpUtility.UrlDecode(text);
    //  byte[] data = new byte[0];
    //  DiscernManager discernManager = new DiscernManager();
    //  using (Bitmap bitmap = discernManager.CreateQrCode(text, 200))
    //  {
    //    using (MemoryStream stream = new MemoryStream())
    //    {
    //      bitmap.Save(stream, ImageFormat.Jpeg);
    //      data = new byte[stream.Length];
    //      stream.Seek(0, SeekOrigin.Begin);
    //      stream.Read(data, 0, (int)stream.Length);
    //    }
    //  }
    //  return File(data, "image/jpeg");
    //}
  }
}