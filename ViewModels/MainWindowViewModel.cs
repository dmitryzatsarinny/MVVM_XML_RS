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
    }
}
