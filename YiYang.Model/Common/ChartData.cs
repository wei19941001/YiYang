namespace YiYang.Model
{
  /// <summary>
  /// 图标项数据
  /// </summary>
  public class HeartChartData
  {
    public string[] labels { get; set; }
    public HeartChartItem[] datasets { get; set; }
  }

  public class HeartChartItem
  {
    public bool fill { get { return false; } }
    public string label { get; set; }
    public int[] data { get; set; }
    public string[] backgroundColor { get; set; }
  }


  public class PressureChartData
  {
    public string[] labels { get; set; }
    public PressureChartItem[] datasets { get; set; }
  }

  public class PressureChartItem
  {
    public bool fill { get { return false; } }
    public string label { get; set; }
    public int[] data { get; set; }
    public string[] backgroundColor { get; set; }
    public string yAxisID { get; set; }
  }


  public class SugarChartData
  {
    public string[] labels { get; set; }
    public SugarChartItem[] datasets { get; set; }
  }

  public class SugarChartItem
  {
    public bool fill { get { return false; } }
    public string label { get; set; }
    public double[] data { get; set; }
    public string[] backgroundColor { get; set; }
  }
}