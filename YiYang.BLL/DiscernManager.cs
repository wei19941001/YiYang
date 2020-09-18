using System.Drawing;
using ZXing;
using ZXing.OneD;
using ZXing.QrCode;

namespace YiYang.BLL
{
  /// <summary>
  /// 识别管理类
  /// </summary>
  public class DiscernManager
  {
    /// <summary>
    /// 创建条形码图片
    /// </summary>
    /// <param name="text"></param>
    /// <param name="width"></param>
    /// <param name="height"></param> 
    /// <returns></returns>
    public Bitmap CreateBarCode(string text, int width, int height)
    {
      BarcodeWriter writer = new BarcodeWriter();
      writer.Format = BarcodeFormat.CODE_128;
      writer.Options = new Code128EncodingOptions()
      {
        ForceCodesetB = false,
        PureBarcode = false,
        GS1Format = false,
        Width = width,
        Height = height,
        Margin = 2
      };
      Bitmap bitmap = writer.Write(text);
      return bitmap;
    }

    /// <summary>
    /// 创建二维码图片
    /// </summary>
    /// <param name="text"></param>
    /// <param name="width"></param>
    /// <returns></returns>
    public Bitmap CreateQrCode(string text, int width)
    {
      BarcodeWriter writer = new BarcodeWriter();
      writer.Format = BarcodeFormat.QR_CODE;
      writer.Options = new QrCodeEncodingOptions()
      {
        DisableECI = true,
        CharacterSet = "UTF-8",
        Width = width,
        Height = width,
        Margin = 1
      };
      Bitmap bitmap = writer.Write(text);
      return bitmap;
    }
  }
}