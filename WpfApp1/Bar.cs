using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp1
{
    public class Bar : INotifyPropertyChanged
    {
        private int i3;
        private int i1;
        private int i2;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}