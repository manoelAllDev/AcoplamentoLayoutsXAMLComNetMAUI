using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1.Views.Controls
{
    [ObservableObject]
    public partial class StateContainerViewModel
    {

        [ObservableProperty]
        string currentState = States.Loading;

        public void ChangeStateSuccess()
        {
            CurrentState = States.Success;
        }

        public void ChangeStateLoading()
        {
            CurrentState = States.Loading;
        }
    }


    static class States
    {
        public const string Loading = nameof(Loading);
        public const string Success = nameof(Success);
    }
}
