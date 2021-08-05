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
using System.Windows.Controls;
using Cinch;

namespace MVVM_XML_RS.ViewModels
{
    internal class MainWindowViewModel: ViewModel
    {
        //private VisualView _visualview;
        //public VisualView visualview
        //{
        //    get => _visualview;
        //    set => Set(ref _visualview, value);
        //}
        private Doc _doc;
        public Doc doc
        {
            get => _doc;
            set => Set(ref _doc, value);
        }
        private ObservableCollection<DeviceView> _DeviceViews = new ObservableCollection<DeviceView>();
        public ObservableCollection<DeviceView> DeviceViews
        {
            get => _DeviceViews;
            set => Set(ref _DeviceViews, value);
        }
        private DeviceView _SelectedDevice;
        public DeviceView SelectedDevice
        {
            get => _SelectedDevice;
            set => Set(ref _SelectedDevice, value);
        }
        private string _windowTitle = "Reabilitation Param Changer";
        public string WindowTitle
        {
            get => _windowTitle;
            set => Set(ref _windowTitle, value);
        }
        private string _applicationVersion = "Version 1.5";
        public string ApplicationVersion
        {
            get => _applicationVersion;
            set => Set(ref _applicationVersion, value);
        }
        public string _status = "Ready";
        public string Status
        {
            get => _status;
            set => Set(ref _status, value);
        }
        public int _progress = 100;
        public int Progress
        {
            get => _progress;
            set => Set(ref _progress, value);
        }
        
        private int _selectPageIndex;
        public int SelectPageIndex
        {
            get => _selectPageIndex;
            set => Set(ref _selectPageIndex, value);
        }
        static private bool _conditionismouseonheader = false;
        public bool Conditionismouseonheader
        {
            get => _conditionismouseonheader;
            set => Set(ref _conditionismouseonheader, value);
        }
        public SimpleCommand<object, EventToCommandArgs> MouseLeftButtonDown { get; private set; }
        public ICommand OpenfileCommand { get; }
        private bool CanOpenfileCommandExecuted(object p) => true;
        private void OnOpenfileCommandExecuted(object p)
        {
            _status = "in progress";
            _progress = 0;
            string str = PathFinder.PathFinder_Ex();
            doc = XML_reader.find_xml_device(str);

            _DeviceViews.Clear();
            if (_doc != null)
            {
                for(int i = 0; i < _doc.Devices.Count; i++)
                {
                    DeviceView deviceView = new DeviceView();
                    deviceView.Deviceinfo = _doc.Devices[i].Deviceinfo;
                    deviceView.DeviceName = _doc.Devices[i].DeviceName;
                    _DeviceViews.Add(deviceView);
                }
            }
        }
        public ICommand CloseApplicationCommand { get; }
        private bool CanCloseApplicationCommandExecuted(object p) => true;
        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }
        public ICommand ChangeIndexCommand { get; }
        private bool CanChangeIndexCommand(object p) => true;
        private void OnChangeIndexCommand(object p)
        {
            SelectPageIndex = 1;
        }
        //public ICommand IsmouseonheaderCommand { get; }
        //private bool CanIsmouseonheaderCommand(object p) => true;
        //private void OnIsmouseonheaderCommand(object p)
        //{
        //    _conditionismouseonheader = true;
        //}
        
        public MainWindowViewModel()
        {
            #region Команды
            MouseLeftButtonDown = new SimpleCommand<object, EventToCommandArgs>(OnMouseLeftButtonDown);
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecuted);
            OpenfileCommand = new LambdaCommand(OnOpenfileCommandExecuted, CanOpenfileCommandExecuted);
            ChangeIndexCommand = new LambdaCommand(OnChangeIndexCommand, CanChangeIndexCommand);
            //IsmouseonheaderCommand = new LambdaCommand(OnIsmouseonheaderCommand, CanIsmouseonheaderCommand);
            // MoveHeadApplicationCommand = new LambdaCommand(OnMoveHeadApplicationCommandExecuted, CanMoveHeadApplicationCommandExecuted);
            #endregion
            DeviceView deviceView1 = new DeviceView();
            deviceView1.DeviceName = "efsef";
            Deviceinfo deviceinfo1 = new Deviceinfo();
            deviceinfo1.BTDeviceName = "154856235";
            deviceinfo1.StressDeviceType = "1";
            deviceView1.Deviceinfo = deviceinfo1;
            _DeviceViews.Add(deviceView1);
            DeviceView deviceView2 = new DeviceView();
            deviceView2.DeviceName = "efjtsef";
            Deviceinfo deviceinfo2 = new Deviceinfo();
            deviceinfo2.BTDeviceName = "15675235";
            deviceinfo2.StressDeviceType = "0";
            deviceView2.Deviceinfo = deviceinfo2;
            _DeviceViews.Add(deviceView2);
        }

        private static void OnMouseLeftButtonDown(EventToCommandArgs e)
        {
            var dp= e.Sender as DockPanel;
            ((Window)dp.Parent.TryFindParent<Window>()).DragMove();
        }

    }
}
