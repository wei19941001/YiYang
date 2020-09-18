using System.Collections.Generic;
using System.Web.Mvc;
using YiYang.BLL;
using YiYang.Common;
using YiYang.Model;

namespace YiYang.LaoRen.Controllers
{
  /// <summary>
  /// 数据采集控制器
  /// </summary>
  public class GatherController : Controller
  {
    // 心率图
    // GET: /Gather/Heart
    public ActionResult Heart()
    {
      return View();
    }

    // 心率图数据
    // GET: /Gather/HeartData
    public ActionResult HeartData()
    {
      // 获取数据列表
      UserInfo userInfo = IdentityManager.ReadIdentity();
      HeartManager heartManager = new HeartManager();
      List<HeartRate> heartList = heartManager.ListHeart(userInfo.Id);
      // 整理数据
      string label = string.Empty;
      List<string> labelList = new List<string>(heartList.Count);
      List<int> dataList = new List<int>(heartList.Count);
      List<string> colorList = new List<string>(heartList.Count);
      foreach (HeartRate heart in heartList)
      {
        string time = heart.Shi.ToString() + ":" + heart.Fen.ToString();
        if (label.Equals(time))
        {
          labelList.Add("");
        }
        else
        {
          label = time;
          labelList.Add(label);
        }
        dataList.Add(heart.XinLv);
        if (heart.XinLv < 60 || heart.XinLv > 100)
        {
          colorList.Add(ChartColor.HongSe);
        }
        else
        {
          colorList.Add(ChartColor.HuiSe);
        }
      }
      // 生成选项列表
      HeartChartItem item = new HeartChartItem()
      {
        data = dataList.ToArray(),
        label = "心率图",
        backgroundColor = colorList.ToArray()
      };
      HeartChartData data = new HeartChartData()
      {
        labels = labelList.ToArray(),
        datasets = new HeartChartItem[] { item }
      };
      // 返回数据
      return OperResult.Succeed(data).CreateJsonResult(false);
    }

    // 血压图
    // GET: /Gather/Pressure
    public ActionResult Pressure()
    {
      return View();
    }

    // 血压图数据
    // GET: /Gather/PressureData
    public ActionResult PressureData()
    {
      // 获取数据列表
      UserInfo userInfo = IdentityManager.ReadIdentity();
      PressureManager pressureManager = new PressureManager();
      List<BloodPressure> pressureList = pressureManager.ListPressure(userInfo.Id);
      // 整理数据
      string label = string.Empty;
      List<string> labelList = new List<string>(pressureList.Count);
      List<int> dataGaoList = new List<int>(pressureList.Count);
      List<string> colorGaoList = new List<string>(pressureList.Count);
      List<int> dataDiList = new List<int>(pressureList.Count);
      List<string> colorDiList = new List<string>(pressureList.Count);
      foreach (BloodPressure pressure in pressureList)
      {
        string time = pressure.Shi.ToString() + ":" + pressure.Fen.ToString();
        if (label.Equals(time))
        {
          labelList.Add("");
        }
        else
        {
          label = time;
          labelList.Add(label);
        }
        dataGaoList.Add(pressure.GaoYa);
        if (pressure.GaoYa < 90 || pressure.GaoYa > 139)
        {
          colorGaoList.Add(ChartColor.HongSe);
        }
        else
        {
          colorGaoList.Add(ChartColor.HuiSe);
        }
        dataDiList.Add(pressure.DiYa);
        if (pressure.DiYa < 60 || pressure.DiYa > 89)
        {
          colorDiList.Add(ChartColor.HongSe);
        }
        else
        {
          colorDiList.Add(ChartColor.HuiSe);
        }
      }
      // 生成选项列表
      PressureChartItem gaoItem = new PressureChartItem()
      {
        data = dataGaoList.ToArray(),
        label = "高压图",
        backgroundColor = colorGaoList.ToArray(),
        yAxisID = "y-axis-gao"
      };
      PressureChartItem diItem = new PressureChartItem()
      {
        data = dataDiList.ToArray(),
        label = "低压图",
        backgroundColor = colorDiList.ToArray(),
        yAxisID = "y-axis-di"
      };
      PressureChartData data = new PressureChartData()
      {
        labels = labelList.ToArray(),
        datasets = new PressureChartItem[] { gaoItem, diItem }
      };
      // 返回数据
      return OperResult.Succeed(data).CreateJsonResult(false);
    }

    // 血糖图
    // GET: /Gather/Sugar
    public ActionResult Sugar()
    {
      return View();
    }

    // 血糖图数据
    // GET: /Gather/SugarData
    public ActionResult SugarData()
    {
      // 获取数据列表
      UserInfo userInfo = IdentityManager.ReadIdentity();
      SugarManager sugarManager = new SugarManager();
      List<BloodSugar> sugarList = sugarManager.ListSugar(userInfo.Id);
      // 整理数据
      string label = string.Empty;
      List<string> labelList = new List<string>(sugarList.Count);
      List<double> dataList = new List<double>(sugarList.Count);
      List<string> colorList = new List<string>(sugarList.Count);
      foreach (BloodSugar sugar in sugarList)
      {
        string time = sugar.GatherDate.ToString("MM-dd");
        labelList.Add(label);
        dataList.Add(sugar.XueTang);
        if (sugar.XueTang < 3.9 || sugar.XueTang > 6.1)
        {
          colorList.Add(ChartColor.HongSe);
        }
        else
        {
          colorList.Add(ChartColor.HuiSe);
        }
      }
      // 生成选项列表
      SugarChartItem item = new SugarChartItem()
      {
        data = dataList.ToArray(),
        label = "血糖图",
        backgroundColor = colorList.ToArray()
      };
      SugarChartData data = new SugarChartData()
      {
        labels = labelList.ToArray(),
        datasets = new SugarChartItem[] { item }
      };
      // 返回数据
      return OperResult.Succeed(data).CreateJsonResult(false);
    }
  }
}