using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1.Views.Controls
{
    [INotifyPropertyChanged]
    public partial class StateContainerViewModel
    {

        [ObservableProperty]
        string currentState = States.Loading;

        [ObservableProperty]
        bool visible = true;


        public void ChangeStateSuccess()
        {
            Visible = false;
        }

        public void ChangeStateLoading()
        {
            CurrentState = States.Loading;
        }

        public void ChangeStateVisibileOn()
        {
            Visible = true;
        }

        public void ChangeStateVisibileOff()
        {
            Visible = false;
        }
    }


    static class States
    {
        public const string Loading = nameof(Loading);
        public const string Success = nameof(Success);
    }
}
