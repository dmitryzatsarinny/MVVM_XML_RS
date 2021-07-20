using MVVM_XML_RS.Infrastructure.Commands;
using MVVM_XML_RS.ViewModels.Base;
using MVVM_XML_RS.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using MVVM_XML_RS.Models;
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

        #region Заголовок окна
        private string _Title = "Reabilitation Param Changer";
        /// <summary>Заголовок окна</summary>
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        #endregion
        #region Версия приложения
        private string _Version = "Version " + "1.1";
        public string Version
        {
            get => _Version;
            set => Set(ref _Version, value);
        }
        #endregion

        #region Статус
        public string _Status = "Ready";
        public string Status
        {
            get => _Status;
            set => Set(ref _Status, value);
        }
        #endregion

        #region Прогресс
        public int _Progress = 100;
        public int Progress
        {
            get => _Progress;
            set => Set(ref _Progress, value);
        }
        #endregion



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

        #region ViewListbox
        public ICommand ViewListboxCommand { get; }
        private bool CanViewListboxCommandExecuted(object p) => true;
        private void OnViewListboxCommandExecuted(object p)
        {
            _mylistboxdata.Clear();
            if ((_doc != null) && (_index <= _doc.Devices.Count) && (_index >= 0))
            {
                _ViewDevice = "Выбрано устройство " + _doc.Devices[_index].Name;
                for (int i = 0; i < 29; i++)
                    _mylistboxdata.Add(new ViewList()
                    {
                        SettingInfo = _doc.Devices[_index].DeviceName[i],
                        SettingValue = _doc.Devices[_index].DeviceInfo[i],
                        SettingButton = "Изменить",
                    });
            }

        }
        #endregion

        #region ViewIndex
        private int _index = -1;
        public int Index
        {
            get => _index;
            set => Set(ref _index, value);
        }
        #endregion

        #region ViewDevice
        private string _ViewDevice = "No device";
        public string ViewDevice
        {
            get => _ViewDevice;
            set => Set(ref _ViewDevice, value);
        }
        #endregion

        #region database
        private ObservableCollection<ViewList> _mylistboxdata = new ObservableCollection<ViewList>();

        public ObservableCollection<ViewList> Mylistboxdata
        {
            get => _mylistboxdata;
            set => Set(ref _mylistboxdata, value);
        }
        #endregion


        #region Openfile

        public ICommand OpenfileCommand { get; }
        private bool CanOpenfileCommandExecuted(object p) => true;
        private void OnOpenfileCommandExecuted(object p)
        {
            _Status = "in progress";
            _Progress = 0;
            string str = PathFinder.PathFinder_Ex();
            doc = XML_reader.find_xml_device(str);

        }
        #endregion

       

        #endregion

        //конструктор
        public MainWindowViewModel()
        {
            #region Команды

            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecuted);
            OpenfileCommand = new LambdaCommand(OnOpenfileCommandExecuted, CanOpenfileCommandExecuted);
            // MoveHeadApplicationCommand = new LambdaCommand(OnMoveHeadApplicationCommandExecuted, CanMoveHeadApplicationCommandExecuted);
            ViewListboxCommand = new LambdaCommand(OnViewListboxCommandExecuted, CanViewListboxCommandExecuted);
            #endregion

            _mylistboxdata.Add(new ViewList()
            {
                SettingInfo = "dfe",
                SettingValue = "ffe",
                SettingButton = "Изменить",
            });
        }
    }
}
