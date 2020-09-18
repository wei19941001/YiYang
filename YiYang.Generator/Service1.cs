using System;
using System.ServiceProcess;
using System.Timers;
using YiYang.BLL;
using YiYang.Model;

namespace YiYang.Generator
{
  public partial class Service1 : ServiceBase
  {
    private static string cardNo = "201912080101001";
    private static Guid userId;

    static Service1()
    {
      CardManager cardManager = new CardManager();
      UserInfo userInfo = cardManager.GetUserInfoByCardNo(cardNo);
      userId = userInfo.Id;
    }

    public Service1()
    {
      InitializeComponent();

      Timer timer = new Timer();
      timer.Elapsed += new ElapsedEventHandler(TimedEvent);
      timer.Interval = 5000;
      timer.Enabled = true;
    }

    /// <summary>
    /// 定时执行事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TimedEvent(object sender, System.Timers.ElapsedEventArgs e)
    {
      // 生成血压值
      // 安全值：60~89，90~139
      int di = 75;
      int gao = 115;
      Random rand = new Random();
      int gaoTemp;
      int gaoSeed = rand.Next(0, 10000);
      if (gaoSeed < 100)
      {
        gaoTemp = rand.Next(-30, 30);
      }
      else if (gaoSeed < 2000)
      {
        gaoTemp = rand.Next(-20, 20);
      }
      else
      {
        gaoTemp = rand.Next(-10, 10);
      }
      gao += gaoTemp;
      int diTemp;
      int diSeed = rand.Next(0, 10000);
      if (diSeed < 100)
      {
        diTemp = rand.Next(-18, 18);
      }
      else if (diSeed < 2000)
      {
        diTemp = rand.Next(-12, 12);
      }
      else
      {
        diTemp = rand.Next(-6, 6);
      }
      di += diTemp;
      // 添加进数据库
      PressureManager pressureManager = new PressureManager();
      pressureManager.AddPressure(userId, gao, di);
      // 生成脉搏值
      // 安全值：60~100
      int bo = 80;
      int boTemp;
      int boSeed = rand.Next(0, 10000);
      if (boSeed < 100)
      {
        boTemp = rand.Next(-24, 24);
      }
      else if (boSeed < 2000)
      {
        boTemp = rand.Next(-16, 16);
      }
      else
      {
        boTemp = rand.Next(-8, 8);
      }
      bo += boTemp;
      // 添加进数据库
      HeartManager heartManager = new HeartManager();
      heartManager.AddHeart(userId, bo);
    }

    protected override void OnStart(string[] args)
    {
      
    }

    protected override void OnStop()
    {
      
    }
  }
}
