using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTaskbarNotifier
{
    public class NotificationHandler : INotificationHandler
    {
        private readonly INotify notify;

        public NotificationHandler(INotify notify)
        {
            this.notify = notify;
        }

        public ObservableCollection<NotifyObject> NotifyContent 
        {
            get;
        } = new ObservableCollection<NotifyObject>();

        public void Add(NotifyObject Notify)
        {
            NotifyContent.Add(Notify);
            notify.Notify();
        }
    }
}
