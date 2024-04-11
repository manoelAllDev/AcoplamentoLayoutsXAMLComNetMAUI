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
        [NotifyCanExecuteChangedFor(nameof(ChangeStateCommand))]
        bool canStateChange;

        [ObservableProperty]
        string currentState = States.Loading;

        [RelayCommand(CanExecute = nameof(CanStateChange))]
        void ChangeState()
        {
            CurrentState = States.Success;
        }
    }

    static class States
    {
        public const string Loading = nameof(Loading);
        public const string Success = nameof(Success);
    }
}
