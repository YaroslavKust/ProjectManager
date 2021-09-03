using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProjectManager.BL.DTO
{
    public abstract class NotifyObject: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}