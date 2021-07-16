﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_XML_RS.Models
{
	internal class Doc
    {
		public string RSSETUP { get; set; }
		public ICollection<Device> Devices { get; set }

	}

	internal class Device
	{
		public string Name { get; set; }
		public bool StressDeviceType { get; set; }
		public int Number { get; set; }
		public Deviceinfo Info { get; set; }
	}

    internal struct Deviceinfo
    {
        public bool StressDeviceType { get; set; }
        public int StressDeviceVeloType { get; set; }
        public int StressDeviceTrmType { get; set; }
        public int StressDevicePort { get; set; }
        public int ECG_Port { get; set; }
        public int ECG_WIRELESS_Port { get; set; }
		public int StressTestProgramm { get; set; }
		public string BTDeviceName { get; set; }
		public int Wireless { get; set; }
		public int VeloStartPower { get; set; }
		public int TrmStartPowerS { get; set; }
		public int TrmStartPowerV { get; set; }
		public int IncPower { get; set; }
		public int VeloMaxPower { get; set; }
		public int TrmMaxPowerS { get; set; }
		public int TrmMaxPowerV { get; set; }
		public int TotalTrainingLenth { get; set; }
		public int MinPowerTrainingLenth { get; set; }
		public int MaxPowerTrainingLenth { get; set; }
		public int TrainingHR { get; set; }
		public int TrainingLDdec { get; set; }
		public int Trendchan { get; set; }
		public int P_RESETTIME { get; set; }
		public int IncTime { get; set; }
		public int IncTimeMode { get; set; }
		public int VeloStopPower { get; set; }
		public int TrmStopPowerS { get; set; }
		public int TrmStopPowerV { get; set; }
		public int UserProtName { get; set; }
	}
}