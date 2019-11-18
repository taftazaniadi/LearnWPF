using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTaskbarNotifier
{
    public interface INotificationHandler
    {
        ObservableCollection<NotifyObject> NotifyContent { get; }
        void Add(NotifyObject Notify);
    }

}
