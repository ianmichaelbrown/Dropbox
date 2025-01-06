using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Dropbox.ViewModels
{
    public partial class NotifiableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        internal void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
