using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace F1.Views.Controls
{
    public class Visitor : INotifyPropertyChanged
    {
        private bool _valid = false;
        public bool Valid
        {
            get { return _valid; }
            set
            {
                SetProperty(ref _valid, value);

                updateValue(_valid);
            }
        }

        private bool _valid2 = false;
        public bool Valid2
        {
            get { return _valid2; }
            set { SetProperty(ref _valid2, value); }
        }


        void updateValue(bool value)
        {
            Valid2 = !value;
        }

        bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
