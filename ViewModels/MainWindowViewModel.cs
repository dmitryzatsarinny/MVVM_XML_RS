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
        private string _Status = "Ready";
        public string Status
        {
            get => _Status;
            set => Set(ref _Status, value);
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

        #region Openfile
        
        public ICommand OpenfileCommand { get; }
        private bool CanOpenfileCommandExecuted(object p) => true;
        private void OnOpenfileCommandExecuted(object p)
        {
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
            #endregion
        }
    }
}
