namespace TYZTDotNetCore.MvcChartApp.Models
{
    public class LineStylingChartModel
    {
        public List<string> Labels { get; set; }
        public List<DataSets> DataSets { get; set; }
    }
    public class DataSets
    {
        public string Label { get; set; }
        public bool Fill { get; set; }
        public string BgColor { get; set; }
        public string BorderColor { get; set; }
        public List<int> BorderDash { get; set; }
        public List<int> Data {  get; set; }


    }
}
