using MVVM_XML_RS.Models.Devinfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace MVVM_XML_RS.Services
{
    internal class XML_reader
    {
        public static Doc find_xml_device(string str)
        {

            Doc doc = new Doc();
            List<DeviceView> Devicelist = new List<DeviceView>();
            XmlDocument xDoc = new XmlDocument();
            int i = 0;
            try
            {
                xDoc.Load(str);
                doc.RSSETUP = xDoc.InnerXml;
                XmlElement xRoot = xDoc.DocumentElement;
                if (xRoot.Name == "RSSETUP")
                foreach (XmlNode xnode in xRoot)
                {
                    if (xnode.Name.Contains("DEVICE")) {
                            DeviceView device = new DeviceView();
                            Deviceinfo deviceinfo = new Deviceinfo();
                            device.DeviceName = xnode.Name;
                            i++;

                            foreach (XmlNode childnode in xnode.ChildNodes)
                            {
                                switch (childnode.Name)
                                {
                                    case "StressDeviceType":
                                        deviceinfo.StressDeviceType = childnode.InnerText;break;
                                    case "StressDeviceVeloType":
                                        deviceinfo.StressDeviceVeloType = childnode.InnerText;break;
                                    case "StressDeviceTrmType":
                                        deviceinfo.StressDeviceTrmType = childnode.InnerText;break;
                                    case "StressDevicePort":
                                        deviceinfo.StressDevicePort = childnode.InnerText;break;
                                    case "ECG_Port":
                                        deviceinfo.ECG_Port = childnode.InnerText;break;
                                    case "ECG_WIRELESS_Port":
                                        deviceinfo.ECG_WIRELESS_Port = childnode.InnerText;break;
                                    case "StressTestProgramm":
                                        deviceinfo.StressTestProgramm = childnode.InnerText;break;
                                    case "BTDeviceName":
                                        deviceinfo.BTDeviceName = childnode.InnerText;break;
                                    case "Wireless":
                                        deviceinfo.Wireless = childnode.InnerText;break;
                                    case "VeloStartPower":
                                        deviceinfo.VeloStartPower = childnode.InnerText;break;
                                    case "TrmStartPowerS":
                                        deviceinfo.TrmStartPowerS = childnode.InnerText;break;
                                    case "TrmStartPowerV":
                                        deviceinfo.TrmStartPowerV = childnode.InnerText;break;
                                    case "IncPower":
                                        deviceinfo.IncPower = childnode.InnerText;break;
                                    case "VeloMaxPower":
                                        deviceinfo.VeloMaxPower = childnode.InnerText;break;
                                    case "TrmMaxPowerS":
                                        deviceinfo.TrmMaxPowerS = childnode.InnerText; break;
                                    case "TrmMaxPowerV":
                                        deviceinfo.TrmMaxPowerV = childnode.InnerText;break;
                                    case "TotalTrainingLenth":
                                        deviceinfo.TotalTrainingLenth = childnode.InnerText;break;
                                    case "MinPowerTrainingLenth":
                                        deviceinfo.MinPowerTrainingLenth = childnode.InnerText;break;
                                    case "MaxPowerTrainingLenth":
                                        deviceinfo.MaxPowerTrainingLenth = childnode.InnerText;break;
                                    case "TrainingHR":
                                        deviceinfo.TrainingHR = childnode.InnerText;break;
                                    case "TrainingLDdec":
                                        deviceinfo.TrainingLDdec = childnode.InnerText;break;
                                    case "Trendchan":
                                        deviceinfo.Trendchan = childnode.InnerText;break;
                                    case "P_RESETTIME":
                                        deviceinfo.P_RESETTIME = childnode.InnerText;break;
                                    case "IncTime":
                                        deviceinfo.IncTime = childnode.InnerText;break;
                                    case "IncTimeMode":
                                        deviceinfo.IncTimeMode = childnode.InnerText;break;
                                    case "VeloStopPower":
                                        deviceinfo.VeloStopPower = childnode.InnerText;break;
                                    case "TrmStopPowerS":
                                        deviceinfo.TrmStopPowerS = childnode.InnerText;break;
                                    case "TrmStopPowerV":
                                        deviceinfo.TrmStopPowerV = childnode.InnerText;break;
                                    case "UserProtName":
                                        deviceinfo.UserProtName = childnode.InnerText;break;
                                }
                            }
                            device.Deviceinfo = deviceinfo;
                            Devicelist.Add(device);
                        }
                }
            }
            catch (System.FormatException e)
            {
                string mess = e.Message;
                MessageBox.Show(mess,  "Device " + (i-1) + " Exception", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (System.ArgumentException e)
            {
                string mess = e.Message;
                MessageBox.Show(mess, "Файл не найден", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            doc.Devices = Devicelist;
            return doc;
        }
    }
}
