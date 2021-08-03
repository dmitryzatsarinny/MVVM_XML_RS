using MVVM_XML_RS.Infrastructure.Commands;
using MVVM_XML_RS.ViewModels.Base;
using MVVM_XML_RS.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using MVVM_XML_RS.Models.Devinfo;
using System.Linq;

namespace MVVM_XML_RS.ViewModels
{
    internal class MainWindowViewModel: ViewModel
    {
        #region database
        private Doc _doc;
        public Doc doc
        {
            get => _doc;
            set => Set(ref _doc, value);
        }
        #endregion

        private string _windowTitle = "Reabilitation Param Changer";
        public string WindowTitle
        {
            get => _windowTitle;
            set => Set(ref _windowTitle, value);
        }
        
        private string _applicationVersion = "Version " + "1.1";
        public string ApplicationVersion
        {
            get => _applicationVersion;
            set => Set(ref _applicationVersion, value);
        }

        private string _status = "Ready";
        public string Status
        {
            get => _status;
            set => Set(ref _status, value);
        }

        private int _progress = 100;
        public int Progress
        {
            get => _progress;
            set => Set(ref _progress, value);
        }

        #region Команды

        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get;  }
        private bool CanCloseApplicationCommandExecuted(object p) => true;
        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }
        #endregion

        #region MoveHeadApplicationCommand
        public MouseButtonEventHandler MoveHeadApplicationCommand { get; }
        private bool CanMoveHeadApplicationCommandExecuted(object p) => true;
        private void OnMoveHeadApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }
        #endregion

 


        #endregion
        private ObservableCollection<DeviceView> _DeviceViews = new ObservableCollection<DeviceView>();
        public ObservableCollection<DeviceView> DeviceViews {
            get => _DeviceViews;
            set => Set(ref _DeviceViews, value);
        }
        private DeviceView _SelectedDevice;
        public DeviceView SelectedDevice
        {
            get => _SelectedDevice;
            set => Set(ref _SelectedDevice, value);
        }

        #region Openfile

        public ICommand OpenfileCommand { get; }
        private bool CanOpenfileCommandExecuted(object p) => true;
        private void OnOpenfileCommandExecuted(object p)
        {
            _Status = "in progress";
            _Progress = 0;
            string str = PathFinder.PathFinder_Ex();
            doc = XML_reader.find_xml_device(str);

            _DeviceViews.Clear();
            if (_doc != null)
            {
                for(int i = 0; i < _doc.Devices.Count; i++)
                {
                    DeviceView deviceView = new DeviceView();
                    deviceView.deviceinfo = _doc.Devices[i].deviceinfo;
                    deviceView.DeviceName = _doc.Devices[i].Name;
                    List<ViewList> viewList = new List<ViewList>();

                    for (int j = 0; j < 29; j++)
                        viewList.Add(new ViewList()
                        {
                            SettingInfo = _doc.Devices[i].DeviceName[j],
                            SettingValue = _doc.Devices[i].DeviceInfo[j],
                            SettingButton = "Изменить",
                        });
                    deviceView.ViewLists = viewList;
                    _DeviceViews.Add(deviceView);
                }
            }
        }
        #endregion


        //конструктор
        public MainWindowViewModel()
        {
            #region Команды

            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecuted);
            OpenfileCommand = new LambdaCommand(OnOpenfileCommandExecuted, CanOpenfileCommandExecuted);
            // MoveHeadApplicationCommand = new LambdaCommand(OnMoveHeadApplicationCommandExecuted, CanMoveHeadApplicationCommandExecuted);
            #endregion
            DeviceView deviceView1 = new DeviceView();
            deviceView1.DeviceName = "efsef";
            Deviceinfo deviceinfo1 = new Deviceinfo();
            deviceinfo1.BTDeviceName = "154856235";
            deviceinfo1.StressDeviceType = "1";
            deviceView1.deviceinfo = deviceinfo1;
            _DeviceViews.Add(deviceView1);
            DeviceView deviceView2 = new DeviceView();
            deviceView2.DeviceName = "efjtsef";
            Deviceinfo deviceinfo2 = new Deviceinfo();
            deviceinfo2.BTDeviceName = "15675235";
            deviceinfo2.StressDeviceType = "0";
            deviceView2.deviceinfo = deviceinfo2;
            _DeviceViews.Add(deviceView2);
        }
    }
}
