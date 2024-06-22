using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace Notas.ViewModels;

internal class AboutViewModel
{
    public string Title => AppInfo.Name;
    public string Version => AppInfo.VersionString;
    public string MoreInfoUrl => "https://github.com/Justxt";
    public string Message => "Quieres ver mas proyectos? Ve a mi Github 😎.";
    public ICommand JMShowMoreInfoCommand { get; }

    public AboutViewModel()
    {
        JMShowMoreInfoCommand = new AsyncRelayCommand(ShowMoreInfo);
    }

    async Task ShowMoreInfo() =>
        await Launcher.Default.OpenAsync(MoreInfoUrl);
}