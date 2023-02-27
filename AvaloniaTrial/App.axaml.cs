using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AvaloniaTrial.ViewModels;
using AvaloniaTrial.Views;
using Reactive.Bindings;
using System;

namespace AvaloniaTrial
{
    public partial class App : Application
    {
        public App()
        {
            ExitCommand = new ReactiveCommandSlim().WithSubscribe(Shutdown);
            OpenCommand = new ReactiveCommandSlim().WithSubscribe(Open);
        }

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = CreateMainWindow();
                desktop.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            }

            base.OnFrameworkInitializationCompleted();
        }

        private void MainWindow_Closed(object? sender, EventArgs e)
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow.Closed -= MainWindow_Closed;
                desktop.MainWindow = null;
            }
        }

        private void Shutdown()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.Shutdown();
            }
        }
        public ReactiveCommandSlim ExitCommand { get; }

        private void Open()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                if (desktop.MainWindow is null)
                {
                    desktop.MainWindow = CreateMainWindow();
                    desktop.MainWindow.Show();
                }
                else
                {
                    desktop.MainWindow.WindowState = WindowState.Normal;
                    desktop.MainWindow.Activate();
                }
            }
        }
        public ReactiveCommandSlim OpenCommand { get; }

        private MainWindow CreateMainWindow()
        {
            var window = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };
            window.Closed += MainWindow_Closed;
            
            return window;
        }
    }
}
