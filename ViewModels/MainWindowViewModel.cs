using MVVM_XML_RS.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVVM_XML_RS.ViewModels
{
    internal class MainWindowViewModel: ViewModel
    {
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
        private string _Version = "Version " + "1.0";
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
    }
}
