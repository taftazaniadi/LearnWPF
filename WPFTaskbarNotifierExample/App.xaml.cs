using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WPFTaskbarNotifier;
using Microsoft.Extensions.Hosting;

namespace WPFTaskbarNotifierExample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>

    public partial class App : System.Windows.Application
    {
        private IServiceProvider _service;
        private IHost _host;

        public App()
        {
            var Service = new ServiceCollection();

            Service.AddSingleton<Window1>();
            Service.AddSingleton<INotificationHandler, NotificationHandler>();
            Service.AddSingleton<INotify, ExampleTaskbarNotifier>();
            //Service.AddHostedService<>

            _service = Service.BuildServiceProvider();
            _host = new HostBuilder().ConfigureServices((context, services) =>
            {
                services.AddSingleton<Window1>();
            })
                .Build();

        }

        private async void Application_Start(object sender, StartupEventArgs e)
        {
            await _host.StartAsync();
            //var Window = _service.GetRequiredService<Window1>();
            var Window = _host.Services.GetService<Window1>();

            Window.Show();
        }

        private async void Application_Exit(object sender, ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync(TimeSpan.FromSeconds(5));
            }
        }
    }

}