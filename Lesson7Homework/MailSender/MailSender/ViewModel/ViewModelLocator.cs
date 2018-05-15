using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using MailSender.Services;

namespace MailSender.ViewModel
{
    public class ViewModelLocator
    {
        public MailSenderViewModel MailSender => ServiceLocator.Current.GetInstance<MailSenderViewModel>();

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MailSenderViewModel>();
            SimpleIoc.Default.Register<IDataAccessService, DataBaseAccessService>();
        }

        public static void Cleanup() { }
    }
}