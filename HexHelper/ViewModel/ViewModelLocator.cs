/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:HexHelper"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using HexHelper.Hex.Interface;
using HexHelper.JsonApi;
using HexHelper.Service;
using Microsoft.Practices.ServiceLocation;

namespace HexHelper.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<MessageViewModel>();
            SimpleIoc.Default.Register<IServerService, ServerService>();
            SimpleIoc.Default.Register<IHexApiService, HexApiService>();
            SimpleIoc.Default.Register<IFileService, FileService>();
            SimpleIoc.Default.Register<IRepository, Repository>();
            SimpleIoc.Default.Register<IDialogService, MetroDialogService>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public MessageViewModel Message
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MessageViewModel>();
            }
        }

        public static async Task Cleanup()
        {
            await ServiceLocator.Current.GetInstance<MainViewModel>().Shutdown();
        }
    }
}