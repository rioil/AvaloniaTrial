using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AvaloniaTrial.Models
{
    public class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected bool SetProperty<T>(ref T source, T value, [CallerMemberName] string propertyName = default!)
        {
            if (Equals(source, value))
            {
                return false;
            }
            else
            {
                source = value;
                var arg = new PropertyChangedEventArgs(propertyName);
                PropertyChanged?.Invoke(this, arg);
                return true;
            }
        }
    }
}
