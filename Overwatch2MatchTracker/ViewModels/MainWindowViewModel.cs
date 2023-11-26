using MathCore.Extensions;
using MathCore.ViewModels;
using Microsoft.EntityFrameworkCore;
using Overwatch2MatchTracker.DAL.Context;
using Overwatch2MatchTracker.DAL.Entities.Base;
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

        private object _HeroName = "Choose Hero" ;

        public object HeroName { get => _HeroName; set => Set(ref _HeroName, value); }

        #endregion
    }
}
