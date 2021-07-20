using MVVM_XML_RS.Models;
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
                            List<string> settvalue = new List<string>();
                            List<string> settname = new List<string>();
                            device.Name = xnode.Name;
                            device.Number = i;
                            i++;

                            foreach (XmlNode childnode in xnode.ChildNodes)
                            {
                                switch (childnode.Name)
                                {
                                    case "StressDeviceType":
                                        device.StressDeviceType = Int32.Parse(childnode.InnerText);
                                        settname.Add("StressDeviceType");
                                        settvalue.Add(childnode.InnerText);
                                        break;
                                    case "StressDeviceVeloType":
                                        settname.Add("StressDeviceVeloType");
                                        settvalue.Add(childnode.InnerText);
                                        break;
                                    case "StressDeviceTrmType":
                                        settname.Add("StressDeviceTrmType");
                                        settvalue.Add(childnode.InnerText);
                                        break;
                                    case "StressDevicePort":
                                        settname.Add("StressDevicePort");
                                        settvalue.Add(childnode.InnerText);
                                        break;
                                    case "ECG_Port":
                                        settname.Add("ECG_Port");
                                        settvalue.Add(childnode.InnerText);
                                        break;
                                    case "ECG_WIRELESS_Port":
                                        settname.Add("ECG_WIRELESS_Port");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "StressTestProgramm":
                                        settname.Add("StressTestProgramm");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "BTDeviceName":
                                        settname.Add("BTDeviceName");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "Wireless":
                                        settname.Add("Wireless");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "VeloStartPower":
                                        settname.Add("VeloStartPower");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "TrmStartPowerS":
                                        settname.Add("TrmStartPowerS");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "TrmStartPowerV":
                                        settname.Add("TrmStartPowerV");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "IncPower":
                                        settname.Add("IncPower");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "VeloMaxPower":
                                        settname.Add("VeloMaxPower");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "TrmMaxPowerS":
                                        settname.Add("TrmMaxPowerS");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "TrmMaxPowerV":
                                        settname.Add("TrmMaxPowerV");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "TotalTrainingLenth":
                                        settname.Add("TotalTrainingLenth");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "MinPowerTrainingLenth":
                                        settname.Add("MinPowerTrainingLenth");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "MaxPowerTrainingLenth":
                                        settname.Add("MaxPowerTrainingLenth");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "TrainingHR":
                                        settname.Add("TrainingHR");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "TrainingLDdec":
                                        settname.Add("TrainingLDdec");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "Trendchan":
                                        settname.Add("Trendchan");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "P_RESETTIME":
                                        settname.Add("P_RESETTIME");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "IncTime":
                                        settname.Add("IncTime");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "IncTimeMode":
                                        settname.Add("IncTimeMode");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "VeloStopPower":
                                        settname.Add("VeloStopPower");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "TrmStopPowerS":
                                        settname.Add("TrmStopPowerS");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "TrmStopPowerV":
                                        settname.Add("TrmStopPowerV");
                                        settvalue.Add(childnode.InnerText); break;
                                    case "UserProtName":
                                        settname.Add("UserProtName");
                                        settvalue.Add(childnode.InnerText); break;
                                }
                            }

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
