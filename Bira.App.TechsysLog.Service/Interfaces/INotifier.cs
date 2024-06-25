using Bira.App.TechsysLog.Service.Notifications;

namespace Bira.App.TechsysLog.Service.Interfaces
{
    public interface INotifier
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
