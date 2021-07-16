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
                            Deviceinfo deviceinfo = new Deviceinfo();
                            device.Name = xnode.Name;
                            device.Number = i;
                            i++;

                            foreach (XmlNode childnode in xnode.ChildNodes)
                            {
                                switch (childnode.Name)
                                {
                                    case "StressDeviceType":
                                        device.StressDeviceType = Int32.Parse(childnode.InnerText);
                                        deviceinfo.StressDeviceType = Int32.Parse(childnode.InnerText);
                                        break;
                                    case "StressDeviceVeloType":
                                        deviceinfo.StressDeviceVeloType = Int32.Parse(childnode.InnerText);
                                        break;
                                    case "StressDeviceTrmType":
                                        deviceinfo.StressDeviceTrmType = Int32.Parse(childnode.InnerText);
                                        break;
                                    case "StressDevicePort":
                                        deviceinfo.StressDevicePort = Int32.Parse(childnode.InnerText);
                                        break;
                                    case "ECG_Port":
                                        deviceinfo.ECG_Port = Int32.Parse(childnode.InnerText);
                                        break;
                                    case "ECG_WIRELESS_Port":
                                        deviceinfo.ECG_WIRELESS_Port = Int32.Parse(childnode.InnerText);
                                        break;
                                    case "StressTestProgramm":
                                        deviceinfo.StressTestProgramm = Int32.Parse(childnode.InnerText);
                                        break;
                                    case "BTDeviceName":
                                        deviceinfo.BTDeviceName = childnode.InnerText;
                                        break;
                                    case "Wireless":
                                        deviceinfo.Wireless = Int32.Parse(childnode.InnerText);
                                        break;
                                    case "VeloStartPower":
                                        deviceinfo.VeloStartPower = Int32.Parse(childnode.InnerText);
                                        break;
                                    case "TrmStartPowerS":
                                        deviceinfo.TrmStartPowerS = Int32.Parse(childnode.InnerText);
                                        break;
                                    case "TrmStartPowerV":
                                        deviceinfo.TrmStartPowerV = Int32.Parse(childnode.InnerText);
                                        break;
                                    case "IncPower":
                                        deviceinfo.IncPower = Int32.Parse(childnode.InnerText);
                                        break;
                                    case "VeloMaxPower":
                                        deviceinfo.VeloMaxPower = Int32.Parse(childnode.InnerText);
                                        break;
                                    case "TrmMaxPowerS":
                                        deviceinfo.TrmMaxPowerS = Int32.Parse(childnode.InnerText);
                                        break;
                                    case "TrmMaxPowerV":
                                        deviceinfo.TrmMaxPowerV = Int32.Parse(childnode.InnerText);
                                        break;
                                    case "TotalTrainingLenth":
                                        deviceinfo.TotalTrainingLenth = Int32.Parse(childnode.InnerText);
                                        break;
                                    case "MinPowerTrainingLenth":
                                        deviceinfo.MinPowerTrainingLenth = Int32.Parse(childnode.InnerText);
                                        break;
                                    case "MaxPowerTrainingLenth":
                                        deviceinfo.MaxPowerTrainingLenth = Int32.Parse(childnode.InnerText);
                                        break;
                                    case "TrainingHR":
                                        deviceinfo.TrainingHR = Int32.Parse(childnode.InnerText);
                                        break;
                                    case "TrainingLDdec":
                                        deviceinfo.TrainingLDdec = Int32.Parse(childnode.InnerText);
                                        break;
                                    case "Trendchan":
                                        deviceinfo.Trendchan = Int32.Parse(childnode.InnerText);
                                        break;
                                    case "P_RESETTIME":
                                        deviceinfo.P_RESETTIME = Int32.Parse(childnode.InnerText);
                                        break;
                                    case "IncTime":
                                        deviceinfo.IncTime = Int32.Parse(childnode.InnerText);
                                        break;
                                    case "IncTimeMode":
                                        deviceinfo.IncTimeMode = Int32.Parse(childnode.InnerText);
                                        break;
                                    case "VeloStopPower":
                                        deviceinfo.VeloStopPower = Int32.Parse(childnode.InnerText);
                                        break;
                                    case "TrmStopPowerS":
                                        deviceinfo.TrmStopPowerS = Int32.Parse(childnode.InnerText);
                                        break;
                                    case "TrmStopPowerV":
                                        deviceinfo.TrmStopPowerV = Int32.Parse(childnode.InnerText);
                                        break;
                                    case "UserProtName":
                                        deviceinfo.UserProtName = childnode.InnerText;
                                        break;
                                }
                            }
                            device.Info = deviceinfo;
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
