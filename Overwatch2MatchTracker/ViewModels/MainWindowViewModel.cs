using MathCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overwatch2MatchTracker.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        #region Title : string Заголовок

        private string _Title = "Overwatch 2 Match Tracker";

        public string Title { get => _Title; set => Set(ref _Title, value); }

        #endregion
    }
}
