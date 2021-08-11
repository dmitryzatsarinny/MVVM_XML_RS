using System.Collections.Generic;
using System.Windows.Controls;

namespace MVVM_XML_RS.Models.Devinfo
{
    internal class DeviceView
    {
		public string DeviceName { get; set; }
        public Deviceinfo Deviceinfo { get; set; }
	}
    internal class Doc
    {
        public string RSSETUP { get; set; }
		public List<DeviceView> Devices { get; set; }
	}
    public class VisualView
    {
        public TextBlock Characteristic { get; set; }
        public TextBlock Parameter { get; set; }
        public Button ChangeButton { get; set; }
    }
	internal struct Deviceinfo
    {
        public string StressDeviceType { get; set; }
        public string StressDeviceVeloType { get; set; }
        public string StressDeviceTrmType { get; set; }
        public string StressDevicePort { get; set; }
        public string ECG_Port { get; set; }
        public string ECG_WIRELESS_Port { get; set; }
		public string StressTestProgramm { get; set; }
		public string BTDeviceName { get; set; }
		public string Wireless { get; set; }
		public string VeloStartPower { get; set; }
		public string TrmStartPowerS { get; set; }
		public string TrmStartPowerV { get; set; }
		public string IncPower { get; set; }
		public string VeloMaxPower { get; set; }
		public string TrmMaxPowerS { get; set; }
		public string TrmMaxPowerV { get; set; }
		public string TotalTrainingLenth { get; set; }
		public string MinPowerTrainingLenth { get; set; }
		public string MaxPowerTrainingLenth { get; set; }
		public string TrainingHR { get; set; }
		public string TrainingLDdec { get; set; }
		public string Trendchan { get; set; }
		public string P_RESETTIME { get; set; }
		public string IncTime { get; set; }
		public string IncTimeMode { get; set; }
		public string VeloStopPower { get; set; }
		public string TrmStopPowerS { get; set; }
		public string TrmStopPowerV { get; set; }
		public string UserProtName { get; set; }
	}
}
