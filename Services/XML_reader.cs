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
            List<Device> Devicelist = new List<Device>();
            //XmlReaderSettings settings = new XmlReaderSettings();
            //settings.DtdProcessing = DtdProcessing.Parse;
            XmlDocument xDoc = new XmlDocument();
            int i = 0;
            try
            {
                xDoc.Load(str);
                doc.RSSETUP = xDoc.InnerXml;           
                //doc.info = doc.RSSETUP.Substring(doc.RSSETUP.IndexOf("<?"), doc.RSSETUP.IndexOf("?>") + 2);
                XmlElement xRoot = xDoc.DocumentElement;
                if (xRoot.Name == "RSSETUP")
                foreach (XmlNode xnode in xRoot)
                {
                        // получаем атрибут name

                        if (xnode.Name.Contains("DEVICE")) {
                            Device device = new Device();
                            Deviceinfo deviceinfo = new Deviceinfo();
                            List<string> settvalue = new List<string>();
                            List<string> settname = new List<string>();
                            device.Name = xnode.Name;
                            i++;

                            foreach (XmlNode childnode in xnode.ChildNodes)
                            {
                                switch (childnode.Name)
                                {
                                    case "StressDeviceType":
                                        deviceinfo.StressDeviceType = childnode.InnerText;
                                        settname.Add("StressDeviceType");
                                        settvalue.Add(childnode.InnerText);
                                        break;
                                    case "StressDeviceVeloType":
                                        deviceinfo.StressDeviceVeloType = childnode.InnerText;
                                        settname.Add("StressDeviceVeloType");
                                        settvalue.Add(childnode.InnerText);
                                        break;
                                    case "StressDeviceTrmType":
                                        deviceinfo.StressDeviceTrmType = childnode.InnerText;
                                        settname.Add("StressDeviceTrmType");
                                        settvalue.Add(childnode.InnerText);
                                        break;
                                    case "StressDevicePort":
                                        deviceinfo.StressDevicePort = childnode.InnerText;
                                        settname.Add("StressDevicePort");
                                        settvalue.Add(childnode.InnerText);
                                        break;
                                    case "ECG_Port":
                                        deviceinfo.ECG_Port = childnode.InnerText;
                                        settname.Add("ECG_Port");
                                        settvalue.Add(childnode.InnerText);
                                        break;
                                    case "ECG_WIRELESS_Port":
                                        deviceinfo.ECG_WIRELESS_Port = childnode.InnerText;
                                        settname.Add("ECG_WIRELESS_Port");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "StressTestProgramm":
                                        deviceinfo.StressTestProgramm = childnode.InnerText;
                                        settname.Add("StressTestProgramm");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "BTDeviceName":
                                        deviceinfo.BTDeviceName = childnode.InnerText;
                                        settname.Add("BTDeviceName");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "Wireless":
                                        deviceinfo.Wireless = childnode.InnerText;
                                        settname.Add("Wireless");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "VeloStartPower":
                                        deviceinfo.VeloStartPower = childnode.InnerText;
                                        settname.Add("VeloStartPower");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "TrmStartPowerS":
                                        deviceinfo.TrmStartPowerS = childnode.InnerText;
                                        settname.Add("TrmStartPowerS");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "TrmStartPowerV":
                                        deviceinfo.TrmStartPowerV = childnode.InnerText;
                                        settname.Add("TrmStartPowerV");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "IncPower":
                                        deviceinfo.IncPower = childnode.InnerText;
                                        settname.Add("IncPower");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "VeloMaxPower":
                                        deviceinfo.VeloMaxPower = childnode.InnerText;
                                        settname.Add("VeloMaxPower");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "TrmMaxPowerS":
                                        deviceinfo.TrmMaxPowerS = childnode.InnerText;
                                        settname.Add("TrmMaxPowerS");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "TrmMaxPowerV":
                                        deviceinfo.TrmMaxPowerV = childnode.InnerText;
                                        settname.Add("TrmMaxPowerV");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "TotalTrainingLenth":
                                        deviceinfo.TotalTrainingLenth = childnode.InnerText;
                                        settname.Add("TotalTrainingLenth");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "MinPowerTrainingLenth":
                                        deviceinfo.MinPowerTrainingLenth = childnode.InnerText;
                                        settname.Add("MinPowerTrainingLenth");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "MaxPowerTrainingLenth":
                                        deviceinfo.MaxPowerTrainingLenth = childnode.InnerText;
                                        settname.Add("MaxPowerTrainingLenth");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "TrainingHR":
                                        deviceinfo.TrainingHR = childnode.InnerText;
                                        settname.Add("TrainingHR");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "TrainingLDdec":
                                        deviceinfo.TrainingLDdec = childnode.InnerText;
                                        settname.Add("TrainingLDdec");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "Trendchan":
                                        deviceinfo.Trendchan = childnode.InnerText;
                                        settname.Add("Trendchan");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "P_RESETTIME":
                                        deviceinfo.P_RESETTIME = childnode.InnerText;
                                        settname.Add("P_RESETTIME");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "IncTime":
                                        deviceinfo.IncTime = childnode.InnerText;
                                        settname.Add("IncTime");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "IncTimeMode":
                                        deviceinfo.IncTimeMode = childnode.InnerText;
                                        settname.Add("IncTimeMode");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "VeloStopPower":
                                        deviceinfo.VeloStopPower = childnode.InnerText;
                                        settname.Add("VeloStopPower");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "TrmStopPowerS":
                                        deviceinfo.TrmStopPowerS = childnode.InnerText;
                                        settname.Add("TrmStopPowerS");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "TrmStopPowerV":
                                        deviceinfo.TrmStopPowerV = childnode.InnerText;
                                        settname.Add("TrmStopPowerV");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "UserProtName":
                                        deviceinfo.UserProtName = childnode.InnerText;
                                        settname.Add("UserProtName");
                                        settvalue.Add(childnode.InnerText); break;
                                }
                            }
                            device.deviceinfo = deviceinfo;
                            device.DeviceName = settname;
                            device.DeviceInfo = settvalue;
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
